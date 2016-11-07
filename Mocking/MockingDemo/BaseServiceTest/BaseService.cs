namespace BaseServiceTest
{
    public partial class OrderFactoryTests
    {
        public class BaseService<TObject, TBaseFactory, TBaseRespository, TInputData>
            where TObject : new()
            where TBaseFactory : IFactory<TObject, TInputData>
            where TBaseRespository : IRepository<TObject>
        {
            private TBaseFactory _factory;
            private TBaseRespository _repository;

            public BaseService(TBaseFactory factory, TBaseRespository repository)
            {
                _factory = factory;
                _repository = repository;
            }

            public void Create(TInputData inputData)
            {
                var instance = _factory.Create(inputData);
                if (instance != null)
                {
                    _repository.Add(instance);
                }
            }
        }
    }
}