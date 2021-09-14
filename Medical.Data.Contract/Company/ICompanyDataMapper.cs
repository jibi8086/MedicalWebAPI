using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Data.Contract.Company
{
    public interface ICompanyDataMapper
    {
        CompanyData MapCompanyDetails(IDataRecord arg);
    }
}
