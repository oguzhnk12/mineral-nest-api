﻿using Application.Mapping.MappingProfiles;
using Application.Mapping.MappingServices;
using Application.Validators.UserValidators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserMappingProfile).Assembly);
            services.AddScoped<UserMappingService>();
            services.AddValidatorsFromAssemblyContaining<UserCreateRequestDtoValidator>();
            return services;
        }
    }
}