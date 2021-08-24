using Medical.Data.Contract.Company;
using Medical.Data.Contract.Configurations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Data.Company
{
    public class CompanyDataAccess : ICompanyDataAccess
    {
        #region PRIVATE
        private readonly ICompanyDataMapper _companyDataMapper;
        private readonly IMedicalDbSqlHelper _sqlHelper;
        #endregion

        #region CONSTRUCTOR
        public CompanyDataAccess(ICompanyDataMapper companyDataMapper, IMedicalDbSqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
            _companyDataMapper = companyDataMapper;
        }
        #endregion

        public async Task<CompanyData> RegisterCompany(CompanyData company)
        {
            const string StoredProcedure = "InsertCompanyDetails";

            var SqlParameters = new[] {
                new SqlParameter("@ComapnyOwnerID",company.ComapnyOwnerID),
                new SqlParameter("@CompanyName",company.CompanyName),
                new SqlParameter("@CompanyCode",company.CompanyCode),
                new SqlParameter("@CompanyEmail",company.CompanyEmail),
                new SqlParameter("@Place",company.Place),
                new SqlParameter("@City",company.City),
                new SqlParameter("@District",company.District),
                new SqlParameter("@State",company.State),
                new SqlParameter("@Country",company.Country),
                new SqlParameter("@ZipCode",company.ZipCode),
                new SqlParameter("@CreatedBy",company.CreatedBy),
                new SqlParameter("@CreatedDate",company.CreatedDate),
            };

            var res = await _sqlHelper.ExecuteNonQueryAsync(
                                    StoredProcedure,
                                    SqlParameters
                                    );
            return company;
        }
    }
}
