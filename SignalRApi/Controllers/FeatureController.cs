using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService FeatureService, IMapper mapper)
        {
            _featureService = FeatureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFeatureList()
        {
            var result = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIDFeature(int id)
        {
            var value = _featureService.TGetByID(id);

            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {

            var value = _mapper.Map<Feature>(createFeatureDto);
            _featureService.TAdd(value);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetByID(id);
            _featureService.TDelete(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);
            _featureService.TUpdate(value);
            return Ok();
        }
    }
}

