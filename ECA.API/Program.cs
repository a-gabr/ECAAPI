using ECA.API.Helper;
using ECA.API.Models;
using ECA.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// DbContext
var connectionString = builder.Configuration.GetConnectionString(name: "DefaultConnection");
var hrConnectionString = builder.Configuration.GetConnectionString(name: "HrConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));
builder.Services.AddDbContext<IdentityDataContext>(options =>
options.UseSqlServer(connectionString));
builder.Services.AddDbContext<HrDbContext>(options =>
options.UseSqlServer(hrConnectionString));
// JWT
builder.Services.Configure<Jwt>(builder.Configuration.GetSection("Jwt"));
// Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IdentityDataContext>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Repository Classes
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<IComputerUserService, ComputerUserService>();
builder.Services.AddTransient<ICustomsDealerService, CustomsDealerService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IMasterRepService, MasterRepService>();
builder.Services.AddTransient<ISecurityUserService, SecurityUserService>();
// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
// CORS
builder.Services.AddCors();
//E-mail
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
// Twilio
builder.Services.Configure<TwilioSettings>(builder.Configuration.GetSection("Twilio"));
builder.Services.AddTransient<ISMSService,SMSService>();
builder.Services.AddTransient<IWhatsAppService, WhatsAppService>();
builder.Services.AddTransient<IMailService, MailService>();
// JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
        ClockSkew = TimeSpan.Zero // once  el token expire msh hydy mohla
    };
})
    ;
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", info: new OpenApiInfo
    {
        Version = "240416",
        Title = "ECA API",
        Description = "Egyptian Customs Authority APIs",
        TermsOfService = new Uri(uriString: "https://customs.gov.eg/"),
        Contact = new OpenApiContact
        {
            Name = "Dalia El-Ghitany",
            Email = "d.elghitany@customs.gov.eg"
        },
        License = new OpenApiLicense
        {
            Name = "ECA License",
            Url = new Uri(uriString: "https://customs.gov.eg/")
        }
    });
    options.AddSecurityDefinition(name: "Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT key"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// CORS
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthentication(); // use AUTHENTICATION
app.UseAuthorization();

app.MapControllers();

app.Run();
