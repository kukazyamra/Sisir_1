using System;
using System.Collections.Generic;

namespace Sisir_1.Data;

public partial class ProjectEmployee
{
    public int ProjectId { get; set; }

    public int EmployeeId { get; set; }

    public bool IsResponsible { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
