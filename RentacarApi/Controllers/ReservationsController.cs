
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentacarApi.Business.DtoModels;
using RentacarApi.Business.Interfaces;
using RentacarApi.Data.Models;
using RentacarApi.Models;

namespace RentacarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ReantacarContext _context;
        private readonly IBusinessLayer _businessLayer;
        private readonly IMapper _mapper;

        public ReservationsController(ReantacarContext context, IBusinessLayer businessLayer, IMapper mapper)
        {
            _context = context;
            _businessLayer = businessLayer;
            _mapper = mapper;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationModel>>> GetReservations()
        {
            try
            {
                var reservations = _businessLayer.ReservationService.GetAll().ToList();

                IEnumerable<ReservationModel> finalReservations = new List<ReservationModel>();
                _mapper.Map(reservations, finalReservations);

                return Ok(finalReservations);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        

        // POST: api/Reservations
        [HttpPost]
        public async Task<ActionResult<ReservationModel>> PostReservation(CreateReservationModel reservation)
        {
            try
            {
                if (reservation == null)
                    return BadRequest();

                ReservationDto reservationDto = _mapper.Map<ReservationDto>(reservation);

                var created = _businessLayer.ReservationService.CreateReservation(reservationDto);

                return CreatedAtAction("GetReservation", new { id = created.Id }, _mapper.Map<ReservationModel>(created));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
