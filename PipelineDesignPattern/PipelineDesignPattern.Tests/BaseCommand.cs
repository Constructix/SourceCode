using System;

namespace PipelineDesignPattern.Tests
{
    public abstract class BaseCommand : ICommand
    {
        public DateTime? ExecutedOn { get; set; }
    }
}