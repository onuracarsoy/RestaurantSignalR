using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService BasketService, IMapper mapper)
        {
            _basketService = BasketService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBasketList()
        {
            var result = _mapper.Map<List<ResultBasketDto>>(_basketService.TGetListAll());

            return Ok(result);
        }


        [HttpGet("GetBasketByTableNumber/{id}")]
        public IActionResult GetBasketByTableNumber(int id)
        {
            var values = _basketService.TGetBasketByTableNumber(id);

            return Ok(values);
        }

        [HttpGet("GetBasketByTableID/{id}")]
        public IActionResult GetBasketByTableIDAndTableID(int tableID, int productID)
        {
            var values = _basketService.TGetBasketByTableIDAndProductID(tableID, productID);

            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIDBasket(int id)
        {
            var value = _basketService.TGetByID(id);

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket(CreateBasketDto createBasketDto)
        {
            var basket = _basketService.TGetBasketByTableIDAndProductID(createBasketDto.MenuTableID, createBasketDto.ProductID);
            var value = _mapper.Map<Basket>(createBasketDto);
            if (basket != null)
            {
                if (value.ProductID == basket.ProductID)
                {
                    value.BasketID = basket.BasketID;
                    value.MenuTableID = createBasketDto.MenuTableID;
                    value.ProductID = createBasketDto.ProductID;
                    value.BasketProductCount += basket.BasketProductCount;
                    value.BasketTotalPrice = 0;

                    _basketService.TUpdate(value);
                    return Ok();
                }
            }
            _basketService.TAdd(value);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetByID(id);
            _basketService.TDelete(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBasket(UpdateBasketDto updateBasketDto)
        {
            var value = _mapper.Map<Basket>(updateBasketDto);
            _basketService.TUpdate(value);
            return Ok();
        }
    }
}
