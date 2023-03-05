using System.Drawing;

namespace RazorPagesMovie.Modes
{
    /// <summary>
    /// 壁纸
    /// </summary>
    public class UserWallpaper
    {

        public Guid Id { get; set; }

        public DateTime? Created { get; set; }

        public byte[]? Image { get; set; }

        public string? Name { get; set; }

    }
}
