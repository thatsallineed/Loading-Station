using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace updater
{
    public class Jsonconfig
    {
        static List<FileDetails> fDetails = new List<FileDetails>();
        public static void Serialize()
        {
            Information info = new Information
            {
                Version = "1.0.2",
                InstallationPath = string.Format("C:\\\\LoadingStation\\"),
                Comments = "Security Patch"
            };


            FileDetails fd1 = new FileDetails
            {
                Id = 1,
                Filename = "loadingStation.exe",
                Uri = "http://192.168.100.254/update/1.0.2/loadingStation.exe"
            };
            FileDetails fd2 = new FileDetails
            {
                Id = 2,
                Filename = "config.json",
                Uri = "http://192.168.100.254/update/1.0.2/config.json"
            };

            fDetails.Add(fd1);
            fDetails.Add(fd2);

            string js = JsonConvert.SerializeObject(new { info, fDetails }, Formatting.Indented);
            Actions.StringToFile("Update.json",js);
        }
        public static bool Deserial(string FileLocation, out string Version, out string InstallationPath, out string Comments, out List<string> Filename, out List<string> Fileuri)
        {
            bool result = false;
            Version = "NULL";
            InstallationPath = "";
            Comments = "No Comments";
            Filename = null;
            Fileuri = null;

            string config = Actions.FileToString(FileLocation);
            
            if (config != "")
            {
                System.Windows.Forms.MessageBox.Show(config);
                var x = JsonConvert.DeserializeObject();
                Information info = JsonConvert.DeserializeObject<Information>(config);
                FileDetails details = JsonConvert.DeserializeObject<FileDetails>(config);


                System.Windows.Forms.MessageBox.Show(info.Comments);

                Version = info.Version;
                InstallationPath = info.InstallationPath;
                Comments = info.Comments;

                foreach(var F in details.Filename)
                {
                    var value = F.ToString();
                    Filename.Add(value);
                }

                foreach(var I in details.Uri)
                {
                    var value = I.ToString();
                    Fileuri.Add(value);
                }

                result = true;
            }
            return result;
        }


        // ----  DATA LIST  ---- //
        class Information
        {
            public string Version { get; set; }
            public string InstallationPath { get; set; }
            public string Comments { get; set; }
        }

        class FileDetails
        {
            public int Id { get; set; }
            public string Filename { get; set; }
            public string Uri { get; set; }
        }
    }
}
