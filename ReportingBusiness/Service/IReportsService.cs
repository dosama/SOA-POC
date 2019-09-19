using System.Threading.Tasks;
using ReportingBusiness.Models;

namespace ReportingBusiness.Service
{
    public interface IReportsService
    {
        Task<ReportModel> GenerateReport();
    }
}
