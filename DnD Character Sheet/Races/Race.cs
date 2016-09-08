using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet
{
    abstract class Race
    {
        public virtual Tuple<string, int> AbilityScoreIncrease { get; set; } = null;

        public virtual Tuple<string, int> SubraceAbilityScoreIncrease { get; set; } = null;

        public virtual int BaseSpeed { get; set; } = 0;

        public virtual String[] Languages { get; set; } = null;

        public virtual Race[] Subraces { get; set; } = null;

        public string Subrace { get; set; } = null;

        public string RaceName { get; set; } = "";

        //1 = small; 2 = medium; 3 = large;
        public int Size { get; set; } = 0;

        public virtual int MinimumHeight { get; set; } = 0;

        public virtual int MaximumHeight { get; set; } = 0;

        public abstract void AddSubraceBonuses(string subrace);

        public abstract string AbilityIncreasePrintString();
    }
}
