using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomainServices.Tools;
using JoreNoeVideo.Store;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace JoreNoeVideo.DomainServices
{
    public class CarouselMapDomainService : ICarouselMapDomainService
    {
        public CarouselMapDomainService(IDbContextFace<CarouselMap> Server, IHttpRequestDomainService httpRequestDomain)
        {
            this.Server = Server;
            this.HttpRequestDomain = httpRequestDomain;
        }
        private readonly IDbContextFace<CarouselMap> Server;
        private readonly IHttpRequestDomainService HttpRequestDomain;

        public string AddCarouselMap(string Url)
        {
            throw new Exception();
        }

        public Task<CarouselMap> AddUser(CarouselMap Model)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CarouselMap>> AllCarouselMap()
        {
            throw new NotImplementedException();
        }

        public Task<IList<CarouselMap>> AllUser()
        {
            throw new NotImplementedException();
        }

        public Task<CarouselMap> EditCarouselMap(CarouselMap Model)
        {
            throw new NotImplementedException();
        }

        public Task<CarouselMap> EditUser(CarouselMap Model)
        {
            throw new NotImplementedException();
        }

        public Task<CarouselMap> RemoveCarouselMap(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<CarouselMap> RemoveUser(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<CarouselMap> SingleCarouselMap(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<CarouselMap> SingleUser(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
