using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet
{
    class Weapons
    {
        public static List<Tuple<string, string, string, string>> SimpleMeleeWeaponsTuple = new List<Tuple<string, string, string, string>>(
            new Tuple<string, string, string, string>[]
            {
                new Tuple<string, string, string, string>("Club", "1d4 Bludgeoning", "2 lb", "Light"),
                new Tuple<string, string, string, string>("Dagger", "1d4 Piercing", "1 lb", "Finesse, light, thrown (range 20/60)"),
                new Tuple<string, string, string, string>("Greatclub", "1d8 Bludgeoning", "10 lb", "Two-handed"),
                new Tuple<string, string, string, string>("Handaxe", "1d6 Slashing", "2 lb", "Light, thrown (range 20/60)"),
                new Tuple<string, string, string, string>("Javelin", "1d6 Piercing", "2 lb", "Thrown (range 30/120)"),
                new Tuple<string, string, string, string>("Light Hammer", "1d4 Bludgeoning", "2 lb", "Light, thrown (range 20/60)"),
                new Tuple<string, string, string, string>("Mace", "1d6 Bludgeoning", "4 lb", "---"),
                new Tuple<string, string, string, string>("Quarterstaff", "1d6 Bludgeoning", "4 lb", "Versatile (1d8)"),
                new Tuple<string, string, string, string>("Sickle", "1d4 Slashing", "2 lb", "Light"),
                new Tuple<string, string, string, string>("Spear", "1d6 Piercing", "3 lb", "Thrown (range 20/60), versatile (1d8)"),
                new Tuple<string, string, string, string>("Unarmed Strike", "1 Bludgeoning", "---", "---")
            });

        public static List<Tuple<string, string, string, string>> SimpleRangedWeaponsTuple = new List<Tuple<string, string, string, string>>(
            new Tuple<string, string, string, string>[]
            {
                new Tuple<string, string, string, string>("Crossbow, light", "1d8 Piercing", "5 lb", "Ammunition (range 80/320), loading, two-handed"),
                new Tuple<string, string, string, string>("Dart", "1d4 Piercing", "1/4 lb", "Finesse, thrown (range 20/60)"),
                new Tuple<string, string, string, string>("Shortbow", "1d6 Piercing", "2 lb", "Ammunition (range 80/320), two-handed"),
                new Tuple<string, string, string, string>("Sling", "1d4 Bludgeoning", "---", "Ammunition (range 30/120)")
            });

        public static List<Tuple<string, string, string, string>> MartialMeleeWeaponsTuple = new List<Tuple<string, string, string, string>>(
            new Tuple<string, string, string, string>[]
            {
                new Tuple<string, string, string, string>("Battleaxe", "1d8 Slashing", "4 lb", "Versatile (1d10)"),
                new Tuple<string, string, string, string>("Flail", "1d8 Bludgeoning", "2 lb", "---"),
                new Tuple<string, string, string, string>("Glaive", "1d10 Slashing", "6 lb", "Heavy, reach, two-handed"),
                new Tuple<string, string, string, string>("Greataxe", "1d12 Slashing", "7 lb", "Heavy, two-handed"),
                new Tuple<string, string, string, string>("Greatsword", "2d6 Slashing", "6 lb", "Heavy, two-handed"),
                new Tuple<string, string, string, string>("Halberd", "1d10 Slashing", "6 lb", "Heavy, reach, two-handed"),
                new Tuple<string, string, string, string>("Lance", "1d12 Piercing", "6 lb", "Reach, special"),
                new Tuple<string, string, string, string>("Longsword", "1d8 Slashing", "3 lb", "Versatile (1d10)"),
                new Tuple<string, string, string, string>("Maul", "2d6 Bludgeoning", "10 lb", "Heavy, two-handed"),
                new Tuple<string, string, string, string>("Morningstar", "1d8 Piercing", "4 lb", "---"),
                new Tuple<string, string, string, string>("Pike", "1d10 Piercing", "18 lb", "Heavy, reach, two-handed"),
                new Tuple<string, string, string, string>("Rapier", "1d8 Piercing", "2 lb", "Finesse"),
                new Tuple<string, string, string, string>("Scimitar", "1d6 Slashing", "3 lb", "Finesse, light"),
                new Tuple<string, string, string, string>("Shortsword", "1d6 Piercing", "2 lb", "Finesse, light"),
                new Tuple<string, string, string, string>("Trident", "1d6 Piercing", "4 lb", "Thrown (range 20/60), versatile (1d8)"),
                new Tuple<string, string, string, string>("War Pick", "1d8 Piercing", "2 lb", "---"),
                new Tuple<string, string, string, string>("Warhammer", "1d8 Bludgeoning", "2 lb", "Versatile (1d10)"),
                new Tuple<string, string, string, string>("Whip", "1d4 Slashing", "3 lb", "Finesse, reach")
            });

        public static List<Tuple<string, string, string, string>> MartialRangedWeaponsTuple = new List<Tuple<string, string, string, string>>(
            new Tuple<string, string, string, string>[]
            {
                new Tuple<string, string, string, string>("Blowgun", "1 Piercing", "1 lb", "Ammunition (range 25/100), loading"),
                new Tuple<string, string, string, string>("Crossbow, hand", "1d6 Piercing", "3 lb", "Ammunition (range 30/120), light, loading"),
                new Tuple<string, string, string, string>("Crossbow, heavy", "1d10 Piercing", "18 lb", "Ammunition (range 100/400), heavy, loading, two-handed"),
                new Tuple<string, string, string, string>("Longbow", "1d8 Piercing", "2 lb", "Ammunition (range 150/600), heavy, two-handed"),
                new Tuple<string, string, string, string>("Net", "--", "3 lb", "Special, thrown (range 5/15)")
            });

        public static List<string> SimpleMeleeWeapons = new List<string>(SimpleMeleeWeaponsTuple.Select(t => t.Item1).ToList());

        public static List<string> SimpleRangedWeapons = new List<string>(SimpleRangedWeaponsTuple.Select(t => t.Item1).ToList());

        public static List<string> MartialMeleeWeapons = new List<string>(MartialMeleeWeaponsTuple.Select(t => t.Item1).ToList());

        public static List<string> MartialRangedWeapons = new List<string>(MartialRangedWeaponsTuple.Select(t => t.Item1).ToList());
    }
}
