using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Serialization;
using HotChocolate.Execution.Configuration;
using HotChocolate.Stitching;
using HotChocolate.Data.Filters.Expressions;
using Template.Api.GraphQL.Filter;
using Template.Api.GraphQL.Types;
using Template.Api.GraphQL.Mutations;
using HotChocolate.Data.Filters;

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
            //Tools
            .AddFiltering()
            .AddSorting()
            .AddProjections()
            .AddAuthorizationCore()
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
            .InitializeOnStartup()
            .PublishSchemaDefinition(c =>
                c.SetName("Template").AddTypeExtensionsFromFile("./Stitching.graphql")
            );

        return builder;
    }
}
