using Bargreen.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bargreen.API.Controllers
{
    //TODO-CHALLENGE: Make the methods in this controller follow the async/await pattern
    //added async task, await for api calls. Appended 'Async' to each async method.

    //TODO-CHALLENGE: Use dotnet core dependency injection to inject the InventoryService
    //Added Interface IInventoryService class for DI.
    //builder.Services.AddTransient<IInventoryService, ShortDate>():

    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [Route("InventoryBalances")]
        [HttpGet]
        public async Task<IEnumerable<InventoryBalance>> GetInventoryBalances()
        {
            //var inventoryService = new InventoryService();
            return await _inventoryService.GetInventoryBalancesAsync();
        }

        [Route("AccountingBalances")]
        [HttpGet]
        public async Task <IEnumerable<AccountingBalance>> GetAccountingBalances()
        {
            //var inventoryService = new InventoryService();
            return await _inventoryService.GetAccountingBalancesAsync();
        }

        [Route("InventoryReconciliation")]
        [HttpGet]
        public async Task<IEnumerable<InventoryReconciliationResult>> GetReconciliation()
        {
            //var inventoryService = new InventoryService();
            var inventoryBlanceList = await _inventoryService.GetInventoryBalancesAsync();
            var accountingList = await _inventoryService.GetAccountingBalancesAsync();

            return _inventoryService.ReconcileInventoryToAccounting(inventoryBlanceList, accountingList);
        }
    }
}