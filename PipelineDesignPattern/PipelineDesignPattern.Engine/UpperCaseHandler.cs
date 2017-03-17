﻿namespace PipelineDesignPattern.Engine
{
    class UpperCaseHandler : IHandler
    {
        public void Process(Command command)
        {
            command.Title = command.Title.ToUpper();
        }
    }
}