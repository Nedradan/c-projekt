﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuzykaAlbumy.Data;
using MuzykaAlbumy.Modele;

namespace MuzykaAlbumy.Pages.Albumy
{
    public class DetailsModel : PageModel
    {
        private readonly MuzykaAlbumy.Data.MuzykaAlbumyContext _context;

        public DetailsModel(MuzykaAlbumy.Data.MuzykaAlbumyContext context)
        {
            _context = context;
        }

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
    }
}
