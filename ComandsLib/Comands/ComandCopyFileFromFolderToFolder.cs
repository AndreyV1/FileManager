using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerComandsLib.Comands
{
    public class ComandCopyFileFromFolderToFolder : IComands
    {
        public string ComandInfo()
        {
            return "Перемещение файла из папки в папку";
        }
        private Dictionary<string, string> _comands = new Dictionary<string, string>()
        {
            {"CopyFileFromFolderToFolder", "CopyFileFromFolderToFolder" },
            {"copyfilefromfoldertofolder", "CopyFileFromFolderToFolder" },
            {"CFFF",                       "CopyFileFromFolderToFolder" },
            {"cfff",                       "CopyFileFromFolderToFolder" }
        };
        public Dictionary<string, string> ComandName()
        {
            return _comands;
        }

        public string Execute(string[] args)
        {
            string successful = "";
            try
            {
                Directory.CreateDirectory(args[2]);
                if (Directory.Exists(args[1]))
                {
                    string[] files = Directory.GetFiles(args[1]);
                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileName(file);
                        string destFile = Path.Combine(args[2], fileName);
                        File.Copy(file, destFile, true);
                    }
                    successful = "Успешно!!!";
                }
                else
                    successful = "Не удалось найти папку по указанному пути";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return successful;
        }
    }
}
