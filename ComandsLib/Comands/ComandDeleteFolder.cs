using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerComandsLib.Comands
{
    internal class ComandDeleteFolder : IComands
    {
        private string[] _args = new string[2];
        public string ComandInfo()
        {
            return "Удаление папки";
        }
        private Dictionary<string, string> _comands = new Dictionary<string, string>()
        {
            {"DeleteFolder", "DeleteFolder"},
            {"deletefolder", "DeleteFolder"},
            {"DF", "DeleteFolder"},
            {"df", "DeleteFolder"}
        };
        public Dictionary<string, string> ComandName()
        {
            return _comands;
        }

        static void Delete(string path)
        {
            if (Directory.Exists(path))
            {

                foreach (string file in Directory.GetFiles(path))
                    File.Delete(file);
                foreach (string directory in Directory.GetDirectories(path))
                {

                    Delete(directory);

                }
                Directory.Delete(path);


            }
        }
        public string Execute(string[] args)
        {
            string successful = "";
            try
            {
                if (Directory.Exists(args[1]))
                {
                Delete(args[1]);
                successful = "Успешно";
                }
            else
                successful = "Не удалось удалить папку по упазанному пути";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return successful;
        }
    }
}
