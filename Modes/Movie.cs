

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

        public string? Title { get; set; }

        [DataType(DataType.Date), Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }


        public string? Cenre { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }

    }

}
