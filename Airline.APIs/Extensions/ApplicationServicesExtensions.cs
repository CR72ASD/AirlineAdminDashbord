
using AirLine.APIs.Erorrs;
using AirLine.Core.Repositories;
using AirLine.Core.Services;
using AirLine.Repositories.Data;
using AirLine.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace AirLine.APIs.Extensions
{
	public static class ApplicationServicesExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped(typeof(ITokenService), typeof(TokenService));

			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.Configure<ApiBehaviorOptions>(options =>
			{
				options.InvalidModelStateResponseFactory = actionContext =>
				{
					var errors = actionContext.ModelState.Where(M => M.Value.Errors.Count() > 0)
														 .SelectMany(M => M.Value.Errors)
														 .Select(E => E.ErrorMessage).ToArray();

					var errorResponse = new ApiValidationErrorResponse()
					{
						Errors = errors
					};

					return new BadRequestObjectResult(errorResponse);
				};
			});
			return services;
		}
	}
}
