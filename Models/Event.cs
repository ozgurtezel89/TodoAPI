using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Event
    {
        [Key]
        
        int Id  { get; set; }
        int EventLocationId  { get; set; }
        string EventName { get; set; }
        DateTime EventDate { get; set; }
        DateTime DateCreated { get; set; }
    }
}