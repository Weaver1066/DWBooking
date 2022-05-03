using DWBooking.Model;
using DWBooking.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWBooking
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddDbContext<DWBookingDbContext>();

            //Setup of services for Clients
            services.AddSingleton<GenericDbService<Client>, GenericDbService<Client>>();
            services.AddSingleton<ClientService, ClientService>();

            //Setup of services for Councelings
            services.AddSingleton<GenericDbService<Counceling>, GenericDbService<Counceling>>();
            services.AddSingleton<CouncelingService, CouncelingService>();

            //Setup of services for Employees
            services.AddSingleton<GenericDbService<Employee>, GenericDbService<Employee>>();
            services.AddSingleton<EmployeeService, EmployeeService>();

            //Setup of services for Events
            services.AddSingleton<GenericDbService<Event>, GenericDbService<Event>>();
            services.AddSingleton<EventService, EventService>();

            //Setup of services for Participants
            services.AddSingleton<GenericDbService<Participant>, GenericDbService<Participant>>();
            services.AddSingleton<ParticipantService, ParticipantService>();

            //Setup of services for Users
            services.AddSingleton<GenericDbService<User>, GenericDbService<User>>();
            services.AddSingleton<UserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
