using BCryptSample.API.Models;

namespace BCryptSample.API.Services;

public interface IUserServices
{
    User? Login(User user);
    User SignUp(User user);
    List<User> GetAll();
}