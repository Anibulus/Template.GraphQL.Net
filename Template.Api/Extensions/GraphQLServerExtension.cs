using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Data.Filters.Expressions;
using Template.Api.GraphQL.Filter;
using Template.Api.GraphQL.Types;
using Template.Api.GraphQL.Mutations;

namespace Template.Api.Extensions;

public static class GraphQLServerExtension
{
    public static WebApplicationBuilder RegisterGraphQLServer(this WebApplicationBuilder builder)
    {
        builder
            .Services.AddGraphQLServer()
            //TODO make true of false depending the enviroment
            .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
            
            //Api
            .AddQueryType<Global>()
            .AddType<TemplateType>()
            .AddMutationType()
            .AddTypeExtension<CreateTemplateMutation>()
            .ConfigureResolverCompiler(c => c.AddService<TemplateContext>())
            //Tools
            .AddFiltering()
            .AddSorting()
            .AddProjections()
            .AddAuthorization()
            //Settings
            .AddConvention<IFilterConvention>(new FilterConvention(x => x.AddDefaults()))
            .AddConvention<IFilterConvention>(
                new FilterConventionExtension(descriptor =>
                {
                    descriptor.ArgumentName("filter");
                })
            )
            .AddConvention<IFilterConvention>(
                new FilterConventionExtension(x =>
                    x.AddProviderExtension(
                        new QueryableFilterProviderExtension(y =>
                            y.AddFieldHandler<QueryableStringInvariantContainsHandler>()
                        )
                    )
                )
            )
            //Addition
            .PublishSchemaDefinition(c =>
                c.SetName("Template").AddTypeExtensionsFromFile("./Stitching.graphql")
            );

        return builder;
    }
}
