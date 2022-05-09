using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal enum RPS
    {
        Rock,
        Paper,
        Scissors
    }
    class RPSGame
    {
        public RPS PlayerOne { get; set; }
        public RPS PlayerTwo { get; set; }
    }

    record RPSGameRecord (RPS PlayerOne, RPS PlayerTwo);
}
