using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class02.Demo.Entities
{
    public static class Test
    {
        public static int Id { get; set; }
        public static string Name { get; set; }

        static Test()
        {
            Id = 1;
            Name = "Test 1";
        }
        public static string TestProblem()
        {
            return "Testiram";
        }
    }
}
