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
    public class IndexModel : PageModel
    {
        private readonly MuzykaAlbumy.Data.MuzykaAlbumyContext _context;

        public IndexModel(MuzykaAlbumy.Data.MuzykaAlbumyContext context)
        {
            _context = context;
        }

        public IList<MuzykaAlbumy.Modele.Albumy> Album { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Gatunki { get; set; }
        public SelectList Wykonawcy { get; set; }
        public SelectList Wersje { get; set; }
        [BindProperty(SupportsGet = true)]
        public string AlbumyGatunek { get; set; }
        public string AlbumyWykonawca { get; set; }
        public string AlbumyWersja { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> GatunekQuery = from g in _context.Albumy
                                              orderby g.gatunekMuzyczny
                                              select g.gatunekMuzyczny;
            IQueryable<string> WykonawcaQuery = from w in _context.Albumy
                                                 orderby w.wykonawca
                                                 select w.wykonawca;
            IQueryable<string> WersjaQuery = from t in _context.Albumy
                                            orderby t.wersjaAlbumu
                                            select t.wersjaAlbumu;
            

            var album = from a in _context.Albumy
                         select a;

            if (!string.IsNullOrEmpty(AlbumyGatunek))
            {
                album = album.Where(x => x.gatunekMuzyczny == AlbumyGatunek);
            }
            if (!string.IsNullOrEmpty(AlbumyWykonawca))
            {
                album = album.Where(x => x.wykonawca == AlbumyWykonawca);
            }
            if (!string.IsNullOrEmpty(AlbumyWersja))
            {
                album = album.Where(x => x.nazwaAlbumu == AlbumyWersja);
            }
            
            Gatunki = new SelectList(await GatunekQuery.Distinct().ToListAsync());
            Wykonawcy = new SelectList(await WykonawcaQuery.Distinct().ToListAsync());
            Wersje = new SelectList(await WersjaQuery.Distinct().ToListAsync());
            Album = await album.ToListAsync();

        }
    }
}
