namespace ScrutorConsoleApp
{
    public class LoggingDecorator : ITestService
    {
        private ITestService _service;

        public LoggingDecorator(ITestService service) 
        {
            _service = service;
        }

        public void DoWork()
        {
            Console.WriteLine("Will do some work!");
            _service.DoWork();
            Console.WriteLine("Work is finished!");
        }
    }

}
