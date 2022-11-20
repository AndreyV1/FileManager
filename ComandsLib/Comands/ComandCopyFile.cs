using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerComandsLib.Comands
{

    public class ComandCopyFile : IComands
    {
        private ComandCopyFileFromFolderToFolder _cfff = new ComandCopyFileFromFolderToFolder();
        private string _pathFrom = "";
        private string _pathTo = "";

        private string[] _args = new string[3];
        public string ComandInfo()
        {
            return "Копирование файла из директории";
        }
        private Dictionary<string, string> _comands = new Dictionary<string, string>()
        {
             { "CopyFile", "CopyFile"},
             { "copyfile", "CopyFile"},
             { "CF",       "CopyFile"},
             { "cf",       "CopyFile"}
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
                if (File.Exists(args[1]))
                {
                    string[] pathFrom = args[1].ToString().Split('\\');
                    for (int i = 0; i < pathFrom.Length - 1; i++)
                    {
                        if (i != pathFrom.Length - 2)
                            _pathFrom += pathFrom[i] + "\\";
                        else
                            _pathFrom += pathFrom[i];
                    }
                    string[] pathTo = args[2].ToString().Split('\\');
                    for (int i = 0; i < pathTo.Length - 1; i++)
                    {
                        if (i != pathTo.Length - 2)
                            _pathTo += pathTo[i] + "\\";
                        else
                            _pathTo += pathTo[i];
                    }
                    FileInfo file = new FileInfo(args[1]);
                    if (Directory.Exists(_pathTo))
                    {
                        File.Copy(Path.Combine(args[1]), Path.Combine(args[2]), true);
                    }
                    else
                    {
                        
                        _args[0] = "CFFF";
                        _args[1] = _pathFrom;
                        _args[2] = _pathTo;
                        _cfff.Execute(_args);
                        
                    }
                    
                
                    successful = "Успешно!";
                }
                else
                    successful = "Не удалось скопировать файл";
            }
            catch (Exception ex)
            {
                successful = ex.Message;
            }


            return successful;
        }
    }
}
