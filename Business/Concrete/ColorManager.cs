using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager: IColorService
    {
        IColorDal _iColorDal;

        public ColorManager(IColorDal iColorDal)
        {
            _iColorDal = iColorDal;
        }

        public void Add(Color color)
        {
            _iColorDal.Add(color);
        }

        public void Update(Color color)
        {
            _iColorDal.Update(color);
        }

        public void Delete(Color color)
        {
            _iColorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _iColorDal.GetAll();
        }

        public Color GetById(int id)
        {
            return _iColorDal.Get(c => c.Id == id);
        }

    }
}