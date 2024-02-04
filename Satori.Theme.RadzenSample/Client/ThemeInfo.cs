using System.Collections.Generic;
using Oqtane.Models;
using Oqtane.Themes;
using Oqtane.Shared;

namespace Satori.Theme.RadzenSample
{
    public class ThemeInfo : ITheme
    {
        public Oqtane.Models.Theme Theme => new Oqtane.Models.Theme
        {
            Name = "Satori RadzenSample",
            Version = "1.0.0",
            PackageName = "Satori.Theme.RadzenSample",
            ThemeSettingsType = "Satori.Theme.RadzenSample.ThemeSettings, Satori.Theme.RadzenSample.Client.Oqtane",
            ContainerSettingsType = "Satori.Theme.RadzenSample.ContainerSettings, Satori.Theme.RadzenSample.Client.Oqtane",
            Resources = new List<Resource>()
            {
		        // obtained from https://cdnjs.com/libraries
                new Resource { ResourceType = ResourceType.Stylesheet, Url = "https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.0/css/bootstrap.min.css", Integrity = "sha512-t4GWSVZO1eC8BM339Xd7Uphw5s17a86tIZIj8qRxhnKub6WoyhnrxeCIMeAqBPgdZGlCcG2PrZjMc+Wr78+5Xg==", CrossOrigin = "anonymous" },
                new Resource { ResourceType = ResourceType.Stylesheet, Url = "~/Theme.css" },
                new Resource { ResourceType = ResourceType.Script, Url = "https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.0/js/bootstrap.bundle.min.js", Integrity = "sha512-VK2zcvntEufaimc+efOYi622VN5ZacdnufnmX7zIhCPmjhKnOi9ZDMtg1/ug5l183f19gG1/cBstPO4D8N/Img==", CrossOrigin = "anonymous" },
                new Resource { ResourceType = ResourceType.Stylesheet, Url = "_content/Radzen.Blazor/css/material3-base.css" },
                new Resource { ResourceType = ResourceType.Script, Url = "_content/Radzen.Blazor/Radzen.Blazor.js", Level = ResourceLevel.Site }
            }

        };

    }
}
