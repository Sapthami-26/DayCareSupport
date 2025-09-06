namespace DayCareApi.Models
{
    public class ChildData
    {
        public int RID { get; set; }
        public int DCID { get; set; }
        public int InitiatorMEmpID { get; set; }
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
        public DateTime? InvoiceDate4 { get; set; }
        public int ModeOfPayment { get; set; }
        public required string ModeOfPaymentOthers { get; set; }
        public int HardCopy { get; set; }
        public required string TermDuration { get; set; }
        public DateTime EntryDate { get; set; }
        public int Quarter { get; set; }
        public int FinYear { get; set; }
        public int IsDraftable { get; set; }
        public bool IsActive { get; set; }
        public int Choice { get; set; }
    }
}
