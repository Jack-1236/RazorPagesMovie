

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Modes
{
    /// <summary>
    /// 电影
    /// </summary>
    public class Movie
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 20)]
        public string? Title { get; set; }

        [DataType(DataType.Date), Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A~Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(20)]
        public string? Cenre { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(1,100)]
        public decimal Price { get; set; }

        [Required]
        [RegularExpression(@"^[A~Z]+[a-zA-Z\s]*$")]
        [StringLength(20)]
        public string Rating { get; set; } = string.Empty;

    }

}
