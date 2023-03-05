using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Modes;

namespace RazorPagesMovie.Pages.Wallpaper
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<WallPaperData> UserWallpaper { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserWallpaper != null)
            {
                var response = await _context.UserWallpaper.ToListAsync();
                foreach (var item in response)
                {
                    UserWallpaper.Add(new WallPaperData()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Created = item.Created,
                        Image = SeedData.ByteToImage(item.Image)

                    });

                }
            }
        }
    }

    public class WallPaperData
    {

        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public Image? Image { get; set; }

        public DateTime? Created { get; set; }
    }
}
