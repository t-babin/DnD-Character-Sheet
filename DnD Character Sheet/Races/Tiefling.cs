using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet.Races
{
    class Tiefling : Race
    {
        //TODO: Implement the Tiefling special abilities.
        //Darkvision: Thanks to your infernal heritage, you have superior vision in dark and dim conditions. You can see in dim light
        //            within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can't discern
        //            color in darkness, only shades of gray.

        //Hellish Resistance: You have resistance to fire damage.

        //Infernal Legacy: You know the thaumaturgy cantrip. Once you reach 3rd level, you can cast the hellish rebuke spell once per day
        //                 as a 2nd-level spell. Once you reach 5th level, you can also cast the darkness spell once per day. Charisma is your
        //                 spellcasting ability for these spells.

        public Tiefling()
        {
            RaceName = "Tiefling";
            AbilityScoreIncrease = new Tuple<string, int>("Intelligence", 1);
            BaseSpeed = 30;
            Languages = new string[2] { "Common", "Orc" };
            MinimumHeight = 4;
            MaximumHeight = 7;
            Size = 2;
        }

        public override string AbilityIncreasePrintString()
        {
            string s = " +1 Int (Tiefling) +2 Cha (Tiefling)";
            return s;
        }

        public override void AddSubraceBonuses(string subrace)
        {
            SubraceAbilityScoreIncrease = new Tuple<string, int>("Charisma", 2);
        }
    }
}
