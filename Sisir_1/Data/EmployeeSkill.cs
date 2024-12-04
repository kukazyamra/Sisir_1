using System;
using System.Collections.Generic;

namespace Sisir_1.Data;

public partial class EmployeeSkill
{
    public int EmployeeId { get; set; }

    public int SkillId { get; set; }

    public int? SkillLevel { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}
