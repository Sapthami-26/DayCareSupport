using DayCareApi.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DayCareApi.Repositories
{
    public class DayCareRepository(IConfiguration config) : IDayCareRepository
    {
#pragma warning disable CS8601 // Possible null reference assignment.
        private readonly string _connectionString = config.GetConnectionString("DefaultConnection");
#pragma warning restore CS8601 // Possible null reference assignment.

        [Obsolete]
        public int GetQuarter(DateTime start, DateTime end)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("DayCareSupportReimbursement_GetQuarter", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@StartDate", start);
            cmd.Parameters.AddWithValue("@EndDate", end);
            conn.Open();
            var result = cmd.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        [Obsolete]
        public int AddOrUpdateChild(ChildData child, int choice)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("DayCareSupportReimbursement_InsertUpdateDataInChild", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@InstanceID", 0);
            cmd.Parameters.AddWithValue("@InitiatorMEmpID", child.InitiatorMEmpID);
            cmd.Parameters.AddWithValue("@GroupMGID", 0);
            cmd.Parameters.AddWithValue("@TeamMGID", 0);
            cmd.Parameters.AddWithValue("@WFStatus", 0);
            cmd.Parameters.AddWithValue("@InitiatedOn", DateTime.Now);
            cmd.Parameters.AddWithValue("@RID", child.RID);
            cmd.Parameters.AddWithValue("@DCID", child.DCID);
            cmd.Parameters.AddWithValue("@NameOfChild", child.NameOfChild ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@DOB", child.DOB);
            cmd.Parameters.AddWithValue("@AgeYear", child.AgeYear);
            cmd.Parameters.AddWithValue("@AgeMonth", child.AgeMonth);
            cmd.Parameters.AddWithValue("@NameOfDayCare", child.NameOfDayCare ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@AdmissionType", child.AdmissionType ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@AdmissionTypeOthers", child.AdmissionTypeOthers ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@DayCareFee", child.DayCareFee);
            cmd.Parameters.AddWithValue("@BillType", child.BillType ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@NoOfInvoice", child.NoOfInvoice);
            cmd.Parameters.AddWithValue("@InvoiceDate1", child.InvoiceDate1 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceDate2", child.InvoiceDate2 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceDate3", child.InvoiceDate3 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@InvoiceDate4", child.InvoiceDate4 ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ModeOfPayment", child.ModeOfPayment);
            cmd.Parameters.AddWithValue("@ModeOfPaymentOthers", child.ModeOfPaymentOthers ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@HardCopy", child.HardCopy);
            cmd.Parameters.AddWithValue("@TermDuration", child.TermDuration ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@FileIndexID", "");
            cmd.Parameters.AddWithValue("@FileName", "");
            cmd.Parameters.AddWithValue("@FilePath", "");
            cmd.Parameters.AddWithValue("@Quarter", child.Quarter);
            cmd.Parameters.AddWithValue("@FinYear", child.FinYear);
            cmd.Parameters.AddWithValue("@IsDraftable", 1);
            cmd.Parameters.AddWithValue("@IsActive", true);
            cmd.Parameters.AddWithValue("@Choice", choice);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        [Obsolete]
        public int DeleteChild(int rid, int dcid)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("DayCareSupportReimbursement_DeleteDataInChild", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@RID", rid);
            cmd.Parameters.AddWithValue("@DCID", dcid);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        [Obsolete]
        public int UpdateDraftStatus(int rid, int dcid, int choice)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("DayCareSupportReimbursement_UpdateIsDraftStatus", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@RID", rid);
            cmd.Parameters.AddWithValue("@DCID", dcid);
            cmd.Parameters.AddWithValue("@Choice", choice);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}
