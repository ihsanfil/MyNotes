using AFirmasi.MyNotes.Business.Abstract;
using AFirmasi.MyNotes.Entities;
using AFirmasi.MyNotes.WebApiService.Filters;
using AFirmasi.MyNotes.WebApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFirmasi.MyNotes.WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService noteService;

        public NoteController(INoteService noteService)
        {
            this.noteService = noteService;
        }
        [HttpGet]
        [NoteException]
        public IActionResult Get()
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>()
            {
                Entities = noteService.GetAll(),
                IsSuccessFul = true
            };
            response.EntitiesCount = response.Entities.Count();
            return Ok(response);
        }
        [HttpGet("{id}")]
        [NoteException]
        public IActionResult Get(int id)
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>()
            {
                Entity = noteService.GetById(id),
                IsSuccessFul = true
            };

            return Ok(response);
        }
        [HttpPost]
        [NoteException]
        [NoteValidate]
        public IActionResult Post([FromBody] NoteModel model)
        {
            Note note = new Note
            {
                NoteTitle = model.NoteTitle,
                NoteDescription = model.NoteDescription,
                CategoryId = model.CategoryId
            };
            noteService.Add(note);
            ServiceResponse<Note> response = new ServiceResponse<Note>
            {
                Entity = note,
                IsSuccessFul = true
            };

            return Ok();
        }
        [HttpPut]
        [NoteException]
        [NoteValidate]
        public IActionResult Put(int id, [FromBody] NoteModel model)
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>();
            var note = noteService.GetById(id);
            if (note == null)
            {
                response.HasError = true;
                response.Errors.Add("Not Bulunamadı");
                return BadRequest(response);
            }

            note.NoteTitle = model.NoteTitle;
            note.NoteDescription = model.NoteDescription;
            note.CategoryId = model.CategoryId;
            noteService.Update(note);
            response.IsSuccessFul = true;
            return Ok(response);
        }
        [HttpDelete]
        [NoteException]
        public IActionResult Delete(int id)
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>();
            var note = noteService.GetById(id);
            if (note == null)
            {
                response.HasError = true;
                response.Errors.Add("Not Bulunamadı");
                return BadRequest(response);
            }

            noteService.Delete(note);
            response.IsSuccessFul = true;
            return Ok(response);
        }
    }
}
