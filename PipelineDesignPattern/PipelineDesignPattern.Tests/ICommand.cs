using System;

namespace PipelineDesignPattern.Tests
{
    public interface ICommand
    {
        DateTime? ExecutedOn { get; set; }
    }
}