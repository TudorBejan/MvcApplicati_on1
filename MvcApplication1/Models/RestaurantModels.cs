using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProiectIEP.Models
{

    public class RestaurantContext : DbContext
    {
        public RestaurantContext()
            : base("ApplicationContext")
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("Restaurants")]
    public class Restaurant
    {
        [Key]
        public int RestId { get; set; }

        [Required(ErrorMessage = "Please enter a Restaurant Name")]
        [Display(Name = "Restaurant Name")]
        public string RestName { get; set; }
        
        [Required(ErrorMessage="Please enter the Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter a City name")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter the County")]
        public string County { get; set; }
        [Required(ErrorMessage = "Please enter the Country")]
        public string Country { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserProfile User { get; set; }

        [ForeignKey("Cuisine")]
        public int CuisineId { get; set; }
        public Cuisine Cuisine { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }

    [Table("Cuisines")]
    public class Cuisine
    {
        [Key]
        public int CusineId { get; set; }
        [Required(ErrorMessage="Cuisine Name Required")]
        [Display(Name="Cuisine Name")]
        public string CuisineName { get; set; }

        public virtual ICollection<Cuisine> Cuisines { get; set; }
    }

    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required(ErrorMessage="Comment text required")]
        [Display(Name="User Comment")]
        public string CommentText { get; set; }

        public UserProfile User { get; set; }

        [ForeignKey("Restaurant")]
        public int RestId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}