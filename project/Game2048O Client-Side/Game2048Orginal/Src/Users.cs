using Game2048Orginal.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game2048Orginal.Src
{
    class Users:DataAcse 
    {
        private string UserName;
        private string Picture;
        private int Id;
        public string userName
        {
            set { UserName = value;}
            get { return UserName; }
        }
        public string picture
        {
            set { Picture = value;}
            get { return Picture; }
        }
        public int id
        {
            set { Id = value;}
            get { return Id; }
        }
       // public Users() : base() { }
        public int insertUser()
        {
           string commandText = "insert into users(user_name,user_picture)values('" + userName + "','" + picture + "')";
           return command(commandText );
        }
        public int DeleteUser()
        {

           string commandText = "delete from users where id='" + id + "'";
           DeleteRecord();
           DeleteFinder();
           return command(commandText );
        }
        public int DeleteRecord()
        {

            string commandText = "delete from records where id_user='" + id + "'";
            return command(commandText);
        }
        public int DeleteFinder()
        {

            string commandText = "delete from finder where id_user='" + id + "'";
            return command(commandText);
        }
        public int selectUserName(){
            string CommandText = "select user_name from users where user_name='"+userName+"'";
            Operations(CommandText);
           // MessageBox.Show(""+reader.FieldCount);
            int count = 0;
            while (reader.Read() )
            {
                count++;
            }
            reader.Close();
            return count;       
        }
        public List<Input> selectAllUser()
        {
            
            string CommandText = "select * from users" ;
            Operations(CommandText);
           // MessageBox.Show("" + reader.FieldCount);
            while (reader.Read())
            {
                Input inpu = new Input();
                inpu.Id = Convert.ToInt16(reader.GetValue(0));
                inpu.UserName = reader.GetString(1);
                inpu.UserPicture = reader.GetString(2);
                input.Add(inpu);
            }
            reader.Close();
            return input;
        }
        public string selectNameUser()
        {
            string CommandText = "select user_name from users where id='"+id+"'";
            Operations(CommandText);
            //MessageBox.Show("" + reader.FieldCount);
            string UserName="";
            while (reader.Read())
            {
                 UserName = reader.GetString(0);
            }
            reader.Close();
            return UserName;
        }
        public string selectPicture()
        {
            string CommandText = "select user_picture from users where id='" + id + "'";
            Operations(CommandText);
            //MessageBox.Show("" + reader.FieldCount);
            string UserName = "";
            while (reader.Read())
            {
                UserName = reader.GetString(0);
            }
            reader.Close();
            return UserName;
        }
        public int updatePicture()
        {

            string commandText = "update  users set user_picture='"+picture+"' where id='"+id+"'";
            return command(commandText);
        }
        public int updateUserName()
        {

            string commandText = "update  users set user_name='" + userName + "' where id='" + id + "'";
            return command(commandText);
        }
        public Input selectCheck(int idd)
        {
            string CommandText = "select * from finder where  id_user='" + idd + "'";
            Operations(CommandText);
            Input inpu = new Input();
           // MessageBox.Show("" + reader.FieldCount);
            while (reader.Read())
            {
                
                inpu.Id = Convert.ToInt16(reader.GetValue(0));
                inpu.Id_User = Convert.ToInt16(reader.GetValue(1));
                inpu.IdPicture = Convert.ToInt16(reader.GetValue(2));
                inpu.First = Convert.ToInt16(reader.GetValue(3));
                input.Add(inpu);
            }
            reader.Close();
            return inpu;
        }
        public int updateIdRecord(int id , int b)
        {

            string commandText = "update  finder set id_record='" + b + "' where  id_user='" + id + "' ";
            return command(commandText);
        }
        public int updateIdFirst(int id)
        {

            string commandText = "update  finder set first_con=1 where  id_user='" + id + "'";
            return command(commandText);
        }
        public int updateIdUserName(int id, int b)
        {

            string commandText = "update  finder set id_user_name='" + b + "' where  id_user='" + id + "'";
            return command(commandText);
        }
        public int updateIdUserPicture(int id,int b)
        {

            string commandText = "update  finder set id_user_picture='"+b+"' where  id_user='" + id + "'";
            return command(commandText);
        }
        public int insertFinder(int idd)
        {
            string commandText = "insert into finder(id_record,id_user_name,id_user_picture,first_con,id_user)values(0,0,0,0,'" + idd + "')";
            return command(commandText);
        }

    }
}
