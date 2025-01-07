using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id  { get; set; }
        [Required(ErrorMessage = "{0} Requerid")]
        [StringLength(100, MinimumLength =3, ErrorMessage ="{0} size should be between {2} and {1}")]

        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} Requerid")]
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name ="Birth Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} Requerid")]
        public DateTime BirthDate  { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]

        [Display(Name ="Base Salary")]
        [Required(ErrorMessage = "{0} Requerid")]
        public double BaseSalary{ get; set; }

        public Department Department { get; set; }

        public int DepartmentId{ get; set; }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public Seller()
        {
        }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }



    }
}
