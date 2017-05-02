<<<<<<< HEAD
﻿using System.Collections.Generic;
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
=======
﻿using PipelineDesignPattern.Engine;
using Xunit;
using Xunit.Abstractions;

namespace PipelineDesignPattern.Tests
{
    public class PipelineManagerTests : BaseTest
    {
        private PipelineManager _pipeLineManager;
        public PipelineManagerTests(ITestOutputHelper helper) : base(helper)
        {
            _pipeLineManager = new PipelineManager();
        }

        [Fact]
        public override void InstanceIsNotNull()
        {
            Assert.NotNull(_pipeLineManager);
            _helper.WriteLine("PipleLineManager is Not Null");
        }

        [Fact]
        public void HandlersIsNotNull()
        {
            Assert.NotNull(_pipeLineManager.Handlers);
            _helper.WriteLine("Handlers is not null");
        }

        [Fact]
        public void AddCommandToPipeLineManager()
        {
            string expectedValue = "11 CARBINE COURT";
            Command cmd = new Command() {Title = "This is a test for command"};

           _pipeLineManager.Handlers.Add( new CarbineCourtHandler());
           _pipeLineManager.Handlers.Add(new UpperCaseHandler());

            _pipeLineManager.Execute(cmd);
            _helper.WriteLine(cmd.Title);
            Assert.True(expectedValue.Equals(cmd.Title));
        }
    }



}
>>>>>>> 59d14908c9a97ee19689daf7eefa6ea22225810b
