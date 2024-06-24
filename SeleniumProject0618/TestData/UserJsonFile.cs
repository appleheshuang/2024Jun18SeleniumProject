namespace SeleniumProject0618.Utils
{
public class User
{
    public Credentials Credentials { get; set; }
    public UserInfo UserInfo { get; set; }
}

public class Credentials
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class UserInfo
{
    public string Role { get; set; }
    public Details Details { get; set; }
}

public class Details
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
}