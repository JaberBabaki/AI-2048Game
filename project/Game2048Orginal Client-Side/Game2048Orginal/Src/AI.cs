



using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Game2048Orginal.Src
{
    class AI
    {
        private double freeTile = 0;
        private double maxNumber = 0;

        public Boolean AvalibleTop = true;
        public Boolean AvalibleRight = true;
        public Boolean AvalibleDown = true;
        public Boolean AvalibleLeft = true;
        public double alphabetarate(Button[,] root, int depth, double alpha, double beta, bool player)
        {

            if (depth == 0)
            {
                Random rnd = new Random();
                double probability = rnd.Next(1, 11);
                double a = SnakeRating(root);
                //MessageBox.Show("" + a);
                return a;
            }

            if (player)
            {
                List<Button[,]> moves = getAllMoveStates(root);
                if (moves.Count == 0)
                    return double.MinValue;

                foreach (Button[,] st in moves)
                {
                    alpha = Math.Max(alpha, alphabetarate(st, depth - 1, alpha, beta, false));
                    if (beta <= alpha)
                        break;
                }
                return alpha;
            }
            else
            {
                List<Button[,]> moves = getAllMoveStates(root);

                foreach (Button[,] st in moves)
                {
                    beta = Math.Min(beta, alphabetarate(st, depth - 1, alpha, beta, true));
                    if (beta <= alpha)
                        break;
                }
                return beta;
            }
        }
        private Button[,] goToLeft(Button[,] pieceLeft)
        {
            AvalibleLeft = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j > 0)
                    {
                        int k = j;
                        while (k > 0 && pieceLeft[i, k - 1].Text == "")
                        {
                            pieceLeft[i, k - 1].Text = pieceLeft[i, k].Text;
                            if (pieceLeft[i, k - 1].Text != "" && pieceLeft[i, k].Text != "" && pieceLeft[i, k - 1].Text == pieceLeft[i, k].Text)
                            {
                                AvalibleLeft = true;
                            }
                            pieceLeft[i, k].Text = "";
                            k--;
                        }

                        if (k > 0)
                        {
                            if (pieceLeft[i, k - 1].Text == pieceLeft[i, k].Text)
                            {
                                AvalibleLeft = true;
                                powerAll(pieceLeft, i, k - 1);
                                String str = (string) pieceLeft[i, k].Text;
                                pieceLeft[i, k].Text = "";
                            }
                        }
                    }
                }
            }
            return pieceLeft;
        }
        ///
        private Button[,] goToRight(Button[,] pieceRight)
        {
            AvalibleRight = false;
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 3; j >= 0; j--)
                {
                    if (j < 3)
                    {
                        int k = j;
                        while (k < 3 && pieceRight[i, k + 1].Text == "")
                        {
                            pieceRight[i, k + 1].Text = pieceRight[i, k].Text;
                            if (pieceRight[i, k + 1].Text != "" && pieceRight[i, k].Text != "" && pieceRight[i, k + 1].Text == pieceRight[i, k].Text)
                            {
                                AvalibleRight = true;
                            }
                            pieceRight[i, k].Text = "";
                            k++;
                        }

                        if (k < 3)
                        {
                            if (pieceRight[i, k + 1].Text == pieceRight[i, k].Text)
                            {
                                AvalibleRight = true;
                                powerAll(pieceRight, i, k + 1);
                                pieceRight[i, k].Text = "";
                            }
                        }
                    }
                }
            }
            return pieceRight;
        }
        ////
        private Button[,] goToDown(Button[,] pieceDown)
        {
            AvalibleDown = false;
            for (int j = 3; j >= 0; j--)
            {
                for (int i = 3; i >= 0; i--)
                {
                    if (i < 3)
                    {
                        int k = i;
                        while (k < 3 && pieceDown[k + 1, j].Text == "")
                        {
                            pieceDown[k + 1, j].Text = pieceDown[k, j].Text;
                            if (pieceDown[k + 1, j].Text != "" && pieceDown[k, j].Text != "" && pieceDown[k + 1, j].Text == pieceDown[k, j].Text)
                            {
                                AvalibleDown = true;
                            }
                            pieceDown[k, j].Text = "";
                            k++;
                        }

                        if (k < 3)
                        {
                            if (pieceDown[k + 1, j].Text == pieceDown[k, j].Text)
                            {
                                AvalibleDown = true;
                                powerAll(pieceDown, k + 1, j);
                                pieceDown[k, j].Text = "";
                            }
                        }
                    }
                }
            }
            return pieceDown;
        }
        ///
        private Button[,] goToUp(Button[,] pieceUp)
        {
            AvalibleTop = false;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i > 0)
                    {
                        int k = i;
                        while (k > 0 && pieceUp[k - 1, j].Text == "")
                        {

                            pieceUp[k - 1, j].Text = pieceUp[k, j].Text;
                            if (pieceUp[k - 1, j].Text != "" && pieceUp[k, j].Text != "" && pieceUp[k - 1, j].Text == pieceUp[k, j].Text)
                            {
                                AvalibleTop = true;
                            }
                            pieceUp[k, j].Text = "";
                            k--;
                        }

                        if (k > 0)
                        {
                            if (pieceUp[k - 1, j].Text == pieceUp[k, j].Text)
                            {
                                AvalibleTop = true;
                                powerAll(pieceUp, k - 1, j);
                                pieceUp[k, j].Text = "";
                            }
                        }
                    }
                }
            }
            return pieceUp;
        }
        public void powerAll(Button[,] pi, int i, int j)
        {

            pi[i, j].Text = "" + Convert.ToInt32(pi[i, j].Text) * 2;
        }
        public List<Button[,]> getAllMoveStates(Button[,] pieceAll)
        {

            List<Button[,]> allMoves = new List<Button[,]>();

            Button[,] pieceLeft = new Button[4, 4];
            Button[,] left = new Button[4, 4];
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    pieceLeft[i, j] = new Button();
                    pieceLeft[i, j].Text = pieceAll[i, j].Text;
                }
            }
            left = goToLeft(pieceLeft);
            if (AvalibleLeft)
            {
                left[2, 2].Tag = "left";
                allMoves.Add(left);
            }

            //MessageBox.Show("ok");

            Button[,] pieceright = new Button[4, 4];
            Button[,] right = new Button[4, 4];
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    pieceright[i, j] = new Button();
                    pieceright[i, j].Text = pieceAll[i, j].Text;
                }
            }
            right = goToRight(pieceright);

            if (AvalibleRight)
            {
                right[2, 2].Tag = "right";
                allMoves.Add(right);
            }

            // MessageBox.Show("ok2");

            Button[,] piecedown = new Button[4, 4];
            Button[,] down = new Button[4, 4];
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    piecedown[i, j] = new Button();
                    piecedown[i, j].Text = pieceAll[i, j].Text;
                }
            }
            down = goToDown(piecedown);
            if (AvalibleDown)
            {
                down[2, 2].Tag = "down";
                allMoves.Add(down);
            }

            // MessageBox.Show("ok3");

            Button[,] pieceup = new Button[4, 4];
            Button[,] up = new Button[4, 4];
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    pieceup[i, j] = new Button();
                    pieceup[i, j].Text = pieceAll[i, j].Text;
                }
            }
            up = goToDown(pieceup);
            if (AvalibleTop)
            {
                up[2, 2].Tag = "up";
                allMoves.Add(up);
            }

            return allMoves;
        }
        public double SnakeRating(Button[,] pi)
        {
            Button[,] piecesm = new Button[4, 4];
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    piecesm[i, j] = new Button();
                    piecesm[i, j].Text = pi[i, j].Text;
                }
            }
            double smoothnesss = smoothness(piecesm);


            Button[,] piecemo = new Button[4, 4];
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    piecemo[i, j] = new Button();
                    piecemo[i, j].Text = pi[i, j].Text;
                }
            }
            double Honest = Honesty(piecemo);

            Button[,] pieceem = new Button[4, 4];
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    pieceem[i, j] = new Button();
                    pieceem[i, j].Text = pi[i, j].Text;
                }
            }
            piceEmpety(pieceem);


            Button[,] piecema = new Button[4, 4];
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    piecema[i, j] = new Button();
                    piecema[i, j].Text = pi[i, j].Text;
                }
            }
            MaxNumber(piecema);


            double smoothWeight = 0.1,
                   mono2Weight = 1.0,
                   emptyWeight = 2.7,
                   maxWeight = 1.0;
            /*MessageBox.Show("smoothness  " + (smoothnesss * smoothWeight));
            MessageBox.Show("monotonicity2  " + (monotonicit * mono2Weight));
            MessageBox.Show("emptyCells  " + (freeTile * emptyWeight));
            MessageBox.Show(" maxValue  " + (maxNumber * maxWeight));
            MessageBox.Show("all ==>  " + ((smoothnesss * smoothWeight)
                  + (monotonicit * mono2Weight)
                  + (freeTile * emptyWeight)
                  + (maxNumber * maxWeight)));*/
            /* Console.WriteLine("all ==>  " + ((smoothnesss * smoothWeight)
                   + (monotonicit * mono2Weight)
                   + (freeTile * emptyWeight)
                   + (maxNumber * maxWeight)));
             Console.ReadLine();*/
            return ((smoothnesss * smoothWeight)
                  + (Honest * mono2Weight)
                  + (freeTile * emptyWeight)
                  + (maxNumber * maxWeight));
        }
        public Boolean piceEmpety(Button[,] pi)
        {
            Boolean check = false;
            double free = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int b = 0; b < 4; b++)
                {
                    if (pi[i, b].Text == "")
                    {
                        check = true;
                        free++;
                    }

                }
            }
            freeTile = Math.Log(free);
            return check;

        }
        public double MaxNumber(Button[,] pi)
        {
            int[] values = new int[16];
            double maxValue = 0;
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (pi[i, j].Text != "")
                    {
                        values[count] = Convert.ToInt16(pi[i, j].Text);
                    }
                    count++;

                }
            }

            for (var i = 0; i < values.Count(); ++i)
            {

                if (values[i] > maxValue)
                {
                    maxValue = values[i];
                }

            }
            maxNumber = Math.Log(maxValue);
            return maxValue;

        }
        private double smoothness(Button[,] pi)
        {
            double smoothness = 0;
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (pi[x, y].Text != "")
                    {
                        var value = Math.Log(Convert.ToInt16(pi[x, y].Text) / Math.Log(2));
                        bool f = true;
                        int k = 1;
                        if (y != 3)
                        {
                            while (f)
                            {
                                if (pi[x, y + k].Text != "")
                                {
                                    f = false;
                                    smoothness -= Math.Abs(value - (Math.Log(Convert.ToInt16(pi[x, y + k].Text) / Math.Log(2))));
                                }
                                else
                                {
                                    k++;
                                    if (k + y > 3)
                                    {
                                        f = false;
                                    }
                                }
                            }
                        }
                        bool h = true;
                        int n = 1;
                        if (x != 3)
                        {
                            while (h)
                            {
                                if (pi[x + n, y].Text != "")
                                {
                                    h = false;
                                    smoothness -= Math.Abs(value - (Math.Log(Convert.ToInt16(pi[x + n, y].Text) / Math.Log(2))));
                                }
                                else
                                {
                                    n++;
                                    if (n + x > 3)
                                    {
                                        h = false;
                                    }
                                }
                            }
                        }

                    }
                }
            }
            return smoothness;
        }
        private double Honesty(Button[,] pi)
        {
            double[] totals = new double[4];
            for (int x = 0; x < 4; x++)
            {

                int current = 0;
                int next = current + 1;

                while (next < 4)
                {
                    while (next < 4 && pi[x, next].Text != "")
                    {
                        next++;
                    }
                    if (next >= 4)
                    {
                        next--;
                    }

                    double currentValue;
                    double nextValue;

                    if (pi[x, current].Text != "")
                    {
                        currentValue = Math.Log(Convert.ToInt16(pi[x, current].Text)) / Math.Log(2);
                    }
                    else
                    {
                        currentValue = 0;
                    }

                    if (pi[x, next].Text != "")
                    {
                        nextValue = Math.Log(Convert.ToInt16(pi[x, next].Text)) / Math.Log(2);
                    }
                    else
                    {
                        nextValue = 0;
                    }


                    if (currentValue > nextValue)
                    {
                        totals[0] += nextValue - currentValue;
                    }
                    else if (nextValue > currentValue)
                    {
                        totals[1] += currentValue - nextValue;
                    }
                    current = next;
                    next++;
                }
            }


            for (int y = 0; y < 4; y++)
            {

                int current = 0;
                int next = current + 1;

                while (next < 4)
                {
                    while (next < 4 && pi[next, y].Text != "")
                    {
                        next++;
                    }
                    if (next >= 4)
                    {
                        next--;
                    }

                    double currentValue;
                    double nextValue;

                    if (pi[current, y].Text != "")
                    {
                        currentValue = Math.Log(Convert.ToInt16(pi[current, y].Text)) / Math.Log(2);
                    }
                    else
                    {
                        currentValue = 0;
                    }

                    if (pi[next, y].Text != "")
                    {
                        nextValue = Math.Log(Convert.ToInt16(pi[next, y].Text)) / Math.Log(2);
                    }
                    else
                    {
                        nextValue = 0;
                    }

                    if (currentValue > nextValue)
                    {
                        totals[2] += nextValue - currentValue;
                    }
                    else if (nextValue > currentValue)
                    {
                        totals[3] += currentValue - nextValue;
                    }
                    current = next;
                    next++;
                }
            }

            return (Math.Max(totals[0], totals[1]) + Math.Max(totals[2], totals[3]));
        }
    }
}
