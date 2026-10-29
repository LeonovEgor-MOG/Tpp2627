using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Character> characters = new List<Character>();

            Player okkk = new Player("okkk", 100, 1);

            Character Burmalda = new Character("burmalda", 100, 1);
            Character okak = new Character("okak", 100, 2);
            Console.WriteLine(Burmalda.GetStatus());
            Burmalda.Attack(okak);
            Console.WriteLine(okak.GetStatus());
            Console.WriteLine(Burmalda.GetStatus());
            okkk.GetStatus();
            Console.WriteLine(okkk.IsAlive());

            characters.Add(okkk);

            Console.WriteLine(characters[0]);
            Console.WriteLine(Burmalda);
        }
    }

    class Character
    {
        private string? name;
        private int hp;
        private int power;
        private static int count;

        public string Name
        {
            get { return name; } set { }
        }
        public int Hp
        {
            get { return hp; } set { if (value > 0) hp = value; }
        }
        
        public Character(string n, int h, int p)
        {
            name = n;   Hp = h;   power = p;
        }

        public virtual void Attack(Character target)
        {
            target.TakeDamage(power);
            Console.WriteLine($"Атака на {target.Name}! {target.Name} получает урон, равный {power}");
            target.IsAlive();
        }

        public virtual string GetStatus()
        {
            return $"Персонаж {name} имеет {Hp} очков здоровья";
        }

        public override string ToString()
        {
            return $"{Name} (HP: {Hp})";
        }

        public static int HowMany()
        {
            return count;
        }

        public static void IsValidStats(int hp, int power)
        {
            if (hp >= 0 && power >= 0) Console.WriteLine("Характеристики допустимы."); 
            else                       Console.WriteLine("Характеристики НЕдопустимы."); 
        }

        public int TakeDamage(int damage)
        {
          if(Hp - damage >= 0)
            return Hp -= damage;
        else
            return Hp;
        }

        public virtual bool IsAlive()
        {
            if (Hp > 0) return true;
            else return false;
        }

        public bool Equals(Character obj)
        {
            if (obj.Name == Name) return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    class Player : Character
    {
        public Player(string n, int h, int p) : base(n, h, p) { }

        public override void Attack(Character target)
        {
            base.Attack(target);
            Console.WriteLine("Игрок атакует!");
            Console.WriteLine(target.GetStatus());
        }

        public override string GetStatus()
        {
            return base.GetStatus();
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
            base.Attack(target);
            Console.WriteLine("Враг атакует!");
            Console.WriteLine(target.GetStatus());
        }

        public override string GetStatus()
        {
            return base.GetStatus();
        }

        public override bool IsAlive()
        {
            return base.IsAlive();
        }


    }

}
