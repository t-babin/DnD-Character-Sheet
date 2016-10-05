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
            { "Strength", new [] { -1, 0 } },
            { "Dexterity", new [] { -1, 0 } },
            { "Constitution", new [] { -1, 0 } },
            { "Intelligence", new [] { -1, 0 } },
            { "Wisdom", new [] { -1, 0 } },
            { "Charisma", new [] { -1, 0 } }
        };

        public Dictionary<string, string[]> RelatedSkills = new Dictionary<string, string[]>()
        {
            { "Strength", new [] { "Athletics" } },
            { "Dexterity", new [] { "Acrobatics", "Sleight of Hand", "Stealth" } },
            { "Constitution", new [] { "" } },
            { "Intelligence", new [] { "Arcana", "History", "Investigation", "Nature", "Religion" } },
            { "Wisdom", new [] { "Animal Handling", "Insight", "Medicine", "Perception", "Survival" } },
            { "Charisma", new [] { "Deception", "Intimidation", "Performance", "Persuasion" } },
        };

        private Dictionary<string, int> skillsDictionary = new Dictionary<string, int>()
        {
            { "Acrobatics", 0 },
            { "Animal Handling", 0 },
            { "Arcana", 0 },
            { "Athletics", 0 },
            { "Deception", 0 },
            { "History", 0 },
            { "Insight", 0 },
            { "Intimidation", 0 },
            { "Investigation", 0 },
            { "Medicine", 0 },
            { "Nature", 0 },
            { "Perception", 0 },
            { "Performance", 0 },
            { "Persuasion", 0 },
            { "Religion", 0 },
            { "Sleight of Hand", 0 },
            { "Stealth", 0 },
            { "Survival", 0 }
        };
        public Dictionary<string, int> SkillsDictionary
        {
            get
            {
                return skillsDictionary;
            }
        }

        private List<string> selectedSkills = new List<string>();
        public List<string> SelectedSkills
        {
            get
            {
                return selectedSkills;
            }
        }

        public AbilityScores() { }

        public void SetStat(string stat, int statValue)
        {
            int[] values = Scores[stat];
            Scores[stat][0] = statValue;
            Scores[stat][1] = computeModifier(Scores[stat][0]);
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

        public bool AllStatsChosen()
        {
            foreach (var item in Scores.Values)
            {
                if (item[0] == -1)
                    return false;
            }

            return true;
        }
    }
}
