using System;

namespace gasmaTools.Application.ViewModels
{
    public class GameViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid PersonId { get; set; }
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public DateTime? InactivateAt { get; set; }
        public DateTime CreationAt { get; set; }
        public PersonViewModel Person { get; set; }
    }
}
