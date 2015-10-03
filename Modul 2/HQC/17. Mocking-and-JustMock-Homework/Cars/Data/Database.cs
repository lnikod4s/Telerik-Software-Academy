namespace Cars.Data
{
    using System.Collections.Generic;
    using Contracts;
    using Models;

    public class Database : IDatabase
    {
        public IList<Car> Cars { get; set; }
    }
}