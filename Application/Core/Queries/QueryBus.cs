using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DataExplorer.Application.Core.Queries
{
    public class QueryBus: IQueryBus
    {
        public static IKernel Kernel;
        private readonly IQueryLogger _logger;

        public QueryBus(IQueryLogger logger)
        {
            _logger = logger;
        }

        public TResult Execute<TResult>(IQuery<TResult> query)
        {
            _logger.LogExecuting(query);

            var handlerType = typeof (IQueryHandler<,>)
                .MakeGenericType(query.GetType(), typeof (TResult));

            dynamic handler = Kernel.Get(handlerType);

            var result = handler.Execute((dynamic) query);

            _logger.LogExecuted(query);

            return result;
        }
    }
}
