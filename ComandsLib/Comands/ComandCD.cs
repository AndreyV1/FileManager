using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace FileManagerComandsLib.Comands
{
    internal class ComandCD : IComands
    {
        public string ComandInfo()
        {
            return "CD";
        }
        private Dictionary<string, string> _comands = new Dictionary<string, string>()
        {
            {"CD", "CD" }
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


                Directory.SetCurrentDirectory(args[1]);
                Console.WriteLine(Directory.GetCurrentDirectory());
                string dllPath = Assembly.GetExecutingAssembly().Location;
                string txtPath = new FileInfo(dllPath).DirectoryName + "backup.txt";
                File.WriteAllText(txtPath, args[1]);
                successful = "Успешно";
            }
            catch
            {
                successful = "Провально";
            }
            return successful;
        }
        
    }
}
