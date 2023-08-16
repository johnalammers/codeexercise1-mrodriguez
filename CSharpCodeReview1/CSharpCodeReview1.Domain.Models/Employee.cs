namespace CSharpCodeReview1.Domain.Models
{
    public class Employee
    {
        private DateTime _birthDate;

        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                _birthDate = value;
            }
        }

        private int id;

        public int Id
        {
            get => id; set
            {
                this.id = value;
                Employee.nextID = value >= Employee.nextID ? this.id + 1 : Employee.nextID;
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        public decimal MonthlySalary { get; set; }

        public static decimal TaxRate => 0.21M;

        public string FullName { get; private set; }

        private static int nextID = 0;

        public Employee(int id, string firstName, string lastName, string jobTitle, DateTime birthDate, decimal monthlySalary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            JobTitle = jobTitle;
            BirthDate = birthDate;
            MonthlySalary = monthlySalary;

            FullName = firstName + lastName;
        }

        public Employee() { }

        /// <summary>
        /// Always contains the next available ID
        /// </summary>
        public static int NextID
        {
            get
            {
                return Employee.nextID++;
            }
        }


        /// <summary>
        /// Method to count sum of 12 salaries (one per month) of the employee
        /// based on attribute monthlySalaryCZK
        /// </summary>
        /// <returns>Sum of all the 12 salaries</returns>
        public decimal CalcYearlySalary()
        {
            return MonthlySalary * 12;
        }

        /// <summary>
        /// Method to calculate salary after taxation
        /// </summary>
        /// <param name="salary">Salary of employee</param>
        /// <returns>Salary after to taxation</returns>
        protected virtual decimal ApplyTaxRateToSalary(decimal salary)
        {
            return salary * (1 - TaxRate);
        }

        public override string ToString() => $"ID:  {Id}; NAME: {FirstName} {LastName}; JOB:{JobTitle}; SALARY: {MonthlySalary}";

    }
}