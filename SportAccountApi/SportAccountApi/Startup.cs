using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SportAccountApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Text;

namespace SportAccountApi
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
            // for localhost (development)
            //string connection = Configuration.GetConnectionString("DefaultConnection");
            
            // for prodaction 
            string connection = "workstation id=SportAccount.mssql.somee.com;packet size=4096;user id=dipaber974_SQLLogin_2;pwd=k4w6zt1rlq;data source=SportAccount.mssql.somee.com;persist security info=False;initial catalog=SportAccount";

            services.AddCors(option =>
                    option.AddDefaultPolicy(builder => 
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod() 
                    )

                ); // добавляем сервисы CORS

            services.AddControllers();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection)); 

            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SportAccountApi", Version = "v1" });

            });
            
            services.AddSwaggerGen(options => {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                    In = ParameterLocation.Header,
                    Name = "Authorization", 
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                         .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     ClockSkew = TimeSpan.Zero
                 };
             });

            services.AddHttpContextAccessor();
            
            #region user manager 
            //services.AddIdentity<IdentityUser, IdentityRole>(options =>
            //{
            //    options.User.RequireUniqueEmail = false;
            //})
            //.AddEntityFrameworkStores<DataContext>()
            //.AddDefaultTokenProviders();

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //                .AddEntityFrameworkStores<DataContext>()
            //                .AddDefaultTokenProviders();

            //services.AddDefaultIdentity<IdentityUser>().AddUserStore<DataContext>();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SportAccountApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
              .AllowAnyMethod()
              .AllowAnyHeader()
              .SetIsOriginAllowed(origin => true) // allow any origin
              .AllowCredentials()); // allow credentials

            //app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AlloAnC);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
