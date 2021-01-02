using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuzykaAlbumy.Data;
using MuzykaAlbumy.Modele;

namespace MuzykaAlbumy.Pages.Albumy
{
    public class EditModel : PageModel
    {
        private readonly MuzykaAlbumy.Data.MuzykaAlbumyContext _context;

        public EditModel(MuzykaAlbumy.Data.MuzykaAlbumyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MuzykaAlbumy.Modele.Albumy Albumy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Albumy = await _context.Albumy.FirstOrDefaultAsync(m => m.ID == id);

            if (Albumy == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Albumy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumyExists(Albumy.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AlbumyExists(int id)
        {
            return _context.Albumy.Any(e => e.ID == id);
        }
    }
}
