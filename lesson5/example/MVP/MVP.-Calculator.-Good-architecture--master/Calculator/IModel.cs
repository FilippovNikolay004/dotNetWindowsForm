namespace Calculator
{
    public interface IModel
    {
        string Result { get; set; }
        void Save();
        void Load();
    }
}
