using System;
using System.Collections.Generic;

// TODO implement fighter
namespace DnD_Character_Sheet.Character_Classes
{
    internal class Fighter : CharacterClass
    {
        private Dictionary<string, List<string>> additionalFeaturesTable = new Dictionary<string, List<string>>();
        public override Dictionary<string, List<string>> AdditionalFeaturesTable
        {
            get { return additionalFeaturesTable; }

            set { }
        }

        // If Eldritch Knight is selected, this will change
        public override string SpellcastingAbility
        {
            get { return ""; }

            set { }
        }

        private int numberOfSkills = 2;
        public override int NumberOfSelectableSkills
        {
            get { return numberOfSkills; }

            set { numberOfSkills = value; }
        }

        private List<string> selectableSkills = new List<string>(new[] { "Acrobatics", "Animal Handling", "Athletics", "History", "Insight",
                                                                         "Intimidation", "Perception", "Survival" });
        public override List<string> SelectableSkills
        {
            get { return selectableSkills; }

            set { }
        }

        public Fighter()
        {
            ClassName = "Fighter";
            HitPointDieType = 10;

            PotentialStartingEquipment = new List<string[]>();
            PotentialStartingEquipment.Add(new string[] { "Chain Mail", "Longbow + Leather Armor" });
            PotentialStartingEquipment.Add(new string[] { "Any Martial Weapon + Shield", "Any Martial Weapon" });
            PotentialStartingEquipment.Add(new string[] { "Light Crossbow", "Two Handaxes" });
            PotentialStartingEquipment.Add(new string[] { "Dungeoneer's Pack", "Explorer's Pack" });

            FeaturesPerLevelTable = new List<Tuple<int, int, string>>(new Tuple<int, int, string>[]
            {
                new Tuple<int, int, string>(1, 2, "Fighting Style, Second Wind"),
                new Tuple<int, int, string>(2, 2, "Action Surge (One Use)"),
                new Tuple<int, int, string>(3, 2, "Martial Archetype"),
                new Tuple<int, int, string>(4, 2, "Ability Score Improvement"),
                new Tuple<int, int, string>(5, 3, "Extra Attack"),
                new Tuple<int, int, string>(6, 3, "Ability Score Improvement"),
                new Tuple<int, int, string>(7, 3, "Martial Archetype Feature"),
                new Tuple<int, int, string>(8, 3, "Ability Score Improvement"),
                new Tuple<int, int, string>(9, 4, "Indomitable (One Use)"),
                new Tuple<int, int, string>(10, 4, "Martial Archetype Feature"),
                new Tuple<int, int, string>(11, 4, "Extra Attack (2)"),
                new Tuple<int, int, string>(12, 4, "Ability Score Improvement"),
                new Tuple<int, int, string>(13, 5, "Indomitable (Two Uses)"),
                new Tuple<int, int, string>(14, 5, "Ability Score Improvement"),
                new Tuple<int, int, string>(15, 5, "Martial Archetype Feature"),
                new Tuple<int, int, string>(16, 5, "Ability Score Improvement"),
                new Tuple<int, int, string>(17, 6, "Action Surge (Two Uses), Indomitable (Three Uses)"),
                new Tuple<int, int, string>(18, 6, "Martial Archetype Feature"),
                new Tuple<int, int, string>(19, 6, "Ability Score Improvement"),
                new Tuple<int, int, string>(20, 6, "Extra Attack (3)")
            });

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 9; j++)
                    SpellSlotsPerLevel[i, j] = "---";
            }

            AddClassFeatures();
            AddProficiencies();
        }

        // TODO Add the class Features
        // something similar to cleric Divine Domains might have to be done for the Martial Archetype selection
        public override void AddClassFeatures()
        {
            
        }

        public override void AddProficiencies()
        {
            ProficientArmors.Add("");
            ProficientArmors.Add("Shield");
            ProficientWeapons.AddRange(Equipment.SimpleMeleeWeapons);
            ProficientWeapons.AddRange(Equipment.SimpleRangedWeapons);
            ProficientWeapons.AddRange(Equipment.MartialMeleeWeapons);
            ProficientWeapons.AddRange(Equipment.MartialRangedWeapons);
            ProficientTools.Add("None");
            SavingThrows.Add("Strength");
            SavingThrows.Add("Constitution");
        }

        //Level 1: 10 + Constitution Modifier
        //Onwards: 1d10 (or 6) + Constitution Modifier
        public override int CalculateHitPoints(int level, AbilityScores scores)
        {
            throw new NotImplementedException();
        }
    }
}