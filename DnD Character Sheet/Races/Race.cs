using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet
{
    abstract class Race
    {
        public virtual Tuple<string, int> AbilityScoreIncrease { get; set; } = null;

        public virtual Tuple<string, int> SubraceAbilityScoreIncrease { get; set; } = null;

        public virtual int BaseSpeed { get; set; } = 0;

        public virtual String[] Languages { get; set; } = null;

        public virtual Race[] Subraces { get; set; } = null;

        public string Subrace { get; set; } = null;

        public string RaceName { get; set; } = "";

        //1 = small; 2 = medium; 3 = large;
        public int Size { get; set; } = 0;

        public virtual int MinimumHeight { get; set; } = 0;

        public virtual int MaximumHeight { get; set; } = 0;

        public Dictionary<string, string> FeaturesDictionary { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, string> SubraceFeaturesDictionary { get; set; } = new Dictionary<string, string>();

        public static Dictionary<string, List<string>> SubraceDictionary = new Dictionary<string, List<string>>()
        {
            { "Dwarf", new List<string>(new string[] {"Hill Dwarf", "Mountain Dwarf"}) },
            { "Elf", new List<string>(new string[] {"High Elf", "Wood Elf", "Dark Elf"}) },
            { "Halfling", new List<string>(new string[] {"Lightfood", "Stout"}) },
            { "Human", new List<string>(new string[] {"None"}) },
            { "Dragonborn", new List<string>(new string[] {"None"}) },
            { "Gnome", new List<string>(new string[] {"Forest Gnome", "Rock Gnome"}) },
            { "Half-Elf", new List<string>(new string[] {"None"}) },
            { "Half-Orc", new List<string>(new string[] {"None"}) },
            { "Tiefling", new List<string>(new string[] {"None"}) },
        };

        public abstract void AddSubraceBonuses(string subrace);

        public abstract string AbilityIncreasePrintString();
    }
}
