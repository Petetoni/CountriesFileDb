namespace Web.Features
{
    using Application.Countries.Exceptions;
    using Application.Countries.Models;
    using Application.Countries.Queries;
    using Application.Countries.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class CountriesCqrsController : ApiController
    {
        private const string Code = "{id}";

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailsCountryOutputModel>>> GetAll()
            => await this.Send(null);

        [HttpGet]
        [Route(Code)]
        public async Task<ActionResult<DetailsCountryOutputModel>> GetByCode(
            [FromRoute] DetailsCountryQuery query)
            => await this.Send(query);

        //[HttpPost]
        //public async Task<ActionResult<CreateCountryOutputModel>> Post(CreateCountryInputModel model)
        //    => Created(
        //        nameof(this.Post),
        //        await countryService.CreateCountry(
        //            model.CountryName, 
        //            model.CountryCode));
    }
}
