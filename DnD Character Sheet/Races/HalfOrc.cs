using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet.Races
{
    class HalfOrc : Race
    {
        //TODO: Implement Half Orc special abilities
        public HalfOrc()
        {
            RaceName = "Half Orc";
            AbilityScoreIncrease = new Tuple<string, int>("Strength", 2);
            BaseSpeed = 30;
            Languages = new string[2] { "Common", "Orc" };
            MinimumHeight = 5;
            MaximumHeight = 7;
            Size = 2;
            FeaturesDictionary.Add("Darkvision", "Thanks to your orc blood, you have superior vision in dark and dim conditions. " +
                                                 "You can see in dim light within 60 feet of you as if it were bright light, and in " +
                                                 "darkness as if it were dim light. You can't discern color in darkness, only shades of gray.");

            FeaturesDictionary.Add("Menacing", "You gain proficiency in the Intimidation skill.");

            FeaturesDictionary.Add("Relentless Endurance", "When you are reduced to 0 hit points but not killed outright, you can drop to 1 " +
                                                           "hit point instead. You can't use this feature again until you finish a long rest.");

            FeaturesDictionary.Add("Savage Attacks", "When you scorea critical hit with a melee weapon attack, you can roll one of the weapon's " +
                                                     "damage dice one additional time and add it to the extra damage of the critical hit.");
        }

        public override string AbilityIncreasePrintString()
        {
            string s = " +2 Str (Half Orc) +1 Con (Half Orc)";
            return s;
        }

        public override void AddSubraceBonuses(string subrace)
        {
            SubraceAbilityScoreIncrease = new Tuple<string, int>("Constitution", 1);
        }
    }
}
