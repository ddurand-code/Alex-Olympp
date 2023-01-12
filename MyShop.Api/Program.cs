using MyShop.Domain.Commands;
using MyShop.Domain.Ports.Commands;
using MyShop.Domain.Ports.Queries;
using MyShop.Domain.Ports.Repositories;
using MyShop.Domain.Queries;
using MyShop.Infrastructure.Handlers;
using MyShop.Infrastructure.Repositories;
using MyShop.Infrastructure.Routers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IReadRepository, ReadRepository>();
builder.Services.AddSingleton<IWriteRepository, WriteRepository>();

builder.Services.AddSingleton<QueryRouter>();
builder.Services.AddSingleton<CommandRouter>();

builder.Services.AddSingleton<MyShopQueryHandler>();
builder.Services.AddSingleton<MyShopCommandHandler>();

builder.Services.AddSingleton<IQueryRouter>(p =>
{
    var queryRouter = p.GetRequiredService<QueryRouter>();
    var handler = p.GetRequiredService<MyShopQueryHandler>();

    queryRouter.AddQueryHandler<GetAllOffersQuery>(handler);
    return queryRouter;
});

builder.Services.AddSingleton<ICommandRouter>(p =>
{
    var commandRouter = p.GetRequiredService<CommandRouter>();
    var handler = p.GetRequiredService<MyShopCommandHandler>();

    commandRouter.AddCommandHandler<CreateOfferCommand>(handler);
    commandRouter.AddCommandHandler<UpdateOfferCommand>(handler);
    return commandRouter;
});

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
