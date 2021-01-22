using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CaptainHook.HttpApi.Client.ConsoleTestApp
{
    public class ClientDemoService : ITransientDependency
    {
        //private readonly IProfileAppService _profileAppService;

        //public ClientDemoService(IProfileAppService profileAppService)
        //{
            //_profileAppService = profileAppService;
        //}

        public Task RunAsync()
        {
            return Task.CompletedTask;
            //var output = await _profileAppService.GetAsync();
            //Console.WriteLine($"UserName : {output.UserName}");
            //Console.WriteLine($"Email    : {output.Email}");
            //Console.WriteLine($"Name     : {output.Name}");
            //Console.WriteLine($"Surname  : {output.Surname}");
        }
    }
}