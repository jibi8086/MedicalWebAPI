using AutoMapper;
using Medical.Domain.Contract.Company;
using MedicalWebAPI.ViewModels.Company;
using MedicalWebAPI.ViewModels.Generic;
using MedicalWebAPI.ViewModels.ResponseMessage;
using Microsoft.AspNetCore.Mvc;
using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalWebAPI.Areas.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        #region PRIVATE
        private readonly ICompanyDomainService _companyDomainService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        #endregion

        #region CONSTRUCTOR
        public CompanyController(ICompanyDomainService companyDomainService, IMapper mapper, ILogger logger)
        {
            _companyDomainService = companyDomainService;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion
            
        #region PUBLIC

        [HttpPost]
        [Route("RegisterCompany")]
        public async Task<IActionResult> RegisterCompany(CompanyViewModel company)
        {
            try
            {
                var companyRegisterDetails = _mapper.Map<CompanyDomainDto>(company);
                var result = await _companyDomainService.RegisterCompany(companyRegisterDetails);
                return Ok(new ResponseVM<CompanyViewModel>(true, ResponseMessages.DATA_ACCESS_SUCCESS, _mapper.Map<CompanyViewModel>(result)));
            }
            catch (Exception ex)
            {
                _logger.Error()
                    .Exception(ex)
                    .Message($"Register Company failed={company.ComapnyOwnerID}")
                    .LoggerName("RegisterCompany")
                    .Property(nameof(company.ComapnyOwnerID), company.CompanyName)
                    .Write();
                return Ok(new ResponseVM<bool>(false, ex.Message));
            }
        }

        [HttpPost]
        [Route("UpdateCompanyDetails")]
        public async Task<IActionResult> UpdateCompanyDetails(CompanyViewModel company)
        {
            try
            {
                var companyRegisterDetails = _mapper.Map<CompanyDomainDto>(company);
                var result = await _companyDomainService.UpdateCompanyDetails(companyRegisterDetails);
                return Ok(new ResponseVM<CompanyViewModel>(true, ResponseMessages.DATA_ACCESS_SUCCESS, _mapper.Map<CompanyViewModel>(result)));
            }
            catch (Exception ex)
            {
                _logger.Error()
                    .Exception(ex)
                    .Message($"UpdateCompanyDetails Failed ComapnyOwnerID={company.ComapnyOwnerID}")
                    .LoggerName("UpdateCompanyDetails")
                    .Property(nameof(company.ComapnyOwnerID), company.CompanyName)
                    .Write();
                return Ok(new ResponseVM<bool>(false, ex.Message));
            }
        }
        [HttpGet]
        [Route("GetAllCompanyDetails")]
        public async Task<IActionResult> GetAllCompanyDetails()
        {
            try
            {
                var result = await _companyDomainService.GetAllCompanyDetails();
                return Ok(new ResponseVM<IList<CompanyViewModel>>(true, ResponseMessages.DATA_ACCESS_SUCCESS, _mapper.Map<IList<CompanyViewModel>>(result)));
            }
            catch (Exception ex)
            {
                _logger.Error()
                    .Exception(ex)
                    .Message($"GetAllCompanyDetails Failed ")
                    .LoggerName("GetAllCompanyDetails")
                    .Write();
                return Ok(new ResponseVM<bool>(false, ex.Message));
            }
        }
        #endregion
    }
}
