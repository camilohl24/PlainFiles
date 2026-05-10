namespace Core;

public class ManualCsvHelper
{
    public void WriteCsv(string path, List<string[]> records)
    {
        using var sw = new StreamWriter(path);
        foreach (var fiel in records)
        {
            var line = string.Join(",", fiel);
            sw.WriteLine(line);

        }
    }

    public List<string[]> ReadCsv(string path)
    {
        var result = new List<string[]>();
        using var sr = new StreamReader(path);
        string? line;
        while ((line = sr.ReadLine()) != null)
        {
            var fields = line.Split(',');
            result.Add(fields);
        }
        return result;

    }
}
