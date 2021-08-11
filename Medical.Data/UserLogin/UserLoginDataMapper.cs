using Medical.Data.Contract.Core;
using Medical.Data.Contract.UserLogin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Data.UserLogin
{
    public class UserLoginDataMapper : IUserLoginDataMapper
    {
        private readonly IDataRecordMappingHelper _mappingHelper;

        public UserLoginDataMapper(IDataRecordMappingHelper mappingHelper)
        {
            _mappingHelper = mappingHelper;
        }

        public UserLoginData MapUserDetails(IDataRecord dataRecord)
        {
            if (dataRecord == null) {

                throw new ArgumentNullException(nameof(dataRecord));
             }
            return new UserLoginData()
            {
                ID= _mappingHelper.GetInteger(dataRecord,"ID"),
                UserName = _mappingHelper.GetString(dataRecord, "UserName"),
                Password= _mappingHelper.GetString(dataRecord, "Password"),
            };
        }
    }
}
