using transactionTest.models;
using transactionTest.services.Icountry;

namespace transactionTest.services
{
    public class CountryService : ICountryService
    {
        private readonly GeodbContext _context;

        public CountryService(GeodbContext context)
        {
            _context = context;
        }
        public async Task<int> saveCountry(Country country)
        {
            await _context.Countries.AddAsync(country);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> saveDivision(Division division)
        {
            await _context.Divisions.AddAsync(division);
            return await _context.SaveChangesAsync();


        }


    }
}
