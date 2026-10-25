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
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
               
            }
        } 

        public Driver(string name)
        {
            Name = name;
        }

        
    }
}
