using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerComandsLib.Comands
{
    public class ComandCopyFile : IComands
    {
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
                FileInfo file = new FileInfo(args[1]);
                if (Directory.Exists(args[2]))
                    {
                        File.Copy(Path.Combine(args[1]), Path.Combine(args[2]), true);
                    }
                else
                    {
                        _args[0] = "CFFF";
                        _args[1] = args[1];
                        _args[2] = args[2];
                        Execute(_args);
                        
                    }
                    
                
                successful = "Успешно!";
                }
                else
                    successful = "Не удалось скопировать файл";
            }
            catch (Exception ex)
            {
                successful = "Неуспешно";
            }


            return successful;
        }
    }
}
