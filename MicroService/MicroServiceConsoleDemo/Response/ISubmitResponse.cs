namespace ConsoleApp1
{
    public interface ISubmitResponse<T>
    {
        T Document { get; set; }
    }
}