namespace Wims.Domain.DTOs
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MinThreshold { get; set; }
        public string Description { get; set; }
    }
}
