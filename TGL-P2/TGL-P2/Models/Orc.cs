using System;
using System.Collections.Generic;
using System.Text;
using TGL_P2.Interfaces;

namespace TGL_P2.Models
{
    /// <summary>
    /// Model of Orc.
    /// Cannot attack models realizing IFlyable.
    /// </summary>
    public class Orc : Monster, IWalkable
    {
        public Orc(string name, int health, int damage, int agility)
            : base(name, health, damage, agility)
        { }

        public override void Attack(Monster enemy)
        {
            if (enemy is IFLyable || enemy.HP <= 0 || HP <= 0)
                return;

            var res = new Random().Next(enemy.Agility + enemy.Damage + 1) > (enemy.Agility + enemy.Damage) * 0.2;
            if (res)
            {
                enemy.DealDamage(Damage);
                MonsterAttacked += OnHitted;
                if (enemy.HP <= 0)
                {
                    MonsterAttacked += OnKilled;
                }
            }
            else
            {
                MonsterAttacked += OnMissed;
            }
            OnAttacked(this, new MonsterEventArgs { Main = this, Enemy = enemy });
        }

        public override void Move()
        {
            Walk();
        }

        public void Walk()
        {
            Console.WriteLine($"Orc {Name} walked to the battle!");
        }
    }
}
