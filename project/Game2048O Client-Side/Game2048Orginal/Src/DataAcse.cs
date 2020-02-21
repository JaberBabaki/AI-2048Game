

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Game2048Orginal.Src
{
    class DataAcse
    {

      static string str= Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        static string filename = str+@"\Game2048\Game2048.sqlite";
        string str_con = "Data Source=" + filename + ";Version=3;New=true;Compress=True;";
        //string str_con = "Data Source=.;Initial Catalog=Game2048;Integrated Security=True";
        
        protected SQLiteConnection con = new SQLiteConnection();
        protected SQLiteCommand com = new SQLiteCommand();
        protected List<Input> input = new List<Input>();
        protected SQLiteDataReader reader;
        protected DataAcse()
        {
          //  MessageBox.Show(str);
            con.ConnectionString = str_con;
            con.Open();
        }
        protected int command( string strSql)
        {
            try
            {
                com.CommandText = strSql;
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return 0;
            }
            return 1;
        }
        protected void Operations(string strsql)
        {
            try
            {


                com = new SQLiteCommand();
                com.CommandText = strsql;
                com.Connection = con;
                com.CommandType = CommandType.Text;
                
                reader = com.ExecuteReader();
             //   MessageBox.Show("" + reader.FieldCount);
            }
            catch (Exception e)
            {

            }

        }
    }
}
