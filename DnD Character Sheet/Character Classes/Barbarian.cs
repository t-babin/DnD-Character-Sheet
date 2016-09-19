﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet.Character_Classes
{
    class Barbarian : CharacterClass
    {
        //Rage: In battle, you fight with primal ferocity. On your turn, you can enter a rage as a bonus action. While raging, you gain the
        //      following benefits if you aren't wearing heavy armor: You have advantage on Strength checks and Strength saving throws.
        //      When you make a melee weapon attack using Strength, you gain a bonus to the damage rol that increases as you gain levels as
        //      a barbarian, as shown in the Rage Damage column of the Barbarian table. You have resistance to bludgeoning, piercing, and
        //      slashing damage. If you are able to cast spells, you can't cast them or concentrate on them while raging. You rage lasts for
        //      1 minute. It ends early if you are knocked unconscious or if your turn ends and you haven't attacked a hostile creature since
        //      your last turn or taken damage since then. You can also end your rage on your turn as a bonus action. Once you have raged the
        //      number of times shown for your barbarian level in the Rages colu,n of the Barbarian table, you must finish a long rest before
        //      you can rage again.

        //Unarmored Defense: While you are not wearing any armor, your Armor Class equals 10 + your Dexterity modifier
        //                   + your Constitution modifier. You can use a shield and still gain this benefit.

        //Reckless Attack: Starting at 2nd level, you can throw aside all concern for defense to attack with fierce desperation.
        //                 When you make your first attack on your turn, you can decide to attack recklessly. Doing so gives you
        //                 advantage on melee weapon attack rolls using Strength during this turn, but attack rolls against you
        //                 have advantage until your next turn.

        //Danger Sense: At 2nd level, you gain an uncanny sense of when things nearby aren't as they should be, giving you an edge when
        //              you dodge away from danger. You have advantage on Dexterity saving throws against effects that you can see, such
        //              as traps and spells. To gain this benefit, you can't be blinded, deafened, or incapacitated.

        //Primal Path: At 3rd level, you choose a path that shapes the nature of your rage. Choose the Path of the Berserker or the Path
        //             of the Totem Warrior, both detailed at the end of the class description. Your choice grants you features at 3rd
        //             level and again at 6th, 10th, and 14th levels.

        //Ability Score Improvement: When you reach 4th level, and again at 8th, 12th, 16th, and 19th level, you can increase one ability
        //                           score of your choice by 2, or you can increase two ability scores of your choice by 1. As normal, you
        //                           can't increase an ability score above 20 using this feature.

        //Extra Attack: Beginning at 5th level, you can attack twice, instead of once, whenever you take the Attack action on your turn.

        //Fast Movement: Starting at 5th level, your speed increases by 10 feet while you aren't wearing heavy armor.

        //Feral Instinct: By 7th level, your instincts are so honed that you have advantage on initiative rolls. Additionally, if you are
        //                surprised at the beginning of combat and aren't incapacitated, you can act normally on your first turn, but only
        //                if you enter your rage before doing anything else on that turn.

        //TODO finish adding the Barbarian features. I guess these will be strings somewhere that can be used in the Form?

        public Barbarian()
        {
            HitPointDieType = 12;
            ProficientArmors = new List<string>(new string[] { "Light Armor", "Medium Armor", "Shields"});
            ProficientWeapons.AddRange(Weapons.SimpleMeleeWeapons);
            ProficientWeapons.AddRange(Weapons.MartialMeleeWeapons);
            ProficientTools.Add("None");
            SavingThrows.Add("Strength");
            SavingThrows.Add("Constitution");
            SelectableSkills.Add(2, new string[] { "Animal Handling", "Athletics", "Intimidation", "Nature", "Perception", "Survival"});
            ProficiencyBonus = 2;
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
