using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface ILineActiveIngreRepository
    {
        public List<LineActiveIngre> AddMultipleLine(List<LineActiveIngre> lines);
        public LineActiveIngre GetLineActiveIngre(int id);
        public List<LineActiveIngre> ListLineActiveIngres();
    }
}
