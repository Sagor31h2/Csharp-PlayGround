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
        private readonly IGeoTransactionService _geoTransactionService;

        public CountryController(ICountryService countryService, ITransactionService transactionService, IGeoTransactionService geoTransactionService)
        {
            _countryService = countryService;
            _transactionService = transactionService;
            _geoTransactionService = geoTransactionService;
        }

        [HttpPost("postCountry")]
        public async Task<IActionResult> PostCountry(CountryDivisionVM model)
        {
            IDbContextTransaction geoTransaction = await _transactionService.GetGeoDbTransaction();
            int id = 0;

            int rollbackStage = 1;


            await _countryService.saveCountry(model.country);

            string saveDbpoint = await _transactionService.SavepointAsync(geoTransaction);

            if (model.divisions.Count > 0)
            {
                foreach (var divion in model.divisions)
                {
                    await _countryService.saveDivision(divion);
                }

            }
            if (id > 0)
            {
                await _transactionService.CommitAsync(geoTransaction);
            }
            if (rollbackStage > 0)
            {
                await _transactionService.RollbackToSavepointAsync(geoTransaction, saveDbpoint);
                await _transactionService.CommitAsync(geoTransaction);

            }
            else
            {
                await _transactionService.RollBackAsync(geoTransaction);
            }
            return Ok();

        }

        //use geo transction 
        [HttpPost("PostCountryUseGeoTransction")]
        public async Task<IActionResult> PostCountryUseGeoTransction(CountryDivisionVM model)
        {
            await _geoTransactionService.BeginTransactionAsync();
            int id = 0;

            int rollbackStage = 0;


            await _countryService.saveCountry(model.country);

            var sp = await _geoTransactionService.SavepointAsync();
            if (model.divisions.Count > 0)
            {
                foreach (var divion in model.divisions)
                {
                    await _countryService.saveDivision(divion);
                }

            }
            if (id > 0)
            {
                await _geoTransactionService.CommitAsync();
            }
            else if (rollbackStage > 0)
            {
                await _geoTransactionService.RollbackToSavepointAsync(sp);
                await _geoTransactionService.CommitAsync();

            }
            else
            {
                await _geoTransactionService.RollBackAsync();
            }


            return Ok();

        }

    }
}
