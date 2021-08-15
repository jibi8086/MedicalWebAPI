using Medical.Data.Contract.Configurations;
using Medical.Data.Contract.UserLogin;
using System.Data.SqlClient;
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
        public async Task<bool> CreateEmployee(EmployeeData employee)
        {
            const string StoredProcedure = "InsertEmployeeDetails";

            var SqlParameters = new[] {
                new SqlParameter("@UserName",employee.UserName),
                new SqlParameter("@Password",employee.Password),
                new SqlParameter("@CreatedBy",employee.CreatedBy),
                new SqlParameter("@Place",employee.Place),
                new SqlParameter("@City",employee.City),
                new SqlParameter("@District",employee.District),
                new SqlParameter("@State",employee.State),
                new SqlParameter("@Country",employee.Country),
                new SqlParameter("@ZipCode",employee.ZipCode),
            };
                
            var res = await _sqlHelper.ExecuteNonQueryAsync(
                                    StoredProcedure,
                                    
                                    SqlParameters
                                    );
            return true;


        }
        #endregion

    }
}
