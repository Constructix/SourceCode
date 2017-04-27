using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PipelineDesignPattern.Tests
{
    public class PipelineManagerTests
    {

        [Fact]
        public void PipelineManagerInstanceCreated()
        {
            var pipelineManager = new PipeLineManager();
            Assert.NotNull(pipelineManager);
        }
    }
}
