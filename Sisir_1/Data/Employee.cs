using System;
using System.Collections.Generic;

namespace Sisir_1.Data;

public partial class Employee
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateOnly Birthdate { get; set; }

    public string PassportSeries { get; set; } = null!;

    public string PassportNumber { get; set; } = null!;

    public string IssuedBy { get; set; } = null!;

    public DateOnly IssueDate { get; set; }

    public string RegistrationAddress { get; set; } = null!;

    public string ResidenceAddress { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public string? Telegram { get; set; }

    public int PositionId { get; set; }

    public int? LevelId { get; set; }

    public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; } = new List<EmployeeSkill>();

    public virtual Level? Level { get; set; }

    public virtual Position Position { get; set; } = null!;

    public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; } = new List<ProjectEmployee>();
    public override string ToString()
    {
        // Get the first letter of the Name and Patronymic (if not null)
        char firstNameInitial = Name.Length > 0 ? Name[0] : ' ';
        char? patronymicInitial = Patronymic?.Length > 0 ? Patronymic[0] : null;

        // Get the Position name (assuming Position has a property called Name)
        string positionName = Position != null ? Position.ToString() : "Unknown Position";
        if (patronymicInitial != null) return $"{Surname} {firstNameInitial}.{patronymicInitial}. - {positionName}";
        else return $"{Surname} {firstNameInitial}. - {positionName}";
        // Construct the desired format

    }

}
