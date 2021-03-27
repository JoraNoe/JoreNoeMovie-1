using JoreNoeVideo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomainServices
{
    public interface ICarouselMapDomainService
    {
        string AddCarouselMap(string Url);
        Task<CarouselMap> EditCarouselMap(CarouselMap Model);
        Task<CarouselMap> RemoveCarouselMap(Guid Id);
        Task<CarouselMap> SingleCarouselMap(Guid Id);
        Task<IList<CarouselMap>> AllCarouselMap();
    }
}
