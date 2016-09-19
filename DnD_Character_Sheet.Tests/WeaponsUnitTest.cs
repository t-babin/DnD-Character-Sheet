using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DnD_Character_Sheet.Tests
{
    [TestClass]
    public class WeaponsUnitTest
    {
        [TestMethod]
        public void TestSimpleMeleeWeaponStrings()
        {
            List<string> expected = new List<string>(new string[]
            {
                "Club",
                "Dagger",
                "Greatclub",
                "Handaxe",
                "Javelin",
                "Light Hammer",
                "Mace",
                "Quarterstaff",
                "Sickle",
                "Spear",
                "Unarmed Strike"
            });

            CollectionAssert.AreEqual(expected, Weapons.SimpleMeleeWeapons);
        }

        [TestMethod]
        public void TestSimpleRangedWeaponStrings()
        {
            List<string> expected = new List<string>(new string[]
            {
                "Crossbow, light",
                "Dart",
                "Shortbow",
                "Sling"
            });

            CollectionAssert.AreEqual(expected, Weapons.SimpleRangedWeapons);
        }

        [TestMethod]
        public void TestMartialMeleeWeaponStrings()
        {
            List<string> expected = new List<string>(new string[]
            {
                "Battleaxe",
                "Flail",
                "Glaive",
                "Greataxe",
                "Greatsword",
                "Halberd",
                "Lance",
                "Longsword",
                "Maul",
                "Morningstar",
                "Pike",
                "Rapier",
                "Scimitar",
                "Shortsword",
                "Trident",
                "War Pick",
                "Warhammer",
                "Whip"
            });

            CollectionAssert.AreEqual(expected, Weapons.MartialMeleeWeapons);
        }

        [TestMethod]
        public void TestMartialRangedWeaponStrings()
        {
            List<string> expected = new List<string>(new string[]
            {
                "Blowgun",
                "Crossbow, hand",
                "Crossbow, heavy",
                "Longbow",
                "Net"
            });

            CollectionAssert.AreEqual(expected, Weapons.MartialRangedWeapons);
        }
    }
}
