using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TGL_P2.Models;

namespace TGL_P2.Collections
{
    public class MonsterTeam : IEnumerable<Monster>
    {
        private readonly Monster[] _monsters;

        public MonsterTeam(Monster[] monsters)
        {
            _monsters = monsters;
        }

        public bool IsAllDead()
        {
          return _monsters.All(m => m.HP.Equals(0));
        }
        public IEnumerator<Monster> GetEnumerator()
        {
            foreach(var m in _monsters)
                yield return m;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
