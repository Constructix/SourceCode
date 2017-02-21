using System;
using System.Collections.Generic;
using MicroServices.Tests;

namespace MicroServices.DTO
{
    public class Payload<T>
    {
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

        public List<ServiceHistory> History { get; set; }
        public T instance { get; set; }

        public PayloadStatus Status { get; set; }


        public Payload()
        {
            History = new List<ServiceHistory> { new ServiceHistory { Status = HistoryStatus.Ok, Message = "Created"} };
        }
        
    }
}