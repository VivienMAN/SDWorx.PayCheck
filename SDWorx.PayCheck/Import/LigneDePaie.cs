// Decompiled with JetBrains decompiler
// Type: PayCheck.Import.LigneDePaie
// Assembly: PayCheck, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 10E32501-D930-4699-A67B-A473DA016A86
// Assembly location: PayCheck.dll inside D:\PayCheck.exe)

#nullable enable
namespace PayCheck.Import
{
  public class LigneDePaie
  {
    public string code { get; set; }

    public string libele { get; set; }

    public double EarningAmount { get; set; }

    public double DeductionAmount { get; set; }

    public double MemoAmount { get; set; }

    public double TaxAmount { get; set; }

    public double OtherAmout { get; set; }
  }
}
