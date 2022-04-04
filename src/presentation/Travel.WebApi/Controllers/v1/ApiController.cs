using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Travel.Identity.Helpers;


namespace Travel.WebApi.Controllers.v1
{
    /// <summary>
    /// The preceding code is a property injection to allow ApiContoller to use Mediator. 
    /// I prefer this approach over the constructor injection because of its simplicity. Property
    /// injection frees you up from maintaining all the controllers' parameters and signatures 
    /// using the constructor injection.
    /// 
    /// We are annotating ApiController with the Authorize attribute, the custom 
    /// attribute that we created earlier.The attribute protects all the children classes of
    /// ApiController from authenticated consumers or users.
    /// </summary>
    [Authorize]
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
