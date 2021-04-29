using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using System.Net;

namespace FirebaseHttpClient
{
    /// <summary>
    /// Фасад для взаимодействия с firebase
    /// </summary>
    public static class FirebaseSender
    {
        private static string FireBasePushNotificationsURL = "https://fcm.googleapis.com/fcm/send";
        private static string ServerKey = ConfigurationManager.AppSettings["FirebaseServerKey"];
        private static string SenderId = ConfigurationManager.AppSettings["SenderId"];

        /// <summary>
        /// Метод отправки сообщения
        /// </summary>
        /// <param name="fcmToken"></param>
        /// <param name="title"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string ExcutePushNotification(string fcmToken, string title, string msg)
        {

            var result = "-1";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(FireBasePushNotificationsURL);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add($"Authorization: key={ServerKey}");
            httpWebRequest.Headers.Add($"Sender: id={SenderId}");
            httpWebRequest.Method = "POST";

            var payload = new
            {
                notification = new
                {
                    title = title,
                    body = msg,
                    sound = "default"
                },
                to = fcmToken,
                priority = "high",
                content_available = true,
            };

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(payload);
                streamWriter.Write(json);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }
}
