using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADABepTuDongWPFV3.Model
{
    public class DataTemp
    {
        private static DataTemp _ins;

        public static DataTemp Ins { get { if (_ins == null) _ins = new DataTemp(); return _ins; } set => _ins = value; }

        private DataTemp()
        {

        }

        public Recipe tempRecipe = new Recipe();
        public List<StepRecipe> tempStepRecipe = new List<StepRecipe>();

        public bool IsAdmin = false;
    }
}
