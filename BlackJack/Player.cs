using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Player
    {
        public string name { get; set; }
        public int age { get; set; }
        public int bet { get; set; }
        public int score { get; set; }
        public Player (string n, int a, int b)
        {
            name = n;
            age = a;
            bet = b;
        }
    }
}
