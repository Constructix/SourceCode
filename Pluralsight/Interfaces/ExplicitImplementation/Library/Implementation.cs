using System.Security.Permissions;

namespace Interfaces
{
    public class StandardCatalog : ISaveable, IPersistable
    {
        public void Load()
        {
            
        }

        public string Save()
        {
            return "Catalog Save";
        }

    }
}