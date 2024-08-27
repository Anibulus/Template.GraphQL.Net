using System.Security.Claims;
using HotChocolate.Authorization;

namespace Template.Api.GraphQL.Mutations;

public record TemplateInput(string? Name);

public record TemplatePayload(Template.Core.Entities.Template Template);

[ExtendObjectType(OperationTypeNames.Mutation)]
public class CreateTemplateMutation
{
    //[Authorize]
    public async Task<TemplatePayload> CreateTemplate(
        TemplateInput input, 
        TemplateContext context
    )
    {
        var Template = new Template.Core.Entities.Template
        {
            Name=input.Name?? "",
        };

        context.Templates.Add(Template);

        try
        {
            await context.SaveChangesAsync();
        }
        catch(Exception e)
        {
            throw new GraphQLException(e.Message);
        }
        
        return new TemplatePayload(Template);
    }
}


