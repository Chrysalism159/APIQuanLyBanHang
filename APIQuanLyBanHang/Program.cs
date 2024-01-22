
using APIQuanLyBanHang.HandleMapping;
using APIQuanLyBanHang.Helper;
using APIQuanLyBanHang.InterfaceRepo;
using APIQuanLyBanHang.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using APIQuanLyBanHang.Areas.Identity.Data;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
//Conection string
builder.Services.AddDbContext<APIQuanLyBanHang.Model.QlbdaTtsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConectionString") ?? throw new InvalidOperationException("Connection string 'ConectionString' not found.")));

builder.Services.AddDbContext<IdentityScaffordContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityScaffordContextConnection") ?? throw new InvalidOperationException("Connection string 'ConectionString' not found.")));

//builder.Services.AddDefaultIdentity<TaiKhoanNguoiDung>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<IdentityScaffordContext>();

//static IHostBuilder CreateHostBuilder(string[] args) =>
//        Host.CreateDefaultBuilder(args)
//            .ConfigureWebHostDefaults(webBuilder =>
//            {
//                webBuilder.UseUrls("http://*:5000"); // Specify your desired port
//                webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
//                {
//                    // Additional configuration if needed
//                });
//                webBuilder.ConfigureServices((hostingContext, services) =>
//                {
//                    // Configure services if needed
//                });
//                webBuilder.Configure((app) =>
//                {
//                    // Configure app if needed
//                });
//            });

// Add services to the container.
builder.Services.AddIdentity<TaiKhoanNguoiDung, IdentityRole>()
    .AddEntityFrameworkStores<IdentityScaffordContext>().AddDefaultTokenProviders();
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});
//update cors, cho phep angular truy cap api
builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 60000000;
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Quan ly ban hang", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
{
{
new OpenApiSecurityScheme
{
Reference = new OpenApiReference
{
Type=ReferenceType.SecurityScheme,
Id="Bearer"
}
},
new string[]{}
}
});
});


//Dang ki dich vu cho ca repository
builder.Services.AddTransient<ITheKhachHangRepository, TheKhachHangRepository>();
builder.Services.AddTransient<ISanPhamRepository, SanPhamRepository>();
builder.Services.AddTransient<IHoaDonRepository, HoaDonRepository>();
builder.Services.AddTransient<INhaCungCapRepository, NhaCungCapRepository>();
builder.Services.AddTransient<IPhieuNhapHangRepository, PhieuNhapHangRepository>();
builder.Services.AddTransient<ISanPhamChiNhanhRepository, SanPhamChiNhanhRepository>();
builder.Services.AddTransient<INhanVienRepository, NhanVienRepository>();
builder.Services.AddTransient<IQuanLyHinhAnhRepository, QuanLyHinhAnhRepository>();
builder.Services.AddTransient<IChiNhanhRepository, ChiNhanhRepository>();
builder.Services.AddTransient<ILoaiTheRepository, LoaiTheRepository>();
builder.Services.AddTransient<IAnhRepository, AnhRepository>();
//Taikhoan repo cua Db
builder.Services.AddTransient<ITaiKhoanRepository, TaiKhoanRepository>();
//Tai Khoan repo cua IdentityDbContext
builder.Services.AddTransient<ITaiKhoanRepositories, TaiKhoanRepositories>();
builder.Services.AddTransient<IPhieuChiTieuRepository, PhieuChiTieuRepository>();
builder.Services.AddTransient<IChiTietHoaDonRepository, ChiTietHoaDonRepository>();
//add mapper
var automapper = new MapperConfiguration(item => item.AddProfile(new MapProfile()));
IMapper map = automapper.CreateMapper();
builder.Services.AddSingleton(map);
//Dang ki phan quyen truy cap
//builder.Services.AddScoped<TaiKhoanRepo>();

//// Đăng ký ủy quyền
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("QuanLyPolicy", policy =>
//        policy.Requirements.Add(new XacThucNguoiDungRequirement()));
//});  \
//builder.Services.AddSingleton<IAuthorizationHandler, XacThucNguoiDungAuthorizationHandler>();
//CreateHostBuilder(args).Build().Run();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "wwwroot/productimg")),
    RequestPath = "/Resources"
});
app.UseCors("corspolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
