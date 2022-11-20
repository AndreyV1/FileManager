using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerComandsLib.Comands
{
    internal class ComandTree : IComands
    {
        private List<string> _treeList = new List<string>();
        public string ComandInfo()
        {
            return "просмотр дерева";
        }
        private Dictionary<string, string> _comands = new Dictionary<string, string>()
        {
            {"Tree", "Tree"},
            {"tree", "Tree"},
            {"TR", "Tree"},
            {"tr", "Tree"}
        };
        public Dictionary<string, string> ComandName()
        {
            return _comands;
        }
        /// <summary>
        /// Дерево директории
        /// </summary>
        /// <param name="path"></param>
        private void Tree(string path)
        {
            List<string> directories = Directory.GetDirectories(path).ToList();
            List<string> files = Directory.GetFiles(path).ToList();
            foreach (string name in directories)
            {
                _treeList.Add(name);
                Tree(name, 1);
            }
            foreach (string name in files)
            {
                _treeList.Add(name);
            }
            
        }
        private void Tree (string path, int depth)
        {
            List<string> directories = Directory.GetDirectories(path).ToList();
            List<string> files = Directory.GetFiles(path).ToList();
            foreach (string name in directories)
            {
                _treeList.Add(name);
                Tree(name, depth+1);
            }
            foreach (string name in files)
            {
                _treeList.Add(name);
            }
            foreach (string name in _treeList)
                Console.WriteLine(name);
            
        }

        public string Execute(string[] args)
        {
            string successful = "";
            try
            {
                Tree(args[1]);
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
