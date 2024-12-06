namespace Login
{
    public class Model: IModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool IsLoginCorrect()
        {
            // Потенциально в коде метода происходит обращение
            // к базе данных и поиск совпадения логина/пароля
            return UserName == "MVP" && Password == "qwerty";
        }
    }
}
