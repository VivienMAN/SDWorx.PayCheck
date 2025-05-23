// Decompiled with JetBrains decompiler
// Type: PayCheck.TraietementExcel
// Assembly: PayCheck, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 10E32501-D930-4699-A67B-A473DA016A86
// Assembly location: PayCheck.dll inside D:\PayCheck.exe)

using OfficeOpenXml;
using PayCheck.Import;
using System;
using System.Collections.Generic;
using System.IO;

#nullable enable
namespace PayCheck
{
    public class TraietementExcel
    {
        public TraietementExcel()
        {
            List<Tuple<string, string>> tupleList = new List<Tuple<string, string>>();
            tupleList.Add(new Tuple<string, string>("Salaire de base", "FORFAIT 218 JOURS"));
            tupleList.Add(new Tuple<string, string>("Allocations familiales (complément)",
                "COMPLEMENT ALLOCATIONS FAMILIALES"));
            tupleList.Add(new Tuple<string, string>("Bonus Annuel", "BONUS ANNUEL"));
            tupleList.Add(new Tuple<string, string>("Salaire Brut", "BRUT"));
            tupleList.Add(new Tuple<string, string>("Prime d'ancienneté ", "ANCIENNETE"));
            tupleList.Add(new Tuple<string, string>("Ancienneté ", "ANCIENNETE"));
            tupleList.Add(new Tuple<string, string>("Ancienneté", "ANCIENNETE"));
            tupleList.Add(new Tuple<string, string>("Maladie - maternité - invalidité - décès",
                "MALADIE REGIME GENERAL"));
            tupleList.Add(new Tuple<string, string>("Contribution Solidarité Autonomie", "CONTRIBUTION SOLIDARITE"));
            tupleList.Add(new Tuple<string, string>("Vieillesse déplafonnée", "VIEILLESSE SALARIALE 1"));
            tupleList.Add(new Tuple<string, string>("Vieillesse déplafonnée", "VIEILLESSE 2"));
            tupleList.Add(new Tuple<string, string>("Vieillesse plafonnée", "ASSURANCE VIEILLESSE"));
            tupleList.Add(new Tuple<string, string>("Allocations familiales", "ALLOCATIONS FAMILIALES"));
            tupleList.Add(new Tuple<string, string>("Accident du travail", "ACCIDENT TRAVAIL"));
            tupleList.Add(new Tuple<string, string>("FNAL plafonné", "FONDS D'AIDE AU LOGEMENT"));
            tupleList.Add(new Tuple<string, string>("CSG déductible", "CSG DEDUITE"));
            tupleList.Add(new Tuple<string, string>("CSG non déductible et CRDS", "CSG NON DEDUCTIBLE ."));
            tupleList.Add(new Tuple<string, string>("Allocations familiales (complément)",
                "COMPLEMENT ALLOCATIONS FAMILIALES"));
            tupleList.Add(new Tuple<string, string>("Maladie (complément)", "COMPLEMENT MALADIE"));
            tupleList.Add(new Tuple<string, string>("Contribution au dialogue social",
                "CONTRIBUTION ORGANISATIONS SYNDICALES"));
            tupleList.Add(new Tuple<string, string>("Assurance chômage TrA+TrB", "CONTRIBUTION CHOMAGE TRA"));
            tupleList.Add(new Tuple<string, string>("AGS", "COTISATION AGS"));
            tupleList.Add(new Tuple<string, string>("APEC TrA", "APEC RUAA"));
            tupleList.Add(new Tuple<string, string>("APEC TrB", "APEC RUAA"));
            tupleList.Add(new Tuple<string, string>("Retraite TU1", "RETRAITE CADRE TRA"));
            tupleList.Add(new Tuple<string, string>("Retraite TU2", "RETRAITE CADRE TRB"));
            tupleList.Add(new Tuple<string, string>("Contribution d'Equilibre Général TU1", "CEG T1"));
            tupleList.Add(new Tuple<string, string>("Contribution d'Equilibre Général TU2", "CEG T2"));
            tupleList.Add(new Tuple<string, string>("Contribution d'Equilibre Technique TU1", "CET T1"));
            tupleList.Add(new Tuple<string, string>("Contribution d'Equilibre Technique TU2", "CET T2"));
            tupleList.Add(new Tuple<string, string>("Prévoyance supplémentaire TrA", "PREVOYANCE CADRE TRA"));
            tupleList.Add(new Tuple<string, string>("Prévoyance supplémentaire TrB", "PREVOYANCE CADRE TRB"));
            tupleList.Add(new Tuple<string, string>("Prévoyance supplémentaire TrC", "PREVOYANCE CAD TC"));
            tupleList.Add(new Tuple<string, string>("Mutuelle", "MUTUELLE"));
            tupleList.Add(new Tuple<string, string>("Surcomplémentaire", "OPTION MUTUELLE"));
            tupleList.Add(new Tuple<string, string>("Contribution formation prof. (légal)",
                "FORMATION PROFESSIONNELLE MOINS DE 11S"));
            tupleList.Add(new Tuple<string, string>("Taxe d'apprentissage ", "TAXE APPRENTISSAGE 1"));
            tupleList.Add(new Tuple<string, string>("Taxe d'apprentissage (Libératoire)", "TAXE APPRENTISSAGE 1"));
            tupleList.Add(new Tuple<string, string>("Total des retenues", "Total Employee Contributions"));
            tupleList.Add(new Tuple<string, string>("Net imposable", "Net imposable"));
            tupleList.Add(new Tuple<string, string>("ESPP 23", "ESPP23"));
            tupleList.Add(new Tuple<string, string>("ESPP 24", "ESPP24"));
            tupleList.Add(new Tuple<string, string>("ESPP 25", "ESPP25"));
            tupleList.Add(new Tuple<string, string>("Indemnité de repas", "TICKET RESTAURANT"));
            tupleList.Add(new Tuple<string, string>("Impôt sur le revenu prélevé à la source - PAS",
                "IMPOT SUR LE REVENU"));
            tupleList.Add(new Tuple<string, string>("Net à payer", "NET A PAYER"));
            tupleList.Add(new Tuple<string, string>("Versement mobilités", "VIEILLESSE COMPLEMENTAIRE"));
            tupleList.Add(new Tuple<string, string>("Contribution formation prof. (légal)", "FORMATION PROF APPRENTI"));
            tupleList.Add(new Tuple<string, string>("Prime d'ancienneté", "ANCIENNETE"));
            tupleList.Add(new Tuple<string, string>("Prime d'ancienneté , régul 2022", "RAPPEL ANCIENNETE"));
            tupleList.Add(new Tuple<string, string>("Prime d'ancienneté , régul 2023", "RAPPEL ANCIENNETE"));
            tupleList.Add(new Tuple<string, string>("Prime d'ancienneté , régul 2024", "RAPPEL ANCIENNETE"));
            tupleList.Add(new Tuple<string, string>("Forfait social sur contributions de prévoyance",
                "FORFAIT SOCIAL SUR PREVOYANCE"));
            tupleList.Add(new Tuple<string, string>("Forfait mensuel NAVIGO Toutes Zones", "CARTE ORANGE(bas)"));
            tupleList.Add(new Tuple<string, string>("UCTIS Dividends", "DIP - Deferred Incentive Plan"));
            tupleList.Add(new Tuple<string, string>("Maternité", "Absence maternite"));
            tupleList.Add(new Tuple<string, string>("Maintien absence maternité 100%", "Absence maternite"));
            tupleList.Add(new Tuple<string, string>("Absence pour entrée/sortie", "DEDUCTION ENTREE SORTIE"));
            tupleList.Add(new Tuple<string, string>("Paternité", "ABSENCE PATERNITE"));
            tupleList.Add(new Tuple<string, string>("Bonus Annuel", "BONUS ANNUEL"));
            tupleList.Add(new Tuple<string, string>("Indemnité compensatrice de congés payés",
                "INDEMNITE COMPENSATRICE DE CONGES PAYES"));
            tupleList.Add(new Tuple<string, string>("Indemnités Jours de repos 10%", "IND COMPENSATRICE RTT"));
            tupleList.Add(new Tuple<string, string>("Stock Acquisition", "AVANTAGE PV ACQUISIITION"));
            tupleList.Add(new Tuple<string, string>("EWM", "DIP - Deferred Incentive Plan"));
            tupleList.Add(new Tuple<string, string>("Long Service Awared", "Long Service Awards"));
            tupleList.Add(new Tuple<string, string>("DIP Taxable", "BONUS COMMERCIAL"));
            tupleList.Add(new Tuple<string, string>("Ajustement du net", "IJSS NETTES"));
            tupleList.Add(new Tuple<string, string>("Indemnité de précarité", "IND COMPENSATRICE RTT"));
            tupleList.Add(new Tuple<string, string>("Prime discrétionnaire", "OTHER BONUS"));
            tupleList.Add(new Tuple<string, string>("Indemnité", "INDEMNITE DE LICENCIEMENT"));
            tupleList.Add(new Tuple<string, string>("Indemnités RTT", "IND COMPENSATRICE RTT"));
            tupleList.Add(new Tuple<string, string>("Maintien de salaire", "Maint.salaire"));
            tupleList.Add(new Tuple<string, string>("Abondement exonéré PEE", "ABONDEMENTS"));
            tupleList.Add(new Tuple<string, string>("Montant net de l'abondement exonéré sur PEE", "ABONDEMENT NET"));
            tupleList.Add(new Tuple<string, string>("Stock Acquisition", "AVANTAGE PV ACQUISITION(bas)"));
            tupleList.Add(new Tuple<string, string>("Long Service Awared", "Long Service Awards"));
            tupleList.Add(new Tuple<string, string>("ESPP 23T Gain", "ESPP TAXABLE BIK(bas)"));
            tupleList.Add(new Tuple<string, string>("IJSS nettes", "IJSS NETTES"));
            tupleList.Add(new Tuple<string, string>("Remboursement abonnement transport", "CARTE ORANGE(bas)"));
            tupleList.Add(new Tuple<string, string>("Trop-perçu IJSS", "IJSS NETTES"));
            tupleList.Add(new Tuple<string, string>("Abonnement Transport", "CARTE ORANGE(bas)"));
            tupleList.Add(new Tuple<string, string>("Indemnité de licenciement exonérée", "INDEMNITE DE LICENCIEMENT"));

            libeleMap = tupleList;
        }

