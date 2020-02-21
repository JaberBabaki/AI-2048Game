
using Game2048Orginal.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2048Orginal
{
    class G: ApplicationContext
    {
        public static int resetRun=0;
        public static Form currentForm;
        public static string IMG_NAME="uy.png";
        public static string PATHMDF = @"C:\Program Files (x86)\jaberCompany\Game2048\Game2048.mdf";
        public static string PATHLDF = @"C:\Program Files (x86)\jaberCompany\Game2048\Game2048_log.ldf";
        public static string ADDPIC = Path.GetDirectoryName(Application.ExecutablePath)+@"\image_user\uy.png";
        public static string DIRIMG=Path.GetDirectoryName(Application.ExecutablePath)+@"\image_user\";
        
       // Path.GetDirectoryName(Application.ExecutablePath)
        Login game = new Login();
        public G()
        {
            //attach();
            game.Show();
        }
        public void attach()
        {
            string a="Game2048";
            String strcon = "Data Source=.;Initial Catalog=master;Integrated Security=True";
            String strsql = "select dbid from sysdatabases where name='"+a+"'";
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand cmd = new SqlCommand(strsql, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.ExecuteScalar ();
            da.Fill(ds);
           if (ds.Tables[0].Rows.Count>0 ) {
            //MsgBox("exist")
           }
            else{
                strsql = "EXEC master.dbo.sp_attach_db @dbname =Game2048,@filename1='" + PATHMDF + "',@filename2='" + PATHLDF + "'";
                cmd.CommandText = strsql;
                cmd.ExecuteNonQuery();
                conn.Close();
           }

        }

    }
}
