using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Character Burmalda = new Character("burmalda", 100, 1);
            Character okak = new Character("okak", 100, 2);

            Console.WriteLine(okak);
            Burmalda.Attack(okak);
            Burmalda.Attack(okak);
            Burmalda.Attack(okak);

            Console.WriteLine(Burmalda);
            Console.WriteLine(Burmalda.Equals("burmalda"));
        }
    }

    class Character
    {
        List<Character> characters = new List<Character>();
        private string? name;
        private int hp;
        private int power;
        private static int count;

        public string Name
        {
            get { return name; }
            set { }
        }
        public int Hp
        {
            get { return hp; }
            set { if (value > 0) hp = value; }
        }

        public Character(string n, int h, int pow)
        {
            name = n;
            if (h > 0 && pow > 0)
            {
                Hp = h;
                power = pow;
                characters.Add(this);
            }
        }

        public override string ToString()
        {
            return $"{Name} (HP: {Hp})";
        }

        public override bool Equals(object? obj)
        {
            if (obj.GetHashCode() == Name.GetHashCode()) return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual void Attack(Character target)
        {
            if (target.IsAlive())
            {
                target.TakeDamage(power);
                Console.WriteLine($"{Name} атакует {target.Name} на {power} урона!");
                Console.WriteLine(target);
                if (!target.IsAlive()) Console.WriteLine($"{target.Name} побежден персонажем {Name}!");
            }
            else Console.WriteLine($"{target.Name} уже мертв...");

        }



        public static int HowMany()
        {
            return count;
        }

        public static void IsValidStats(int hp, int power)
        {
            if (hp >= 0 && power >= 0) Console.WriteLine("Характеристики допустимы.");
            else Console.WriteLine("Характеристики НЕдопустимы.");
        }

        public void TakeDamage(int damage)
        {
            hp -= damage;
        }

        public virtual bool IsAlive()
        {
            if (Hp > 0) return true;
            else return false;
        }
    }
    class Player : Character
    {
        public Player(string n, int h, int p) : base(n, h, p) { }

        public override void Attack(Character target)
        {
            Console.WriteLine("ПЕРСОНАЖ АТАКУЕТ:");
            base.Attack(target);
        }
        public override bool IsAlive()
        {
            return base.IsAlive();
        }


    }

    class Enemy : Character
    {
        public Enemy(string n, int h, int p) : base(n, h, p) { }


        public override void Attack(Character target)
        {
            Console.WriteLine("ПРОТИВНИК АТАКУЕТ:");
            base.Attack(target);
        }

        public override bool IsAlive()
        {
            return base.IsAlive();
        }


    }


}