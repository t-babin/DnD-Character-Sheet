using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet.Character_Classes
{
    class Bard : CharacterClass
    {
        private Dictionary<string, List<string>> additionalFeaturesTable = new Dictionary<string, List<string>>();
        public override Dictionary<string, List<string>> AdditionalFeaturesTable
        {
            get { return additionalFeaturesTable; }

            set
            { }
        }

        public override string SpellcastingAbility
        {
            get { return "Charisma"; }

            set
            { }
        }        

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
            FeaturesDictionary.Add("Bardic Inspiration", "You can inspire others through stirring words or music. To do so, you use a bonus action on your turn to " +
                                                         "choose one creature other than yourself within 60 feet of you who can hear you. That creature gains one " +
                                                         "Bardic Inspiration die, a d6. Once within the next 10 minutes, the creature can roll the die and add the " +
                                                         "number rolled to one ability check, attack roll, or saving throw it makes. The creature can wait until after " +
                                                         "it rolls the d20 before deciding to use the Bardic Inspiration die, but must decide before the DM says whether " +
                                                         "the roll succeeds or fails. Once the Bardic Inspiration die is rolled, it is lost. A creature can have only " +
                                                         "one Bardic Inspiration die at a time. You can use this feature a number of times equal to your Charisma " +
                                                         "modifier (a minimum of once). You regain any expended uses when you finish a long rest. Your Bardic " +
                                                         "Inspiration die changes when you reach certain levels in this class. The die becomes a d8 at 5th level, a " +
                                                         "d10 at 10th level, anda d12 at 15th level.");

            FeaturesDictionary.Add("Jack of All Trades", "Starting at 2nd level, you can add half your proficiency bonus, rounded down, to any ability check you make " +
                                                         "that doesn't already include your proficiency bonus.");

            FeaturesDictionary.Add("Song of Rest", "Beginning at 2nd level, you can use soothing music or oration to help revitalize your wounded allies during a short " +
                                                   "rest. If you or any friendly creatures who can hear your performance regain hit points at the end of the short rest, " +
                                                   "each of those creatures regains an extra 1d6 hit points. The extra hit points increase when you reach certain levels " +
                                                   "in this class: to 1d8 at 9th level, 1d10 at 13th level, and to 1d12 at 17th level.");

            FeaturesDictionary.Add("Bard College", "At 3rd level, you delve into the advanced techniques of a bard college of your choice: the College of Lore or the " +
                                                   "College of Valor, both detailed at the end of the class description. Your choice grants you features at 3rd level " +
                                                   "and again at 6th and 14th level.");

            FeaturesDictionary.Add("Expertise", "At 3rd level, choose two of your skill proficiencies. Your proficiency bonus is doubled for any ability check you " +
                                                "make that uses either of the chosen proficiencies. At 10th level, you can choose another two skill proficiencies to " +
                                                "gain this benefit");

            FeaturesDictionary.Add("Ability Score Improvement", "When you reach 4th level, and again at 8th, 12th, 16th, and 19th level, you can increase one ability " +
                                                                "score of your choice by 2, or you can increase two ability scores of your choice by 1. As normal, you " +
                                                                "can’t increase an ability score above 20 using this feature.");

            FeaturesDictionary.Add("Font of Inspiration", "Beginning when you reach 5th level, you regain all of your expended uses of Bardic Inspiration when you " +
                                                          "finish a short or long rest.");

            FeaturesDictionary.Add("Countercharm", "At 6th level, you gain the ability to use musical notes or words of power to disrupt mind-influencing effects. " +
                                                   "As an action, you can start a performance that lasts until the end of your next turn. During that time, you and any " +
                                                   "friendly creatures within 30 feet of you have advantage on saving throws against being frightened or charmed. A " +
                                                   "creature must be able to hear you to gain this benefit. The performance ends early if you are incapacitated or " +
                                                   "silenced or if you voluntarily end it (no action required).");

            FeaturesDictionary.Add("Magical Secrets", "By 10th level, you have plundered magical knowledge from a wide spectrum or disciplines. Choose two spells from " +
                                                      "any class, including this one. A spell you choose must be of a level you can cast, as shown on the Bard table, or " +
                                                      "a cantrip. The chosen spells count as bard spells for you and are included in the number in the Spells Known column " +
                                                      "of the Bard table. You learn two additional spells from any class at 14th level and again at 18th level.");

            FeaturesDictionary.Add("Superior Inspiration", "At 20th level, when you roll initiative and have no uses of Bardic Inspiration left, you regain one use.");

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
