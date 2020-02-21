using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Game2048Orginal.Src;
namespace Game2048Orginal.Src
{
    class SendData
    {
        private string Mac;
        private int Id;
        private Input input;
        private Users users;
        public int id
        {
            set { Id = value; }
            get { return Id; }
        }

        public SendData()
        {
            Mac = WebService.GetMacAddress();
            users = new Users();
        }
        public void setInput()
        {
               
                input = users.selectCheck(id);
        }
        public int firstSend()
        {

             //MessageBox.Show("1");
                if (input.First == 0 && (input.Id != 0 || input.Id_User != 0 || input.IdPicture != 0))
                {

                   // MessageBox.Show("2");
                    RcordEachUser rcordEachUser = new RcordEachUser();
                    if (input.Id != 0)
                    {
                        rcordEachUser.id = input.Id;
                    }
                    else if (input.Id_User != 0)
                    {
                        rcordEachUser.id = input.Id_User;
                    }
                    else if (input.IdPicture != 0)
                    {
                        rcordEachUser.id = input.IdPicture;
                    }

                    //  Input inpu = rcordEachUser.selectRecordForId();

                    Input inpu = sort(rcordEachUser.selectRecord());
                    if (inpu != null)
                    {
                       // MessageBox.Show("3");
                        WebService webService = new WebService();
                        users.id = inpu.Id_User;
                        inpu.UserName = users.selectNameUser();                        
                        string filePath = users.selectPicture();
                        if (!filePath.Contains(G.IMG_NAME))
                        {
                            inpu.UserPicture = Mac + "-" + inpu.Id_User + "." + filePath.Substring(((filePath.Length) - 3), 3);
                            webService.picture = filePath;
                            webService.uploadPicture(inpu.UserPicture);
                        }
                        else
                        {
                          
                            inpu.UserPicture = G.IMG_NAME;
                        }                        
                        inpu.serialId = Mac + "-" + inpu.Id_User;
                        var n = new NameValueCollection()
                        {
                          { "UserName", inpu.UserName },
                          { "Score"   , inpu.Score    },
                          { "Max", inpu.Max },
                          { "Move", inpu.Move },
                          { "Time", inpu.Time },
                          { "serialId", inpu.serialId },
                          { "UserPicture", inpu.UserPicture },
                       };
                        webService.uRl = "http://www.martyriran.ir/Game2048/index.php?action=insertF";
                        webService.namevalueCollection = n;
                        webService.cli();
                        users.updateIdFirst(id);
                        users.updateIdRecord(id, 0);
                        users.updateIdUserName(id, 0);
                        users.updateIdUserPicture(id, 0);
                    }
                    return 1;
                }
            return 0;
            
        }
        public void sendIP_PICTURE_USERNAME(){
            if (input.Id != 0)
            {
                //MessageBox.Show("input.Id"+"::"+input.Id);
                //id user
                RcordEachUser rcordEachUser = new RcordEachUser();
                rcordEachUser.id = input.Id;
                Input inpu = sort(rcordEachUser.selectRecord());
                inpu.serialId = Mac + "-" + inpu.Id_User;
                WebService webService = new WebService();
                var n = new NameValueCollection()
                        {                      
                          { "Score"   , inpu.Score    },
                          { "Max", inpu.Max },
                          { "Move", inpu.Move },
                          { "Time", inpu.Time },
                          { "serialId", inpu.serialId },
                        };
                webService.uRl = "http://www.martyriran.ir/Game2048/index.php?action=updateR";
                webService.namevalueCollection = n;
                webService.cli();
                users.updateIdRecord(id, 0);

            }
            if (input.Id_User != 0)
            {
                //id karbar
                users.id = input.Id_User;
                string UserName = users.selectNameUser();
                string serialId = Mac + "-" + input.Id_User;
                WebService webService = new WebService();
                var n = new NameValueCollection()
                        {                      
                          { "UserName", UserName },
                          { "serialId", serialId },
                        };
                webService.uRl = "http://www.martyriran.ir/Game2048/index.php?action=updateU";
                webService.namevalueCollection = n;
                webService.cli();
                users.updateIdUserName(id, 0);
            }
            if (input.IdPicture != 0)
            {
                WebService webService = new WebService();
                users.id = input.IdPicture;
                string filePath = users.selectPicture();
                 string UserPicture;
                if (!filePath.Contains(G.IMG_NAME))
                {
                    UserPicture = Mac + "-" + input.IdPicture + "." + filePath.Substring(((filePath.Length) - 3), 3);
                    webService.picture = filePath;
                    webService.uploadPicture(UserPicture);
                }
                else
                {
                    UserPicture = G.IMG_NAME;
                } 
                string serialId = Mac + "-" + input.IdPicture;
                //MessageBox.Show("" + serialId + "::" + UserPicture);
                
                var n = new NameValueCollection()
                        {                      
                          { "UserPicture", UserPicture },
                          { "serialId", serialId },
                        };
                webService.uRl = "http://www.martyriran.ir/Game2048/index.php?action=updateP";
                webService.namevalueCollection = n;
                webService.cli();
                users.updateIdUserPicture(id, 0);
            }
        }
        private Input sort(List<Input> inpu)
        {
            Input temp = new Input();
            for (int i = 0; i < inpu.Count(); i++)
            {
                for (int j = 0; j < inpu.Count() - 1; j++)
                {
                    if (Convert.ToInt16(inpu[j].Score) < Convert.ToInt16(inpu[j + 1].Score))
                    {
                        temp = inpu[j + 1];
                        inpu[j + 1] = inpu[j];
                        inpu[j] = temp;

                    }
                }
            }
            if (inpu.Count > 0)
            {
                return inpu[0];
            }
            return null;

        }
    }
}
