using MySqlX.XDevAPI.Common;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace ndr
{
    internal class Api
    {
        private string status;

        public string get_status(){
            
            try
            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send("nadiraa.my.id", 1000);
                if (reply != null)
                {
                    var url = "http://localhost/rpc/api.php/";

                    var httpRequest = (HttpWebRequest)WebRequest.Create(url);

                    httpRequest.Accept = "application/json";
                    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        status = "True";
                        return result;

                    }

                }
            }
            catch
            {
                string result = "Not Connected";
                return result;
            }
            string tidak = "Not Available";
            return tidak;

        }
        
    }
   
}
