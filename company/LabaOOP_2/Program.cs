using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int hours, minutes, seconds, _N, k = 1;
                string _FIO, _Departament;
                decimal _SalaryPerOperation, _BossIndex;

                TimeSpan _TimeOneOperation;
                List<Employee> _Subardinates = new List<Employee>();
                List<DepartamentHead> _CompanyEmployees = new List<DepartamentHead>();

                Console.Write("Введите количество деталей для расчета времени на их изготовление: ");
                _N = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nВведите ФИО начальника: ");
                _FIO = Console.ReadLine();
                Console.WriteLine("На выполнение одной операции затрачивается : 1 час");
                Console.Write("Введите стоимость выполнения одной операции в рублях : ");
                _SalaryPerOperation = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Введите надбавку в процентах от зарплаты в час: ");
                _BossIndex = Convert.ToDecimal(Console.ReadLine());
                _TimeOneOperation = new TimeSpan(1, 0, 0);
                _Departament = "Начальник";

                Company OBJCompany = new Company(_FIO, _Departament, _TimeOneOperation, _SalaryPerOperation, _CompanyEmployees, _Subardinates, _BossIndex, _N);
                _Subardinates.Add(new Employee(_FIO, _Departament, _TimeOneOperation, _SalaryPerOperation + OBJCompany.bossIndex1()));
                _CompanyEmployees.Add(new DepartamentHead(_FIO, _Departament, _TimeOneOperation, _SalaryPerOperation + OBJCompany.bossIndex1(), _Subardinates, _BossIndex));

                for (; ; )
                {
                    int Punkt;
                    Console.WriteLine("\n\n1. Добавить сотрудника ");
                    Console.WriteLine("2. Добавить компанию ");
                    Console.WriteLine("3. Вывести информацию ");
                    Console.WriteLine("4. Выход ");

                    Punkt = Convert.ToInt32(Console.ReadLine());

                    switch (Punkt)
                    {
                        case 1:
                            k++;
                            Console.Write("\n\nВведите ФИО сотрудника: ");
                            _FIO = Console.ReadLine();
                            Console.Write("Введите подразделение: ");
                            _Departament = Console.ReadLine();
                            Console.Write("На выполнение одной операции затрачивается : \nчас(-ов) - ");
                            hours = Convert.ToInt32(Console.ReadLine());
                            Console.Write("минут(-ы) - ");
                            minutes = Convert.ToInt32(Console.ReadLine());
                            Console.Write("секунд(-ы) - ");
                            seconds = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите стоимость выполнения одной операции в рублях : ");
                            _SalaryPerOperation = Convert.ToDecimal(Console.ReadLine());
                            _TimeOneOperation = new TimeSpan(hours, minutes, seconds);

                            OBJCompany = new Company(_FIO, _Departament, _TimeOneOperation, _SalaryPerOperation, _CompanyEmployees, _Subardinates, _BossIndex, _N);
                            _Subardinates.Add(new Employee(_FIO, _Departament, _TimeOneOperation, _SalaryPerOperation));
                            _CompanyEmployees.Add(new DepartamentHead(_FIO, _Departament, _TimeOneOperation, _SalaryPerOperation, _Subardinates, _BossIndex));
                            break;
                        case 2:
                            for (int h = 0; h < k; h++)
                            {
                                if (h == 0)
                                {
                                    Console.Write("\nВведите ФИО начальника: ");
                                    _FIO = Console.ReadLine();
                                    Console.WriteLine("На выполнение одной операции затрачивается : 1 час");
                                    Console.Write("Введите стоимость выполнения одной операции в рублях : ");
                                    _SalaryPerOperation = Convert.ToDecimal(Console.ReadLine());
                                    Console.Write("Введите надбавку в процентах от зарплаты в час: ");
                                    _BossIndex = Convert.ToDecimal(Console.ReadLine());
                                    _TimeOneOperation = new TimeSpan(1, 0, 0);
                                    _Departament = "Начальник";

                                    OBJCompany = new Company(_FIO, _Departament, _TimeOneOperation, _SalaryPerOperation, _CompanyEmployees, _Subardinates, _BossIndex, _N);
                                    _Subardinates.Add(new Employee(_FIO, _Departament, _TimeOneOperation, _SalaryPerOperation + OBJCompany.bossIndex1()));
                                    _CompanyEmployees.Add(new DepartamentHead(_FIO, _Departament, _TimeOneOperation, _SalaryPerOperation + OBJCompany.bossIndex1(), _Subardinates, _BossIndex));

                                }
                                else
                                {
                                    Console.Write("\n\nВведите ФИО сотрудника: ");
                                    _FIO = Console.ReadLine();
                                    Console.Write("Введите подразделение: ");
                                    _Departament = Console.ReadLine();
                                    Console.Write("На выполнение одной операции затрачивается : \nчас(-ов) - ");
                                    hours = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("минут(-ы) - ");
                                    minutes = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("секунд(-ы) - ");
                                    seconds = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Введите стоимость выполнения одной операции в рублях : ");
                                    _SalaryPerOperation = Convert.ToDecimal(Console.ReadLine());
                                    _TimeOneOperation = new TimeSpan(hours, minutes, seconds);

                                    OBJCompany = new Company(_FIO, _Departament, _TimeOneOperation, _SalaryPerOperation, _CompanyEmployees, _Subardinates, _BossIndex, _N);
                                    _Subardinates.Add(new Employee(_FIO, _Departament, _TimeOneOperation, _SalaryPerOperation));
                                    _CompanyEmployees.Add(new DepartamentHead(_FIO, _Departament, _TimeOneOperation, _SalaryPerOperation, _Subardinates, _BossIndex));
                                }

                            }
                            break;
                        case 3:
                            OBJCompany.WriteLineAll();
                            Console.WriteLine("Всего начальникам придется заплатить: " + OBJCompany.SalaryOfAllBosses1());
                            Console.WriteLine("Всего сотрудникам придется заплатить: " + OBJCompany.SalaryOfAllEmployees1());
                            OBJCompany.TimeForNPart1();
                            break;
                        case 4:
                                Environment.Exit(0);
                                break;

                    }
                }
            }
            catch
            { 
                Console.WriteLine("\nНекорректный ввод!");
                Console.ReadLine();
            }

        }
    }

    class Employee
    {
        private string FIO { get; set; }
        public string Departament { get; set; }
        public TimeSpan TimeOneOperation { get; set; }
        private decimal SalaryPerOperation { get; set; }
        private int QuantityOperations { get; set; }

        private int QuantityOperationsForASpecificDay()
        {
            int quantity, k = 0;
            DateTime dt1 = DateTime.Today;
            dt1 = dt1.AddMonths(1);
            DateTime saturday = new DateTime(2020,02,01) , sunday = new DateTime(2020,02,02); 
            DateTime dt2=DateTime.Today;
            while (dt2 <= dt1)
            {
                if (dt2.DayOfWeek != saturday.DayOfWeek && dt2.DayOfWeek != sunday.DayOfWeek)
                { k++; }

                dt2 = dt2.AddDays(1);
            }
            quantity = k * QuantityOperations;
            return quantity;
        }

        private decimal SalaryOperationsForASpecificDay()
        {
            int k = QuantityOperationsForASpecificDay();
            decimal salary = k * SalaryPerOperation;
            return salary;
        }

        public Employee(string _FIO, string _Departament, TimeSpan _TimeOneOperation, decimal _SalaryPerOperation)
        {
            FIO = _FIO;
            Departament = _Departament;
            TimeOneOperation = _TimeOneOperation;
            SalaryPerOperation = _SalaryPerOperation;
            QuantityOperations = 28800 / (3600 * TimeOneOperation.Hours + 60 * TimeOneOperation.Minutes + TimeOneOperation.Seconds);
        }

        public int QuantityOperationsForASpecificDay1()
        {
            int quantity = QuantityOperationsForASpecificDay();
            return quantity;
        }

        public decimal SalaryOperationsForASpecificDay1()
        {
            decimal salary = SalaryOperationsForASpecificDay();
            return salary;
        }
        public override string ToString()
        {
            return string.Format("\nФИО: {0}\nПодразделение:  {1}\nКоличество операций в день: {2}\nПлата за выполнение 1 операции: {3}\nКоличество деталей в месяц: {4}\nЗаработная плата: {5}", FIO, Departament, QuantityOperations, SalaryPerOperation, QuantityOperationsForASpecificDay1(), SalaryOperationsForASpecificDay1());
        }

    }

    class DepartamentHead: Employee
    {
        private decimal BossIndex { get; set; }
        public List<Employee> Subordinates { get; set; }
        private string FIO { get; set; }
        public new string Departament { get; set; }
        private new TimeSpan TimeOneOperation { get; set; }
        private decimal SalaryPerOperation { get; set; }
        private int QuantityOperations { get; set; }

        private  decimal bossIndex()
        {
            decimal salary = SalaryPerOperation / 100 * BossIndex;
            return salary;
        }

        private int TimeForOnePart()
        {
            int time, TIME=0, k, i = 0;
            foreach (Employee j in Subordinates)
            {
                k = 0;
                time = 3600*Subordinates[i].TimeOneOperation.Hours + 60 * Subordinates[i].TimeOneOperation.Minutes + Subordinates[i].TimeOneOperation.Seconds;
                if (TIME == 0)
                {
                    TIME = time;
                }
                else
                {
                    if (time < TIME)
                    {
                        k = TIME / time;
                        if (k * time == TIME)
                        {
                            TIME = TIME + time;
                        }
                        else
                        {
                            TIME = time * k + 2 * time;
                        }
                    }
                    else
                    {
                        TIME = 2 * time;
                    }
                }
                i++;
                
            }
            return TIME;
        }
        public DepartamentHead(string _FIO, string _Departament, TimeSpan _TimeOneOperation, decimal _SalaryPerOperation, List <Employee> _Subardinates, decimal _BossIndex): base(_FIO,_Departament,_TimeOneOperation,_SalaryPerOperation)
        {
            Subordinates = _Subardinates;
            FIO = _FIO;
            Departament = _Departament;
            TimeOneOperation = _TimeOneOperation;
            SalaryPerOperation = _SalaryPerOperation;
            BossIndex = _BossIndex;
            QuantityOperations = 28800 / (3600 * TimeOneOperation.Hours + 60 * TimeOneOperation.Minutes + TimeOneOperation.Seconds);
        }

        public void AddEmployee(Employee subordinates)
        {
            Subordinates.Add(subordinates);
        }
        public decimal bossIndex1()
        {
            decimal salary = bossIndex();
            return salary;
        }
      

        public int TimeForOnePart1()
        {
            int TIME = TimeForOnePart();
            return TIME;
        }

        public void WriteLineAll()
        {
            foreach (var k in Subordinates)
            {
                Console.WriteLine(k.ToString());
            }
        }

    }

    class Company: DepartamentHead
    {
        private decimal BossIndex { get; set; }
        private List<DepartamentHead> CompanyEmployees;
        private new List<Employee> Subordinates { get; set; }
        private string FIO { get; set; }
        public new string Departament { get; set; }
        public new TimeSpan TimeOneOperation { get; set; }
        private decimal SalaryPerOperation { get; set; }
        private int QuantityOperations { get; set; }
        private int N { get; set; }

        private int NumberOfDetails()
        {
            int k = N*TimeForOnePart1();
            return k;
        }

        private decimal SalaryOfAllBosses()
        {
            int i = 0;
            decimal salary = 0;
            foreach (DepartamentHead j in CompanyEmployees)
            {
                if(CompanyEmployees[i].Departament == "Начальник")
                    salary += CompanyEmployees[i].SalaryOperationsForASpecificDay1();
                i++;
            }
            return salary;
        }

        private decimal SalaryOfAllEmployees()
        {
            int i = 0;
            decimal salary = 0;
            foreach (DepartamentHead j in CompanyEmployees)
            {
                if (CompanyEmployees[i].Departament != "Начальник")
                    salary += CompanyEmployees[i].SalaryOperationsForASpecificDay1();
                i++;
            }
            return salary;
        }

        private void TimeForNPart()
        {
            int time, TIME = 0, k, i = 0, comp = 1, q=0;
            foreach (DepartamentHead j in CompanyEmployees)
            {
                k = 0;
                if (CompanyEmployees[i].Departament == "Начальник" && i != 0)
                {
                    q = N * TIME;
                    Console.WriteLine("{0} компанией на изготовление {1} деталей затратится {2} секунд", comp, N, q);
                    TIME = 0;
                    comp++;
                }

                time = 3600 * CompanyEmployees[i].TimeOneOperation.Hours + 60 * CompanyEmployees[i].TimeOneOperation.Minutes + CompanyEmployees[i].TimeOneOperation.Seconds;
                if (TIME == 0)
                {
                    TIME = time;
                }
                else
                {
                    if (time < TIME)
                    {
                        k = TIME / time;
                        if (k * time == TIME)
                        {
                            TIME = TIME + time;
                        }
                        else
                        {
                            TIME = time * k + 2 * time;
                        }
                    }
                    else
                    {
                        TIME = 2 * time;
                    }
                }
                i++;

            }
            if (q != 0)
            {
                q = N * TIME;
                Console.WriteLine("{0} компанией на изготовление {1} деталей затратится {2} секунд", comp, N, q);
            }
        }


        public Company (string _FIO, string _Departament, TimeSpan _TimeOneOperation, decimal _SalaryPerOperation, List<DepartamentHead> _CompanyEmployees, List<Employee> _Subordinates, decimal _BossIndex, int _N) : base(_FIO, _Departament, _TimeOneOperation, _SalaryPerOperation, _Subordinates, _BossIndex)
        {
            CompanyEmployees = _CompanyEmployees;
            Subordinates = _Subordinates;
            FIO = _FIO;
            Departament = _Departament;
            TimeOneOperation = _TimeOneOperation;
            SalaryPerOperation = _SalaryPerOperation;
            BossIndex = _BossIndex;
            N = _N;
            QuantityOperations = 28800 / (3600 * TimeOneOperation.Hours + 60 * TimeOneOperation.Minutes + TimeOneOperation.Seconds);
        }

        public void AddСompanyEmployees(DepartamentHead companyEmployees)
        {
            CompanyEmployees.Add(companyEmployees);
        }
        public int NumberOfDetails1()
        {
            int k = NumberOfDetails();
            return k;
        }

        public decimal SalaryOfAllBosses1()
        {
            decimal k = SalaryOfAllBosses();
            return k;
        }
        public decimal SalaryOfAllEmployees1()
        {
            decimal k = SalaryOfAllEmployees();
            return k;
        }

        public void TimeForNPart1()
        {
            TimeForNPart();
        }


    }

}