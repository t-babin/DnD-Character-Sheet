﻿using System;
using System.Collections.Generic;

// TODO implement rogue
namespace DnD_Character_Sheet.Character_Classes
{
    internal class Rogue : CharacterClass
    {
        public override Dictionary<string, List<string>> AdditionalFeaturesTable
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override int NumberOfSelectableSkills
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override List<string> SelectableSkills
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override string SpellcastingAbility
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddClassFeatures()
        {
            throw new NotImplementedException();
        }

        public override void AddProficiencies()
        {
            throw new NotImplementedException();
        }

        public override int CalculateHitPoints(int level, AbilityScores scores)
        {
            throw new NotImplementedException();
        }
    }
}