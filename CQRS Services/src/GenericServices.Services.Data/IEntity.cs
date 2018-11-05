namespace GenericServices.Services.Models
{
    /// <summary>
    /// All models should be derived from this interface.
    /// </summary>
    /// <typeparam name="T"><remarks>Generic T identifies the ID of the entity.</remarks></typeparam>
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
