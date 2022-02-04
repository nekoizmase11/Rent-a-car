
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentacarApi.Business.DtoModels;
using RentacarApi.Business.Interfaces;
using RentacarApi.Models;

namespace RentacarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IBusinessLayer _businessLayer;
        private readonly IMapper _mapper;

        public CarsController(IBusinessLayer businessLayer, IMapper mapper)
        {
            _businessLayer = businessLayer;
            _mapper = mapper;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
        {
            try
            {
                return Ok(_businessLayer.CarService.GetAll().ToList());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/Cars
        [HttpGet]
        [Route("/api/Cars/brands")]
        public async Task<ActionResult<IEnumerable<CarBrandDto>>> GetCarBrands()
        {
            try
            {
                return Ok(_businessLayer.CarService.GetCarBrands().ToList());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/Cars
        [HttpGet]
        [Route("/api/Cars/types/{id}")]
        public async Task<ActionResult<IEnumerable<CarTypeDto>>> GetCarBrands(int id)
        {
    
            if(id == 0)
                return BadRequest();

            try
            {
                var result = _businessLayer.CarService.GetCarModels(id);

                List<CarTypeModel> carModels = new List<CarTypeModel>();
                _mapper.Map(result, carModels);

                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST: api/Cars
        [HttpPost]
        public async Task<ActionResult<CarModel>> PostCar(CarModel car)
        {
            try
            {
                if(car == null)
                    return BadRequest();

                CarDto carDto = _mapper.Map<CarDto>(car);
                CarDto createdCar = _businessLayer.CarService.CreateCar(carDto);

                return CreatedAtAction("GetCar", new { id = createdCar.Id }, _mapper.Map<CarDto>(createdCar));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarModel>> GetCar(int id)
        {
            var carDto = _businessLayer.CarService.GetCarById(id);

            if (carDto == null)
            {
                return NotFound();
            }

            return _mapper.Map<CarModel>(carDto); 
        }
    }
}
