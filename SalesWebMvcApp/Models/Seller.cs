using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvcApp.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime dateBirth, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            DateBirth = dateBirth;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sales)
        {
            SalesRecords.Add(sales);
        }

        public void RemoveSales(SalesRecord sales)
        {
            SalesRecords.Remove(sales);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return SalesRecords.Where(x => x.Date >= initial && x.Date <= final).Sum(x => x.Amount);
        }
    }
}
