using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_2
{
    class FootballTeam
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public static List<FootballTeam> teams = FootballTeamDataInitialization();

        public static List<FootballTeam> FootballTeamDataInitialization()
        {
            List<FootballTeam> teams = new List<FootballTeam>
            {
               new FootballTeam {Name="Dynamo", ID=1},
               new FootballTeam {Name="Shakhtar", ID=2},
               new FootballTeam {Name="Dnipro", ID=3}
            };
            return teams;
        }
    }
}
