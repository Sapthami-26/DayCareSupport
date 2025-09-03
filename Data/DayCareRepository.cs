using DayCareSupportAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

public class DayCareRepository(IConfiguration config)
{
#pragma warning disable CS8601 // Possible null reference assignment.
    private readonly string _connStr = config.GetConnectionString("DefaultConnection");
#pragma warning restore CS8601 // Possible null reference assignment.

    public int AddOrUpdateChild(ChildData data)
    {
        using var con = new SqlConnection(_connStr);
        using var cmd = new SqlCommand("DayCareSupportReimbursement_InsertUpdateDataInChild", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@InstanceID", 0);
        cmd.Parameters.AddWithValue("@InitiatorMEmpID", 0); // You may add this dynamically
        cmd.Parameters.AddWithValue("@GroupMGID", 0);
        cmd.Parameters.AddWithValue("@TeamMGID", 0);
        cmd.Parameters.AddWithValue("@WFStatus", 0);
        cmd.Parameters.AddWithValue("@InitiatedOn", DateTime.Now);
        cmd.Parameters.AddWithValue("@RID", data.RID);
        cmd.Parameters.AddWithValue("@DCID", data.DCID);
        cmd.Parameters.AddWithValue("@NameOfChild", data.NameOfChild);
        cmd.Parameters.AddWithValue("@DOB", data.DOB);
        cmd.Parameters.AddWithValue("@AgeYear", data.AgeYear);
        cmd.Parameters.AddWithValue("@AgeMonth", data.AgeMonth);
        cmd.Parameters.AddWithValue("@NameOfDayCare", data.NameOfDayCare);
        cmd.Parameters.AddWithValue("@AdmissionType", data.AdmissionType);
        cmd.Parameters.AddWithValue("@AdmissionTypeOthers", (object?)data.AdmissionTypeOthers ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@DayCareFee", data.DayCareFee);
        cmd.Parameters.AddWithValue("@BillType", data.BillType);
        cmd.Parameters.AddWithValue("@NoOfInvoice", data.NoOfInvoice);
        cmd.Parameters.AddWithValue("@InvoiceDate1", (object?)data.InvoiceDate1 ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@InvoiceDate2", (object?)data.InvoiceDate2 ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@InvoiceDate3", (object?)data.InvoiceDate3 ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@InvoiceDate4", DBNull.Value);
        cmd.Parameters.AddWithValue("@ModeOfPayment", data.ModeOfPayment);
        cmd.Parameters.AddWithValue("@ModeOfPaymentOthers", (object?)data.ModeOfPaymentOthers ?? "");
        cmd.Parameters.AddWithValue("@HardCopy", data.HardCopy ? 1 : 0);
        cmd.Parameters.AddWithValue("@TermDuration", data.TermDuration);
        cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);
        cmd.Parameters.AddWithValue("@FileIndexID", "");
        cmd.Parameters.AddWithValue("@FileName", "");
        cmd.Parameters.AddWithValue("@FilePath", "");
        cmd.Parameters.AddWithValue("@Quarter", data.Quarter);
        cmd.Parameters.AddWithValue("@FinYear", data.FinYear);
        cmd.Parameters.AddWithValue("@IsDraftable", 1);
        cmd.Parameters.AddWithValue("@IsActive", true);
        cmd.Parameters.AddWithValue("@Choice", data.RID == 0 ? 1 : 2); // Insert=1, Update=2

        con.Open();
        int result = cmd.ExecuteNonQuery();
        return result;
    }

    public int DeleteChild(int rid, int dcid)
    {
        using var con = new SqlConnection(_connStr);
        using var cmd = new SqlCommand("DayCareSupportReimbursement_DeleteDataInChild", con)
        {
            CommandType = CommandType.StoredProcedure
        };
        cmd.Parameters.AddWithValue("@RID", rid);
        cmd.Parameters.AddWithValue("@DCID", dcid);
        con.Open();
        return cmd.ExecuteNonQuery();
    }

    public int SubmitDraftStatus(int rid, int dcid, int choice)
    {
        using var con = new SqlConnection(_connStr);
        using var cmd = new SqlCommand("DayCareSupportReimbursement_UpdateIsDraftStatus", con)
        {
            CommandType = CommandType.StoredProcedure
        };
        cmd.Parameters.AddWithValue("@RID", rid);
        cmd.Parameters.AddWithValue("@DCID", dcid);
        cmd.Parameters.AddWithValue("@Choice", choice); // 1=Employee submit, 3=HR approve
        con.Open();
        return cmd.ExecuteNonQuery();
    }

    public int GetQuarter(DateTime start, DateTime end)
    {
        int quarter = 0;
        using var con = new SqlConnection(_connStr);
        using var cmd = new SqlCommand("DayCareSupportReimbursement_GetQuarter", con)
        {
            CommandType = CommandType.StoredProcedure
        };
        cmd.Parameters.AddWithValue("@StartDate", start);
        cmd.Parameters.AddWithValue("@EndDate", end);
        con.Open();
        var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            quarter = reader["QID"] is int q ? q : 0;
        }
        return quarter;
    }
}
