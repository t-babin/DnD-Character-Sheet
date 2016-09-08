using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet
{
    class Human : Race
    {
        //Apparently humans don't have any special abilities?
        public Human()
        {
            RaceName = "Human";
            AbilityScoreIncrease = new Tuple<string, int>("All", 1);
            BaseSpeed = 30;
            Languages = new string[1] { "Common" };
            MinimumHeight = 4;
            MaximumHeight = 7;
            Size = 2;
        }

        public override string AbilityIncreasePrintString()
        {
            var tmp = " +1 All (Human)";
            return tmp;
        }

        public override void AddSubraceBonuses(string subrace)
        {
            SubraceAbilityScoreIncrease = null;
        }
    }
}
