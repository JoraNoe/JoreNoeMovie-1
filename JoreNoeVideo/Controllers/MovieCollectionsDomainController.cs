using JoreNoeVideo.DomainServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoreNoeVideo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCollectionsDomainController : ControllerBase
    {
        private readonly IMovieCollectionsDomainService MovieCollectionsDomainService;
        public MovieCollectionsDomainController(IMovieCollectionsDomainService MovieCollectionsDomainService)
        {
            this.MovieCollectionsDomainService = MovieCollectionsDomainService;
        }
    }
}
