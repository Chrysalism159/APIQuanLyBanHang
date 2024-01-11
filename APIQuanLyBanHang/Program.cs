
using APIQuanLyBanHang.HandleMapping;
using APIQuanLyBanHang.Helper;
using APIQuanLyBanHang.InterfaceRepo;
using APIQuanLyBanHang.Model;
using APIQuanLyBanHang.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//Conection string
builder.Services.AddDbContext<APIQuanLyBanHang.Model.QlbdaTtsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConectionString") ?? throw new InvalidOperationException("Connection string 'ConectionString' not found.")));

// Add services to the container.
builder.Services.AddIdentity<TaiKhoanNguoiDung, IdentityRole>()
    .AddEntityFrameworkStores<QlbdaTtsContext>().AddDefaultTokenProviders();
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
builder.Services.AddTransient<ITheKhachHangRepo, TheKhachHangRepo>();
builder.Services.AddTransient<ISanPhamRepo, SanPhamRepo>();
builder.Services.AddTransient<IHoaDonRepo, HoaDonRepo>();
builder.Services.AddTransient<IPhieuNhapHangRepo, PhieuNhapHangRepo>();
builder.Services.AddTransient<INhanVienRepo, NhanVienRepo>();
builder.Services.AddTransient<IQuanLyHinhAnhRepo, QuanLyHinhAnhRepo>();
builder.Services.AddTransient<ILoaiTheRepo, LoaiTheRepo>();
builder.Services.AddTransient<IAnhRepo, AnhRepo>();
builder.Services.AddTransient<ITaiKhoanRepository, TaiKhoanRepository>();

//add mapper
var automapper = new MapperConfiguration(item => item.AddProfile(new MapProfile()));
IMapper map = automapper.CreateMapper();
builder.Services.AddSingleton(map);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
