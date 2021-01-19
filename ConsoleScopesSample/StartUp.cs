using System;

namespace ConsoleScopesSample
{
    public interface IOperation
    {
        string OperationId { get; }
    }

    public interface ITransientOperation : IOperation
    {
    }

    public interface IScopedOperation : IOperation
    {
    }

    public interface ISingletonOperation : IOperation
    {
    }

    public class DefaultOperation :
        ITransientOperation,
        IScopedOperation,
        ISingletonOperation
    {
        public string OperationId { get; } = Guid.NewGuid().ToString()[^4..];
    }

    public class OperationLogger
    {
        private readonly ITransientOperation transientOperation;
        private readonly IScopedOperation scopedOperation;
        private readonly ISingletonOperation singletonOperation;

        public OperationLogger(ITransientOperation transientOperation, IScopedOperation scopedOperation, ISingletonOperation singletonOperation) =>
            (this.transientOperation, this.scopedOperation, this.singletonOperation) = (transientOperation, scopedOperation, singletonOperation);

        public void LogOperations(string scope)
        {
            LogOperation(transientOperation, scope, "Always different");
            LogOperation(scopedOperation, scope, "Changes only with scope");
            LogOperation(singletonOperation, scope, "Always the same");
        }

        private static void LogOperation<T>(T operation, string scope, string message) where T : IOperation =>
            Console.WriteLine($"{scope}: {typeof(T).Name,-19} [ {operation.OperationId}...{message,-23} ]");
    }
}