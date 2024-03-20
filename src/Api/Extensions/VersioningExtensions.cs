using Asp.Versioning;
using static Api.Constants.ApiConstants;

namespace Api.Extensions;

public static class VersioningExtensions
{
    public static IServiceCollection AddVersioning(this IServiceCollection services)
    {
        var defaultVersion = new ApiVersion(1, 0);
        
        services
            .AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = defaultVersion;
                options.ApiVersionReader = GetApiVersionReader();
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = GroupNameFormat;
                options.SubstituteApiVersionInUrl = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = defaultVersion;
                options.ApiVersionParameterSource = GetApiVersionReader();
            });

        return services;
    }

    private static IApiVersionReader GetApiVersionReader()
    {
        return ApiVersionReader.Combine(
            new UrlSegmentApiVersionReader(),
            new QueryStringApiVersionReader(VersionHeaderName),
            new HeaderApiVersionReader(VersionHeaderName),
            new MediaTypeApiVersionReader(VersionHeaderName));
    }
}