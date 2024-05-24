using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class PhotoDal : BaseRepository<Photo, ApplicationDbContext>, IPhotoDal
    {
        private readonly ApplicationDbContext _contex;

        public PhotoDal(ApplicationDbContext contex)
        {
            _contex = contex;
        }

        public List<PhotoDto> GetPhotMeWithCategory()
        {

            var result = from photo in _contex.Photos
                         where photo.Deleted == 0
                         join photoC in _contex.PhotoCategories
                         on photo.PhotoCategoryId equals photoC.Id
                         where photoC.Deleted == 0
                         select new PhotoDto
                         {
                             Id = photo.Id,
                             Name = photo.Name,
                         };
            return result.ToList(); 
        }
    }
}
