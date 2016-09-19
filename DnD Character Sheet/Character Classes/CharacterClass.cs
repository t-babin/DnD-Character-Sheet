using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet
{
    abstract class CharacterClass
    {
        public int HitPointDieType { get; set; } = 0;

        public List<string> ProficientArmors { get; set; } = new List<string>();

        public List<string> ProficientWeapons { get; set; } = new List<string>();

        public List<string> ProficientTools { get; set; } = new List<string>();

        public List<string> SavingThrows { get; set; } = new List<string>();

        public Dictionary<int, string[]> SelectableSkills { get; set; } = new Dictionary<int, string[]>();

        //level, proficiency bonus, features
        public List<Tuple<int, int, string[]>> FeaturesPerLevelTable { get; set; } = new List<Tuple<int, int, string[]>>();

        public int ProficiencyBonus { get; set; } = 0;

        abstract public int CalculateHitPoints(int level, AbilityScores scores);

        abstract public void AddProficiencies();
    }
}
