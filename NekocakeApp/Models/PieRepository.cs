using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NekocakeApp.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDBContext _appDBContext;

        public PieRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public IEnumerable<Pie> Pies => _appDBContext.Pies;

        public IEnumerable<Pie> PiesOfTheWeek => _appDBContext.Pies.Where(x => x.IsPieOfTheWeek);

        public Pie GetPieById(int pieId) => _appDBContext.Pies.Single(x => x.PieId == pieId);
    }
}
