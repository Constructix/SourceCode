namespace Constructix.OnlineServices.Data.Contexts
{
    public class EntityFrameworkContext<T> : IContext<T>
    {
        public T Value { get; set; }

        public EntityFrameworkContext()
        {
            
        }

        public EntityFrameworkContext(T value)
        {
            Value = value;
        }
    }
}