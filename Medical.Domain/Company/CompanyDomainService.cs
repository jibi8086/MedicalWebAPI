using AutoMapper;
using Medical.Data.Contract.Company;
using Medical.Domain.Contract.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain.Company
{
    public class CompanyDomainService : ICompanyDomainService
    {
        #region PRIVATE
        private readonly ICompanyDataAccess _companyDataAccess;
        private readonly IMapper _mapper;
        #endregion

        #region CONSTRUCTOR
        public CompanyDomainService(ICompanyDataAccess companyDataAccess, IMapper mapper)
        {
            _companyDataAccess = companyDataAccess;
            _mapper = mapper;
        }
        #endregion

        public async Task<CompanyDomainDto> RegisterCompany(CompanyDomainDto companyRegisterDetails)
        {
            var companyDetails = _mapper.Map<CompanyData>(companyRegisterDetails);
            var result = await _companyDataAccess.RegisterCompany(companyDetails);
            return _mapper.Map<CompanyDomainDto>(result);
        }
    }
}
