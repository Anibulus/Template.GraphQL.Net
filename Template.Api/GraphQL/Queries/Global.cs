namespace Template.Api.GraphQL.Queries
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class Global
    {
        //[Authorize]
        //[UseProjection]
        //public Task<Member> GetMe(ClaimsPrincipal claimsPrincipal, [Service] IMemberService _memberService, TemplateContext context)
        //{
        //var userIdStr = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

        //var user = _memberService.GetMe(userIdStr);

        //    return user;
        //}

    }
}
