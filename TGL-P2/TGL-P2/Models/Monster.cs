using System;
using System.Collections.Generic;
using System.Text;

namespace TGL_P2.Models
{
    /// <summary>
    /// Base class of Monster.
    /// </summary>
    public abstract class Monster
    {
        public delegate void MonsterEventHandler(object sender, MonsterEventArgs args);
        public event MonsterEventHandler MonsterAttacked;
        public string Name { get; }
        public int HP { get; private set;  }
        public int Damage { get; }
        public int Agility { get; }
        protected Monster(string name, int health, int damage, int agility)
        {
            Name = name;
            HP = health;
            Damage = damage;
            Agility = agility;
        }
        public void DealDamage(int hp)
        {
            if (HP - hp <= 0)
                HP = 0;
            else
                HP -= hp;
        }

        protected void OnHitted(object sender, MonsterEventArgs args)
        {
            Console.WriteLine($"{args.Main.GetType().Name} {args.Main.Name} hits {args.Enemy.GetType().Name} {args.Enemy.Name} and damaged {args.Main.Damage} points.");
        }

        protected void OnMissed(object sender, MonsterEventArgs args)
        {
            Console.WriteLine($"{args.Main.GetType().Name} {args.Main.Name} missed.");
        }

        protected void OnKilled(object sender, MonsterEventArgs args)
        {
            Console.WriteLine($"{args.Main.GetType().Name} {args.Main.Name} killed {args.Enemy.Name}.");
        }

        protected void OnAttacked(object sender, MonsterEventArgs args)
        {
            if(MonsterAttacked != null)
                MonsterAttacked(this, args);
        }

        abstract public void Attack(Monster enemy);
        abstract public void Move();
    }
}
