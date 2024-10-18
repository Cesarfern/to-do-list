﻿namespace CrudAPI.Entities
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime  CreatedAt { get; set; }
    }
}
