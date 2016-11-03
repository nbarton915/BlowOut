using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlowOut.Models;
using System.Data.Entity;

namespace BlowOut.DAL
{
    public class BlowOut1Context : DbContext
    {
        public BlowOut1Context() : base("BlowOut1Context")
        {

        }

        public DbSet<AddClient> AddClients { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Instrument> Instuments { get; set; }
    }
}