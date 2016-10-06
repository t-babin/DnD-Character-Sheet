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
            Languages = new List<string>(new[] { "Common"});
            MinimumHeight = 4;
            MaximumHeight = 7;
            Size = 2;

            FeaturesDictionary.Add("Languages Known", "You can speak, read, and write Common and one extra language of your choice. Humans typically " +
                                                      "learn the languages of other peoples they deal with, including obscure dialects. They are fond of " +
                                                      "sprinking their speech with words borrowed from other tongues: Orc curses, Elvish musical expressions, " +
                                                      "Dwarvish military phrases, and so on.");

            CanHaveExtraLanguages = true;
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
