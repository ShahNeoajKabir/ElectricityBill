using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ModelClass.ViewModel;
using Newtonsoft.Json.Serialization;
using SecurityBLLManager;
using Service.Electricity.Handler;
using Service.Electricity.MailConfig;

namespace Service.Electricity
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
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });
            services.AddControllers();
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection")), ServiceLifetime.Transient);
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = Configuration["JwtTokenSetting:Issuer"],
            //            ValidAudience = Configuration["JwtTokenSetting:Issuer"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtTokenSetting:Key"]))
            //        };
            //    });
            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
            services.AddSingleton<IMailer, Mailer>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", null);
                //var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //var xmlPath = Path.Combine(basePath, "SwaggerProject.xml");
                //c.IncludeXmlComments(xmlPath);
            });


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.Configure<JwtTokenSetting>(Configuration.GetSection("JwtTokenSetting"));
            services.AddScoped<IUserBLLManager, UserBLLManager>();
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            services.AddScoped<IZoneBLLManager, ZoneBLLManager>();
            services.AddScoped<ISupportBLLManager, SupportBLLManager>();
            services.AddScoped<IRoleBLLManager, RoleBLLManager>();
            services.AddScoped<INoticeBLLManager, NoticeBLLManager>();
            services.AddScoped<IMeterBLLManager, MeterBLLManager>();
            services.AddScoped<ICustomerBLLManager, CustomerBLLManager>();
            services.AddScoped<ISecurityBLLmanager, SecurityBLLManager.SecurityBLLManager>();
            services.AddScoped<IMeterAssignBLLmanager, MeterAssignBLLmanager>();
            services.AddScoped<IUserRoleBLLManager, UserRoleBLLManager>();
            services.AddScoped<IZoneAssignBLLManager, ZoneAssignBLLManager>();
            services.AddScoped<IUnitPriceBLLManager, UnitPriceBLLManager>();
            services.AddScoped<IMeterReadingBLLManager, MeterReadingBLLManager>();
            services.AddScoped<IBillTableBLLManager, BillTableBLLManager>();
            services.AddScoped<ICardBLLManager, CardBLLManager>();
            services.AddScoped<IMobileBankingBLLmanager, MobileBankingBLLmanager>();
            services.AddScoped<IRolePermissionBLLManager, RolePermissionBLLManager>();
            services.AddScoped<IPaymentBLLManager, PaymentBLLManager>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseMiddleware<JwtMiddleware>();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
