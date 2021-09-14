using Medical.Data.Contract.Company;
using Medical.Data.Contract.Core;
using System;
using System.Data;

namespace Medical.Data.Company
{
    public class CompanyDataMapper : ICompanyDataMapper
    {
        private readonly IDataRecordMappingHelper _mappingHelper;

        public CompanyDataMapper(IDataRecordMappingHelper mappingHelper)
        {
            _mappingHelper = mappingHelper;
        }
        public CompanyData MapCompanyDetails(IDataRecord dataRecord)
        {
            if (dataRecord == null)
            {

                throw new ArgumentNullException(nameof(dataRecord));
            }
            return new CompanyData()
            {
                ID = _mappingHelper.GetInteger(dataRecord, "ID"),
                CompanyName = _mappingHelper.GetString(dataRecord, "CompanyName"),
                CompanyCode = _mappingHelper.GetString(dataRecord, "CompanyCode"),
                CompanyEmail = _mappingHelper.GetString(dataRecord, "CompanyEmail"),
                Place = _mappingHelper.GetString(dataRecord, "Place"),
                City = _mappingHelper.GetString(dataRecord, "City"),
                District = _mappingHelper.GetString(dataRecord, "District"),
                State = _mappingHelper.GetString(dataRecord, "State"),
                Country = _mappingHelper.GetString(dataRecord, "Country"),
                ZipCode = _mappingHelper.GetString(dataRecord, "ZipCode"),
                //Password = _mappingHelper.GetString(dataRecord, "Password"),
            };
        }
    }
}
