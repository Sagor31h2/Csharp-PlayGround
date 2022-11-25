using transactionTest.models;

namespace transactionTest.services.Icountry
{
    public interface ICountryService
    {
        Task<int> saveCountry(Country country);

        Task<int> saveDivision(Division division);
    }
}
