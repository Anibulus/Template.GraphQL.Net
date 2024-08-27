using Template.Core.Entities;

namespace Template.Api.GraphQL.Types;

public class TemplateType : ObjectType<Template.Core.Entities.Template>
{
    protected override void Configure(IObjectTypeDescriptor<Template.Core.Entities.Template> descriptor)
    {
        descriptor
            .Field(st => st.Childs)
            .ResolveWith<TemplateTypeResolver>(x => x.GetServiceTemplate(default!, default!))
            .UseDbContext<TemplateContext>();
    }

    private class TemplateTypeResolver
    {
        public IQueryable<Template.Core.Entities.Template> GetServiceTemplate(
            [Parent] Template.Core.Entities.Template Template,
            [ScopedService] TemplateContext context
        )
        {
            return context.Templates.Where(x => x.TemplateId == Template.Id);
        }
    }
}
