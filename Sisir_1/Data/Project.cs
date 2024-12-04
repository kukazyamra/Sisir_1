using System;
using System.Collections.Generic;

namespace Sisir_1.Data;

public partial class Project
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateOnly CreationDate { get; set; }

    public DateOnly StartDatePlan { get; set; }

    public DateOnly? StartDateFact { get; set; }

    public DateOnly EndDatePlan { get; set; }

    public DateOnly? EndDateFact { get; set; }

    public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; } = new List<ProjectEmployee>();
}
