using Lemon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lemon.Data.Interfaces
{
    interface IPurchaseRepository
    {
        IEnumerable<Purchase> Purchases { get; }

        Purchase GetPurchaseById(int purchaseId);
    }
}
