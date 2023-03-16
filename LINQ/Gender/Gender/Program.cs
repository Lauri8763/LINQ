namespace LINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("LINQ");

            WhereLINQ();

            PeopleByAge();

            ThenByLINQ();

            ThenByDescendingLINQ();

            ToLookupLINQ();

            JoinLINQ();

            GroupJoinLINQ();

            SelectLINQ();

            AllAndAnyLINQ();

            ContainsLINQ();

            AggregateLINQ();

            AvarageLINQ();

            CountLINQ();

            MaxLINQ();

            SumLINQ();

            ElementAtLINQ();

            ElementAtOrDefaultLINQ();

            FirstLINQ();

            FirstOrDefaultLINQ();

            LastLINQ();

            LastOrDefaultLINQ();

            SequenceEqualLINQ();

            ConcatLINQ();

            DefaultIfEmptyLINQ();

            EmptyLINQ();

            RangeLINQ();

            RepeatLINQ();

            DistinctLINQ();

            ExceptLINQ();

            IntersectLINQ();
        }


        public static void WhereLINQ()
        {
            var filteredResult = PeopleList.people.Where((s, i) =>
            {
                if (i % 2 == 0)
                {
                    return true;
                }
                return false;
            });

            foreach (var people in filteredResult)
            {
                Console.WriteLine(people.Name);
            }
        }

        public static void PeopleByAge()
        {
            Console.WriteLine("Vanuse järgi selekteerimine");

            var peopleByAge = PeopleList.people
                .Where(s => s.Age > 14 && s.Age < 20);

            foreach (var people in peopleByAge)
            {
                Console.WriteLine(people.Age + " " + people.Name);
            }
        }

        public static void ThenByLINQ()
        {
            Console.WriteLine("ThenBy ja ThenByDescending järgi reastamine");

            var thenByResult = PeopleList.people
                .OrderBy(x => x.Name)
                .ThenBy(y => y.Age);

            Console.WriteLine("ThenBy järgi");
            foreach (var people in thenByResult)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }
        }

        public static void ThenByDescendingLINQ()
        {
            Console.WriteLine("ThenByDescending järgi reastamine");

            var thenByDescending = PeopleList.people
                .OrderBy(x => x.Name)
                .ThenByDescending(y => y.Age);

            foreach (var people in thenByDescending)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }
        }

        public static void ToLookupLINQ()
        {
            Console.WriteLine("ToLookup järgi reastamine");

            var toLookup = PeopleList.people
                .ToLookup(x => x.Age);

            foreach (var people in toLookup)
            {
                Console.WriteLine("Age group " + people.Key);

                foreach (People p in people)
                {
                    Console.WriteLine("Person name {0}", p.Name);
                }
            }
        }

        public static void JoinLINQ()
        {
            Console.WriteLine("InnerJoin in LINQ");

            var innerJoin = PeopleList.people.Join(
                GenderList.genderList,
                humans => humans.GenderId,
                gender => gender.Id,
                (humans, gender) => new
                {
                    Name = humans.Name,
                    Sex = gender.Sex
                });

            foreach (var obj in innerJoin)
            {
                Console.WriteLine("{0} - {1}", obj.Name, obj.Sex);
            }
        }

        public static void GroupJoinLINQ()
        {
            Console.WriteLine("Group Join LINQ");

            var groupJoin = GenderList.genderList
                .GroupJoin(PeopleList.people,
                p => p.Id,
                g => g.GenderId,
                (p, peopleGroup) => new
                {
                    Humans = peopleGroup,
                    GenderFullName = p.Sex
                });

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.GenderFullName);

                foreach (var name in item.Humans)
                {
                    Console.WriteLine(name.Name);
                }
            }
        }

        public static void SelectLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Select in LINQ");

            var selectResult = PeopleList.people
                .Select(x => new
                {
                    Name = x.Name,
                    Age = x.Age
                });

            foreach (var item in selectResult)
            {
                Console.WriteLine("Human name: {0}, Age: {1}", item.Name, item.Age);
            }
        }

        public static void AllAndAnyLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("All LINQ");

            bool areAllPeopleTeenagers = PeopleList.people
                .All(x => x.Age > 12);
            //vastus tuleb true
            Console.WriteLine(areAllPeopleTeenagers);

            Console.WriteLine("Any LINQ");
            bool isAnyPersonTeenAger = PeopleList.people
                .Any(x => x.Age < 12);
            //kasv]i [ks andmerida vastab tingimusele
            Console.WriteLine(isAnyPersonTeenAger);
        }

        public static void ContainsLINQ()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Contains LINQ");

            //pärib, kas on number 10 numbrite nimekirjas olemas
            bool result = NumberList.numberList.Contains(10);

            Console.WriteLine(result);
        }

        public static void AggregateLINQ()
        {
            string commaSeparatedPersonNames = PeopleList.people
                .Aggregate<People, string>(
                "People names: ",
                (str, y) => str += y.Name + ", "
                );

            Console.WriteLine(commaSeparatedPersonNames);
        }

        public static void AvarageLINQ()
        {
            Console.WriteLine("Avarage LINQ");

            var avarageResult = PeopleList.people
                .Average(x => x.Age);

            Console.WriteLine(avarageResult);
        }

        public static void CountLINQ()
        {
            var totalPersons = PeopleList.people.Count();

            Console.WriteLine("Inimesi on kokku: " + totalPersons);

            var adultPersons = PeopleList.people.Count(x => x.Age >= 18);

            Console.WriteLine("Täisealisi inimesi on : " + adultPersons);
        }

        public static void MaxLINQ()
        {
            Console.WriteLine("Max LINQ");

            var oldestPerson = PeopleList.people
                .Max(x => x.Age);

            Console.WriteLine("Oldest person age is " + oldestPerson);
        }

        public static void SumLINQ()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("Sum LINQ");

            var sumAge = PeopleList.people.Sum(x => x.Age);

            Console.WriteLine(sumAge);

            Console.WriteLine("Täisealiste isikute koondvanus");

            var sumAdult = 0;

            var numAdults = PeopleList.people.Sum(x =>
            {
                if (x.Age >= 18)
                {
                    //tahan teada t'iskasvanud t;;tajate koondvanust
                    sumAdult = PeopleList.people.Sum(x => x.Age);

                    return 1;
                }
                else
                {
                    return 0;
                }
            });

            Console.WriteLine("Täiskasvanud isikute arv " + numAdults);
            Console.WriteLine("Täiskasvanute koondvanuse tulemus " + sumAdult);
        }
        public static void ElementAtLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("ElementAtLINQ");
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { "One", "Two", null, "Four", "Five" };

            Console.WriteLine("1st Element in intList: {0}", intList.ElementAt(0));
            Console.WriteLine("1st Element in strList: {0}", strList.ElementAt(0));

            Console.WriteLine("2nd Element in intList: {0}", intList.ElementAt(1));
            Console.WriteLine("2nd Element in strList: {0}", strList.ElementAt(1));

            Console.WriteLine("3rd Element in intList: {0}", intList.ElementAtOrDefault(2));
            Console.WriteLine("3rd Element in strList: {0}", strList.ElementAtOrDefault(2));
        }
        public static void ElementAtOrDefaultLINQ()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("ElementAtOrDefaultLINQ");
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { "One", "Two", null, "Four", "Five" };
            Console.WriteLine("10th Element in intList: {0} - default int value",
                intList.ElementAtOrDefault(9));
            Console.WriteLine("10th Element in strList: {0} - default string value (null)",
                             strList.ElementAtOrDefault(9));


            Console.WriteLine("intList.ElementAt(9) throws an exception: Index out of range");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine(intList.ElementAt(9));
        }
        public static void FirstLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("FirstLINQ");
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine("1st Element in intList: {0}", intList.First());
            Console.WriteLine("1st Even Element in intList: {0}", intList.First(i => i % 2 == 0));

            Console.WriteLine("1st Element in strList: {0}", strList.First());

            Console.WriteLine("emptyList.First() throws an InvalidOperationException");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine(emptyList.First());
        }
        public static void FirstOrDefaultLINQ()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("FirstOrDefaultLINQ");
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine("1st Element in intList: {0}", intList.FirstOrDefault());
            Console.WriteLine("1st Even Element in intList: {0}",
                                             intList.FirstOrDefault(i => i % 2 == 0));

            Console.WriteLine("1st Element in strList: {0}", strList.FirstOrDefault());

            Console.WriteLine("1st Element in emptyList: {0}", emptyList.FirstOrDefault());
        }
        public static void LastLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("LastLINQ");
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine("Last Element in intList: {0}", intList.Last());

            Console.WriteLine("Last Even Element in intList: {0}", intList.Last(i => i % 2 == 0));

            Console.WriteLine("Last Element in strList: {0}", strList.Last());

            Console.WriteLine("emptyList.Last() throws an InvalidOperationException");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine(emptyList.Last());
        }
        public static void LastOrDefaultLINQ()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("LastOrDefaultLINQ");
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine("Last Element in intList: {0}", intList.LastOrDefault());

            Console.WriteLine("Last Even Element in intList: {0}",
                                             intList.LastOrDefault(i => i % 2 == 0));

            Console.WriteLine("Last Element in strList: {0}", strList.LastOrDefault());

            Console.WriteLine("Last Element in emptyList: {0}", emptyList.LastOrDefault());
        }
        public static void SequenceEqualLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("SequenceEqualLINQ");
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Three" };

            IList<string> strList2 = new List<string>() { "One", "Two", "Three", "Four", "Three" };

            bool isEqual = strList1.SequenceEqual(strList2); // returns true
            Console.WriteLine(isEqual);
        }
        public static void ConcatLINQ()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("ConcatLINQ");
            IList<string> collection1 = new List<string>() { "One", "Two", "Three" };
            IList<string> collection2 = new List<string>() { "Five", "Six" };

            var collection3 = collection1.Concat(collection2);

            foreach (string str in collection3)
                Console.WriteLine(str);
        }
        public static void DefaultIfEmptyLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("DefaultIfEmptyLINQ");
            IList<string> emptyList = new List<string>();

            var newList1 = emptyList.DefaultIfEmpty();
            var newList2 = emptyList.DefaultIfEmpty("None");

            Console.WriteLine("Count: {0}", newList1.Count());
            Console.WriteLine("Value: {0}", newList1.ElementAt(0));

            Console.WriteLine("Count: {0}", newList2.Count());
            Console.WriteLine("Value: {0}", newList2.ElementAt(0));
        }
        public static void EmptyLINQ()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("EmptyLINQ");
            var emptyCollection1 = Enumerable.Empty<string>();
            var emptyCollection2 = Enumerable.Empty<string>();

            Console.WriteLine("Count: {0} ", emptyCollection1.Count());
            Console.WriteLine("Type: {0} ", emptyCollection1.GetType().Name);

            Console.WriteLine("Count: {0} ", emptyCollection2.Count());
            Console.WriteLine("Type: {0} ", emptyCollection2.GetType().Name);
        }
        public static void RangeLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("RangeLINQ");
            var intCollection = Enumerable.Range(10, 10);
            Console.WriteLine("Total Count: {0} ", intCollection.Count());

            for (int i = 0; i < intCollection.Count(); i++)
                Console.WriteLine("Value at index {0} : {1}", i, intCollection.ElementAt(i));

        }
        public static void RepeatLINQ()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("RepeatLINQ");
            var intCollection = Enumerable.Repeat<int>(10, 10);
            Console.WriteLine("Total Count: {0} ", intCollection.Count());

            for (int i = 0; i < intCollection.Count(); i++)
                Console.WriteLine("Value at index {0} : {1}", i, intCollection.ElementAt(i));
        }
        public static void DistinctLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("DistinctLINQ");
            IList<string> strList = new List<string>() { "One", "Two", "Three", "Two", "Three" };

            IList<int> intList = new List<int>() { 1, 2, 3, 2, 4, 4, 3, 5 };

            var distinctList1 = strList.Distinct();

            foreach (var str in distinctList1)
                Console.WriteLine(str);

            var distinctList2 = intList.Distinct();

            foreach (var i in distinctList2)
                Console.WriteLine(i);
        }
        public static void ExceptLINQ()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("ExceptLINQ");
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

            var result = strList1.Except(strList2);

            foreach (string str in result)
                Console.WriteLine(str);
        }
        public static void IntersectLINQ()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("IntersectLINQ");
            IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };

            var result = strList1.Intersect(strList2);

            foreach (string str in result)
                Console.WriteLine(str);
        }

    }
}