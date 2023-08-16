namespace CSharpCodeReview1.Domain.Models
{
    public class Manager : Employee
    {
        private const int MONTHS_OF_YEAR = 12;
        private decimal perEmployeeSalaryBonus;
        private HashSet<Employee> employees;


        /// <summary>
        /// Constructor for Boss class.
        /// </summary>
        /// <param name="department">Department under boss control.</param>
        public Manager()
        {
            employees = new HashSet<Employee>();
        }

        public Manager(int id, string firstName, string lastName, string job, DateTime birthDate, decimal monthlySalary) :
            base(id, firstName, lastName, job, birthDate, monthlySalary)
        {
            employees = new HashSet<Employee>();
        }

        public decimal SalaryBonusPerEmployee
        {
            get => perEmployeeSalaryBonus;
            set
            {
                if (value >= 0.0M)
                    perEmployeeSalaryBonus = value;
            }
        }

        public void Add(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException("Employee is null");
            employees.Add(employee);
        }

        /// <summary>
        /// Method on remove employee from boss control.
        /// </summary>
        /// <param name="employee">Employee which is remove from boss control.</param>
        public void Remove(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException("Employee is null");
            employees.Remove(employee);
        }


        /// <summary>
        /// Method which return if employess is under boss control.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Return true if employee is found. Else return false.  </returns>
        public bool HasEmployee(Employee employee)
        {
            // todo: complete this function
            throw new NotImplementedException();
        }


        /// <summary>
        /// Method which return all employees.
        /// </summary>
        /// <returns>Return all employees in HashSet.</returns>
        public ISet<Employee> GetEmployees() => new HashSet<Employee>(employees);

        /// <summary>
        /// Property for get count of employees.
        /// </summary>
        /// <returns>Return count of employees.</returns>
        public int EmployeeCount => employees.Count;

        /// <summary>
        /// Method which calculate year salary and subemployee bonus (include boss salary).
        /// </summary>
        /// <returns>Return value of year department salary.</returns>
        public decimal CalcYearlySalary() => base.CalcYearlySalary() + CalculateYearlyBonusForEmployees();

        private decimal CalculateYearlyBonusForEmployees() => EmployeeCount * perEmployeeSalaryBonus * MONTHS_OF_YEAR;

        /// <summary>
        /// Method calculate yearly income of all employees (with VAT).
        /// </summary>
        /// <returns>Return calculate yearly income after tax.</returns>
        public decimal CalcYearlyIncome() => ApplyTaxRateToSalary(CalcYearlySalary());

        protected override decimal ApplyTaxRateToSalary(decimal salary) => salary * (1 - Manager.TaxRate);

        public override string ToString() => base.ToString() + $"; Employee count={GetEmployees().Count}";

    }
}