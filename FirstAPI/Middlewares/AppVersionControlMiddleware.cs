﻿using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Bootcamp_Odev_2.Middlewares
{
    public class AppVersionControlMiddleware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new System.NotImplementedException();
        }
    }
}
