using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD_Character_Sheet.Character_Classes;

namespace DnD_Character_Sheet
{
    //TODO implement Background
    class Character
    {
        public string Name { get; set; } = "";

        public Race Race { get; set; }

        public int Age { get; set; } = 0;

        public string Alignment { get; set; } = "";

        public int Height { get; set; } = 0;

        public int Weight { get; set; } = 0;

        public CharacterClass CharClass { get; set; }

        public int Level { get; set; } = 1;

        public int ExperiencePoints { get; set; } = 0;

        public int HitPoints { get; set; } = 0;

        public AbilityScores AbilityScores { get; set; }

        public Skills Skills { get; set; }

        public string Sex { get; set; } = "";

        public Character()
        {
            AbilityScores = new AbilityScores();
        }

        public void DetermineLevel()
        {
            int[] xpList = { 0, 300, 900, 2700, 6500, 14000, 23000, 34000, 48000, 64000, 85000,
                             100000, 120000, 140000, 165000, 195000, 225000, 265000, 305000, 355000};
            
            for (int i = 0; i < xpList.Length; i++)
            {
                if (ExperiencePoints >= xpList[i])
                    Level = i + 1;
            }
        }
    }
}
