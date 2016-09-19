﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet
{
    class Dwarf : Race
    {
        //TODO: Implement Dwarf Special Abilities
        public int AverageWeight = 150;

        public string[] ProficientWeapons = { "Battleaxe", "Handaxe", "Throwing Hammer", "Warhammer" };

        public string[] AvailableToolProficiencies = { "Smith's Tools", "Brewer's Supplies", "Mason's Tools" };

        public Dwarf()
        {
            RaceName = "Dwarf";
            AbilityScoreIncrease = new Tuple<string, int>("Constitution", 2);
            BaseSpeed = 25;
            Languages = new string[2] { "Common", "Dwarfish" };
            MinimumHeight = 4;
            MaximumHeight = 5;
            Size = 2;

            FeaturesDictionary.Add("Darkvision", "Accustomed to life underground, you have superior vision in dark and dim conditions. " +
                                                 "You can see in dim light within 60 feet of you as if it were bright light, and in darkness " +
                                                 "as if it were dim light. You can't discern color in darkness, only shades of gray.");

            FeaturesDictionary.Add("Dwarven Resilience", "You have advantage on saving throws against poison, and you have resistance " +
                                                         "against poison damage.");

            FeaturesDictionary.Add("Stonecutting", "Whenever you make an Intelligence (History) check related to the origin of stonework, " +
                                                   "you are considered proficient in the History skill and add double your proficiency " +
                                                   "bonus to the check, instead of your normal proficiency bonus.");

            //TODO: How should I do this? Maybe when computing HP I just have a check to see if race instanceof Dwarf?
            FeaturesDictionary.Add("Dwarven Toughness (Hill Dwarf)", "Your hit point maximum increases by 1, and it increases by 1 every time " +
                                                                     "you gain a level.");

            FeaturesDictionary.Add("Dwarven Armor Training (Mountain Dwarf)", "You have proficiency with light and medium armor.");
        }

        public override void AddSubraceBonuses(string subrace)
        {
            if (subrace == "Hill Dwarf")
            {
                SubraceAbilityScoreIncrease = new Tuple<string, int>("Wisdom", 1);
            }

            if (subrace == "Mountain Dwarf")
            {
                SubraceAbilityScoreIncrease = new Tuple<string, int>("Strength", 2);
            }
        }

        public override string AbilityIncreasePrintString()
        {
            string abilityString = " +2 Con (Dwarf)";
            Console.WriteLine(Subrace);
            switch (Subrace)
            {
                case "Hill Dwarf":
                    abilityString += " +1 Wis (Hill Dwarf)";
                    break;
                case "Mountain Dwarf":
                    abilityString += " +2 Str (Mountain Dwarf)";
                    break;
            }

            return abilityString;
        }
    }
}
