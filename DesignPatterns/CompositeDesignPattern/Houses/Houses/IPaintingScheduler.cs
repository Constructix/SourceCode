using System;
using System.Collections;
using System.Collections.Generic;

namespace CompositeDesignPattern
{
    public interface IPaintingScheduler
    {
        IEnumerable<Tuple<IPainter, double>> Organise(IEnumerable<IPainter> painters, double houses);
    }
}