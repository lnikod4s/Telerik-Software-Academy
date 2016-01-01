﻿namespace Cars.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface IDatabase
    {
        IList<Car> Cars { get; set; }
    }
}