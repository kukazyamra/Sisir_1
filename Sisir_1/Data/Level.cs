﻿using System;
using System.Collections.Generic;

namespace Sisir_1.Data;

public partial class Level
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Coefficient { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
