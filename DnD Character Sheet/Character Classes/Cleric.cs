using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet.Character_Classes
{
    class Cleric : CharacterClass
    {
        private Dictionary<string, List<string>> additionalFeaturesTable = new Dictionary<string, List<string>>();
        public override Dictionary<string, List<string>> AdditionalFeaturesTable
        {
            get
            {
                return additionalFeaturesTable;
            }

            set
            { }
        }

        private List<string> selectableSkills = new List<string>(new [] { "History", "Insight", "Medicine", "Persuasion", "Religion" });
        public override List<string> SelectableSkills
        {
            get
            {
                return selectableSkills;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Cleric()
        {
            ClassName = "Cleric";
            HitPointDieType = 8;
            ProficientArmors = new List<string>(new string[] { "Light Armor", "Medium Armor", "Shields" });
            AddProficiencies();
            //SelectableSkills.Add(2, new string[] { "History", "Insight", "Medicine", "Persuasion", "Religion" });

            FeaturesPerLevelTable = new List<Tuple<int, int, string>>(new Tuple<int, int, string>[]
            {
                new Tuple<int, int, string>(1, 2, "Spellcasting, Divine Domain"),
                new Tuple<int, int, string>(2, 2, "Channel Divinity (1/rest), Divine Domain Feature"),
                new Tuple<int, int, string>(3, 2, "---"),
                new Tuple<int, int, string>(4, 2, "Ability Score Improvement"),
                new Tuple<int, int, string>(5, 3, "Destroy Undead (CR 1/2)"),
                new Tuple<int, int, string>(6, 3, "Channel Divinity (2/rest), Divine Domain feature"),
                new Tuple<int, int, string>(7, 3, "---"),
                new Tuple<int, int, string>(8, 3, "Ability Score Improvement, Destroy Undead (CR 1), Divine Domain Feature"),
                new Tuple<int, int, string>(9, 4, "---"),
                new Tuple<int, int, string>(10, 4, "Divine Intervention"),
                new Tuple<int, int, string>(11, 4, "Destroy Undead (CR 2)"),
                new Tuple<int, int, string>(12, 4, "Ability Score Improvement"),
                new Tuple<int, int, string>(13, 5, "---"),
                new Tuple<int, int, string>(14, 5, "Destroy Undead (CR 3)"),
                new Tuple<int, int, string>(15, 5, "---"),
                new Tuple<int, int, string>(16, 5, "Ability Score Improvement"),
                new Tuple<int, int, string>(17, 6, "Destroy Undead (CR 4), Divine Domain Feature"),
                new Tuple<int, int, string>(18, 6, "Channel Divinity (3/rest)"),
                new Tuple<int, int, string>(19, 6, "Ability Score Improvement"),
                new Tuple<int, int, string>(20, 6, "Divine Intervention Improvement")
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
        }

        public override string SpellcastingAbility
        {
            get { return "Wisdom"; }

            set
            { }
        }

        public override int NumberOfSelectableSkills
        {
            get
            {
                return 2;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddClassFeatures()
        {
            FeaturesDictionary.Add("Divine Domain", "Choose one domain related to your deity: Knowledge, Life, Light, Nature, Tempest, Trickery, or War. Each domain " +
                                                    "is detailed at the end of the class description, and each one provides examples of gods associated with it. Your " +
                                                    "choice grants you domain spells and other features when you choose it at 1st level. It also grants you additional " +
                                                    "ways to use Channel Divinity when you gain that feature at 2nd level, and additional benefits at 6th, 8th, and 17th " +
                                                    "levels.\n\nEach domain has a list of spells - its domain spells - that you gain at the cleric levels noted in the " +
                                                    "domain description. Once you gain a domain spell, you always have it prepared, and it doesn't count against the number " +
                                                    "of spells you can prepare each day. If you have a domain spell that doesn't appear on the cleric spell list, the spell " +
                                                    "is nonetheless a cleric spell for you.".Replace("\n", Environment.NewLine));

            FeaturesDictionary.Add("Channel Divinity", "At 2nd level, you gain the ability to channel divine energy directly from your deity, using that energy to fuel " +
                                                       "magical effects. You start with two such effects: Turn Undead and an effect determined by your domain. Some domains " +
                                                       "grant you additional effects as you advance in levels, as noted in the domain description. When you use your Channel " +
                                                       "Divinity, you choose which effect to create. You must then finish a short or long rest to use your Channel Divinity " +
                                                       "again. Some Channel Divinity effects require saving throws. When you use such an effect from this class, the DC " +
                                                       "equals your cleric spell save DC. Beginning at 6th level, you can use your Channel Divinity twice between rests, " +
                                                       "and beginning at 18th level, you can use it three times between rests. When you finish a short or long rest, you " +
                                                       "regain your expended uses.");

            FeaturesDictionary.Add("Skills That You May be Proficient in", "History, Insight, Medicine, Persuasion, Religion");

            additionalFeaturesTable.Add("Cantrips Known", new List<string>(new string[] { "3", "3", "3", "4", "4", "4", "4", "4", "4", "5", "5", "5", "5", "5", "5", "5",
                                                                                 "5", "5", "5", "5"}));
        }

        public override void AddProficiencies()
        {
            ProficientWeapons.AddRange(Weapons.SimpleMeleeWeapons);
            ProficientWeapons.AddRange(Weapons.SimpleRangedWeapons);
            ProficientTools.Add("None");
            SavingThrows.Add("Wisdom");
            SavingThrows.Add("Charisma");
        }

        public override int CalculateHitPoints(int level, AbilityScores scores)
        {
            throw new NotImplementedException();
        }
    }
}
