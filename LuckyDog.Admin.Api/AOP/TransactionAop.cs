using Castle.DynamicProxy;

namespace LuckyDog.Admin.Api.AOP
{
    public class TransactionAop : IInterceptor
    {
        public TransactionAop() 
        {
        }
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine(" Intercepter has been implemented.");
            invocation.Proceed();
        }
    }
}
