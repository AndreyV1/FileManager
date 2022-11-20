using FileManagerComandsLib.Comands;
using System.Reflection;

namespace ComandsLib
{
    public class Manager
    {

        public Manager()
        {
            SetComandsList();
            _args = new string[3];
        }


        
        private string[] _args;                 
        private static List<IComands> _comands = new List<IComands>();
        /// <summary>
        /// Автоматически создает лист команд
        /// </summary>
        private void SetComandsList()
        {
            Assembly asm = Assembly.LoadFrom("FileManagerComandsLib.dll");
            Type[] types = asm.GetTypes();
            foreach (Type type in types)
            {
                if ((type.IsInterface == false) &&
                    (type.IsAbstract == false)&&
                    (type.GetInterface("IComands")!=null))
                {
                    IComands value = (IComands)Activator.CreateInstance(type);
                    _comands.Add(value);
                }
            }
        }
        /// <summary>
        /// проверка на правильность введенной команды
        /// </summary>
        /// <param name="comand"></param>
        /// <returns></returns>
        public string ExecuteComand(string comand)
        {
            ParseComandString(comand);
            string result = "";
            foreach (IComands com in _comands)
            {
                if (com.ComandName().ContainsKey(_args[0]))
                {
                    result = com.Execute(_args);
                }
                

            }
            if (result == "")
                return "Ошибка!";
            else
                return result;

        }
        /// <summary>
        /// "парсит" строку команды
        /// </summary>
        private void ParseComandString(string comand)
        {
            string[] str = comand.Split(' ');
            _args[0] = str[0];
            if (str.Length > 1)
            {
                comand = comand.Substring(_args[0].Length);
                if (comand.Contains('>'))
                {
                    string[] str2 = comand.Split('>');
                    _args[1] = str2[0].Trim();
                    _args[2] = str2[1].Trim();
                }
                else
                {
                    _args[1] = comand.Trim();
                }
            }

        }
        /// <summary>
        /// Возвращает справку по всем командам
        /// </summary>
        /// <returns></returns>
        public static string ComandsInfo()
        {
            foreach (IComands com in _comands)
                return com.ComandInfo();
            return "";
        }

    }
}