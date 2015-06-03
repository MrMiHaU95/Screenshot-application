using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ScreenAppWinForms
{
    static class UploadToImgurHelper
    {
        /// <summary>
        /// uplouduje screena na imgur 
        /// </summary>
        /// <param name="pathToScreenshot">pełna ścieżka dostępu do screenshota z verbatim literal</param>
        public static void UploadScreenshot(string pathToScreenshot)
        {
            //WebClient wprowadza wspólne metody do wysyłania i otrzymywania danych z zasobów rozpoznanych po url
            using (var w = new WebClient())
            {
                string clientID = "e780af3f12ba2d5";
                w.Headers.Add("Authorization", "Client-ID " + clientID);
                //kolekcja string keys i string values
                var values = new NameValueCollection
                {
                     { "image", Convert.ToBase64String(File.ReadAllBytes(pathToScreenshot)) }
                };

                //zapisywanie odpowiedzi w buforze 
                byte[] response = w.UploadValues("https://api.imgur.com/3/upload.xml", values);
                //kilka linijek kodu aby z response odczytać url
                XDocument responseData = XDocument.Load(new MemoryStream(response));
                Console.WriteLine(responseData);
                XElement element = responseData.Root.Element("link");
                string url = element.Value;
                //uruchamia przeglądarkę lub otwiera nową kartę z zuploudowanym screenem
                Process.Start(@"chrome.exe", url);
                //plik po zuploadowaniu jest usuwany z dysku
                if (File.Exists(pathToScreenshot))
                {
                    File.Delete(pathToScreenshot);
                }

                //przykładowe response w postaci XML 
                /*
                 <data success="1" status="200">
                    <id>SbBGk</id>
                    <title/>
                    <description/>
                    <datetime>1341533193</datetime>
                    <type>image/jpeg</type>
                    <animated>false</animated>
                    <width>2559</width>
                    <height>1439</height>
                    <size>521916</size>
                    <views>1</views>
                    <bandwidth>521916</bandwidth>
                    <deletehash>eYZd3NNJHsbreD1</deletehash>
                    <section/>
                    <link>http://i.imgur.com/SbBGk.jpg</link>
                </data>
                 */
            }
        }
    }
}
