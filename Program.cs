using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BInFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Register obj = new Register();
            /*obj.RegAdmin();
            obj.RegUser();
            obj.RegUser();
            obj.RegUser();*/
            obj.Show();
            obj.Abil();
            Console.ReadKey();

        }

        public class Register
        {
            string path = "users.ras";
            Random r = new Random();
            public void RegUser()
            {
                int id = r.Next(1000, 9999);
                Console.WriteLine("Введите фамилию");
                string surname = Console.ReadLine();
                Console.WriteLine("Введите имя");
                string name = Console.ReadLine();
                Console.WriteLine("Введите возраст");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите логин");
                string login = Console.ReadLine();
                Console.WriteLine("Введите пароль");
                string password = Console.ReadLine();
                using (BinaryWriter br = new BinaryWriter(File.Open(path, FileMode.Append)))
                {
                    br.Write(id);
                    br.Write(surname);
                    br.Write(name);
                    br.Write(age);
                    br.Write(login);
                    br.Write(password);
                    br.Write(2);
                }
            }
            public void RegAdmin()
            {
                int id = r.Next(1000, 9999);
                Console.WriteLine("Введите фамилию");
                string surname = Console.ReadLine();
                Console.WriteLine("Введите имя");
                string name = Console.ReadLine();
                Console.WriteLine("Введите возраст");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите логин");
                string login = Console.ReadLine();
                Console.WriteLine("Введите пароль");
                string password = Console.ReadLine();
                using (BinaryWriter br = new BinaryWriter(File.Open(path, FileMode.Append)))
                {
                    br.Write(id);
                    br.Write(surname);
                    br.Write(name);
                    br.Write(age);
                    br.Write(login);
                    br.Write(password);
                    br.Write(1);
                }
            }
            public void Show()
            {
                using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
                {

                    while (br.PeekChar() > -1)
                    {
                        Console.Write($"{br.ReadInt32()} ");
                        Console.Write($"{br.ReadString()} ");
                        Console.Write($"{br.ReadString()} ");
                        Console.Write($"{br.ReadInt32()} ");
                        Console.Write($"{br.ReadString()} ");
                        Console.Write($"{br.ReadString()} ");
                        Console.Write($"{br.ReadInt32()}\n");
                    }
                }
            }
        
        public void Show18()
        {
            string path = "users.ras";
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                string login, password, name, surname;
                int role, id, age;
                while (br.PeekChar() > -1)
                {
                    id = br.ReadInt32();//id
                    surname = br.ReadString();//Фамилия
                    name = br.ReadString();//Имя
                    age = br.ReadInt32();//Возраст
                    login = br.ReadString();//Логин
                    password = br.ReadString();//Пароль
                    role = br.ReadInt32();//Роль
                    if (age >= 18)
                    {
                        Console.WriteLine($"id - {id}");
                        Console.WriteLine($"Фамилия - {surname}");
                        Console.WriteLine($"Имя - {name}");
                        Console.WriteLine($"Возраст - {age}");
                        Console.WriteLine($"Логин - {login}");
                        Console.WriteLine($"Пароль - {password}\n");
                    }
                }
            }
        }
        public void PersonData()
        {
            string path = "users.ras";
            Console.WriteLine("Введите фамилию пользователя");
            string surnamech = Console.ReadLine();
            Console.WriteLine("Введите имя пользователя");
            string namech = Console.ReadLine();
            using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
            {

                string login, password, name, surname;
                int role, id, age;
                while (br.PeekChar() > -1)
                {
                    id = br.ReadInt32();//id
                    surname = br.ReadString();//Фамилия
                    name = br.ReadString();//Имя
                    age = br.ReadInt32();//Возраст
                    login = br.ReadString();//Логин
                    password = br.ReadString();//Пароль
                    role = br.ReadInt32();//Роль
                    if ((surname == surnamech) && (name == namech))
                    {
                        Console.WriteLine($"id - {id}");
                        Console.WriteLine($"Фамилия - {surname}");
                        Console.WriteLine($"Имя - {name}");
                        Console.WriteLine($"Возраст - {age}");
                        Console.WriteLine($"Логин - {login}");
                        Console.WriteLine($"Пароль - {password}\n");
                        break;
                    }
                }
            }
        }
            public void Abil()
            {
                string path = "users.ras";
                Register obj = new Register();
                Console.WriteLine("Пожалуйста, введите свой логин");
                string login = Console.ReadLine();
                Console.WriteLine("Пожалуйста, введите пароль");
                string password = Console.ReadLine();
                string logcheck, pascheck, name, surname;
                int role, id, age;
                using (BinaryReader br = new BinaryReader(File.Open(path, FileMode.Open)))
                {

                    while (br.PeekChar() > -1)
                    {
                        id = br.ReadInt32();//id
                        surname = br.ReadString();//Фамилия
                        name = br.ReadString();//Имя
                        age = br.ReadInt32();//Возраст
                        logcheck = br.ReadString();//Логин
                        pascheck = br.ReadString();//Пароль
                        role = br.ReadInt32();//Роль
                        if ((logcheck == login) && (pascheck == password))
                        {
                            if (role == 2)
                            {
                                Console.WriteLine("Вы - пользователь, вот вся доступная информация:");
                                Console.WriteLine($"id - {id}");
                                Console.WriteLine($"Фамилия - {surname}");
                                Console.WriteLine($"Имя - {name}");
                                Console.WriteLine($"Возраст - {age}");
                                Console.WriteLine($"Логин - {login}");
                                Console.WriteLine($"Пароль - {password}");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Вы - администратор, вот все доступные действия:");
                                Console.WriteLine("1 - Просмотр своей учётной записи");
                                Console.WriteLine("2 - Просмотр учётных записей всех пользователей");
                                Console.WriteLine("3 - Просмотр данных совершеннолетних пользователей");
                                Console.WriteLine("4 - Просмотр данных об определённом пользователе");
                                Console.WriteLine("5 - Регистрация нового пользователя");
                                Console.WriteLine("Введите значение действия, которе хотите выполнить");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        Console.WriteLine("Вот вся доступная информация:");
                                        Console.WriteLine($"id - {id}");
                                        Console.WriteLine($"Фамилия - {surname}");
                                        Console.WriteLine($"Имя - {name}");
                                        Console.WriteLine($"Возраст - {age}");
                                        Console.WriteLine($"Логин - {login}");
                                        Console.WriteLine($"Пароль - {password}");
                                        break;
                                    case "2":
                                        Console.WriteLine("Информация о всех пользователях:");
                                        br.Close();
                                        Show();
                                        break;
                                    case "3":
                                        Console.WriteLine("Информация о совершеннолетних пользователях:");
                                        br.Close();
                                        Show18();
                                        break;
                                    case "4":
                                        br.Close();
                                        PersonData();
                                        break;
                                    case "5":
                                        br.Close();
                                        RegUser();
                                        break;
                                    default:
                                        Console.WriteLine("Такого действия нет");
                                        break;
                                }
                                break;
                            }
                        }

                    }
                }
            }
        }
    }
}