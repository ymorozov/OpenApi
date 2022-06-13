using OpenApiPoc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    //Using 'type' as property that defines field type
    c.SelectDiscriminatorNameUsing(_ => "type");

    // Map value from 'type' property object type 
    c.SelectDiscriminatorValueUsing(subType =>
    {
        if (subType.IsSubclassOf(typeof(BaseField)))
        {
            return subType.Name.ToLowerInvariant().Split("field")[0];
        }

        return null;
    });

    c.UseAllOfForInheritance();
    c.UseOneOfForPolymorphism();

    // Detect subtypes for a base type
    c.SelectSubTypesUsing(baseType =>
        typeof(Program).Assembly.GetTypes().Where(type => type.IsSubclassOf(baseType))
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();


