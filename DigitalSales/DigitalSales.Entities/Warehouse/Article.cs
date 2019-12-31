using System.ComponentModel.DataAnnotations;

namespace DigitalSales.Entities.Warehouse
{
    public class Article
    {
        public int IdArticle { get; set; }
        [Required]
        public int idCategory { get; set; }
        public string Code { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener mas de 50 caracteres, ni menos de 3 caracteres.")]
        public string Name { get; set; }
        [Required]
        public decimal Price_Sale { get; set; }
        [Required]
        public int Stock { get; set; }
        public string Description { get; set; }
        public bool Condition { get; set; }
        public Category Category { get; set; }
        public string CategoryName => Category.Name;
    }
}
