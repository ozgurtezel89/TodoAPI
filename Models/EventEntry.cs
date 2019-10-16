using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class EventEntry
    {
        [Key]
        public int Id  { get; set; }
        public int EventLocationId  { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime DateCreated { get; set; }
    }
}