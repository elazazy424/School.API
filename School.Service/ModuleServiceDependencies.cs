﻿using Microsoft.Extensions.DependencyInjection;
using School.Service.Implementations;
using School.Service.Interfaces;

namespace School.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            return services;
        }
    }
}
