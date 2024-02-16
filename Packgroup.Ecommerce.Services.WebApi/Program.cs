using AutoMapper;
using Packgroup.Ecommerce.Aplication.Interface;
using Packgroup.Ecommerce.Aplication.Main;
using Packgroup.Ecommerce.Domain.Core;
using Packgroup.Ecommerce.Domain.Interface;
using Packgroup.Ecommerce.Infraestructura.Data;
using Packgroup.Ecommerce.Infraestructura.Repository;
using Packgroup.Ecommerce.Transversal.Common;
using Packgroup.Ecommerce.Transversal.Mapper;
using PackGroup.Ecommerce.Infrastructura.Interface;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//AutoMapper
builder.Services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));

builder.Services.AddSingleton<IConectionFactory, ConectionFactory>();
builder.Services.AddScoped<ICustomerApplication, CustomerApplication>();
builder.Services.AddScoped<ICustomerDomain, CustomerDomain>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddControllers();
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
