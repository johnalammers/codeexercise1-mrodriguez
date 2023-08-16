namespace CSharpCodeReview1.Domain.Models.Entities
{
    /// <summary>
    /// Represents a manager, inheriting from the <see cref="Person"/> class.
    /// Manages a group of employees and provides methods to control and interact with them.
    /// </summary>
    public class Manager : Person
    {
        private readonly HashSet<Employee> _employees;

        public decimal SalaryBonusPerEmployee { get; set; }

        public Manager()
        {
            _employees = new HashSet<Employee>();
        }

        /// <summary>
        /// Adds an employee to the manager's group.
        /// </summary>
        /// <param name="employee">The employee to be added.</param>
        public void AddEmployee(Employee employee)
        {
            if (employee != null) _employees.Add(employee);
        }

        /// <summary>
        /// Removes an employee from the manager's group.
        /// </summary>
        /// <param name="employee">The employee to be removed.</param>
        public void RemoveEmployee(Employee employee)
        {
            if (employee != null) _employees.Remove(employee);
        }

        /// <summary>
        /// Checks if an employee is under the manager's supervision.
        /// </summary>
        /// <param name="employee">The employee to check.</param>
        /// <returns><c>true</c> if the employee is managed, otherwise <c>false</c>.</returns>
        public bool HasEmployee(Employee employee)
        {
            return _employees.Contains(employee);
        }

        /// <summary>
        /// Gets the count of employees managed by this manager.
        /// </summary>
        public int EmployeeCount => _employees.Count;

        /// <summary>
        /// Overrides the base class's ToString method to include employee count.
        /// </summary>
        /// <returns>A string representation of the manager.</returns>
        public override string ToString()
        {
            return base.ToString() + $"; Employee count={EmployeeCount}";
        }

        /*
         * These methods will be delegated to decorators
         * 
         * GetYearlySalary: Can be calculated using the YearlySalaryCalculatorDecorator
         * CalcYearlyIncome: Can be calculated using TaxedSalaryCalculatorDecorator in conjunction with GetYearlySalary
         * ApplyTaxRateToSalary: Can be calculated using TaxedSalaryCalculatorDecorator
         * CalculateYearlyBonusForEmployees: Can be calculated using BonusPerEmployeeSalaryCalculatorDecorator in conjunction with GetYearlySalary
         */

        /// <summary>
        /// Method which calculate year salary and subemployee bonus (include boss salary).
        /// </summary>
        /// <returns>Return value of year department salary.</returns>
        //public override decimal GetYearlySalary() => base.GetYearlySalary() + CalculateYearlyBonusForEmployees();

        /// <summary>
        /// Method calculate yearly income of all employees (with VAT).
        /// </summary>
        /// <returns>Return calculate yearly income after tax.</returns>
        //public decimal CalcYearlyIncome() => ApplyTaxRateToSalary(GetYearlySalary());

        //protected override decimal ApplyTaxRateToSalary(decimal salary) => salary * (1 - TaxRate);

        //private decimal CalculateYearlyBonusForEmployees() => EmployeeCount * perEmployeeSalaryBonus * MONTHS_OF_YEAR;
    }
}