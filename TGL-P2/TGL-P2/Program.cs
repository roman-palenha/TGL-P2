﻿using System;
using System.Linq;
using TGL_P2.Collections;
using TGL_P2.Interfaces;
using TGL_P2.Models;

namespace TGL_P2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var teamA = new MonsterTeam(
                new Monster[] {
                    new Orc("Vasya", 50, 25, 12), 
                    new Worm("Petya", 50, 30, 12), 
                    new Dragon("Luci", 50, 60, 35) 
                });
            var teamB = new MonsterTeam(
                 new Monster[] {
                    new Orc("Ores", 50, 43, 12),
                    new Worm("Ivan", 50, 70, 12),
                    new Dragon("Lika", 50, 40, 35)
                });
            var arena = new BattleArena(teamA, teamB);
            arena.Fight();
        }
    }
}
