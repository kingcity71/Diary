using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diary.Data;
using Diary.Data.Repository;
using Diary.Identity;
using Diary.Interfaces;
using Diary.Services;
using Diary.WebApp.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Diary.WebApp
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
            services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();

            services.AddScoped<IMapper, MapperHelper>();

            services.AddSignalR();
            services.AddOptions();
            
            services.AddDbContext<Context>();
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DiaryIdentity")));
            
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IScoreRepository, ScoreRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStudentService, UserService>();
            services.AddScoped<IParentService, UserService>();
            services.AddScoped<ITeacherService, UserService>();
            services.AddScoped<IPropertyValueService, PropertyValueService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IScoreService, ScoreService>();

            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IScheduleService, ScheduleService>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //        .AddJwtBearer(options =>
            //        {
            //            options.RequireHttpsMetadata = false;
            //            options.TokenValidationParameters = new TokenValidationParameters
            //            {
            //                // укзывает, будет ли валидироваться издатель при валидации токена
            //                ValidateIssuer = true,
            //                // строка, представляющая издателя
            //                ValidIssuer = AuthOptions.ISSUER,

            //                // будет ли валидироваться потребитель токена
            //                ValidateAudience = true,
            //                // установка потребителя токена
            //                ValidAudience = AuthOptions.AUDIENCE,
            //                // будет ли валидироваться время существования
            //                ValidateLifetime = true,

            //                // установка ключа безопасности
            //                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            //                // валидация ключа безопасности
            //                ValidateIssuerSigningKey = true,
            //            };
            //        });


            services.AddControllersWithViews().AddRazorRuntimeCompilation();
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<ChatHub>("/chat");
            });

            
        }
    }
}
