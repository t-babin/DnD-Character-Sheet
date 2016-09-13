using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet
{
    class Character
    {
        public String name { get; set; } = "";

        public Race race { get; set; }

        public int age { get; set; } = 0;

        public String alignment { get; set; } = "";

        public int height { get; set; } = 0;

        public int weight { get; set; } = 0;

        public CharacterClass charClass { get; set; }

        public int level { get; set; } = 1;

        public int experiencePoints { get; set; } = 0;

        public int hitPoints { get; set; } = 0;

        public AbilityScores abilityScores { get; set; }

        public Skills skills { get; set; }

        public string sex { get; set; } = "";

        public Character()
        {
            abilityScores = new AbilityScores();
        }

        public void DetermineLevel()
        {
            int[] xpList = { 0, 300, 900, 2700, 6500, 14000, 23000, 34000, 48000, 64000, 85000,
                             100000, 120000, 140000, 165000, 195000, 225000, 265000, 305000, 355000};

            //level = 1;
            for (int i = 0; i < xpList.Length; i++)
            {
                if (experiencePoints >= xpList[i])
                    level = i + 1;
            }
        }
    }
}
