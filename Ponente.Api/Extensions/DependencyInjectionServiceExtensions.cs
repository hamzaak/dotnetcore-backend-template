using Microsoft.Extensions.DependencyInjection;
using Ponente.Business.Abstract;
using Ponente.Business.Concrete;
using Ponente.Data.Abstract;
using Ponente.Data.Concrete.Ef;

namespace Ponente.Api.Extensions
{
    public static class DependencyInjectionServiceExtensions
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IDirectoryService, DirectoryService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransactionService, TransactionService>();

            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<ICurrencyRepository, EfCurrencyRepository>();
            services.AddScoped<IDirectoryRepository, EfDirectoryRepository>();
            services.AddScoped<IAccountRepository, EfAccountRepository>();
            services.AddScoped<ITransactionRepository, EfTransactionRepository>();

            return services;
        }
    }
}
