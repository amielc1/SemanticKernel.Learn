using BethanysPieShop.Contracts.Repositories;
using BethanysPieShop.Data;
using BethanysPieShop.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace BethanysPieShop.Repositories
{
    public class PieRepository : IPieRepository, IDisposable
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PieRepository(IDbContextFactory<ApplicationDbContext> DbFactory)
        {
            _applicationDbContext = DbFactory.CreateDbContext();
        }

        public async Task<Pie> AddPie(Pie pie)
        {
            var addedEntity = await _applicationDbContext.Pies.AddAsync(pie);
            await _applicationDbContext.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task DeletePie(int pieId)
        {
            var foundPie = await _applicationDbContext.Pies.FirstOrDefaultAsync(e => e.Id == pieId);
            if (foundPie == null) return;

            _applicationDbContext.Pies.Remove(foundPie);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pie>> GetAllPies()
        {
            return await _applicationDbContext.Pies.ToListAsync();
        }

        public async Task<Pie> GetPieById(int pieId)
        {
            return await _applicationDbContext.Pies.FirstOrDefaultAsync(c => c.Id == pieId);
        }

        public async Task<Pie> UpdatePie(Pie Pie)
        {
            var foundPie = await _applicationDbContext.Pies.FirstOrDefaultAsync(e => e.Id == Pie.Id);

            if (foundPie != null)
            {
                foundPie.Name = Pie.Name;
                foundPie.IsPieOfTheWeek = Pie.IsPieOfTheWeek;
                foundPie.ShortDescription = Pie.ShortDescription;
                foundPie.LongDescription = Pie.LongDescription;
                foundPie.Price = Pie.Price;
                foundPie.ImageUrl = Pie.ImageUrl;

                await _applicationDbContext.SaveChangesAsync();

                return foundPie;
            }

            return null;
        }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }
    }
}
