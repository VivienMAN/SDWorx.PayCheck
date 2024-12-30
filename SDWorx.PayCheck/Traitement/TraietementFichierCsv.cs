using CsvHelper;
using CsvHelper.Configuration;
using PayCheck.Import;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

#nullable enable
namespace PayCheck
{
    public class TraietementFichierCsv
    {
        public List<EmployeId> ProcessCsvFile(MemoryStream memoryStream)
        {
            memoryStream.Position = 0;
            var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };
            // Création du StreamReader à partir du MemoryStream
            using var streamReader = new StreamReader(memoryStream);
            using var csvReader = new CsvReader(streamReader, csvConfiguration);

            // Extraction des enregistrements
            var employeIds = csvReader.GetRecords<EmployeId>().ToList();
            return employeIds;
        }
    }
}