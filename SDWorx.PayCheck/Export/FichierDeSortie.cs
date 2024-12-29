
using PayCheck.Export;
using PayCheck.Import;

namespace SDWorx.PayCheck.Export
{
  public static class FichierDeSortie
  {
    public static List<ExcelData> GenerateData(
      List<Employe> lEmploye,
      DateTime payDate,
      List<EmployeId> lEmployeId,
      DateTime beginDate,
      DateTime endDate)
    {
      List<ExcelData> data = new List<ExcelData>();
      foreach (Employe employe in lEmploye)
      {
        foreach (LigneDePaie ligneDePay in employe.LigneDePaies)
        {
          ExcelData excelData = new ExcelData();
          excelData.PayeeFullName = employe.FullName;
          excelData.EmployeeID = employe.Code;
          if (Enumerable.Any<EmployeId>((IEnumerable<EmployeId>) lEmployeId, (Func<EmployeId, bool>) (x => x.EMPLID == excelData.EmployeeID)))
            excelData.Department = Enumerable.First<EmployeId>(Enumerable.Where<EmployeId>((IEnumerable<EmployeId>) lEmployeId, (Func<EmployeId, bool>) (x => x.EMPLID == excelData.EmployeeID))).DEPT;
          excelData.CheckVoucher = "V";
          excelData.CurrencyCode = "EUR";
          excelData.EarningAmount = ligneDePay.EarningAmount;
          excelData.MemoAmount = ligneDePay.MemoAmount;
          excelData.DeductionAmount = ligneDePay.DeductionAmount;
          excelData.TaxAmount = ligneDePay.TaxAmount;
          excelData.OtherAmount = ligneDePay.OtherAmout;
          excelData.PayElementDescription = ligneDePay.libele;
          if (excelData.PayElementDescription.Equals("DIP - Deferred Incentive Plan"))
            excelData.PayCode = "DIP";
          excelData.PayDate = payDate;
          excelData.PeriodBeginning = beginDate;
          excelData.PeriodEnd = endDate;
          excelData.InterfaceFileName = payDate.ToString("yyyyMMdd") + "_ICP_FR_PAYCHKDTL_2";
          data.Add(excelData);
        }
      }
      return data;
    }
  }
}
