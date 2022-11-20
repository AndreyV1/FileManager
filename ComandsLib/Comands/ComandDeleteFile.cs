using ComandsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerComandsLib.Comands
{
    public class ComandDeleteFile : IComands
    {
        
        public string ComandInfo()
        {
            return "Удаление файла";
        }

        private Dictionary<string, string> _comands= new Dictionary<string, string>
        {
            {"DeleteFile", "DeleteFile" },
            {"deletefile", "DeleteFile" },
            {"DFL", "DeleteFile" },
            {"dfl", "DeleteFile" }
        };
        public Dictionary<string, string> ComandName()
        {
            return _comands;
        }
        public string Execute(string[] args)
        {


            FileInfo fileInfo = new FileInfo(args[1]);
            try
            {
                if (fileInfo.Exists)
                    fileInfo.Delete();
                else
                    return $"File {fileInfo} not found";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
         
            return $"File {fileInfo} deleted! ";
                
        }

        
    }
}
