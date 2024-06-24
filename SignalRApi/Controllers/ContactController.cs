﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService ContactService, IMapper mapper)
        {
            _contactService = ContactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetContactList()
        {
            var result = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIDContact(int id)
        {
            var value = _contactService.TGetByID(id);

            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {

            var value = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(value);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetByID(id);
            _contactService.TDelete(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(value);
            return Ok();
        }
    }
}

