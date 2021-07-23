using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationSample.Controllers.Bases
{
    public abstract class ApiBase : ControllerBase
    {
        protected readonly IMediator _mediator;

        protected ApiBase(IMediator mediator)
        {
            this._mediator = mediator;
        }

        protected void AddErrors(ValidationResult validation)
        {
            foreach (var error in validation.Errors)
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }
}
