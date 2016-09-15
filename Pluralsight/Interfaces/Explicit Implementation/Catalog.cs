public class Catalog : ISavable
{
    public string Save()
    {
        return "Catalog Save";
    }

     string ISavable.Save()
    {
        return "ISavable.Save()";
    }
}
