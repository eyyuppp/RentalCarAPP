
using Azure.Core;
using Business.Abstract;
using Business.Concrete;
using DataAccess;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Runtime.ConstrainedExecution;

namespace WepAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Veri tabanýnda Tablo yok ise tabloyu oluþturur
            //var dbContext = new MyCarContext();
            //dbContext.Database.EnsureCreated();


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();



            //kendimiz ekliyoruz(ICarService hangi manager ile çalýþýcaðýný bilmiyor!,IcarDal hangi dal ile çalýþacaðýný bilmiyor)


            //AddSingleton:Projemiz ilk çalýþtýrdýðýmýz sýrada, servisin tek bir instance’ýný(Nesne) oluþturularak
            // AddScoped: Gelen her bir web requesti için bir instance oluþturur.
            //AddTransient: Her nesne çaðrýsýnda yeni bir instance.

            builder.Services.AddSingleton<IBrandService, BrandManager>();
            builder.Services.AddSingleton<ICarService, CarManager>();
            builder.Services.AddSingleton<IColorService, ColorManager>();
            builder.Services.AddSingleton<IUserService, UserManager>();

            builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();

            builder.Services.AddSingleton(new MyCarContext());






            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



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
        }
    }
}