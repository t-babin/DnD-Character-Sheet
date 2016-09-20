using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet.Character_Classes
{
    class Bard : CharacterClass
    {
        public override Dictionary<string, List<string>> AdditionalFeaturesTable
        {
            get
            {
                return additionalFeaturesTable;
            }

            set
            { }
        }

        private Dictionary<string, List<string>> additionalFeaturesTable = new Dictionary<string, List<string>>();

        public Bard()
        {
            ClassName = "Bard";
            HitPointDieType = 8;
            ProficientArmors = new List<string>(new string[] { "Light Armor" });
            SelectableSkills.Add(3, new string[] { "Acrobatics", "AnimalHandling", "Arcana", "Athletics", "Deception", "History", "Insight", "Intimidation",
                                                   "Investigation", "Medicine", "Nature", "Perception", "Performance", "Persuasion", "Religion", "SleightOfHand",
                                                   "Stealth", "Survival"});
            FeaturesPerLevelTable = new List<Tuple<int, int, string>>(new Tuple<int, int, string>[]
            {
                new Tuple<int, int, string>(1, 2, "Spellcasting, Bardic Inspiration (d6)"),
                new Tuple<int, int, string>(2, 2, "Jack of All Trades, Song of Rest (d6)"),
                new Tuple<int, int, string>(3, 2, "Bard College, Expertise"),
                new Tuple<int, int, string>(4, 2, "Ability Score Improvement"),
                new Tuple<int, int, string>(5, 3, "Bardic Inspiration (d8), Font of Inspiration"),
                new Tuple<int, int, string>(6, 3, "Countercharm, Bard College Feature"),
                new Tuple<int, int, string>(7, 3, "---"),
                new Tuple<int, int, string>(8, 3, "Ability Score Improvement"),
                new Tuple<int, int, string>(9, 4, "Song of Rest (d8)"),
                new Tuple<int, int, string>(10, 4, "Bardic Inspiration (d10), Expertise, Magical Secrets"),
                new Tuple<int, int, string>(11, 4, "---"),
                new Tuple<int, int, string>(12, 4, "Ability Score Improvement"),
                new Tuple<int, int, string>(13, 5, "Song of Rest (d10)"),
                new Tuple<int, int, string>(14, 5, "Magical Secrets, Bard College Feature"),
                new Tuple<int, int, string>(15, 5, "Bardic Inspiration (d12)"),
                new Tuple<int, int, string>(16, 5, "Ability Score Improvement"),
                new Tuple<int, int, string>(17, 6, "Song of Rest (d12)"),
                new Tuple<int, int, string>(18, 6, "Magical Secrets"),
                new Tuple<int, int, string>(19, 6, "Ability Score Improvement"),
                new Tuple<int, int, string>(20, 6, "Superior Inspiration")
            });
            AddProficiencies();
            AddClassFeatures();
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
        }

        public override void AddClassFeatures()
        {
            //TODO Finish adding the Bard Class Features
            additionalFeaturesTable.Add("Cantrips Known", new List<string>(new string[] { "2", "2", "2", "3", "3", "3", "3", "3", "3", "4", "4", "4", "4", "4", "4", "4",
                                                                                 "4", "4", "4", "4"}));

            additionalFeaturesTable.Add("Spells Known", new List<string>(new string[] { "4", "5", "6", "7", "8", "9", "10", "11", "12", "14", "15", "15", "16", "18",
                                                                                       "19", "19", "20", "22", "22", "22"}));
        }

        public override void AddProficiencies()
        {
            ProficientWeapons.AddRange(Weapons.SimpleMeleeWeapons);
            ProficientWeapons.Add("Crossbow, hand");
            ProficientWeapons.Add("Longsword");
            ProficientWeapons.Add("Rapier");
            ProficientWeapons.Add("Shortsword");
            ProficientTools.Add("First Instrument of Your Choice");
            ProficientTools.Add("Second Instrument of Your Choice");
            ProficientTools.Add("Third Instrument of Your Choice");
            SavingThrows.Add("Dexterity");
            SavingThrows.Add("Charisma");
        }

        public override int CalculateHitPoints(int level, AbilityScores scores)
        {
            throw new NotImplementedException();
        }
    }
}
