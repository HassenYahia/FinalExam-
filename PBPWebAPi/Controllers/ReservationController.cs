﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBP.BusinessLogic;
using PBP.DataAccess;
using PBP.Pocos;

namespace PBPWebAPi.Controllers
{
    [Route("api/ParkingBooking/v1")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly Reservation _logic;

        public ReservationController()
        {
            var repo = new DataRepository<ReservationPoco>();
            _logic = new Reservation(repo);
        }

        [Route("Reservation/{id}")]
        [HttpGet]
        public ActionResult GetReservation(Guid id)
        {
            ReservationPoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(poco);
            }

        }
        [Route("Reservation")]
        [HttpGet]
        public ActionResult GetAllReservation()
        {
            var poco = _logic.GetAll();
            if (poco == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(poco);
            }
        }
        [HttpPost]
        [Route("Reservation")]
        public ActionResult PostReservation([FromBody] ReservationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("Reservation")]
        public ActionResult PutReservation([FromBody] ReservationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("Reservation")]
        public ActionResult DeleteReservation([FromBody] ReservationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}