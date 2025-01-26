using StrategyPattern.Interfaces;
using StrategyPattern.PaymentStrategies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<CreditCardPaymentStrategy>();
builder.Services.AddScoped<PayPalPaymentStrategy>();

builder.Services.AddScoped<IDictionary<string, IPaymentStrategy>>(serviceProvider =>
        new Dictionary<string, IPaymentStrategy>
        {
            { "CreditCard", serviceProvider.GetService<CreditCardPaymentStrategy>() },
            { "PayPal", serviceProvider.GetService<PayPalPaymentStrategy>() }
        });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
