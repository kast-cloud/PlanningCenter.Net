using System;

namespace PlanningCenter.Net.Models.People.Lists
{
    public class List
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int TotalPeople { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime ModifiedUtc { get; set; }
    }
}