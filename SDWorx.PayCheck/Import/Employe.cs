// Decompiled with JetBrains decompiler
// Type: PayCheck.Import.Employe
// Assembly: PayCheck, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 10E32501-D930-4699-A67B-A473DA016A86
// Assembly location: PayCheck.dll inside D:\PayCheck.exe)

using System.Collections.Generic;

#nullable enable
namespace PayCheck.Import
{
  public class Employe
  {
    public int Code { get; set; }

    public string FullName { get; set; }

    public List<LigneDePaie> LigneDePaies { get; set; }

    public Employe() => this.LigneDePaies = new List<LigneDePaie>();
  }
}
