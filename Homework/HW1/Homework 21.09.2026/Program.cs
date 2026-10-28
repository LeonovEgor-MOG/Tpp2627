using System;

namespace Homework
{
    class Bank_account
    {
        private static int _balance;
        private static List<string> _operations = new List<string>(); 
        public static List<string> Operations = new List<string>();
        
        public static int Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                if (value >= 0)
                    _balance = value;
                else
                { }    
            }
        }

        public static void PrintBalance(char valuta = 'Р')
        {
            if(valuta == 'Р')
                Console.WriteLine($"Ваш баланс: {Balance}₽");
            else
                Console.WriteLine($"Ваш баланс: {Math.Round(Balance/84.07, 2)}$");
        }


        public static void Invest()
        {
            int number = Convert.ToInt16(Console.ReadLine());
            if (number >= 0) 
            { 
                Balance += number;
                Console.WriteLine("Операция успешно выполнена (+)");
                Operations.Add($"Операция пополнения: +{number}");
            }

            else
                Console.WriteLine("серьезно? не стыдно тебе такие цифры вводить? пополнение доступно только в НЕОТРИЦАТЕЛЬНЫХ числах, грамотей");
        }

        public static void Withdraw()
        {
            int number = Convert.ToInt16(Console.ReadLine());
            if (number >= 0 && Balance - number >= 0)
            {
                Balance -= number;
                Console.WriteLine("Операция успешно выполнена (-)");
                Operations.Add($"Операция cнятия: -{number}");
            }
            else
                Console.WriteLine($"серьезно? не стыдно тебе такие цифры вводить? а где ты столько денег на своем балансе нашел? из {Balance} ты хочешь взять {number}, ну совесть имей");


        }

        public static void ShowList()
        {
            for(int i = 0; i < Operations.Count; i++)
                Console.WriteLine(Operations[i]);
        }
        static void Main()
        {
            Console.WriteLine("Пожалуйста, введите ваш баланс:");
            bool flag = true;
            string repeatedChar = new string('-', 33);
            int user_input = Convert.ToInt16(Console.ReadLine());
            Balance = user_input;
            while (flag)
            {
                Console.WriteLine("Выберите операцию: \n1) Покажите, пожалуйста, мой баланс \n2) Я хочу пополнить счёт! \n3) Я хочу снять деньги со счета! \n4) Покажите историю операции, пожалуйста \n5) Выйти отсюда");
                byte user_wish = Convert.ToByte(Console.ReadLine());
                if (user_wish == 1)
                {
                    Console.WriteLine(repeatedChar);
                    Console.WriteLine("В какой валюте вам ее показать? (по умолчанию: Рубль (введите русскую Р). Для долларов: $)");
                    Console.WriteLine(repeatedChar);
                    string symbol = Convert.ToString(Console.ReadKey());
                    if (symbol == "$")
                    {
                        Console.WriteLine(repeatedChar);
                        PrintBalance('$');
                        Console.WriteLine(repeatedChar);
                    }
                    else
                    {
                        Console.WriteLine(repeatedChar);
                        PrintBalance();
                        Console.WriteLine(repeatedChar);
                    }
                }
                else if (user_wish == 2)
                {
                    Console.WriteLine(repeatedChar);
                    Invest();
                    Console.WriteLine(repeatedChar);
                }
                else if (user_wish == 3)
                {
                    Console.WriteLine(repeatedChar);
                    Withdraw();
                    Console.WriteLine(repeatedChar);
                }
                else if (user_wish == 4)
                {
                    Console.WriteLine(repeatedChar);
                    ShowList();
                    Console.WriteLine(repeatedChar);
                }
                else if (user_wish == 5)
                {
                    flag = false;
                    Console.WriteLine(repeatedChar);
                }
                else
                    Console.WriteLine("Введите допустимую команду");

            }
        }
    }
}