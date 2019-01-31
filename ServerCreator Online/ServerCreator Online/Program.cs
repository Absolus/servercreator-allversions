using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerCreator_Offline
{
    class Program
    {
        static void Main(string[] args)
        {
            string Host = Dns.GetHostName(); // Host.

            WebClient v_Spigot = new WebClient();

            // Versions: 1.13, 1.12.2, 1.12, 1.11, 1.10.

            Console.Title = "ServerCreator Online (x32 - x64)";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(">> Программа работает в режиме онлайн, версия сборки 0.1.1");
            Console.WriteLine(">> Программа работает в диапазоне только новых версий.");
            Console.WriteLine(">> Доступные версии: 1.13.2, 1.13, 1.12.2, 1.12, 1.11, 1.10.");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Укажите версию вашего сервера:");

            string ServerVersion = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(">> Если Вы просто пропустите нажав Enter, программа сама узнает ваш IP адресс >:3");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Укажите ваш IP адресс:");

            string ServerIP = Console.ReadLine();

            Console.WriteLine("Укажите максимальное количество человек:");

            string ServerUsers = Console.ReadLine();

            Console.WriteLine("Укажите название сервера:");

            string ServerName = Console.ReadLine();

            Console.WriteLine("Включить PVP на сервере? [Да - Нет]:");

            string ServerPVP = Console.ReadLine();

            Console.WriteLine("Заключительный этап, создать сервер? [Да - Нет]:");

            string CreatedServer = Console.ReadLine();

            if (CreatedServer == "Да")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(">> Создание сервера, подождите пожалуйста...");

                using (System.IO.StreamWriter replaceset = new System.IO.StreamWriter(@"data_files/server.properties", false))
                {
                    replaceset.WriteLine("");
                }

                using (StreamWriter settings = File.AppendText(@"data_files/server.properties"))
                {
                    if (ServerIP == "")
                    {
                        ServerIP = Dns.GetHostByName(Host).AddressList[0].ToString(); // Ip.
                        settings.WriteLine("server-ip=" + ServerIP);
                    }
                    else
                    {
                        settings.WriteLine("server-ip=" + ServerIP);
                    }

                    settings.WriteLine("motd=" + ServerName);
                    settings.WriteLine("online-mode=false");
                    settings.WriteLine("max-players=" + ServerUsers);

                    if (ServerPVP == "Да")
                    {
                        settings.WriteLine("pvp=true");
                    }
                    else if (ServerPVP == "Нет")
                    {
                        settings.WriteLine("pvp=false");
                    }
                }

                switch (ServerVersion){
                    case "1.13.2":
                        Uri spigot = new Uri("https://cdn.getbukkit.org/spigot/spigot-1.13.2.jar");
                        v_Spigot.DownloadFileAsync(spigot, "MyServer/spigot-1.13.2.jar");
                        File.Copy("data_files/ServerSatrt1.13.bat", "MyServer/ServerStart1.13.2.bat");
                        break;
                    case "1.13":
                        Uri spigot1 = new Uri("https://cdn.getbukkit.org/spigot/spigot-1.13.jar");
                        v_Spigot.DownloadFileAsync(spigot1, "MyServer/spigot-1.13.jar");
                        File.Copy("data_files/ServerSatrt1.13.bat", "MyServer/ServerStart1.13.bat");
                        break;
                    case "1.12.2":
                        Uri spigot2 = new Uri("https://cdn.getbukkit.org/spigot/spigot-1.12.2.jar");
                        v_Spigot.DownloadFileAsync(spigot2, "MyServer/spigot-1.12.2.jar");
                        File.Copy("data_files/ServerSatrt1.13.bat", "MyServer/ServerStart1.12.2.bat");
                        break;
                    case "1.12":
                        Uri spigot3 = new Uri("https://cdn.getbukkit.org/spigot/spigot-1.12.jar");
                        v_Spigot.DownloadFileAsync(spigot3, "MyServer/spigot-1.12.jar");
                        File.Copy("data_files/ServerSatrt1.13.bat", "MyServer/ServerStart1.12.bat");
                        break;
                    case "1.11":
                        Uri spigot5 = new Uri("https://cdn.getbukkit.org/spigot/spigot-1.11.jar");
                        v_Spigot.DownloadFileAsync(spigot5, "MyServer/spigot-1.11.jar");
                        File.Copy("data_files/ServerSatrt1.13.bat", "MyServer/ServerStart1.11.bat");
                        break;
                    case "1.10":
                        Uri spigot6 = new Uri("https://cdn.getbukkit.org/spigot/spigot-1.10.jar");
                        v_Spigot.DownloadFileAsync(spigot6, "MyServer/spigot-1.10.jar");
                        File.Copy("data_files/ServerSatrt1.13.bat", "MyServer/ServerStart1.10.bat");
                        break;
                }

                File.WriteAllText(@"MyServer/eula.txt", "eula=true");
                File.Copy("data_files/server.properties", "MyServer/server.properties");

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine(">> Сервер успешно создан, он находиться в папке с программой.");
                Console.WriteLine(">> Что-б запустить уже готовый сервер, нужно открыть файл ServerStart" + ServerVersion + ".bat");
                Console.WriteLine(">> Для игры с друзьями откройте порты и дайте им этот IP: " + ServerIP);
                Console.WriteLine(">> Если есть вопросы или нужна помощь, соц.сети создателей программы:");
                Console.WriteLine(">> ВКонтакте: vk.com/bogdanbedn | Инстаграмм @bogdanbedn");
                Console.WriteLine(">> ВКонтакте: vk.com/stanislav.lavshuk | Инстаграмм @absolus.aa");

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(">> Для выхода нажмите на Enter.");

                Console.ReadKey();

            } else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine(">> До новых встреч! Соц.сети создателя программы:");
                Console.WriteLine(">> ВКонтакете: vk.com/bogdanbedn | Инстаграмм @bogdanbedn");
                Console.WriteLine(">> ВКонтакте: vk.com/stanislav.lavshuk | Инстаграмм @absolus.aa");

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(">> Для выхода нажмите на Enter.");
                Console.ReadLine();
            }
        }
    }
}
