using Core;
var textFile = new SimpleTextFile("c:\\tmp\\animals.txt");
using var logger = new LogWriter("C:\\tmp\\app.log");
try
{
    logger.WriteLog("Info", "Application started");
    var lines = textFile.ReadLines();
    var list = lines.ToList();
    var option = string.Empty;

    do
    {
        option = Menu();
        switch (option)
        {
            case "1":
                foreach (var item in list)
                { Console.WriteLine(item); }
                logger.WriteLog("Info", "File listed");
                break;
            case "2":
                Console.Write("Enter a new line: ");
                var newLine = Console.ReadLine();
                list.Add(newLine!);
                logger.WriteLog("Info", $"New line added: {newLine}");
                break;
            case "3":
                Console.Write("Enter line to remove: ");
                var ocurrence = Console.ReadLine();
                list.Remove(ocurrence!);
                logger.WriteLog("Info", $"Line to remove: {ocurrence}");
                break;
            case "4":
                Console.Write("Enter lines to remove: ");
                var ocurrences = Console.ReadLine();
                list.RemoveAll(x => x == ocurrences);
                break;
            case "5":
                list.Sort();
                break;
            case "6":
                textFile.WriteLines(list.ToArray());
                Console.WriteLine("Save changes.");
                logger.WriteLog("Info", "Lines save");
                break;
            case "0":
                Console.WriteLine("Exiting...");
                break;
            default:
                break;
        }

    }
    while (option != "0");
    textFile.WriteLines(list.ToArray());
    Console.WriteLine("Save changes.");



}
catch (Exception ex)
{
    logger.WriteLog("Error", $"An error happend: {ex.Message}");
}
finally
{
    logger.WriteLog("info", "Application ended");
}

string Menu()
{
    Console.WriteLine("1. Show lines");
    Console.WriteLine("2. Add line");
    Console.WriteLine("3. Remove one ocurrence");
    Console.WriteLine("4. Remove all ocurrences");
    Console.WriteLine("5. Sort");
    Console.WriteLine("6. Save changes");
    Console.WriteLine("0. Exit");
    Console.WriteLine("Choose an option.");
    return Console.ReadLine() ?? string.Empty;
}
//===========================================================================================================
// Example 2
//===========================================================================================================


//var people = new List<string[]>
//{
//    new [] {"Id", "Name", "Age"},
//    new [] {"1", "Juan", "28"},
//    new [] {"2", "Maria", "18"},
//    new [] {"3", "camilo", "31"},

//};

//var manualCsvHelper = new ManualCsvHelper();
//manualCsvHelper.WriteCsv("c:\\tmp\\people.csv", people);

//var loadedPeople = manualCsvHelper.ReadCsv("c:\\tmp\\people.csv");

//foreach (var person in loadedPeople)
//{
//    Console.WriteLine(string.Join("|", person));
//}
//===========================================================================================================
// Example 3
//===========================================================================================================


//using Core;

//var list = new List<Person>
//{
//    new Person { Id = 1, Name = "Juan", Age = 28 },
//    new Person { Id = 2, Name = "Maria", Age = 18 },
//    new Person { Id = 3, Name = "Camilo", Age = 31 },
//    new Person { Id = 4, Name = "Ana", Age = 25 },
//    new Person { Id = 5, Name = "Luis", Age = 22 },
//    new Person { Id = 6, Name = "Sofia", Age = 30 }
//};

//var helper = new CsvHelperExample();
//helper.Write("c:\\tmp\\people2.csv", list);
//foreach (var P in helper.Read("c:\\tmp\\people2.csv"))
//{
//    Console.WriteLine($"{P.Id} | {P.Name} | ({P.Age}) years old");
//}