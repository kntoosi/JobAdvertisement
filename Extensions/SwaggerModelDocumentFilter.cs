using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CrouseServiceEmployment.Extensions
{
    public class SwaggerModelDocumentFilter<T> : Swashbuckle.AspNetCore.SwaggerGen.IDocumentFilter where T : class
    {
        public void Apply(OpenApiDocument openapiDoc, DocumentFilterContext context)
        {
            context.SchemaGenerator.GenerateSchema(typeof(T), context.SchemaRepository);
        }

     
    }

}
