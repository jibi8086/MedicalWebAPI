using Medical.Data.Contract.Configurations;
using Medical.Data.Contract.UserLogin;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Medical.Data.UserLogin
{
    public class UserLoginDataAccess : IUserLoginDataAccess
    {
        #region PRIVATE
        private readonly IUserLoginDataMapper _userLoginDataMapper;
        private readonly IMedicalDbSqlHelper _sqlHelper;
        #endregion
        public UserLoginDataAccess(IUserLoginDataMapper userLoginDataMapper, IMedicalDbSqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
            _userLoginDataMapper = userLoginDataMapper;
        }
        public async Task<UserLoginData> AuthenticateUser(UserLoginData login) 
        {
            const string StoredProcedure = "getLoginDetails";
            //var SqlParameters = new[] {
            //    new SqlParameter("",5)
            //};

            return await _sqlHelper.GetFirstOrDefaultAsync(
                                    StoredProcedure,
                                    _userLoginDataMapper.MapUserDetails                                    
                );

        
        }
    }
}
