using Game2048Orginal.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2048Orginal.Src
{
    class RcordEachUser:DataAcse 
    {
        private int Id;
        private int IdUser;
        private string Score;
        private string Max;
        private string Move;
        private string Time;
        public int id
        {
            set { Id = value; }
            get { return Id; }
        }
        public int idUser
        {
            set { IdUser = value; }
            get { return IdUser; }
        }
        public string score
        {
            set { Score = value; }
            get { return Score; }
        }
        public string max
        {
            set { Max = value; }
            get { return Max; }
        }
        public string move
        {
            set { Move = value; }
            get { return Move; }
        }
        public string time
        {
            set { Time = value; }
            get { return Time; }
        }
        public int inserRecord()
        {
            string commandText = "insert into records(id_user,score,max,move,time)values('" + idUser + "','" + score + "','" + max + "','" + move + "','" + time + "')";
           return command(commandText);
        }
        public List<Input> selectRecord(){
            string CommandText = "select * from records where id_user='"+id+"'";
            Operations(CommandText);
            while (reader.Read())
            {
                Input inpu = new Input();
                inpu.Id = Convert.ToInt16(reader.GetValue(0));
                inpu.Id_User = Convert.ToInt16(reader.GetValue(1));
                inpu.Score = reader.GetString(2);
                inpu.Max = reader.GetString(3);
                inpu.Move = reader.GetString(4);
                inpu.Time = reader.GetString(5);
                input.Add(inpu);
            }
            reader.Close();
            return input;
        }
        public int DeleteRecord(){
           // MessageBox.Show("" + id);
            string commandText = "delete from records where id='" + id + "'";
            return command(commandText);
        }
      /*  public Input selectRecordForId()
        {
            string CommandText = "select * from records where id='" + id + "'";
            Operations(CommandText);
            Input inpu = new Input();
            while (reader.Read())
            {
               
                inpu.Id = Convert.ToInt16(reader.GetValue(0));
                inpu.Id_User = Convert.ToInt16(reader.GetValue(1));
                inpu.Score = reader.GetString(2);
                inpu.Max = reader.GetString(3);
                inpu.Move = reader.GetString(4);
                inpu.Time = reader.GetString(5);
                //input.Add(inpu);
            }
            reader.Close();
            return inpu;
        }*/
    }
}
