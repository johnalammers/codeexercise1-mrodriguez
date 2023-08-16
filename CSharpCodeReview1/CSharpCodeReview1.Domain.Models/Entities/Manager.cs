namespace CSharpCodeReview1.Domain.Models.Entities
{
    public class Manager : Person
    {
        private decimal perEmployeeSalaryBonus;

        public HashSet<Employee> Employees { get; }

        public decimal SalaryBonusPerEmployee { get; set; }

        /// <summary>
        /// Constructor for Boss class.
        /// </summary>
        /// <param name="department">Department under boss control.</param>
        public Manager()
        {
            Employees = new HashSet<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            if (employee != null) Employees.Add(employee);
        }

        /// <summary>
        /// Method on remove employee from boss control.
        /// </summary>
        /// <param name="employee">Employee which is remove from boss control.</param>
        public void RemoveEmployee(Employee employee)
        {
            if (employee != null) Employees.Remove(employee);
        }


        /// <summary>
        /// Method which return if employess is under boss control.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Return true if employee is found. Else return false.  </returns>
        public bool HasEmployee(Employee employee)
        {
            return Employees.Contains(employee);
        }

        /// <summary>
        /// Property for get count of employees.
        /// </summary>
        /// <returns>Return count of employees.</returns>
        public int EmployeeCount => Employees.Count;

        public override string ToString() => base.ToString() + $"; Employee count={EmployeeCount}";

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