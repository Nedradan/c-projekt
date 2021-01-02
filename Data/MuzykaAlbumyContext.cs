using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MuzykaAlbumy.Modele;

namespace MuzykaAlbumy.Data
{
    public class MuzykaAlbumyContext : DbContext
    {
        internal object albumy;

        public MuzykaAlbumyContext (DbContextOptions<MuzykaAlbumyContext> options)
            : base(options)
        {
        }

        public DbSet<MuzykaAlbumy.Modele.Albumy> Albumy { get; set; }
    }
}
