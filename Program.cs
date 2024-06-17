using ExercicioLinq.Entities;

const string csvPath = "./employees.csv";
List<Employee> employees = [];

using (StreamReader sr = File.OpenText(csvPath))
{
    while (!sr.EndOfStream)
    {
        string[] parts = (sr.ReadLine() ?? string.Empty).Split(',');
        string name = parts[0];
        string email = parts[1];
        double salary = double.Parse(parts[2]);
        employees.Add(new Employee(name, email, salary));
    }
}

Console.Write("Enter salary: ");
double inputSalary = double.Parse(Console.ReadLine() ?? "");
var emailsWithSalaryGreaterInputSalary = employees
                                            .Where(x => x.Salary > inputSalary)
                                            .Select(x => x.Email)
                                            .Order();
var sumOfSalaries = employees
                        .Where(x => x.Name[0] == 'M')
                        .Sum(x => x.Salary);

Console.WriteLine($"Email of people whose salary is more than {inputSalary:F2}");
foreach (var email in emailsWithSalaryGreaterInputSalary)
    Console.WriteLine(email);

Console.WriteLine($"Sum of salary of people whose name starts with 'M': {sumOfSalaries:F2}");
