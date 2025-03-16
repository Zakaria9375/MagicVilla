using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;

namespace MagicVilla_VillaAPI.Repository
{
    public class VillaRepository(AppDbContext db) : Repository<Villa>(db), IVillaRepository
    {
        private readonly AppDbContext _db = db;
    }
}