        public const string blueColor = "#FFDEEBF7";
        public const string redColor = "#FFFBE5D6";
        public const string orangeColor = "#FFFFF2CC";
        public const string blackRedColor = "#FFED7D31";
        public const string greenColor = "#FFE2F0D9";
        private static List<Tuple<string, string>> libeleMap;

        public List<Employe> ProcessExcelFile(MemoryStream filePath)
        {
            List<Employe> employeList = new List<Employe>();
            Dictionary<string, string> dictionary1 = new Dictionary<string, string>();
            Dictionary<string, List<string>> dictionary2 = new Dictionary<string, List<string>>();
            foreach (Tuple<string, string> libele in libeleMap)
            {
                if (!dictionary2.ContainsKey(libele.Item1))
                    dictionary2[libele.Item1] = new List<string>();
                dictionary2[libele.Item1].Add(libele.Item2);
            }

            using (ExcelPackage excelPackage = new ExcelPackage(filePath))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
                int rows = worksheet.Dimension.Rows;
                int columns = worksheet.Dimension.Columns;
                int num = 5;
                int Row1 = 3;
                for (int Col1 = 3; Col1 <= columns; Col1 += 2)
                {
                    Employe employeeData = ExtractEmployeeData(worksheet.Cells[Row1, Col1].Value?.ToString());
                    Console.WriteLine("Processing employee: " + employeeData.FullName);
                    for (int Row2 = num; Row2 <= rows; ++Row2)
                    {
                        string code = worksheet.Cells[Row2, 1].Value?.ToString();
                        string libele = worksheet.Cells[Row2, 2].Value?.ToString();
                        for (int Col2 = Col1 + 1; Col2 < Col1 + 3; ++Col2)
                        {
                            LigneDePaie ligne = new LigneDePaie()
                            {
                                code = code,
                                libele = GetLibeleFromMap(dictionary2, libele)
                            };
                            try
                            {
                                ExcelRange cell = worksheet.Cells[Row2, Col2];
                                string cellColor = cell.Style.Fill.BackgroundColor.LookupColor();
                                dictionary1.TryAdd(cellColor, cellColor);
                                ligne = ProcessCell(ligne, cell, cellColor, code, libele, dictionary2);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error processing cell: " + ex.Message);
                            }

                            if (ligne != null)
                                employeeData.LigneDePaies.Add(ligne);
                        }
                    }

                    employeList.Add(employeeData);
                }
            }

