using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet
{
    class AbilityScores
    {
        public int[] finalStats { get; set; } = new int[6];
        public Dictionary<string, int[]> Scores = new Dictionary<string, int[]>()
        {
            { "Strength", new int[2] },
            { "Dexterity", new int[2] },
            { "Constitution", new int[2] },
            { "Intelligence", new int[2] },
            { "Wisdom", new int[2] },
            { "Charisma", new int[2] }
        };

        public AbilityScores()
        {
        }

        public void SetStat(string stat, int statValue)
        {
            int[] values = Scores[stat];
            values[0] = statValue;
            values[1] = computeModifier(values[0]);
        }

        private int computeModifier(int v)
        {
            int[] mods = new int[] { -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2,
                                      3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10};
            
            return mods[v-1];
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
