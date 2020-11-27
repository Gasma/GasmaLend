using System;

namespace gasmaTools.Application.ViewModels
{
    public class PersonViewModel
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public int Age { get; private set; }
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public DateTime? InactivateAt { get; set; }
        public DateTime CreationAt { get; set; }
    }
}
