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

        public int level { get; set; } = 0;

        public int experiencePoints { get; set; } = 0;

        public int hitPoints { get; set; } = 0;

        public AbilityScores abilityScores { get; set; }

        public Skills skills { get; set; }

        public string sex { get; set; } = "";

        public Character()
        {
            abilityScores = new AbilityScores();
        }
    }
}
