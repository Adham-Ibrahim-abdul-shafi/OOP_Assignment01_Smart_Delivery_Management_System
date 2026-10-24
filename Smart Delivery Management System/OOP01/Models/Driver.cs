namespace Smart_Delivery_Management_System.OOP01.Models
{
    internal class Driver
    {
        private string _name = default!;
        public string Name 
        { 
            get => _name;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                Name = value;
            }
        } 

        public Driver(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        
    }
}
