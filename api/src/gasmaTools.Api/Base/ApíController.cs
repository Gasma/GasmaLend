using gasmaTools.Abstraction.Bus;
using gasmaTools.Abstraction.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace gasmaTools.Api.Base
{
    public class ApiController : ControllerBase
    {
        private readonly IMediatorHandler mediator;
        private readonly DomainNotificationHandler domainNotification;

        public ApiController(
            INotificationHandler<DomainNotification> domainNotification,
            IMediatorHandler mediator)
        {
            this.mediator = mediator;
            this.domainNotification = (DomainNotificationHandler)domainNotification;
        }

        #region [IActionResult] sync

        protected IActionResult Result<TData>(TData data)
            where TData : class
        {
            if (this.IsValidOperation)
            {
                return ResultOk(data);
            }

            return ResultErro(data, this.domainNotification.GetNotifications().Select(s => s.Value));
        }

        protected IActionResult Result()
        {
            if (this.IsValidOperation)
            {
                return ResultOk();
            }

            return ResultErro(this.domainNotification.GetNotifications().Select(s => s.Value));
        }

        protected IActionResult ResultOk()
        {
            return ResultOk("Sucesso!");
        }

        protected IActionResult ResultOk<TData>(TData data, IEnumerable<string> messages)
            where TData : class
        {
            return new JsonResult(new Response<TData>(data, true, HttpStatusCode.OK, messages));
        }

        protected IActionResult ResultOk<TData>(TData data)
            where TData : class
        {
            return new JsonResult(new Response<TData>(data, true, HttpStatusCode.OK));
        }

        private IActionResult ResultErro(IEnumerable<string> messages)
        {
            return ResultErro("Erro!", messages);
        }

        private IActionResult ResultErro<TData>(TData data, IEnumerable<string> messages)
            where TData : class
        {
            return new JsonResult(new Response<TData>(data, false, HttpStatusCode.OK, messages));
        }

        #endregion

        #region [IActionResult] async 

        protected Task<IActionResult> ResultOkAsync()
        {
            return Task.FromResult(ResultOk());
        }

        protected Task<IActionResult> ResultOkAsync<TData>(TData data, IEnumerable<string> messages)
            where TData : class
        {
            return Task.FromResult(ResultOk(data, messages));
        }

        protected Task<IActionResult> ResultOkAsync<TData>(TData data)
            where TData : class
        {
            return Task.FromResult(ResultOk(data));
        }

        protected Task<IActionResult> ResultErroAsync(IEnumerable<string> messages)
        {
            return Task.FromResult(ResultErro(messages));
        }

        protected Task<IActionResult> ResultErroAsync<TData>(TData data, IEnumerable<string> messages)
            where TData : class
        {
            return Task.FromResult(ResultErro(data, messages));
        }

        #endregion

        #region protected

        protected IEnumerable<DomainNotification> Notifications => this.domainNotification.GetNotifications();

        protected bool IsValidOperation => !this.domainNotification.HasNotification();

        protected void NotifyError(string code, string message)
        {
            this.mediator.RaiseEventAsync(new DomainNotification(code, message));
        }

        #endregion
    }
}
