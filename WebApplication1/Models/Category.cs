using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        //data anotations
        [Required]
        //service side validation
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string? Name { get; set; }

        //data annotations 
        [Required]
        [DisplayName("Display Order")]
        //server side validation
        [Range(1,100)]
        public int DispalyOrder { get; set; }
    }
}
