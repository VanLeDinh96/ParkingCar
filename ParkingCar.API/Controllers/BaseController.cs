using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ParkingCar.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private IMediator? _mediator;

        protected IMediator Mediator
        {
            get
            {
                if (_mediator == null)
                {
                    _mediator = HttpContext.RequestServices.GetService<IMediator>();
                    if (_mediator == null)
                    {
                        throw new InvalidOperationException("IMediator is not registered in the service provider.");
                    }
                }

                return _mediator;
            }
        }
    }
}