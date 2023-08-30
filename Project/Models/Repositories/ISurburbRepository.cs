using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface ISurburbRepository
    {
        public Surburb AddSurburb(Surburb surburb);
        public Surburb UpdateSurburb(Surburb surburb);
        public Surburb DeleteSurburb(Surburb surburb);
        public Surburb GetSurburb(int id);
        public List<Surburb> ListSurburbs();
    }
}
