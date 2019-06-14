using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork_2
{
    class Person
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public int Age { get; set; }
        public int FootballTeamID { get; set; }

        private static List<Person> persons;

        public static void InitPerson()
        {
            persons = new List<Person>
            {
               new Person {FirstName="Ihor", LastName="Kozachenko", ID=1111, Age = 18, FootballTeamID = 1},
               new Person {FirstName="Petro", LastName="Petrenko", ID=1112, Age = 19, FootballTeamID = 2},
               new Person {FirstName="Gerasym", LastName="Gerasymenko", ID=1113, Age = 30, FootballTeamID = 1},
               new Person {FirstName="Vasyl", LastName="Ivanenko", ID=1114, Age = 25, FootballTeamID = 2},
               new Person {FirstName="Zakhar", LastName="Sergienko", ID=1115, Age = 20, FootballTeamID = 1}
            };
        }

        public static void SortedPersons()
        {
            //IEnumerable<Person> sortedPersons = from person in persons
            //                                    where person.Age >= 10 && person.Age < 30
            //                                    orderby person.LastName ascending, person.FirstName ascending
            //                                    select person;

            //var sortedPersons = persons.Where(person => person.Age >= 20 && person.Age < 30).
            //                                    OrderBy(person => person.LastName).
            //                                    OrderByDescending(person => person.FirstName).
            //                                    Select(person => person);

            //Console.WriteLine("sortedPersons: ");

            //foreach (var person in sortedPersons)
            //{
            //    Console.WriteLine(person.LastName + " " + person.FirstName);
            //}

            IEnumerable<Person> sortedPersons =
                from person in persons
                orderby person.LastName ascending
                select person;

            sortedPersons.Where(person => person.Age >= 20 && person.Age < 30);

            Console.WriteLine("sortedPersons - deffered execution:");

            // deffered execution
            foreach (Person person in sortedPersons)
                Console.WriteLine(person.LastName + " " + person.FirstName);

            Console.WriteLine();
            Console.WriteLine("sortedPersons - immediate execution:");
            // immediate execution
            List<Person> persons2 = sortedPersons.OrderByDescending(person => person.FirstName).ToList<Person>();
            foreach (Person person in persons2)
                Console.WriteLine(person.LastName + " " + person.FirstName);

            Console.WriteLine();
        }

        public static void SortedGroups()
        {
            var SortedGroups = from person in persons
                                orderby person.LastName, person.FirstName
                                group person by person.LastName[0] into newGroup
                                orderby newGroup.Key
                                select newGroup;

            Console.WriteLine(Environment.NewLine + "SortedGroups: ");

            foreach (var item in SortedGroups)
            {
                Console.WriteLine(item.Key);
                foreach (var person in item)
                {
                    Console.WriteLine($"{person.LastName}, {person.FirstName}");
                }
            }
        }

        public static void JoinQuery()
        {

            var innerJoinQuery = from team in FootballTeam.teams
                                 join p in persons on team.ID equals p.FootballTeamID
                                 select new
                                 {
                                     FirstName = p.FirstName,
                                     LastName = p.LastName,
                                     TeamID = team.ID
                                 };

            Console.WriteLine(Environment.NewLine + "Simple GroupingJoin: ");

            foreach (var item in innerJoinQuery)
            {
                    Console.WriteLine("{0, -20}{1, -20}{2}", item.LastName, item.FirstName, item.TeamID);
            }

            Console.WriteLine("innerJoin: {0} items in group", innerJoinQuery.Count());
        }

        public static void GroupJoinQuery()
        {

            var groupJoinQuery = from team in FootballTeam.teams
                                 join p in persons on team.ID equals p.FootballTeamID into pGroup
                                 select pGroup;

            int totalItems = 0;

            Console.WriteLine(Environment.NewLine + "Simple GroupJoin: ");

            foreach (var pGrouping in groupJoinQuery)
            {
                Console.WriteLine("Group: ");
                foreach (var item in pGrouping)
                {
                    totalItems++;
                    Console.WriteLine("{0, -20}{1, -20}{2}", item.LastName, item.FirstName, item.FootballTeamID);
                }
            }
            Console.WriteLine("GroupJoin: {0} items in {1} unnamed group", totalItems, groupJoinQuery.Count());
        }

        public static void LeftOuterQuery()
        {
            var leftOuterQuery =
                from team in FootballTeam.teams
                join p in persons on team.ID equals p.FootballTeamID into pGroup
                select pGroup.DefaultIfEmpty(new Person() { FirstName = "NoName", LastName = "NoLastName", FootballTeamID = team.ID });

            int totalItems = 0;

            Console.WriteLine(Environment.NewLine + "LeftOuterJoin:");

            foreach (var pGrouping in leftOuterQuery)
            {
                Console.WriteLine("Group:");
                foreach (var item in pGrouping)
                {
                    totalItems++;
                    Console.WriteLine("   {0,-20}{1,-20}{2}", item.LastName, item.FirstName, item.FootballTeamID);
                }
            }
            Console.WriteLine("GroupJoin: {0} items in {1} unnamed groups", totalItems, leftOuterQuery.Count());
            Console.WriteLine();
        }
    }
}
