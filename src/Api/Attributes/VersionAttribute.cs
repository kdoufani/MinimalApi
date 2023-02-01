namespace Api.Attributes;

using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Routing;

[AttributeUsage(AttributeTargets.Class)]
public class VersionAttribute : Attribute, IRouteTemplateProvider,
    IApiDescriptionGroupNameProvider, IApiDescriptionVisibilityProvider
{
    public VersionAttribute(string versionNumber)
    {
        VersionNumber = versionNumber;
        GroupName = $"v{versionNumber}";
    }

    public string GroupName { get; set; }

    public bool IgnoreApi { get; set; }

    public string Template => $"/api/v{VersionNumber}/[controller]";
    
    public int? Order { get; set; }


    public string Name { get; set; }

    public string VersionNumber { get; set; }


}

