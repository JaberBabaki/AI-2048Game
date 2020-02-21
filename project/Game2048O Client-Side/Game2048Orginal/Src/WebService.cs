
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game2048Orginal.Src
{
    class WebService
    {
        private string URL;
        private NameValueCollection NamevalueCollection;
        private string Picture;
        public string uRl
        {
            set { URL = value; }
            get { return URL; }
        }
        public string picture
        {
            set { Picture = value; }
            get { return Picture; }
        }
        public NameValueCollection namevalueCollection
        {
            set { NamevalueCollection = value; }
            get { return NamevalueCollection; }
        }
        public string readURL()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uRl);
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)request.GetResponse();
            if (myHttpWebResponse.StatusCode == HttpStatusCode.OK)
            {
                request.Method = "post";
                request.ContentType = "application/x-www-form-urlencoded";
                string postData = "home=Cosby&favorite+flavor=flies";
                byte[] bytes = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = bytes.Length;

                //Stream requestStream = request.GetRequestStream();
                StreamReader reader = new StreamReader(myHttpWebResponse.GetResponseStream());
                string str = streamToString(reader);
                return str;

            }

            myHttpWebResponse.Close();
            return null;
        }
        private string streamToString(StreamReader reader)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    builder.Append(line);
                }
                return builder.ToString();
            }
            catch 
            {
            }
            return "";
        }
        /*string teamname = (string)jObject["Hello2"];
          Object jObject = JObject.Parse(str);
          JToken jUser = jObject["Another Array"];
          JArray forloop = (JArray)jUser["ForLoop"];
          MessageBox.Show(" " + forloop.Count());
          for (int i = 0; i < forloop.Count(); i++)
          {
              MessageBox.Show(" " + i + ":::" + forloop[i]);
          }
          MessageBox.Show(" " + teamname + ":::" + jUser["Test2"]);*/
        public string cli()
        {
            try {

                WebClient client = new WebClient();
                if (namevalueCollection != null)
                {
                    // MessageBox.Show("5" + namevalueCollection);
                    // MessageBox.Show("+ i");
                    byte[] response = client.UploadValues(uRl, namevalueCollection);
                    string resulti = System.Text.Encoding.UTF8.GetString(response);
                    return null;
                }

                var res = client.DownloadString(uRl);
                return res;
            }catch(Exception e)
            {
                return "n";
            }

                
                
        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static string GetMacAddress()
        {
            const int MIN_MAC_ADDR_LENGTH = 12;
            string macAddress = string.Empty;
            long maxSpeed = -1;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                string tempMac = nic.GetPhysicalAddress().ToString();
                if (nic.Speed > maxSpeed &&
                    !string.IsNullOrEmpty(tempMac) &&
                    tempMac.Length >= MIN_MAC_ADDR_LENGTH)
                {

                    maxSpeed = nic.Speed;
                    macAddress = tempMac;
                }
            }

            return macAddress;
        }
        public void uploadPicture(string name)
        {
            ///
            try
            {
               // MessageBox.Show("4");
               // MessageBox.Show("+ input.First");
                WebClient client = new WebClient();

                //NetworkCredential nc = new NetworkCredential("erandika1986", "123");
                Uri addy = new Uri("http://www.martyriran.ir/Game2048/index.php?action=insertP&value=" + name + "");
                client.Credentials = CredentialCache.DefaultCredentials;
                //client.Credentials = nc;
               // byte[] response = client.UploadValues(uRl, namevalueCollection);
                byte[] arrReturn = client.UploadFile(addy,@picture);
               // MessageBox.Show(arrReturn.ToString());
                
            }
            catch (Exception ex1)
            {
               // MessageBox.Show(ex1.Message+"jaber");
            }
            ///
        }
        public void downloadFile(string name)
        {

            string url = "http://www.martyriran.ir/Game2048/image_user/" + name + "";
            // Create an instance of WebClient
            WebClient client = new WebClient();
            // Hookup DownloadFileCompleted Event
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);

            // Start the download and copy the file to c:\temp
            client.DownloadFileAsync(new Uri(url), G.DIRIMG+name+"");
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //MessageBox.Show("File downloaded");
        }
        

    }
}
