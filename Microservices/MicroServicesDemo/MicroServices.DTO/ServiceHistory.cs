using System;
using MicroServices.Tests;

namespace MicroServices.DTO
{
    public class ServiceHistory
    {
        public DateTime EntereedService { get; set; }
        public DateTime EnteredService { get; set; }
        public HistoryStatus Status { get; set; }
        public string Message { get; set; }
    }
}