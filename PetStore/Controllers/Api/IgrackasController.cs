using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using PetStore.Dtos;
using PetStore.Models;

namespace PetStore.Controllers.Api
{
    [Authorize(Roles = RoleName.CanManageIgrackas)]
    public class IgrackasController : ApiController
    {
        private ApplicationDbContext _context;

        public IgrackasController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/igrackas
        public IEnumerable<IgrackaDto> GetIgrackas()
        {
            return _context.Igrackas
                .Include(k => k.Kategorija)
                .ToList()
                .Select(Mapper.Map<Igracka,IgrackaDto>);
        }

        // GET /api/igrackas/1
        public IHttpActionResult GetIgracka(int id)
        {
            var igracka =_context.Igrackas.SingleOrDefault(i => i.Id == id);

            if(igracka == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Igracka, IgrackaDto>(igracka));
        }

        // POST /api/igrackas
        [Authorize(Roles = RoleName.CanManageIgrackas)]
        [HttpPost]
        public IHttpActionResult CreateIgracka(IgrackaDto igrackaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var igracka = Mapper.Map<IgrackaDto, Igracka>(igrackaDto);
            _context.Igrackas.Add(igracka);
            _context.SaveChanges();

            igrackaDto.Id = igracka.Id;
            return Created(new Uri(Request.RequestUri + "/" + igracka.Id),igrackaDto);
        }

        // PUT /api/igrackas/1
        [Authorize(Roles = RoleName.CanManageIgrackas)]
        [HttpPut]
        public IHttpActionResult UpdateIgracka(int id, IgrackaDto igrackaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var igrackaInDb = _context.Igrackas.SingleOrDefault(i => i.Id == id);
            if(igrackaInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(igrackaDto, igrackaInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/igracka/1
        [Authorize(Roles = RoleName.CanManageIgrackas)]
        [HttpDelete]
        public IHttpActionResult DeleteIgracka(int id)
        {
            var igrackaInDb = _context.Igrackas.SingleOrDefault(i => i.Id == id);
            if (igrackaInDb == null)
            {
                return NotFound();
            }

            _context.Igrackas.Remove(igrackaInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
