namespace ExercicioLinq.Entities;

public class Employee
{
    public Employee(string name, string email, double salary)
    {
        Name = name;
        Email = email;
        Salary = salary;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public double Salary { get; private set; }
}
