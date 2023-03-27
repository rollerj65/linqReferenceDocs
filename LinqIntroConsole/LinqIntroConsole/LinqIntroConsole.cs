

// See https://aka.ms/new-console-template for more information
using static JoinTables;

string[] words = { "hello", "wonderful", "LINQ", "beautiful", "world" };

//Get only short words
var shortWords = from word in words where word.Length <= 5 select word;

//Print each word out
foreach (var word in shortWords)
{
    Console.WriteLine(word);
}

Console.WriteLine("\nWHERE Query Expressions:");
string[] whereWords = { "humpty", "dumpty", "set", "on", "a", "wall" };

IEnumerable<string> query = from word in whereWords where word.Length == 3 select word;

foreach (string str in query)
{
    Console.WriteLine(str);
}

Console.WriteLine("\nJoin Query Expressions:");



List<JoinTables.DepartmentsClass> departments = new List<JoinTables.DepartmentsClass>();
departments.Add(new JoinTables.DepartmentsClass { DepartmentId = 1, Name = "Account" });
departments.Add(new JoinTables.DepartmentsClass { DepartmentId = 2, Name = "Sales" });
departments.Add(new JoinTables.DepartmentsClass { DepartmentId = 3, Name = "Marketing" });

List<JoinTables.EmployeeClass> employees = new List<JoinTables.EmployeeClass>();
employees.Add(new JoinTables.EmployeeClass { DepartmentId = 1, EmployeeId = 1, EmployeeName = "William" });
employees.Add(new JoinTables.EmployeeClass { DepartmentId = 2, EmployeeId = 2, EmployeeName = "Miley" });
employees.Add(new JoinTables.EmployeeClass { DepartmentId = 1, EmployeeId = 3, EmployeeName = "Benjamin" });

var list = (from e in employees join d in departments on e.DepartmentId equals d.DepartmentId select new
{
    EmployeeName = e.EmployeeName,
    DepartmentName = d.Name
});

foreach (var e in list)
{
    Console.WriteLine("Employee Name: {0}, Department Name: {1}, ", e.EmployeeName, e.DepartmentName);
}

Console.WriteLine("\nProjection Query Expressions:");
var projectionWords = new List<string>() { "an", "apple", "a", "day" };

query = from word in projectionWords select word.Substring(0, 1);

foreach (string s in query)
{
Console.WriteLine(s);
}

Console.WriteLine("\nSelect many using projection:");
List<string> phrases = new List<string>() { "an apple a day", "the quick brown fox" };

query = from phrase in phrases
        from word in phrase.Split(' ')
        select word;

foreach (string s in query)
{
    Console.WriteLine(s);
}

Console.WriteLine("\nsorting:");
int[] intNum = { -20, 12, 6, 10, 0, -3, 1 };

var sortedNums = from n in intNum
                 orderby n
                 select n;

Console.Write("Values in ascending order: ");

foreach (int i in sortedNums)
    Console.Write(i + "\n");

Console.Write("Values in descending order: ");
var sortedNumsDesc = from n in intNum
                     orderby n descending
                     select n;

foreach (int i in sortedNumsDesc)
    Console.Write(i + "\n");

Console.Write("Grouping: ");
List<int> listToGroup = new List<int>() { 35, 44, 200, 84, 3987, 4, 199, 329, 446, 208 };

IEnumerable<IGrouping<int, int>> groupedList = from number in listToGroup
                                         group number by number % 2;

foreach (var group in groupedList)
{
    Console.WriteLine(group.Key == 0 ? "\nEven numbers:" : "\nOdd numbers:");

    foreach (int i in group)
        Console.WriteLine(i);
}

Console.WriteLine("\nConversions:");

Plant[] plants = new Plant[] {new CarnivorousPlant { Name = "Venus Fly Trap", TrapType = "Snap Trap" },
                          new CarnivorousPlant { Name = "Pitcher Plant", TrapType = "Pitfall Trap" },
                          new CarnivorousPlant { Name = "Sundew", TrapType = "Flypaper Trap" },
                          new CarnivorousPlant { Name = "Waterwheel Plant", TrapType = "Snap Trap" }};

var plantQuery = from CarnivorousPlant cPlant in plants
            where cPlant.TrapType == "Snap Trap"
            select cPlant;

foreach (var e in plantQuery)
{
    Console.WriteLine("Name = {0} , Trap Type = {1}", e.Name, e.TrapType);
}

Console.WriteLine("\nConcatenations:");

Pet[] cats = GetCats();
Pet[] dogs = GetDogs();

IEnumerable<string> concatQuery = cats.Select(cat => cat.Name).Concat(dogs.Select(dog => dog.Name));

foreach (var e in concatQuery)
{
    Console.WriteLine("Name = {0} ", e);
}

Console.WriteLine("\nPress any key to continue.");

Console.ReadLine();

static Pet[] GetCats()
{
    Pet[] cats = { new Pet { Name = "Barley", Age = 8 },
                       new Pet { Name = "Boots", Age = 4 },
                       new Pet { Name = "Whiskers", Age = 1 } };
    return cats;
}

static Pet[] GetDogs()
{
    Pet[] dogs = { new Pet { Name = "Bounder", Age = 3 },
                       new Pet { Name = "Snoopy", Age = 14 },
                       new Pet { Name = "Fido", Age = 9 } };

    return dogs;
}

class JoinTables
{
public class DepartmentsClass
{
    public int DepartmentId { get; set; }
    public string Name { get; set; }

}
public class EmployeeClass
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public int DepartmentId { get; set; }
}

public class Plant
{
    public string Name { get; set; }
}
public class CarnivorousPlant : Plant
{
    public string TrapType { get; set; }
}

public class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
