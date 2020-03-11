using System.Threading;
using System.Threading.Tasks;
using Camelot.Services.Operations.Interfaces;

namespace Camelot.Services.Operations.Implementations
{
    public class MoveOperation : OperationBase
    {
        private readonly IOperation _copyOperation;
        private readonly IOperation _deleteOperation;

        public MoveOperation(IOperation copyOperation, IOperation deleteOperation)
        {
            _copyOperation = copyOperation;
            _deleteOperation = deleteOperation;
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: support parallel copy and delete
            await _copyOperation.RunAsync(cancellationToken);
            await _deleteOperation.RunAsync(cancellationToken);
        }
    }
}