using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Sheet.Races
{
    class Gnome : Race
    {
        //TODO: Implement Gnome Special Abilities

        //Forest Gnome
        //Natural Illusionist: You know the minor illusion cantrip. Intelligence is your spellcasting ability for it.
        //Speak with Small Beasts: Through sounds and gestures, you an communicate simple ideas with Small or smaller beasts. Forest
        //                         Gnomes love animals and often keep squirrels, badgers, rabbits, moles, woodpeckers, and other creatures
        //                         as beloved pets.

        //Rock Gnome
        //Artificer's Lore: Whenever you make an Intelligence (History) check related to magic items, alchemical objects, or technological
        //                  devices, you can add twice your proficiency bonus, instead of any proficiency bonus you normally apply.
        //Tinker: You have proficiency with artisan's tools (tinker's tools). Using these tools, you can spend 1 hour and 10 gp worth of
        //        materials to construct a Tiny clockwork device (AC 5, 1 hp). The device ceases to function after 24 hours (unless you spend
        //        1 hour repairing it to keep the device functioning), or when you use your action to dismantle it; at that time, you can reclaim
        //        the materials used to create it. You can have up to three such devices active at a time. When you create a device, choose one of
        //        the following options:
        //        Clockwork Toy: This toy is a clockwork animal, monster, or person, such as a frog, mouse, bird, dragon, or soldier. When placed
        //                       on the ground, the toy moves 5 feet across the ground on each of your turns in a random direction. It makes noises
        //                       as appropriate to the creature it represents.
        //        Fire Starter: The device produces a miniature flame, which you can use to light a candle, torch, or campfire. Using the device
        //                      requires your action.
        //        Music Box: When opened, this music box plays a single song at a moderate volume. The box stops playing when it reaches the song's
        //                   end or when it is closed.

        public Gnome()
        {
            RaceName = "Gnome";
            AbilityScoreIncrease = new Tuple<string, int>("Intelligence", 2);
            BaseSpeed = 25;
            Languages = new List<string>(new[] { "Common", "Gnomish" });
            MinimumHeight = 3;
            MaximumHeight = 4;
            Size = 1;
            FeaturesDictionary.Add("Darkvision", "Accustomed to life underground, you have superior vision in dark and dim conditions. " +
                                                 "You can see in dim light within 60 feet of you as if it were bright light, and in darkness " +
                                                 "as if it were dim light. You can't discern color in darkness, only shades of gray.");

            FeaturesDictionary.Add("Gnome Cunning", "You have advantage on all Intelligence, Wisdom, and Charisma saving throws against magic.");

            FeaturesDictionary.Add("Languages Known", "You can speak, read, and write Common and Gnomish. The Gnomish language, which uses " +
                                                       "the Dwarvish script, is renowned for its technical treatises and its catalogs of knowledge about " +
                                                       "the natural world.");
        }

        public override string AbilityIncreasePrintString()
        {
            string abilityString = " +2 Int (Gnome)";
            Console.WriteLine(Subrace);
            switch (Subrace)
            {
                case "Forest Gnome":
                    abilityString += " +1 Dex (Forest Gnome)";
                    break;
                case "Rock Gnome":
                    abilityString += " +1 Con (Rock Gnome)";
                    break;
            }

            return abilityString;
        }

        public override void AddSubraceBonuses(string subrace)
        {
            if (subrace == "Forest Gnome")
            {
                SubraceAbilityScoreIncrease = new Tuple<string, int>("Dexterity", 1);
                SubraceFeaturesDictionary.Add("Natural Illusionist (Forest Gnome)", "You know the minor illusion cantrip. Intelligence " +
                                                                                    "is your spellcasting ability for it.");

                SubraceFeaturesDictionary.Add("Speak with Small Beasts (Forest Gnome)", "Through sounds and gestures, you can communicate " +
                                                    "simple ideas with Small or smaller beasts. Forest gnomes love animals and often keep " +
                                                    "squirrels, badgers, rabbits, moles, woodpeckers, and other creatures as beloved pets.");
            }

            if (subrace == "Rock Gnome")
            {
                SubraceAbilityScoreIncrease = new Tuple<string, int>("Constitution", 1);
                SubraceFeaturesDictionary.Add("Artificer's Lore (Rock Gnome)", "Whenever you make an Intelligence (History) check related to magic " +
                                                                               "items, alchemical objects, or technological devices, you can add " +
                                                                               "twice your proficiency bonus, instead of any proficiency bonus you " +
                                                                               "normally apply.");

                SubraceFeaturesDictionary.Add("Tinker (Rock Gnome)", "You have proficiency with artisan's tools (tinker's tools). Using these tools, " +
                                                                     "you can spend 1 hour and 10 gp worth of materials to construct a Tiny clockwork " +
                                                                     "device (AC 5, 1 hp). The device ceases to function after 24 hours (unless you spend " +
                                                                     "1 hour repairing it to keep the device functioning), or when you use your action to " +
                                                                     "dismantle it; at that time, you can reclaim the materials used to create it. You can " +
                                                                     "have up to three such devices active at a time. When you create a device, choose one of " +
                                                                     "the following options: \n\nClockwork Toy: This toy is a clockwork animal, monster, or " +
                                                                     "person, such as a frog, mouse, bird, dragon, or soldier. When placed on the ground, the " +
                                                                     "toy moves 5 feet across the ground on each of your turns in a random direction. It makes " +
                                                                     "noises as appropriate to the creature it represents. \n\nFire Starter: The device produces " +
                                                                     "a miniature flame, which you can use to light a candle, torch, or campfire. Using the " +
                                                                     "device requires your action. \n\nMusic Box: When opened, this music box plays a single " +
                                                                     "song at a moderate volume. The box stops playing when it reaches the song's end or when " +
                                                                     "it is closed.".Replace("\n", Environment.NewLine));
            }
        }
    }
}
