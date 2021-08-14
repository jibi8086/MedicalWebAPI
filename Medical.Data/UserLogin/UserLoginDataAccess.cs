using Medical.Data.Contract.Configurations;
using Medical.Data.Contract.UserLogin;
using System.Threading.Tasks;

namespace Medical.Data.UserLogin
{
    public class UserLoginDataAccess : IUserLoginDataAccess
    {
        #region PRIVATE
        private readonly IUserLoginDataMapper _userLoginDataMapper;
        private readonly IMedicalDbSqlHelper _sqlHelper;
        #endregion

        #region CONSTRUCTOR
        public UserLoginDataAccess(IUserLoginDataMapper userLoginDataMapper, IMedicalDbSqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
            _userLoginDataMapper = userLoginDataMapper;
        }
        #endregion

        #region PUBLIC
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
        #endregion

    }
}
