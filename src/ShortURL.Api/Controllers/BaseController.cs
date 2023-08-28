﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ShortURL.Api.Controllers
{
    /// <summary>
    /// Base api controller
    /// </summary>
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator = null!;

        /// <summary>
        /// Mediator
        /// </summary>
#pragma warning disable CS8601, CS8603
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
#pragma warning restore CS8601, CS8603
    }
}
