using System;

namespace TodoApi.Models
{
   public class TodoItem
   {    
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
   
        //Construction
        public TodoItem(int id, DateTime? endDate, string summary, string title)
        {
            this.Id = id;
            this.StartDate = DateTime.Now;
            this.EndDate = endDate;
            this.Summary = summary;
            this.Title = title;
        }
   }
}