            return employeList;
        }

        private LigneDePaie ProcessCell(
            LigneDePaie ligne,
            ExcelRange cell,
            string cellColor,
            string code,
            string libele,
            Dictionary<string, List<string>> dictionaryMap)
        {
            bool flag = false;
            try
            {
                double cellValue = cell.GetCellValue<double>();
                string str = cellColor;
                if (str.Equals("#FFFBE5D6"))
                {
                    ligne.OtherAmout = -1.0 * cellValue;
                    ligne.libele = !dictionaryMap.ContainsKey(libele) || dictionaryMap[libele].Count <= 1
                        ? dictionaryMap[libele][0]
                        : dictionaryMap[libele][1];
                    ligne.libele += "-ER";
                    flag = true;
                }
                else if (str.Equals("#FFED7D31"))
                {
                    ligne.MemoAmount = -1.0 * cellValue;
                    flag = true;
                }
                else if (str.Equals("#FFFFF2CC"))
                {
                    ligne.TaxAmount = !code.Equals("K07") || !code.Equals("K18") ? cellValue : -1.0 * cellValue;
                    if (!ligne.libele.Equals("IMPOT SUR LE REVENU"))
                        ligne.libele += "-EE";
                    flag = true;
                }
                else if (str.Equals("#FFDEEBF7"))
                {
                    ligne.EarningAmount = cellValue;
                    flag = true;
                }
                else if (str.Equals("#FFE2F0D9"))
                {
                    ligne.DeductionAmount = cellValue;
                    flag = true;
                }
                else if (ligne.libele.Equals("Versement indirect sur PEE"))
                    return (LigneDePaie)null;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Ligne " + cell.Address + " ignoré");
            }

            return !flag ? (LigneDePaie)null : ligne;
        }

        private  string GetLibeleFromMap(Dictionary<string, List<string>> map, string libele)
        {
            List<string> stringList = null;
            if (!map.TryGetValue(libele, out stringList))
                return libele;
            return stringList.Count <= 1 ? stringList[0] : stringList[1];
        }

        public  Employe ExtractEmployeeData(string inputText)
        {
            Employe employeeData = new Employe();
            string[] strArray = inputText.Split(' ', (StringSplitOptions)0);
            if (strArray.Length >= 2)
            {
                employeeData.Code = Convert.ToInt32(strArray[0]);
                employeeData.FullName = string.Join(" ", strArray, 1, strArray.Length - 1);
            }

            return employeeData;
        }
    }
}