using UserApi.ViewModel;

namespace UserApi.Service.Interface
{
    public interface IUserService
    {
        Task<string> Login(UserLoginModel userLoginModel);
    }
}
