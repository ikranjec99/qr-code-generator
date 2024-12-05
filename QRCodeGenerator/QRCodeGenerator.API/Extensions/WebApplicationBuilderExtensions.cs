namespace QRCodeGenerator.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplication ConfigureWebApplication(this WebApplicationBuilder builder)
    {
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (builder.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();

        return app;
    }
}
