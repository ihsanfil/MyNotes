using AFirmasi.Core.Entities;
using System.Collections.Generic;

namespace AFirmasi.MyNotes.Entities
{
    public class Category: IEntity //1 kategori birden fazla not tarafından kullanılabilir dedik
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Note> Notes { get; set; }
    }


}
