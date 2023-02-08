using System.Collections.Generic;
using System.Threading.Tasks;


namespace Bargreen.Services
{
    public class InventoryReconciliationResult
    {
        public string ItemNumber { get; set; }
        public decimal TotalValueOnHandInInventory { get; set; }
        public decimal TotalValueInAccountingBalance { get; set; }
    }

    public class InventoryBalance
    {
        public string ItemNumber { get; set; }
        public string WarehouseLocation { get; set; }
        public int QuantityOnHand { get; set; }
        public decimal PricePerItem { get; set; }
    }

    public class AccountingBalance
    {
        public string ItemNumber { get; set; }
        public decimal TotalInventoryValue { get; set; }
    }


    public class InventoryService : IInventoryService    {
       
        public async Task<IEnumerable<InventoryBalance>> GetInventoryBalancesAsync()
        {
            List<InventoryBalance> inventoryBalanceList = new List<InventoryBalance>()
            //return new List<InventoryBalance>()
            {
                new InventoryBalance()
                {
                     ItemNumber = "ABC123",
                     PricePerItem = 7.5M,
                     QuantityOnHand = 312,
                     WarehouseLocation = "WLA1"
                },
                new InventoryBalance()
                {
                     ItemNumber = "ABC123",
                     PricePerItem = 7.5M,
                     QuantityOnHand = 146,
                     WarehouseLocation = "WLA2"
                },
                new InventoryBalance()
                {
                     ItemNumber = "ZZZ99",
                     PricePerItem = 13.99M,
                     QuantityOnHand = 47,
                     WarehouseLocation = "WLA3"
                },
                new InventoryBalance()
                {
                     ItemNumber = "zzz99",
                     PricePerItem = 13.99M,
                     QuantityOnHand = 91,
                     WarehouseLocation = "WLA4"
                },
                new InventoryBalance()
                {
                     ItemNumber = "xxccM",
                     PricePerItem = 245.25M,
                     QuantityOnHand = 32,
                     WarehouseLocation = "WLA5"
                },
                new InventoryBalance()
                {
                     ItemNumber = "xxddM",
                     PricePerItem = 747.47M,
                     QuantityOnHand = 15,
                     WarehouseLocation = "WLA6"
                }
            };

           return inventoryBalanceList;
        }

        public async Task<IEnumerable<AccountingBalance>> GetAccountingBalancesAsync()
        {
            return new List<AccountingBalance>()
            {
                new AccountingBalance()
                {
                     ItemNumber = "ABC123",
                     TotalInventoryValue = 3435M
                },
                new AccountingBalance()
                {
                     ItemNumber = "ZZZ99",
                     TotalInventoryValue = 1930.62M
                },
                new AccountingBalance()
                {
                     ItemNumber = "xxccM",
                     TotalInventoryValue = 7602.75M
                },
                new AccountingBalance()
                {
                     ItemNumber = "fbr77",
                     TotalInventoryValue = 17.99M
                }
            };
        }

        public IEnumerable<InventoryReconciliationResult> ReconcileInventoryToAccounting(IEnumerable<InventoryBalance> inventoryBalances, IEnumerable<AccountingBalance> accountingBalances)
        {
            //TODO-CHALLENGE: Compare inventory balances to accounting balances and find differences

            List<InventoryReconciliationResult> Matched = new List<InventoryReconciliationResult>();
            List<InventoryReconciliationResult> unMatched = new List<InventoryReconciliationResult>();
            var differenceQuery = inventoryBalances.Equals(accountingBalances);
            if (!differenceQuery)
            {
                foreach (var inventoryItem in inventoryBalances)
                {
                    foreach (var accountingItem in accountingBalances)
                    {
                        if(inventoryItem.ItemNumber  == accountingItem.ItemNumber)
                        {
                            var list = new InventoryReconciliationResult
                            {
                                TotalValueInAccountingBalance = inventoryItem.QuantityOnHand,
                                TotalValueOnHandInInventory = accountingItem.TotalInventoryValue,
                                ItemNumber = accountingItem.ItemNumber
                            };
                            Matched.Add(list);
                        }
                        else
                        {
                            var list = new InventoryReconciliationResult
                            {
                                TotalValueInAccountingBalance = inventoryItem.QuantityOnHand,
                                TotalValueOnHandInInventory = accountingItem.TotalInventoryValue,
                                ItemNumber = accountingItem.ItemNumber
                            };
                            unMatched.Add(list);
                        }
                    }
                }
               
            }

            return unMatched;

        }
    }
}