using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        void Add(Color car);
        void Update(Color car);
        void Delete(Color car);
        List<Color> GetAll();
        Color GetById(int id);
    }
}