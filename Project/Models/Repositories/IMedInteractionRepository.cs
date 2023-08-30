using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Repositories
{
    public interface IMedInteractionRepository
    {
        public MedInteraction AddMedInteraction(MedInteraction medInteraction);
        public MedInteraction UpdateMedInteraction(MedInteraction medInteraction);
        public MedInteraction DeleteMedInteraction(MedInteraction medInteraction);
        public MedInteraction GetMedInteraction(int id);
        public List<MedInteraction> ListMedInteractions();
    }
}
