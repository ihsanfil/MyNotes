using System.ComponentModel.DataAnnotations;

namespace AFirmasi.MyNotes.WebApiService.Models
{
    public class NoteModel
    {
        [Required(ErrorMessage ="Başlık alanı boş geçilemez.")]
        public string NoteTitle { get; set; }
        [Required(ErrorMessage ="Açıklama alanı boş geçilemez.")]
        public string NoteDescription { get; set; }
        [Required(ErrorMessage = "Kategori alanı boş geçilemez.")]
        public int CategoryId { get; set; }
    }
}
