namespace Web.Features
{
    using Application.Countries.Exceptions;
    using Application.Countries.Models;
    using Application.Countries.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private const string Code = "{code}";
        private readonly ICountryService countryService;
        public CountriesController(ICountryService countryService)
            => this.countryService = countryService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailsCountryOutputModel>>> GetAll()
            => Ok(await countryService.GetCountries());

        [HttpGet]
        [Route(Code)]
        public async Task<ActionResult<DetailsCountryOutputModel>> GetByCode(string code)
        {
            try
            {
                return Ok(await countryService.GetCountry(code));
            }
            catch (CountryNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<CreateCountryOutputModel>> Post(CreateCountryInputModel model)
            => Created(
                nameof(this.Post),
                await countryService.CreateCountry(
                    model.CountryName, 
                    model.CountryCode));
    }
}
