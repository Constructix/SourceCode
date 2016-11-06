namespace MockingDemo
{
    public interface IFactory<T, I>
    {
        T Create(I inputData);
    }
}