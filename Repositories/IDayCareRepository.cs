using DayCareApi.Models;

namespace DayCareApi.Repositories
{
    public interface IDayCareRepository
    {
        int GetQuarter(DateTime start, DateTime end);
        int AddOrUpdateChild(ChildData child, int choice);
        int DeleteChild(int rid, int dcid);
        int UpdateDraftStatus(int rid, int dcid, int choice);
    }
}
