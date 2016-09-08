using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet
{
    class Elf : Race
    {
        ////TODO: Implement Elf Special Abilities
        //Darkvision: Accustomed to twilit forests and the night sky, you have superior vision in dark and dim conditions.
        //            You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it 
        //            were dim light. You can't discern color in darkness, only shades of gray.

        //Keen Senses: You have proficiency in the Perception skill.

        //Fey Ancestry: You have advantage on saving throws against being charmed, and magic can't put you to sleep.

        //Trance: Elves don't need to sleep. Instead, they meditate deeply, remaining semiconscious, for 4 hours a day.
        //        (The Common word for such meditation is "trance.") While meditating, you can dream after a fashion; such
        //        dreams are actually mental exercises that have become reflexive through years of practice. After resting
        //        in this way, you gain the same benefit that a human does from 8 hours of sleep.

        //High Elf
        //Elf Weapon Training: You have proficiency with the longsword, shortsword, shortbow, and longbow.
        //Cantrip: You know one cantrip of your choice from the wizard spell list. Intelligence is your spellcasting ability for it.
        //Extra Language: You can speak, read, and write one extra language of your choice.

        //Wood Elf
        //Elf Weapon Training: You have proficiency with the longsword, shortsword, shortbow, and longbow.
        //Fleet of Foot: Your base walking speed increases to 35 feet.
        //Mask of the Wild: You can attempt to hide even when you are only lightly obscured by foliage, heavy rain, falling snow,
        //                  mist, and other natural phenomena.

        //Dark Elf (Drow)
        //Superior Darkvision: Your darkvision has a radius of 120 feet.
        //Sunlight Sensitivity: You have disadvantage on attack rolls and on Wisdom (Perception) checks that rely on sight when you,
        //                      the target of your attack, or whatever you are trying to perceive is in direct sunlight.
        //Drow Magic: You know the dancing lights cantrip. When you reach 3rd level, you can cast the faerie fire spell once per day.
        //            When you reach 5th level, you can also cast the darkness spell once per day. Charisma is your spellcasting ability
        //            for these spells.
        //Drow Weapon Training: You have proficiency with rapiers, shortswords, and hand crossbows.

        public string[] ProficientWeapons;

        public Elf()
        {
            RaceName = "Elf";
            AbilityScoreIncrease = new Tuple<string, int>("Dexterity", 2);
            BaseSpeed = 30;
            Languages = new string[2] { "Common", "Elvish" };
            MinimumHeight = 4;
            MaximumHeight = 7;
            Size = 2;
        }
        
        public override void AddSubraceBonuses(string subrace)
        {
            if (subrace == "High Elf")
            {
                SubraceAbilityScoreIncrease = new Tuple<string, int>("Intelligence", 1);
                ProficientWeapons = new string[] { "Longsword", "Shortsword", "Shortbow", "Longbow" };
            }
            if (subrace == "Wood Elf")
            {
                SubraceAbilityScoreIncrease = new Tuple<string, int>("Wisdom", 1);
                ProficientWeapons = new string[] { "Longsword", "Shortsword", "Shortbow", "Longbow" };
            }
            if (subrace == "Dark Elf")
            {
                SubraceAbilityScoreIncrease = new Tuple<string, int>("Charisma", 1);
                ProficientWeapons = new string[] { "Rapier", "Shortsword", "Hand Crossbow" };
            }
        }

        public override string AbilityIncreasePrintString()
        {
            string abilityString = " +2 Dex (Elf)";
            switch (Subrace)
            {
                case "High Elf":
                    abilityString += " +1 Int (High Elf)";
                    break;
                case "Wood Elf":
                    abilityString += " +2 Wis (Wood Elf)";
                    break;
                case "Dark Elf":
                    abilityString += " +1 Cha (Dark Elf)";
                    break;
            }

            return abilityString;
        }
    }
}
