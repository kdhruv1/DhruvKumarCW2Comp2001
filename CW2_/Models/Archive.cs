using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CW2_.Models;

public partial class Archive
{
    public int? ArchiveId { get; set; }
    public int? UserId { get; set; }


    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? AboutMe { get; set; }

    public string? Location { get; set; }

    public string? Units { get; set; }

    public string? ActivtiyPreference { get; set; }

    public string? Height { get; set; }

    public string? Weight { get; set; }

    public string? Birthday { get; set; }

    public string? MarketingLanguage { get; set; }

     string? Password { get; set; }

    public bool Admin { get; set; }

    public bool Archive1 { get; set; }
}
