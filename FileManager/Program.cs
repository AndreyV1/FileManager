using ComandsLib;

namespace Program;
class Program
{
    public static bool running = true;
    static void Main()
    {
        Manager manager = new Manager();
        

        while (running)
        {



            string comand = Console.ReadLine();
            Console.WriteLine(manager.ExecuteComand(comand));
            ConsoleComandExecute(comand);
            






        }
    }
    static void ConsoleComandExecute(string comandName)
    {
        
        switch (comandName)
        {
            case "!exit":
                running = false;
                break;
            case "!clear":
                Console.Clear();
                break;


        }


        //какие-то вспомогательные команды:
        //сlear()
        //exit()
        //
    }
}