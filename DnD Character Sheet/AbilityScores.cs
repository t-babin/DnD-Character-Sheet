using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet
{
    class AbilityScores
    {
        public int[] Strength { get; set; } = new int[2];
        public int[] Dexterity { get; set; } = new int[2];
        public int[] Constitution { get; set; } = new int[2];
        public int[] Intelligence { get; set; } = new int[2];
        public int[] Wisdom { get; set; } = new int[2];
        public int[] Charisma { get; set; } = new int[2];
        public int[] finalStats { get; set; } = new int[6];

        public AbilityScores()
        {

        }

        public int[] RollStats()
        {
            //finalStats = new int[6]; //{ Strength[0], Dexterity[0], Constitution[0], Intelligence[0], Wisdom[0], Charisma[0] };
            int[] tmpStats = new int[4];

            Random rand = new Random();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tmpStats[j] = rand.Next(1, 7);
                }

                Array.Sort(tmpStats);
                finalStats[i] = tmpStats[1] + tmpStats[2] + tmpStats[3];
            }
            return finalStats;
        }
    }
}
