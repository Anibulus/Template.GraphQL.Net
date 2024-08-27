using System.Security.Claims;
using HotChocolate.Authorization;

namespace Template.Api.GraphQL.Queries;

[ExtendObjectType(OperationTypeNames.Query)]
public class Global
{
    //[Authorize]
    //[UseProjection]
    public async Task<Template.Core.Entities.Template> GetTemplate(
        ClaimsPrincipal claimsPrincipal,
        //[Service] ITemplateService _templateService,
        TemplateContext context
    )
    {
        //var userIdStr = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        //Validate your stuff
        var result = new Template.Core.Entities.Template();

        return result;
    }
}
