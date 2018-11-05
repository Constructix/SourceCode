using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataObjects.Tests
{
    public class PersonDTO : IDataTransferObject
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PersonDTO()
        {
            
        }

        public PersonDTO(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public static PersonDTO FromJson(string contents)
        {
            PersonDTO newPerson =  JsonConvert.DeserializeObject<PersonDTO>(contents);
            return newPerson;
        }


    }

    public interface IDataTransferObject
    {
        string ToJson();
    }
    public class Person 
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
