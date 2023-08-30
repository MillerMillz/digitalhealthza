using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.ViewModels
{
    public class AddConditionViewModel
    {
        public int ID { get; set; }
        public List<UnitCondition> conditions { get; set; }
    }
}
