﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet.Character_Classes
{
    class Barbarian : CharacterClass
    {
        //TODO finish adding the Barbarian features. I guess these will be strings somewhere that can be used in the Form?
        public Barbarian()
        {
            HitPointDieType = 12;
            //ProficiencyBonus = 2;
            ProficientArmors = new List<string>(new string[] { "Light Armor", "Medium Armor", "Shields" });
            AddProficiencies();            
            SelectableSkills.Add(2, new string[] { "Animal Handling", "Athletics", "Intimidation", "Nature", "Perception", "Survival"});
            FeaturesPerLevelTable = new List<Tuple<int, int, string[]>>(new Tuple<int, int, string[]>[]
            {
                new Tuple<int, int, string[]>(1, 2, new string[] { "Rage", "Unarmored Defense" }),
                new Tuple<int, int, string[]>(2, 2, new string[] { "Reckless Attack", "Danger Sense" }),
                new Tuple<int, int, string[]>(3, 2, new string[] { "Primal Path" }),
                new Tuple<int, int, string[]>(4, 2, new string[] { "Ability Score Improvement" }),
                new Tuple<int, int, string[]>(5, 3, new string[] { "Extra Attack", "Fast Movement" }),
                new Tuple<int, int, string[]>(6, 3, new string[] { "Path Feature" }),
                new Tuple<int, int, string[]>(7, 3, new string[] { "Feral Instinct" }),
                new Tuple<int, int, string[]>(8, 3, new string[] { "Ability Score Improvement" }),
                new Tuple<int, int, string[]>(9, 4, new string[] { "Brutal Critical (1 die)" }),
                new Tuple<int, int, string[]>(10, 4, new string[] { "Path Feature" }),
                new Tuple<int, int, string[]>(11, 4, new string[] { "Relentless Rage" }),
                new Tuple<int, int, string[]>(12, 4, new string[] { "Ability Score Improvement" }),
                new Tuple<int, int, string[]>(13, 5, new string[] { "Brutal Critical (2 dice)" }),
                new Tuple<int, int, string[]>(14, 5, new string[] { "Path Feature" }),
                new Tuple<int, int, string[]>(15, 5, new string[] { "Persistent Rage" }),
                new Tuple<int, int, string[]>(16, 5, new string[] { "Ability Score Improvement" }),
                new Tuple<int, int, string[]>(17, 6, new string[] { "Brutal Critical (3 dice)" }),
                new Tuple<int, int, string[]>(18, 6, new string[] { "Indomitable Might" }),
                new Tuple<int, int, string[]>(19, 6, new string[] { "Ability Score Improvement" }),
                new Tuple<int, int, string[]>(20, 6, new string[] { "Primal Champion" })
            });
            AddClassFeatures();
        }

        public override void AddProficiencies()
        {
            ProficientWeapons.AddRange(Weapons.SimpleMeleeWeapons);
            ProficientWeapons.AddRange(Weapons.MartialMeleeWeapons);
            ProficientTools.Add("None");
            SavingThrows.Add("Strength");
            SavingThrows.Add("Constitution");
        }

        public override void AddClassFeatures()
        {
            FeaturesDictionary.Add("Rage", "In battle, you fight with primal ferocity. On your turn, you can enter a rage as a bonus action. While raging, you gain the " +
                                           "following benefits if you aren't wearing heavy armor: You have advantage on Strength checks and Strength saving throws. " +
                                           "When you make a melee weapon attack using Strength, you gain a bonus to the damage rol that increases as you gain levels as " +
                                           "a barbarian, as shown in the Rage Damage column of the Barbarian table. You have resistance to bludgeoning, piercing, and " +
                                           "slashing damage.If you are able to cast spells, you can't cast them or concentrate on them while raging. You rage lasts for " +
                                           "1 minute.It ends early if you are knocked unconscious or if your turn ends and you haven't attacked a hostile creature since " +
                                           "your last turn or taken damage since then. You can also end your rage on your turn as a bonus action. Once you have raged the " +
                                           "number of times shown for your barbarian level in the Rages colu, n of the Barbarian table, you must finish a long rest before " +
                                           "you can rage again.");

            FeaturesDictionary.Add("Unarmored Defense", "While you are not wearing any armor, your Armor Class equals 10 + your Dexterity modifier + your Constitution " +
                                                        "modifier. You can use a shield and still gain this benefit.");

            FeaturesDictionary.Add("Reckless Attack", "Starting at 2nd level, you can throw aside all concern for defense to attack with fierce desperation. " +
                                                      "When you make your first attack on your turn, you can decide to attack recklessly.Doing so gives you " +
                                                      "advantage on melee weapon attack rolls using Strength during this turn, but attack rolls against you " +
                                                      "have advantage until your next turn.");

            FeaturesDictionary.Add("Danger Sense", "At 2nd level, you gain an uncanny sense of when things nearby aren't as they should be, giving you an edge " +
                                                   "when you dodge away from danger. You have advantage on Dexterity saving throws against effects that you can " +
                                                   "see, such as traps and spells. To gain this benefit, you can't be blinded, deafened, or incapacitated.");

            FeaturesDictionary.Add("Primal Path", "At 3rd level, you choose a path that shapes the nature of your rage. Choose the Path of the Berserker or the " +
                                                  "Path of the Totem Warrior, both detailed at the end of the class description. Your choise grants you features " +
                                                  "at 3rd level and again at 6th, 10th, and 14th levels.");

            FeaturesDictionary.Add("Ability Score Improvement", "When you reach 4th level, and again at 8th, 12th, 16th, and 19th level, you can increase one " +
                                                                "ability score of your choice by 2, or you can increase two ability scores of your choice by 1. " +
                                                                "As normal, you cant increase an ability score above 20 using this feature.");

            FeaturesDictionary.Add("Extra Attack", "Beginning at 5th level, you can attack twice, instead of once, whenever you take the Attack action on your turn.");

            FeaturesDictionary.Add("Fast Movement", "Starting at 5th level, your speed increases by 10 feet while you aren't wearing heavy armor.");

            FeaturesDictionary.Add("Feral Instinct", "By 7th level, your instincts are so honed that you have advantage on initiative rolls. Additionally, " +
                                                     "if you are surprised at the beginning of combat and aren't incapacitated, you can act normally on your first " +
                                                     "turn, but only if you enter your rage before doing anything else on that turn.");

            FeaturesDictionary.Add("Brutal Critical", "Beginning at 9th level, you can roll one additional weapon damage die when determining the extra damage " +
                                                      "die when determining the extra damage for a critical hit with a melee attack. This increases to two additional " +
                                                      "dice at 13th level and three additional dice at 17th level.");

            FeaturesDictionary.Add("Relentless Rage", "Starting at 11th level, your rage can keep you fighting despite grievous wounds. If you drop to 0 hit points " +
                                                      "while you're raging and don't die outright, you can make a DC 10 Constitution saving throw. If you succeed, " +
                                                      "you drop to 1 hit point instead. Each time you use this feature after the first, the DC increases bt 5. When " +
                                                      "you finish a short or long rest, the DC resets to 10.");

            FeaturesDictionary.Add("Persistent Rage", "Beginning at 15th level, your rage is so fierce that it ends early only if you fall unconcious or if you choose " +
                                                      "to end it.");

            FeaturesDictionary.Add("Indomitable Might", "Beginning at 18th level, if your total for a Strength check is less than your Strength score, you can use that " +
                                                        "score in place of the total.");

            FeaturesDictionary.Add("Primal Champion", "At 20th level, you embody the power of the wilds. Your Strength and Constitution scores increase by 4. Your " +
                                                      "maximum for those scores is now 24.");
        }

        //Level 1: 12 + Constitution Modifier
        //Onwards: 1d12 (or 7) + Constitution Modifier
        public override int CalculateHitPoints(int level, AbilityScores scores)
        {
            int hp = 0;

            if (level == 1)
            {
                hp = 12 + scores.Scores["Constitution"][1];
            }
            else
            {

            }

            return hp;
        }
    }
}
