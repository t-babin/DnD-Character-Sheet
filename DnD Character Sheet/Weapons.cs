using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet
{
    class Weapons
    {
        public static List<Tuple<string, string, string, string>> SimpleMeleeWeapons = new List<Tuple<string, string, string, string>>(
            new Tuple<string, string, string, string>[]
            {
                new Tuple<string, string, string, string>("Club", "1d4 Bludgeoning", "2 lb", "Light"),
                new Tuple<string, string, string, string>("Dagger", "1d4 Piercing", "", ""),
                new Tuple<string, string, string, string>("Greatclub", "1d8 Bludgeoning", "", ""),
                new Tuple<string, string, string, string>("Handaxe", "1d6 Slashing", "", ""),
                new Tuple<string, string, string, string>("Javelin", "1d6 Piercing", "", ""),
                new Tuple<string, string, string, string>("Light Hammer", "1d4 Bludgeoning", "", ""),
                new Tuple<string, string, string, string>("Mace", "1d6 Bludgeoning", "", ""),
                new Tuple<string, string, string, string>("Quarterstaff", "1d6 Bludgeoning", "", ""),
                new Tuple<string, string, string, string>("Sickle", "1d4 Slashing", "", ""),
                new Tuple<string, string, string, string>("Spear", "1d6 Piercing", "", ""),
                new Tuple<string, string, string, string>("Club", "1 Bludgeoning", "", "")
            });

        public static List<Tuple<string, string, string, string>> SimpleRangedWeapons = new List<Tuple<string, string, string, string>>(
            new Tuple<string, string, string, string>[]
            {
                new Tuple<string, string, string, string>("Crossbow, light", "1d8 Piercing", "", ""),
                new Tuple<string, string, string, string>("Dart", "1d4 Piercing", "", ""),
                new Tuple<string, string, string, string>("Shortbow", "1d6 Piercing", "", ""),
                new Tuple<string, string, string, string>("Sling", "1d4 Bludgeoning", "", "")
            });

        //TODO fix these last 2 and add in the weight and properties of each one
        public static Dictionary<string, string> MartialMeleeWeapons = new Dictionary<string, string>()
        {
            { "Battleaxe", "1d8 Slashing" },
            { "Flail", "1d8 Bludgeoning" },
            { "Glaive", "1d10 Slashing" },
            { "Greataxe", "1d12 Slashing" },
            { "Greatsword", "2d6 Slashing" },
            { "Halberd", "1d10 Slashing" },
            { "Lance", "1d12 Piercing" },
            { "Longsword", "1d8 Slashing" },
            { "Maul", "2d6 Bludgeoning" },
            { "Morningstar", "1d8 Piercing" },
            { "Pike", "1d10 Piercing" },
            { "Rapier", "1d8 Piercing" },
            { "Scimitar", "1d6 Slashing" },
            { "Shortsword", "1d6 Piercing" },
            { "Trident", "1d6 Piercing" },
            { "War Pick", "1d8 Piercing" },
            { "Warhammer", "1d8 Bludgeoning" },
            { "Whip", "1d4 Slashing" }
        };

        public static Dictionary<string, string> MartialRangedWeapons = new Dictionary<string, string>()
        {
            { "Blowgun", "1 Piercing" },
            { "Crossbow, hand", "1d6 Piercing" },
            { "Crossbow, heavy", "1d10 Piercing" },
            { "Longbow", "1d8 Piercing" },
            { "Net", "--" }
        };
    }
}
