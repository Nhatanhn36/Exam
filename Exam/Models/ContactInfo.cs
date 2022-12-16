using System;
using System.Collections.Generic;

namespace Exam.Models;

public partial class ContactInfo
{
    public int ContactId { get; set; }

    public string ContactName { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string? GroupName { get; set; }

    public DateTime? HireDate { get; set; }

    public DateTime? BirthDay { get; set; }
}
