using Lemon.Data.Interfaces;
using Lemon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public PurchaseRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Purchase> Purchases => _appDbContext.Purchases;

        public Purchase GetPurchaseById(int purchaseId) => _appDbContext.Purchases.FirstOrDefault(p => p.PurchaseId == purchaseId);
        
    }
}
