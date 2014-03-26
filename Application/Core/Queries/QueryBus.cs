using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Presentation;
using Ninject;

namespace DataExplorer.Application.Core.Queries
{
    public class QueryBus: IQueryBus
    {
        public static IKernel Kernel;
        private readonly IQueryLogger _logger;
        private readonly IExceptionDialogService _dialogService;

        public QueryBus(
            IQueryLogger logger,
            IExceptionDialogService dialogService)
        {
            _logger = logger;
            _dialogService = dialogService;
        }

        public TResult Execute<TResult>(IQuery<TResult> query)
        {
            try 
            {
                _logger.LogExecuting(query);

                var handlerType = typeof (IQueryHandler<,>)
                    .MakeGenericType(query.GetType(), typeof (TResult));

                dynamic handler = Kernel.Get(handlerType);

                var result = handler.Execute((dynamic) query);

                _logger.LogExecuted(query);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);

                _dialogService.Show(ex);
            }

            return default(TResult);
        }
    }
}
