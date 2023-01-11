using MyShop.Domain.Ports.Queries;
using MyShop.Domain.Queries;
using MyShop.Infrastructure.Handlers;
using MyShop.Infrastructure.Routers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<QueryRouter>();
builder.Services.AddSingleton<CommandRouter>();

builder.Services.AddSingleton<MyShopQueryHandler>();

builder.Services.AddSingleton<IQueryRouter>(p =>
{
    var queryRouter = p.GetRequiredService<QueryRouter>();
    var handler = p.GetRequiredService<MyShopQueryHandler>();

    queryRouter.AddQueryHandler<GetAllOffersQuery>(handler);
    return queryRouter;
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
