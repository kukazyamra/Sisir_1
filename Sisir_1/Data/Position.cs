using System;
using System.Collections.Generic;

namespace Sisir_1.Data;

public partial class Position
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Salary { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public override string ToString()
    {
        return Name; // Возвращаем название должности
    }
}
