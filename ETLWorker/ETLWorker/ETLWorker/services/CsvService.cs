using CsvHelper;
using System.Globalization;

public class CsvService
{
    public List<string> LeerCsv(string ruta)
    {
        using var reader = new StreamReader(ruta);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<Opinion>().ToList();

        return records.Select(r => r.comentario).ToList();
    }
}