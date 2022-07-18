using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TGL_P2.Collections;
using TGL_P2.Interfaces;

namespace TGL_P2.Models
{
    public class BattleArena
    {
        public MonsterTeam TeamA { get; set; }
        public MonsterTeam TeamB { get; set; }
        public BattleArena(MonsterTeam teamA, MonsterTeam teamB)
        {
            TeamA = teamA;
            TeamB = teamB;
        }
        public void Fight()
        {
            Console.WriteLine("| INTRODUCE TEAM A |");
            foreach (var m in TeamA)
                m.Move();
            Console.WriteLine("| INTRODUCE TEAM B |");
            foreach (var m in TeamB)
                m.Move();
            Console.WriteLine("| BATTLE |");
            var isDraw = false;
            while (!(TeamA.IsAllDead() || TeamB.IsAllDead()))
            {
                if(TeamA.Where(x => x.HP > 0).All(x => x is IFLyable) && TeamB.Where(x => x.HP > 0).All(x => x is ICrawlable) ||
                    TeamB.Where(x => x.HP > 0).All(x => x is IFLyable) && TeamA.Where(x => x.HP > 0).All(x => x is ICrawlable))
                {
                    isDraw = true;
                    break;
                }
                    
                foreach (var m in TeamA)
                {
                    foreach (var e in TeamB)
                    {
                        m.Attack(e);
                        e.Attack(m);
                    }
                }
                foreach (var m in TeamB)
                {
                    foreach (var e in TeamA)
                    {
                        m.Attack(e);
                        e.Attack(m);
                    }
                }
            }
            Console.WriteLine("| BATTLE RESULT |");
            if (TeamA.IsAllDead() && TeamB.IsAllDead() || isDraw)
                Console.WriteLine("There is no winner");
            else if (TeamA.IsAllDead() && !TeamB.IsAllDead())
                Console.WriteLine("TeamB is winner");
            else
                Console.WriteLine("TeamA is winner");
        }
    }
}
