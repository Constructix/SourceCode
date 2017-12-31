﻿using System.Web.Http;
using Services;

namespace WebApplication1.Controllers
{
    public class TriangleTypeController : ApiController
    {
        KnockKnockService _service;

        protected TriangleTypeController()
        {
            _service = new KnockKnockService();
        }

        /// <summary>
        /// Returns the type of triange given the lengths of its sides
        /// </summary>
        /// <param name="a">The length of side a</param>
        /// <param name="b">The length of side b</param>
        /// <param name="c">The length of side c</param>
        /// <returns></returns>
        [Route("api/TriangleType")]
        [HttpGet]
        public string Get(int a, int b, int c)
        {

            Triangle inputTriangle = new Triangle(a,b,c);


            return _service.TriangleType(inputTriangle);




        
        }
    }

    
}