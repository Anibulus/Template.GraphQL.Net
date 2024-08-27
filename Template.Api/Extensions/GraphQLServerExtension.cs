using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Data.Filters.Expressions;
using Template.Api.GraphQL.Filter;

namespace Template.Api.Extensions;

public static class GraphQLServerExtension
{
  public static WebApplicationBuilder RegisterGraphQLServer(this WebApplicationBuilder builder)
  {
    builder.Services
    .AddGraphQLServer()
    //TODO make true of false depending the enviroment
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
    .AddConvention<IFilterConvention>(new FilterConvention(x =>
        x.AddDefaults()))
    .AddConvention<IFilterConvention>(new FilterConventionExtension(descriptor =>
    {
      descriptor.ArgumentName("filter");
    }))
    .AddQueryType()
    .AddTypeExtension<Global>()
    //.AddMutationType()
    //    .AddTypeExtension<CreateMemberMutation>()
    .ConfigureResolverCompiler(c => c.AddService<TemplateContext>())
    .AddFiltering()
    .AddSorting()
    .AddProjections()
    .AddAuthorization()
    .AddConvention<IFilterConvention>(new 
                FilterConventionExtension(x => x.AddProviderExtension(
                    new QueryableFilterProviderExtension(y => y.AddFieldHandler<QueryableStringInvariantContainsHandler>()))));

    //.PublishSchemaDefinition(c => c.SetName("template").AddTypeExtensionsFromFile("./Stitching.graphql"));
    
    return builder;
  }
}
