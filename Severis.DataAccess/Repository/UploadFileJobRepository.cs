using Severis.DataAccess.Models.Context;
using Severis.DataAccess.Models.DB;
using Db = Severis.DataAccess.Models.DB;

namespace Severis.DataAccess.Repository
{
    public interface IUploadFileJobRepository
    {
        List<UploadFileJob> SearchFilesByYearAndVersion(string year, string version);
    }
    public class UploadFileJobRepository : GenericRepository<Db.UploadFileJob>, IUploadFileJobRepository
    {
        public UploadFileJobRepository(BS_OE_BudgetContext context) : base(context)
        {

        }

        public List<UploadFileJob> SearchFilesByYearAndVersion(string year, string version)
        {
            var Year = int.Parse(year);
            var Version = version.Equals("*") ? 0 : int.Parse(version);
            if (Version.Equals(0))
            {
                return this._context.UploadFileJobs.Where(i => i.Year.Value == Year).ToList();
            }
            else
            {
                return this._context.UploadFileJobs.Where(i => i.Year.Value == Year && i.Version == Version).ToList();
            }
        }
    }
}
