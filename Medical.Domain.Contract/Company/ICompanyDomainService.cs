using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain.Contract.Company
{
    public interface ICompanyDomainService
    {
        Task<CompanyDomainDto> RegisterCompany(CompanyDomainDto companyRegisterDetails);
    }
}
