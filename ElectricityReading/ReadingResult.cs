using System;

public class ReadingResult
{

    public bool Isvalid { get; private set; }

    public int TotalUsage { get; private set; }
    public DateTime CalcualatedOn { get; private set; }
    public ReadingResult(int totalUsage, bool isValid)
    {
        this.TotalUsage = totalUsage;
        this.Isvalid = isValid;
        this.CalcualatedOn = DateTime.Now;
    }
}