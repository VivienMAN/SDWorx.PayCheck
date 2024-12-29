// Decompiled with JetBrains decompiler
// Type: PayCheck.Export.ExcelData
// Assembly: PayCheck, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 10E32501-D930-4699-A67B-A473DA016A86
// Assembly location: PayCheck.dll inside D:\PayCheck.exe)

using CsvHelper.Configuration.Attributes;
using System;

#nullable enable
namespace PayCheck.Export
{
  public class ExcelData
  {
    [Name("Pay Date")]
    public DateTime PayDate { get; set; }

    [Name("Period Beginning")]
    public DateTime PeriodBeginning { get; set; }

    [Name("Period Ending")]
    public DateTime PeriodEnd { get; set; }

    [Name("File# EMPLID")]
    public int EmployeeID { get; set; }

    [Name("DEPT")]
    public int Department { get; set; }

    [Name("Check #")]
    public string CheckNumber { get; set; }

    [Name("Check Voucher")]
    public string CheckVoucher { get; set; }

    [Name("Payee Full Name")]
    public string PayeeFullName { get; set; }

    [Name("Pay Code")]
    public string PayCode { get; set; }

    [Name("Pay Element Desc")]
    public string PayElementDescription { get; set; }

    [Name("Currency Code")]
    public string CurrencyCode { get; set; }

    [Name("Earning Amount")]
    public double EarningAmount { get; set; }

    [Name("Hours")]
    public double Hours { get; set; }

    [Name("Deduction Amount")]
    public double DeductionAmount { get; set; }

    [Name("Memo Amount")]
    public double MemoAmount { get; set; }

    [Name("Tax Amount")]
    public double TaxAmount { get; set; }

    [Name("Other Amount")]
    public double OtherAmount { get; set; }

    [Name("INTERFACE_FILE_NAME")]
    public string InterfaceFileName { get; set; }

    [Name("Source App Name")]
    public string SourceAppName { get; set; } = "ICP_FR";

    [Name("Interface By Name")]
    public string InterfaceByName { get; set; } = "Alison McKenzie";
  }
}
