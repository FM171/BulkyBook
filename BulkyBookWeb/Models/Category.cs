using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category //public class can called by other fuctions
    {
        [Key] //This  is data attribute that turns id into primary key like sql
        public int Id { get; set; }
        
        [Required] //This turns Key into required field
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now; 
    }
}

