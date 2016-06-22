using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonCars.Data;

namespace LinqToSqlRelationships.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Person> People { get; set; } 
    }
}