namespace lab_2.Models
{
    public class Birth
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public bool IsValid()
        {
            return Name != null && BirthDate < DateTime.Now;
        }

        public int CalculateAge()
        {
            var result = DateTime.Now - BirthDate;
            return result.Days / 365;
        }
    }
}
