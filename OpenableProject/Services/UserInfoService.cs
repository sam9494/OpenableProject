namespace OpenableProject.Services;

public class UserInfoService:IUserInfoService
{
    public UserInfo Authenticate(string username, string password)
    {
        if (username == "admin" && password == "Test1234") //TODO 有空再來做雜湊 (´c_`)
        {
            return new UserInfo("admin", 1);
        }

        throw new NotFoundException("Not found this user");
    }
}

public class NotFoundException : Exception
{
    public string Message { get; set; }
    public NotFoundException(string message)
    {
        Message = message;
    }
}

public class UserInfo
{
    public UserInfo(string userName, int restaurantId)
    {
        UserName = userName;
        RestaurantId = restaurantId;
    }

    public string UserName { get; set; }
    public int RestaurantId { get; set; }
}

public interface IUserInfoService
{
    public UserInfo Authenticate(string username, string password);
}