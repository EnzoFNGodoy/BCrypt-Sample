using BCryptSample.API.Data;
using BCryptSample.API.Models;

namespace BCryptSample.API.Services;

public sealed class UserServices : IUserServices
{
    public List<User> GetAll() => UserData.Users;

    public User? Login(User user)
    {
        var userExists = UserData.Users.SingleOrDefault(u => u.Username == user!.Username);

        if (userExists is null) return null;

        var isValidPassword = BCrypt.Net.BCrypt.Verify(user.Password, userExists.Password);

        if (isValidPassword) return user;

        return null;
    }

    public User SignUp(User user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        UserData.Users.Add(user);
        return user;
    }
}