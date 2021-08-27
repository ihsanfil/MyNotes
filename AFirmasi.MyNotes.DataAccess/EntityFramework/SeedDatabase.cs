using AFirmasi.MyNotes.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFirmasi.MyNotes.DataAccess.EntityFramework
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
              var context = serviceProvider.GetRequiredService<MyNotesDbContext>();

            Category category = new Category
            {
                 CategoryName = "Sosyal Ağlar",
            };
            if (!context.Categories.Any())
            {
                context.Categories.Add(category);
                if (context.SaveChanges() > 0)
                {
                    Note note = new Note
                    {
                        NoteTitle = "Yeni Not",
                        NoteDescription = "Notumuzun Açıklaması",
                        CategoryId = category.Id,
                        Category = category
                    };
                    context.Notes.Add(note);
                    context.SaveChanges();
                }  
            }
            
        }
    }
}
