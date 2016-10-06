using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet.Races
{
    class HalfElf : Race
    {
        //TODO: Implement Half Elf special abilities
        public HalfElf()
        {
            RaceName = "Half Elf";
            AbilityScoreIncrease = new Tuple<string, int>("Charisma", 2);
            BaseSpeed = 30;
            //Also get a language of your choice
            Languages = new List<string>(new[] { "Common", "Elvish" });
            MinimumHeight = 5;
            MaximumHeight = 6;
            Size = 2;
            FeaturesDictionary.Add("Darkvision", "Thanks to your elf blood, you have superior vision in dark and dim conditions. " +
                                                 "You can see in dim light within 60 feet of you as if it were bright light, and in " +
                                                 "darkness as if it were dim light. You can't discern color in darkness, only shades of gray.");

            FeaturesDictionary.Add("Fey Ancestry", "You have advantage on saving throws against being charmed, and magic can't put you to sleep.");

            FeaturesDictionary.Add("Skill Versatility", "You gain proficiency in two skills of your choice.");

            FeaturesDictionary.Add("Languages Known", "You can speak, read, and write Common, Elvish, and one extra language of your choice.");

            CanHaveExtraLanguages = true;
        }

        public override string AbilityIncreasePrintString()
        {
            string s = " +2 Cha (Half Elf)";
            return s;
        }

        public override void AddSubraceBonuses(string subrace)
        {
            //Maybe use this to somehow allow for the user to select their 2 additional increases for picking half elf?
            SubraceAbilityScoreIncrease = null;
        }
    }
}
