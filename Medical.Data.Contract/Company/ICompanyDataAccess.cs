using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Data.Contract.Company
{
    public interface ICompanyDataAccess
    {
        Task<CompanyData> RegisterCompany(CompanyData companyDetails);
    }
}
