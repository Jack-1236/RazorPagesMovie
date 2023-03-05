using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Modes;

namespace RazorPagesMovie.Pages.Wallpaper
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public DeleteModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
      public UserWallpaper UserWallpaper { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.UserWallpaper == null)
            {
                return NotFound();
            }

            var userwallpaper = await _context.UserWallpaper.FirstOrDefaultAsync(m => m.Id == id);

            if (userwallpaper == null)
            {
                return NotFound();
            }
            else 
            {
                UserWallpaper = userwallpaper;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.UserWallpaper == null)
            {
                return NotFound();
            }
            var userwallpaper = await _context.UserWallpaper.FindAsync(id);

            if (userwallpaper != null)
            {
                UserWallpaper = userwallpaper;
                _context.UserWallpaper.Remove(UserWallpaper);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
