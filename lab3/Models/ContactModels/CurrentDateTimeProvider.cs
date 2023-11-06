namespace lab3_App.Models.ContactModels
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
