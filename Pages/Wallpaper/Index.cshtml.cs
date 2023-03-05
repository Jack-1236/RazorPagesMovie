using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IList<UserWallpaper> UserWallpaper { get; set; } = default!;
       
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? WallPaperGenre { get; set; }
        public async Task OnGetAsync()
        {
            if (_context.UserWallpaper != null)
            {
                var papers = from m in _context.UserWallpaper
                             select m;
                if (!string.IsNullOrEmpty(SearchString))
                {
                    papers = papers.Where(v => v.Name.Equals(SearchString));
                }

                var response = await papers.ToListAsync();
                UserWallpaper = response;
                /*   List<Task<WallPaperData>> tasks = new List<Task<WallPaperData>>();
                   foreach (var item in response)
                   {
                       tasks.Add(Task.Run(() =>
                       {
                           return new WallPaperData()
                           {
                               Id = item.Id,
                               Name = item.Name,
                               Created = item.Created,
                               Image = SeedData.ByteToImage(item.Image)
                           };
                       }));
                   }
                   await Task.WhenAll(tasks);
                   foreach (var item in tasks)
                   {
                       if (UserWallpaper == null)
                           UserWallpaper = new List<WallPaperData>();
                       UserWallpaper.Add(item.Result);
                   
               }*/
            }
        }
    }

  /*  public class WallPaperData
    {

        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public Image? Image { get; set; }

        public DateTime? Created { get; set; }
    }*/
}
