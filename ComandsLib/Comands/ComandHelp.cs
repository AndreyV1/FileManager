using ComandsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerComandsLib.Comands
{
    internal class ComandHelp : IComands
    {
        public string ComandInfo()
        {
            return "Список команд с описанием";
        }
        private Dictionary<string, string> _comands = new Dictionary<string, string>()
        {
            {"Help","Help" },
            {"help","Help" },
            {"!Help","Help" },
            {"!help","Help" },
        };

        public Dictionary<string, string> ComandName()
        {
            return  _comands;
        }

        public string Execute(string[] args)
        {
            string message = $"-------------------------------------------- Основные команды ---------------------------------------------\n" +
                $"cd <путь> \t\t - перемещение по файловой системе\n" +
                $"List \t\t\t - вывод списка файлов и папок в текущей директории постраничный\n" +
                $"DFL <путь> \t\t - удаление указанного файла\n" +
                $"DF <путь> \t\t - удаление указанной папки\n" +
                $"CF <путь> > <путь>\t - копирование файла с заменой\n" +
                $"CFFF <путь> > <путь>\t - копирование файлов из папки в другую папку\n" +
                $"tree \t\t\t - просмотр файловой системы из текущей директори постраничный\n" +
                $"fi <путь> \t\t - вывод информации о файле. Путь относительный или полный\n" +
                $"di <путь> \t\t - вывод информации о папке. Путь относительный или полный\n" +
                $"!clear \t\t\t - очистка консоли\n" +
                $"!help \t\t\t - вызов описания команд\n" +
                $"-----------------------------------------------------------------------------------------------------------";
            return message;


            
           
        }
    }
}
