using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using transactionTest.services.Icountry;
using transactionTest.VM;

namespace transactionTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly ITransactionService _transactionService;

        public CountryController(ICountryService countryService, ITransactionService transactionService)
        {
            _countryService = countryService;
            _transactionService = transactionService;
        }

        [HttpPost("postCountry")]
        public async Task<IActionResult> PostCountry(CountryDivisionVM model)
        {
            IDbContextTransaction groTransaction = await _transactionService.GetGeoDbTransaction();
            int id = 0;

            int rollbackStage = 1;


            await _countryService.saveCountry(model.country);

            string saveDbpoint = await _transactionService.SavepointAsync(groTransaction);

            if (model.divisions.Count > 0)
            {
                foreach (var divion in model.divisions)
                {
                    await _countryService.saveDivision(divion);
                }

            }
            if (id > 0)
            {
                await _transactionService.CommitAsync(groTransaction);
            }
            if (rollbackStage > 0)
            {
                await _transactionService.RollbackToSavepointAsync(groTransaction, saveDbpoint);
                await _transactionService.CommitAsync(groTransaction);

            }
            else
            {
                await _transactionService.RollBackAsync(groTransaction);
            }
            return Ok();

        }
    }
}
