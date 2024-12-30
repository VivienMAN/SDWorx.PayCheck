// Decompiled with JetBrains decompiler
// Type: CsvGenerator
// Assembly: PayCheck, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 10E32501-D930-4699-A67B-A473DA016A86
// Assembly location: PayCheck.dll inside D:\PayCheck.exe)

using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using PayCheck.Export;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

#nullable enable
public class CsvGenerator
{
    public string GenerateCsv(List<ExcelData> data)
    {
        Console.WriteLine("GenerateCsv");
        string fichiercsv = "FichierCsv_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
        CultureInfo cultureInfo = (CultureInfo)CultureInfo.GetCultureInfo("fr-FR").Clone();
        cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
        cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
        CsvConfiguration csvConfiguration = new CsvConfiguration(cultureInfo)
        {
            Delimiter = "\t"
        };
        Console.WriteLine("GenerateCsv2");
        using (StreamWriter streamWriter = new StreamWriter(fichiercsv, false, Encoding.UTF8))
        {
            using (CsvWriter csvWriter =
                   new CsvWriter((TextWriter)streamWriter, (IWriterConfiguration)csvConfiguration, false))
            {
                csvWriter.Context.TypeConverterOptionsCache.AddOptions<DateTime>(new TypeConverterOptions()
                {
                    Formats = new string[1] { "yyyyMMdd" }
                });
                TypeConverterOptions options = new TypeConverterOptions()
                {
                    Formats = new string[1] { "0.00" }
                };
                csvWriter.Context.TypeConverterOptionsCache.AddOptions<double>(options);
                Console.WriteLine("GenerateCsv3");
                csvWriter.WriteRecords<ExcelData>((IEnumerable<ExcelData>)data);
                Console.WriteLine("GenerateCsv4");
            }
        }

        return Path.GetFullPath(fichiercsv);
    }
}