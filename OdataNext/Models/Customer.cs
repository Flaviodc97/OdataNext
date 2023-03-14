namespace OdataNext.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public virtual IList<Order> Orders { get;set; }
    }
}
