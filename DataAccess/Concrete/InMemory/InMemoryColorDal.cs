using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;

        public InMemoryColorDal(List<Color> colors)
        {
            _colors = new List<Color> 
            {
                new Color {ColorId=1,ColorName="Beyaz" },
                new Color {ColorId=2,ColorName="Siyah" },
                new Color {ColorId=3,ColorName="Mavi" },
                new Color {ColorId=4,ColorName="Kırmızı" },
            };
        }

        public void Add(Color entity)
        {
            _colors.Add(entity);
        }

        public void Delete(Color entity)
        {
            Color colorToDelete = _colors.SingleOrDefault(c=>c.ColorId == entity.ColorId);
            _colors.Remove(colorToDelete);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            var result = _colors.SingleOrDefault();
            return result;
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return _colors.ToList();
        }

        public void Update(Color entity)
        {
            Color colorToDelete = _colors.SingleOrDefault(c => c.ColorId == entity.ColorId);
            colorToDelete.ColorId = entity.ColorId;
            colorToDelete.ColorName = entity.ColorName;
        }
    }
}
