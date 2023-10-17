using FinTechApplication.Infrastructure;
using FinTechApplication.Infrastructure.Database;
using FinTechApplication.Infrastructure.Repositories.Implementation;
using FinTechApplication.Infrastructure.Repositories.Interface;
using FinTechApplication.Infrastructure.Settings;
using FinTechApplication.Services.Implementation;
using FinTechApplication.Services.Interface;
using FinTechApplication.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FinTechApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            builder.Services.AddAuthentication();

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
           {
               options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
           });
            //builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.Configure<JWTData>(configuration.GetSection(JWTData.Data));
            builder.Services.AddControllers();
            //     var connectionString = builder.Configuration.GetConnectionString("connectionstring");
            //builder.Services.AddDbContext<AppDbContext>(options =>
            //options.UseSqlServer(connectionString));
            //builder.Services.AddIdentity<AppUser, IdentityRole>()
            //    .AddUserStore<AppUser>();
            //    builder.Services.AddIdentity<AppUser, IdentityRole>()
            //.AddEntityFrameworkStores<AppDbContext>()
            //.AddDefaultTokenProviders();


            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddTransient<IAccountService, AccountService>();
            builder.Services.AddTransient<ITransactionService, TransactionService>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // add jwt authentication

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("JWTConfigurations:SecretKey").Value)),
                    ValidateIssuer = true,
                    ValidIssuer = configuration.GetSection("JWTConfigurations:Issuer").Value,
                    ValidateAudience = true,
                    ValidAudience = configuration.GetSection("JWTConfigurations:Audience").Value
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}