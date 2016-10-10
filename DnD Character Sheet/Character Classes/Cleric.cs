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
            get { return additionalFeaturesTable; }

            set { }
        }

        private List<string> selectableSkills = new List<string>(new [] { "History", "Insight", "Medicine", "Persuasion", "Religion" });
        public override List<string> SelectableSkills
        {
            get { return selectableSkills; }

            set { }
        }

        private int numberOfSkills = 2;
        public override int NumberOfSelectableSkills
        {
            get { return numberOfSkills; }

            set { numberOfSkills = value; }
        }

        public override string SpellcastingAbility
        {
            get { return "Wisdom"; }

            set { }
        }

        public Cleric()
        {
            ClassName = "Cleric";
            HitPointDieType = 8;
            ProficientArmors = new List<string>(new string[] { "Light Armor", "Medium Armor", "Shields" });
            AddProficiencies();
            AddClassFeatures();
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
                                                       "regain your expended uses.\n\nChannel Divinity: Turn Undead\nAs an action, you present your holy symbol and speak a " +
                                                       "prayer censuring the undead. Each undead that can see or hear you within 30 feet of you must make a Wisdom saving throw. " +
                                                       "If the creature fails its saving throw, it is turned for 1 minute or until it takes any damage. A turned creature must spend " +
                                                       "its turns trying to move as far away from you as it can, and it can't willingly move to a space within 30 feet of you. It also " +
                                                       "can't take reactions. For its action, it can use only the Dash action or try to escape from an effect that prevents it from " +
                                                       "moving. If there's nowhere to move, the creature can use the Dodge action.".Replace("\n", Environment.NewLine));

            FeaturesDictionary.Add("Ability Score Improvement", "When you reach 4th level, and again at 8th, 12th, 16th, and 19th level, you can increase one ability " +
                                                                "score of your choice by 2, or you can increase two ability scores of your choice by 1. As normal, you " +
                                                                "can’t increase an ability score above 20 using this feature.");

            FeaturesDictionary.Add("Destroy Undead", "Starting at 5th level, when an undead fails its saving throw against your Turn Undead feature, the creature is " +
                                                     "instantly destroyed if its challenge rating is ator below a certain threshold, as shown in the Destroy Undead " +
                                                     "Table.\n\nCleric Level       Destroys Unewrdead of CR...\n5th                    1/2 or lower\n8th                    " +
                                                     "1 or lower\n11th                  2 or lower\n14th                  3 or lower\n17th                  " +
                                                     "4 or lower".Replace("\n", Environment.NewLine));

            FeaturesDictionary.Add("Divine Intervention", "Beginning at 10th level, you can call on your deity to intervene on your behalf when your need is great. " +
                                                          "Imploring your deity's aid requires you to use your action. Describe the assistance you seek, and roll " +
                                                          "percentile dice. If you roll a number equal to or lower than your cleric level, your deity intervenes. The " +
                                                          "DM chooses the nature of the intervention; the effect of any cleric spell or cleric domain spell would be " +
                                                          "appropriate. If your deity intervenes, you can't sue this feature again for 7 days. Otherwise, you can use " +
                                                          "it again after you finish a long rest. At 20th level, your call for intervention succeeds automatically, no " +
                                                          "roll required.");

            // TODO add the different divine domains (a ton of typing)

            FeaturesDictionary.Add("Skills That You May be Proficient in", "History, Insight, Medicine, Persuasion, Religion");

            additionalFeaturesTable.Add("Cantrips Known", new List<string>(new string[] { "3", "3", "3", "4", "4", "4", "4", "4", "4", "5", "5", "5", "5", "5", "5", "5",
                                                                                 "5", "5", "5", "5"}));
        }

        public override void AddProficiencies()
        {
            ProficientWeapons.AddRange(Equipment.SimpleMeleeWeapons);
            ProficientWeapons.AddRange(Equipment.SimpleRangedWeapons);
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
