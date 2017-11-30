namespace Constructix.Home.Electricity.Validators
{
    public  interface IValidator<T> where T :  class, new()
    {
       bool IsValid(T firstInstance, T secondInstance);
    }
}