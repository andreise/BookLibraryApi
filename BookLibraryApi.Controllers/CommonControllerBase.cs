using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace BookLibraryApi.Controllers
{
    public abstract class CommonControllerBase : Controller
    {
        protected readonly ILogger logger;

        protected abstract ILogger CreateLogger(ILoggerFactory loggerFactory);

        public CommonControllerBase(ILoggerFactory loggerFactory)
        {
            if (!(loggerFactory is null))
            {
                this.logger = this.CreateLogger(loggerFactory);
            }
        }

        public virtual StatusCodeResult InternalServerError() => this.StatusCode(500);

        protected virtual void LogInternalServerError(int eventId, string actionName, Exception ex)
        {
            this.logger?.LogError(
                new EventId(eventId, $"{actionName} error"),
                ex,
                ex?.GetExtendedMessage());
        }
    }
}
