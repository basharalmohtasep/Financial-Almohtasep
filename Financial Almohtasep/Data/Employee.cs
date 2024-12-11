using Financial_Almohtasep.Data.Base;

namespace Financial_Almohtasep.Data
{
    public class Employee : BaseClass
    {
        public string FullName
        {
            get
            {
                return FName + " " + LName;
            }
        }
        public string FName { get; set; }
        public string LName { get; set; }
        public string PhoneNumper { get; set; }
        public double Salary { get; set; }//الراتب الشهري
        public DateTime HireDate { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<EmployeeTransaction>? Transaction { get; set; }
    }
}