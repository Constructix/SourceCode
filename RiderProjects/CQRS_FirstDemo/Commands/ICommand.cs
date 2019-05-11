using System;

namespace CQRS_FirstDemo.Commands
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}