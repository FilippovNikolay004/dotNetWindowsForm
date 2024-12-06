namespace Login
{
    public interface IModel
    {
        string UserName { get; set; }
        string Password { get; set; }
        bool IsLoginCorrect();
    }
}
