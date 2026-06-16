using Core.Interfaces;
using GymManagementSystem.Helper;
using GymManagementSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Repository.Context;
using Repository.Repository;
using Service.Interfaces;
using Service.Services;
using System.Text;

namespace GymManagementSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<GymManagementSystemDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("GymManagementSystemConnection")));

            builder.Services.AddAutoMapper(typeof(MappingProfiles));

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));

            builder.Services.AddScoped(typeof(IMemberService), typeof(MemberService));
            builder.Services.AddScoped(typeof(ITrainerService), typeof(TrainerService));
            builder.Services.AddScoped(typeof(IMembershipPlanService), typeof(MembershipPlanService));
            builder.Services.AddScoped(typeof(IMembershipSubscriptionService), typeof(MembershipSubscriptionService));
            builder.Services.AddScoped(typeof(IPaymentService), typeof(PaymentService));



            builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"]
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            { 
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using(var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var LoggerFactory = service.GetRequiredService<ILoggerFactory>();
                try
                {
                    var dbContext = service.GetRequiredService<GymManagementSystemDbContext>();
                    await dbContext.Database.MigrateAsync();
                    await GymManagementSystemDataSeeding.SeedAsync(dbContext);
                }
                catch (Exception ex)
                {
                    var logger = LoggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "Error happen when migration!");
                }
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}