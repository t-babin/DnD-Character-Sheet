using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet
{
    class Halfling : Race
    {
        public Halfling()
        {
            RaceName = "Halfling";
            AbilityScoreIncrease = new Tuple<string, int>("Dexterity", 2);
            BaseSpeed = 25;
            Languages = new string[2] { "Common", "Halfling" };
            MinimumHeight = 2;
            MaximumHeight = 4;
            Size = 1;

            FeaturesDictionary.Add("Lucky", "When you roll a 1 on an attack roll, ability check, or saving throw, you can reroll the die " +
                                            "and must use the new roll.");

            FeaturesDictionary.Add("Brave", "You have advantage on saving throws against being frightened.");

            FeaturesDictionary.Add("Halfling Nimbleness", "You can move through the space of any creature that is of a size larger than yours.");
        }

        public override void AddSubraceBonuses(string subrace)
        {
            if (subrace == "Lightfoot")
            {
                SubraceAbilityScoreIncrease = new Tuple<string, int>("Charisma", 1);
                SubraceFeaturesDictionary.Add("Naturally Stealthy (Lightfoot)", "You cna attempt to hide even when you are obscured only by " +
                                                                                "a creature that is at least one size larger than you.");
            }

            if (subrace == "Stout")
            {
                SubraceAbilityScoreIncrease = new Tuple<string, int>("Constitution", 2);
                SubraceFeaturesDictionary.Add("Stout Resilience (Stout)", "You have advantage on saving throws against poison, and you have " +
                                                                          "resistance against poison damage.");
            }
        }

        public override string AbilityIncreasePrintString()
        {
            string abilityString = " +2 Dex (Halfling)";
            Console.WriteLine(Subrace);
            switch (Subrace)
            {
                case "Lightfoot":
                    abilityString += " +1 Cha (Lightfoot)";
                    break;
                case "Stout":
                    abilityString += " +2 Con (Stout)";
                    break;
            }

            return abilityString;
        }
    }
}
