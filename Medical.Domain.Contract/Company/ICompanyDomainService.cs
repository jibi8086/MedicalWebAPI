using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medical.Domain.Contract.Company
{
    public interface ICompanyDomainService
    {
        Task<CompanyDomainDto> RegisterCompany(CompanyDomainDto companyRegisterDetails);
        Task<CompanyDomainDto> UpdateCompanyDetails(CompanyDomainDto companyRegisterDetails);
        Task<IList<CompanyDomainDto>> GetAllCompanyDetails();
    }
}
