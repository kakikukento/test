using System.Globalization;
using System.IO;
using System.Data;
using System.Text;
using CsvHelper;

namespace WpfApp1.Models;

public class Csv2Datatable
{
    
    public static DataTable FromCsv(string path)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        
        using (var reader = new StreamReader(path, Encoding.GetEncoding("Shift_JIS")))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            // Do any configuration to `CsvReader` before creating CsvDataReader.
            using (var dr = new CsvDataReader(csv))
            {
                var dt = new DataTable();
                dt.Load(dr);
                return dt;
            }
        }
    }
}