﻿namespace tp_app_back.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
