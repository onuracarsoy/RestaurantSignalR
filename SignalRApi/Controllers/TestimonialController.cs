using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService TestimonialService, IMapper mapper)
        {
            _testimonialService = TestimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTestimonialList()
        {
            var result = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());

            return Ok(result);
        }

        [HttpGet("GetByIDTestimonial/{id}")]
        public IActionResult GetByIDTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);

            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateTest(CreateTestimonialDto createTestimonialDto)
        {

            var value = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(value);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(value);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(value);
            return Ok();
        }
    }
}

