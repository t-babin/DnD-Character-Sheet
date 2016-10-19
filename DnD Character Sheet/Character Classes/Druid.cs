using System;
using System.Collections.Generic;

namespace DnD_Character_Sheet.Character_Classes
{
    internal class Druid : CharacterClass
    {
        private Dictionary<string, List<string>> additionalFeaturesTable = new Dictionary<string, List<string>>();
        public override Dictionary<string, List<string>> AdditionalFeaturesTable
        {
            get { return additionalFeaturesTable; }

            set { }
        }

        private int numberOfSkills = 2;
        public override int NumberOfSelectableSkills
        {
            get { return numberOfSkills; }

            set { numberOfSkills = value; }
        }

        private List<string> selectableSkills = new List<string>(new[] { "Arcana", "Animal Handling", "Insight", "Medicine", "Nature", "Perception", "Religion", "Survival" });
        public override List<string> SelectableSkills
        {
            get { return selectableSkills; }

            set { }
        }

        public override string SpellcastingAbility
        {
            get { return "Wisdom"; }

            set { }
        }

        public Druid()
        {
            ClassName = "Druid";
            HitPointDieType = 8;

            FeaturesPerLevelTable = new List<Tuple<int, int, string>>(new Tuple<int, int, string>[]
            {
                new Tuple<int, int, string>(1, 2, "Druidic, Spellcasting"),
                new Tuple<int, int, string>(2, 2, "Wild Shape, Druid Circle"),
                new Tuple<int, int, string>(3, 2, "---"),
                new Tuple<int, int, string>(4, 2, "Wild Shape Improvement, Ability Score Improvement"),
                new Tuple<int, int, string>(5, 3, "---"),
                new Tuple<int, int, string>(6, 3, "Druid Circle Feature"),
                new Tuple<int, int, string>(7, 3, "---"),
                new Tuple<int, int, string>(8, 3, "Wild Shape Improvement, Ability Score Improvement"),
                new Tuple<int, int, string>(9, 4, "---"),
                new Tuple<int, int, string>(10, 4, "Druid Circle Feature"),
                new Tuple<int, int, string>(11, 4, "---"),
                new Tuple<int, int, string>(12, 4, "Ability Score Improvement"),
                new Tuple<int, int, string>(13, 5, "---"),
                new Tuple<int, int, string>(14, 5, "Druid Circle Feature"),
                new Tuple<int, int, string>(15, 5, "---"),
                new Tuple<int, int, string>(16, 5, "Ability Score Improvement"),
                new Tuple<int, int, string>(17, 6, "---"),
                new Tuple<int, int, string>(18, 6, "Timeless Body, Beast Spells"),
                new Tuple<int, int, string>(19, 6, "Ability Score Improvement"),
                new Tuple<int, int, string>(20, 6, "Archdruid")
            });

            SpellSlotsPerLevel = new string[,] { { "2", "---", "---", "---", "---", "---", "---", "---", "---" },
                                                 { "3", "---", "---", "---", "---", "---", "---", "---", "---" },
                                                 { "4", "2", "---", "---", "---", "---", "---", "---", "---" },
                                                 { "4", "3", "---", "---", "---", "---", "---", "---", "---" },
                                                 { "4", "3", "2", "---", "---", "---", "---", "---", "---" },
                                                 { "4", "3", "3", "---", "---", "---", "---", "---", "---" },
                                                 { "4", "3", "3", "1", "---", "---", "---", "---", "---" },
                                                 { "4", "3", "3", "2", "---", "---", "---", "---", "---" },
                                                 { "4", "3", "3", "3", "1", "---", "---", "---", "---" },
                                                 { "4", "3", "3", "3", "2", "---", "---", "---", "---" },
                                                 { "4", "3", "3", "3", "2", "1", "---", "---", "---" },
                                                 { "4", "3", "3", "3", "2", "1", "---", "---", "---" },
                                                 { "4", "3", "3", "3", "2", "1", "1", "---", "---" },
                                                 { "4", "3", "3", "3", "2", "1", "1", "---", "---" },
                                                 { "4", "3", "3", "3", "2", "1", "1", "1", "---" },
                                                 { "4", "3", "3", "3", "2", "1", "1", "1", "---" },
                                                 { "4", "3", "3", "3", "2", "1", "1", "1", "1" },
                                                 { "4", "3", "3", "3", "3", "1", "1", "1", "1" },
                                                 { "4", "3", "3", "3", "3", "2", "1", "1", "1" },
                                                 { "4", "3", "3", "3", "3", "2", "2", "1", "1" } };

            PotentialStartingEquipment = new List<string[]>();
            PotentialStartingEquipment.Add(new string[] { "Shield", "Any Simple Weapon" });
            PotentialStartingEquipment.Add(new string[] { "Scimitar", "Any Simple Melee Weapon" });
            PotentialStartingEquipment.Add(new string[] { "Leather Armor" });
            PotentialStartingEquipment.Add(new string[] { "Explorer's Pack" });
            PotentialStartingEquipment.Add(new string[] { "Druidic Focus" });

            AddClassFeatures();
            AddProficiencies();
        }

        // TODO enter in all of the druid features
        // Druid Circles might become something similar to the Cleric Divine Domains
        public override void AddClassFeatures()
        {
            additionalFeaturesTable.Add("Cantrips Known", new List<string>(new string[] { "2", "2", "2", "3", "3", "3", "3", "3", "3", "4", "4", "4", "4", "4", "4", "4",
                                                                                 "4", "4", "4", "4"}));
        }

        public override void AddProficiencies()
        {
            ProficientArmors = new List<string>(new[] { "Light Armor", "Medium Armor", "Shields", "(Druids will not wear armor or use shields made of metal)" });
            ProficientWeapons.Add("Club");
            ProficientWeapons.Add("Dagger");
            ProficientWeapons.Add("Dart");
            ProficientWeapons.Add("Javelin");
            ProficientWeapons.Add("Mace");
            ProficientWeapons.Add("Quarterstaff");
            ProficientWeapons.Add("Scimitar");
            ProficientWeapons.Add("Sickle");
            ProficientWeapons.Add("Sling");
            ProficientWeapons.Add("Spear");
            ProficientTools.Add("Herbalism Kit");
            SavingThrows.Add("Intelligence");
            SavingThrows.Add("Wisdom");
        }

        //Level 1: 8 + Constitution Modifier
        //Onwards: 1d8 (or 5) + Constitution Modifier
        public override int CalculateHitPoints(int level, AbilityScores scores)
        {
            throw new NotImplementedException();
        }
    }
}