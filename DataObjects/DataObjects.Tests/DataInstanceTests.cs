using AutoMapper;
using Xunit;

namespace DataObjects.Tests
{
    public class DataInstanceTests
    {
        [Fact]
        public void DataObjectCreated()
        {
            PersonDTO personDTO = new PersonDTO("Richard", "Jones");

            var json = personDTO.ToJson();
            Assert.NotNull(json);

            var convertedBackToPersonDTO = PersonDTO.FromJson(json);

            Assert.Equal(personDTO.FirstName, convertedBackToPersonDTO.FirstName);
            Assert.Equal(personDTO.LastName, convertedBackToPersonDTO.LastName);

        }

        [Fact]
        public void MapPersontoPersonDTO()
        {
            Person newPerson = new Person("Richard", "Jones");

            PersonDTO personDTO = Mapper.Map<Person, PersonDTO>(newPerson);

            Assert.NotNull(personDTO);
            Assert.Equal("Richard", personDTO.FirstName);
            Assert.Equal("Jones", personDTO.LastName);

        }


        public class PersonDTOProfile : Profile
        {
            public PersonDTOProfile()
            {
                CreateMap<Person, PersonDTO>()
            }
        }
    }
}