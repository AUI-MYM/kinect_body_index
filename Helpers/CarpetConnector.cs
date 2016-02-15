using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MYMGames.Hopscotch.Helpers
{
    //The class responsible for the connection with the carpet
    public class CarpetConnector
    {
        private static Mutex mut = new Mutex();
        private static string last_sent_action;
        public static async void sendData(string action)
        {
            mut.WaitOne();
            //check if the last action executed is the same
            if (last_sent_action != null && action.Equals(last_sent_action))
            {
                //no need to send again.
                mut.ReleaseMutex();
                return;
            }
            last_sent_action = action;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5050");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "POST";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"Action\":\"CarpetAction\"," +
                                  "\"Trigger\":\""+ action +"\"}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
            catch(System.Net.WebException)
            {

            }
            mut.ReleaseMutex();
            
        }
    }
}
