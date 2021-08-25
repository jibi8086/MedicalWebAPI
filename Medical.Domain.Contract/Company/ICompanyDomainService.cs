using System.Threading.Tasks;

namespace Medical.Domain.Contract.Company
{
    public interface ICompanyDomainService
    {
        Task<CompanyDomainDto> RegisterCompany(CompanyDomainDto companyRegisterDetails);
    }
}
