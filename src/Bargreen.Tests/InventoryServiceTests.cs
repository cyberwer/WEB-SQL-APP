using Bargreen.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace Bargreen.Tests
{
    public class InventoryServiceTests
    {

        private readonly IInventoryService _inventoryService;

        public InventoryServiceTests(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }       


        [Fact]
        public void Inventory_Reconciliation_Performs_As_Expected()
        {
            //TODO-CHALLENGE: Verify expected output of your recon algorithm. Note, this will probably take more than one test
            var inventoryBalance =  _inventoryService.GetInventoryBalancesAsync();

            var accountingBalance =  _inventoryService.GetAccountingBalancesAsync();

            //Assert.IsTrue(accountingBalance.SequenceEqual(inventoryBalance));
            //Assert.Equal(accountingBalance, inventoryBalance);
            //Assert.AreEqual(accountingBalance, inventoryBalance);
            //CollectionAssert.AreEqual(accountingBalance, inventoryBalance);
            //Assert.IsTrure(accountingBalance, inventoryBalance);

        }
    }
}
