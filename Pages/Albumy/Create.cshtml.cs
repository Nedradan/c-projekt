using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuzykaAlbumy.Data;
using MuzykaAlbumy.Modele;

namespace MuzykaAlbumy.Pages.Albumy
{
    public class CreateModel : PageModel
    {
        private readonly MuzykaAlbumy.Data.MuzykaAlbumyContext _context;

        public CreateModel(MuzykaAlbumy.Data.MuzykaAlbumyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MuzykaAlbumy.Modele.Albumy Albumy { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (Albumy == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            

            _context.Albumy.Add(Albumy);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
