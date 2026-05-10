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
                var lineToRemove = Console.ReadLine();
                list.Remove(lineToRemove!);
                logger.WriteLog("Info", $"Line to remove: {lineToRemove}");
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