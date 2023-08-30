using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.Models;
using Project.Models.DataAccess;
using Project.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project
{
    public class Startup
    {
        private readonly IConfiguration configure;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration _configure)
        {
            configure = _configure;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(configure.GetConnectionString("MyConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<IActiveIngredientRepository, ActiveIngredientRepository>();
            services.AddScoped<IPatientAllergyRepository, PatientAllergyRepository>();
            services.AddScoped<IHighestQualRepository, HighestQualRepository>();
            services.AddScoped<IDispLineAlertRepository, DispLineAlertRepository>();
            services.AddScoped<IPrescrLineAlertRepository, PrescrLineAlertRepository>();
            
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IConditionDiagnosisRepository, ConditionDiagnosisRepository>();
            services.AddScoped<IContraIndicationRepository, ContraIndicationRepository>();
            services.AddScoped<IDispenseDetailsRepository, DispenseDetailsRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDosageFormRepository, DosageFormRepository>();
            services.AddScoped<IMedActiveIngredientRepository, MedActiveIngredientRepository>();
            services.AddScoped<IMedicalHistoryRepository, MedicalHistoryRepository>();
            services.AddScoped<IMedicationRepository, MedicationRepository>();
            services.AddScoped<IMedicationTakingRepository, MedicationTakingRepository>();
            services.AddScoped<IMedInteractionRepository, MedInteractionRepository>();
            services.AddScoped<IMedPracticeRepository, MedPracticeRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientConditionRepository, PatientConditionRepository>();
            services.AddScoped<IPharmacistRepository, PharmacistRepository>();
            services.AddScoped<IPharmacyRepository, PharmacyRepository>();
            services.AddScoped<IPrescriptionLineRepository, PrescriptionLineRepository>();
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<ISurburbRepository, SurburbRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();

            services.AddScoped<IActiveIngrStrengthRepository, ActiveIngrStrengthRepository>();
            services.AddScoped<ILineActiveIngreRepository, LineActiveIngreRepository>();
            services.AddScoped<IstrengthRepository, StrengthRepository>();
          
      
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
