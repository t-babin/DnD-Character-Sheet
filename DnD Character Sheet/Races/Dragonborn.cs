using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet.Races
{
    class Dragonborn : Race
    {
        //TODO: Implement Dragonborn special abilities
        //Draconic Ancestry: You have draconic ancestry. Choose one type of dragon from the Draconic Ancestry table.
        //                   Your breath weapon and damage resistance are determined by the dragon type, as shown in the table.
        //-----Dragon----------------Damage Type-----------------Breath Weapon
        //-----Black-----------------Acid------------------------5 by 30 ft. line (Dex. save)
        //-----Blue------------------Lightning-------------------5 by 30 ft. line (Dex. save)
        //-----Brass-----------------Fire------------------------5 by 30 ft. line (Dex. save)
        //-----Bronze----------------Lightning-------------------5 by 30 ft. line (Dex. save)
        //-----Copper----------------Acid------------------------5 by 30 ft. line (Dex. save)
        //-----Gold------------------Fire------------------------15 ft. cone (Dex. save)
        //-----Green-----------------Poison----------------------15 ft. cone (Con. save)
        //-----Red-------------------Fire------------------------15 ft. cone (Dex. save)
        //-----Silver----------------Cold------------------------15 ft. cone (Con. save)
        //-----White-----------------Cold------------------------15 ft. cone (Con. save)

        //Breath Weapon: You can use your action to exhale destrucive energy. Your draconic ancestry determines the size, shape,
        //               and damage type of the exhalation. When you use your breath weapon, each creature in teh area of the exhalation
        //               must make a saving throw, the type of which is determined by your draconic ancestry. The DC for this saving throw
        //               equals 8 + your Constitution modifier + your proficiency bonus. A creature takes 2d6 damage on a failed save, and half
        //               as much damage on a successful one. The damage increases to 3d6 at 6th level, 4d6 at 11th level, and 5d6 at 16th level.
        //               After you use your breath weapon, you can't use it again until you complete a short or long rest.
        //Damage Resistance: You have resistance to the damage type associated with your draconic ancestry.

        public Dragonborn()
        {
            RaceName = "Dragonborn";
            AbilityScoreIncrease = new Tuple<string, int>("Strength", 2);
            BaseSpeed = 30;
            Languages = new string[2] { "Common", "Draconic" };
            MinimumHeight = 6;
            MaximumHeight = 8;
            Size = 2;
        }

        public override string AbilityIncreasePrintString()
        {
            string abilityString = " +2 Str (Dragonborn) +1 Cha (Dragonborn)";
            return abilityString;
        }

        public override void AddSubraceBonuses(string subrace)
        {
            //This is to work around the Dragonborn ability that increases both their strength and charisma
            SubraceAbilityScoreIncrease = new Tuple<string, int>("Charisma", 1);
        }
    }
}
