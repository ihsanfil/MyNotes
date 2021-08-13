using AFirmasi.Core.Entities;

namespace AFirmasi.MyNotes.Entities
{
    public class Note:IEntity //1 notun 1 kategorisi olabilir dedik 
    {
        public int Id { get; set; }
        public string NoteTitle { get; set; }
        public string NoteDescription { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }


}
