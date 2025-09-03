namespace DayCareSupportAPI.Models
{
    public class ChildData
    {
        public int RID { get; set; }
        public int DCID { get; set; }
        public required string NameOfChild { get; set; }
        public DateTime DOB { get; set; }
        public int AgeYear { get; set; }
        public int AgeMonth { get; set; }
        public required string NameOfDayCare { get; set; }
        public required string AdmissionType { get; set; }
        public required string AdmissionTypeOthers { get; set; }
        public decimal DayCareFee { get; set; }
        public required string BillType { get; set; }
        public int NoOfInvoice { get; set; }
        public DateTime? InvoiceDate1 { get; set; }
        public DateTime? InvoiceDate2 { get; set; }
        public DateTime? InvoiceDate3 { get; set; }
        public required string ModeOfPayment { get; set; }
        public required string ModeOfPaymentOthers { get; set; }
        public bool HardCopy { get; set; }
        public required string TermDuration { get; set; }
        public int Quarter { get; set; }
        public int FinYear { get; set; }
    }
}
