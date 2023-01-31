using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bargreen.Services
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryBalance>> GetInventoryBalancesAsync();

        Task<IEnumerable<AccountingBalance>> GetAccountingBalancesAsync();

        IEnumerable<InventoryReconciliationResult> ReconcileInventoryToAccounting(IEnumerable<InventoryBalance> inventoryBalances, IEnumerable<AccountingBalance> accountingBalances);
    }
}
