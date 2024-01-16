using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CW2_.Models;

public partial class UserTable
{
   
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string AboutMe { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string Units { get; set; } = null!;

    public string ActivtiyPreference { get; set; } = null!;

    public string Height { get; set; } = null!;

    public string Weight { get; set; } = null!;

    public string Birthday { get; set; } = null!;

    public string MarketingLanguage { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Admin { get; set; }

    public bool Archive { get; set; }

    internal static object Select(Func<object, object> value)
    {
        throw new NotImplementedException();
    }
}
