using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


namespace Travel.WebApi.Controllers.v1
{
    /// <summary>
    /// The preceding code is a property injection to allow ApiContoller to use Mediator. 
    /// I prefer this approach over the constructor injection because of its simplicity. Property
    /// injection frees you up from maintaining all the controllers' parameters and signatures 
    /// using the constructor injection.
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class ApiController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
