namespace AzureFunctionAppWithDIAndScrutor
{
    public class SimpleDecorator : ISomeService
    {
        private readonly ISomeService decoratee;

        public SimpleDecorator(ISomeService decoratee)
        {
            this.decoratee = decoratee;
        }

        public void DoSomething()
        {
            decoratee.DoSomething();
        }
    }
}