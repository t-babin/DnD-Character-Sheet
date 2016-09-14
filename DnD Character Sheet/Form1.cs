using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnD_Character_Sheet.Races;

namespace DnD_Character_Sheet
{    
    public partial class Form1 : Form
    {
        ToolTip BasicInfoToolTip;
        List<String> abilities = new List<string>(new string[] { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" });
        List<Button> saveButtons = new List<Button>();
        List<Label> abilityLabels = new List<Label>();
        List<ComboBox> abilityCombos = new List<ComboBox>();
        bool[] validBasicInfo = new bool[11] { false, false, false, false, false, false, false, false, false, false, false };

        List<Tuple<Button, Label, ComboBox, Label>> abilityScoreFormTuples = new List<Tuple<Button, Label, ComboBox, Label>>();

        Character character;
        XmlDocument document;
        public Form1()
        {
            InitializeComponent();
            abilityScoreFormTuples.Add(new Tuple<Button, Label, ComboBox, Label>(abilityValueOneSaveButton, abilityValueLabelOne, abilityValuesComboOne, abilityValueModifierOne));
            abilityScoreFormTuples.Add(new Tuple<Button, Label, ComboBox, Label>(abilityValueTwoSaveButton, abilityValueLabelTwo, abilityValuesComboTwo, abilityValueModifierTwo));
            abilityScoreFormTuples.Add(new Tuple<Button, Label, ComboBox, Label>(abilityValueThreeSaveButton, abilityValueLabelThree, abilityValuesComboThree, abilityValueModifierThree));
            abilityScoreFormTuples.Add(new Tuple<Button, Label, ComboBox, Label>(abilityValueFourSaveButton, abilityValueLabelFour, abilityValuesComboFour, abilityValueModifierFour));
            abilityScoreFormTuples.Add(new Tuple<Button, Label, ComboBox, Label>(abilityValueFiveSaveButton, abilityValueLabelFive, abilityValuesComboFive, abilityValueModifierFive));
            abilityScoreFormTuples.Add(new Tuple<Button, Label, ComboBox, Label>(abilityValueSixSaveButton, abilityValueLabelSix, abilityValuesComboSix, abilityValueModifierSix));

            saveButtons.Add(abilityValueOneSaveButton);
            saveButtons.Add(abilityValueTwoSaveButton);
            saveButtons.Add(abilityValueThreeSaveButton);
            saveButtons.Add(abilityValueFourSaveButton);
            saveButtons.Add(abilityValueFiveSaveButton);
            saveButtons.Add(abilityValueSixSaveButton);

            abilityLabels.Add(abilityValueLabelOne);
            abilityLabels.Add(abilityValueLabelTwo);
            abilityLabels.Add(abilityValueLabelThree);
            abilityLabels.Add(abilityValueLabelFour);
            abilityLabels.Add(abilityValueLabelFive);
            abilityLabels.Add(abilityValueLabelSix);

            abilityCombos.Add(abilityValuesComboOne);
            abilityCombos.Add(abilityValuesComboTwo);
            abilityCombos.Add(abilityValuesComboThree);
            abilityCombos.Add(abilityValuesComboFour);
            abilityCombos.Add(abilityValuesComboFive);
            abilityCombos.Add(abilityValuesComboSix);
            foreach (string i in abilities)
            {
                abilityValuesComboOne.Items.Add(i);
                abilityValuesComboTwo.Items.Add(i);
                abilityValuesComboThree.Items.Add(i);
                abilityValuesComboFour.Items.Add(i);
                abilityValuesComboFive.Items.Add(i);
                abilityValuesComboSix.Items.Add(i);
            }

            abilityValuesComboOne.Enabled = false;
            abilityValuesComboTwo.Enabled = false;
            abilityValuesComboThree.Enabled = false;
            abilityValuesComboFour.Enabled = false;
            abilityValuesComboFive.Enabled = false;
            abilityValuesComboSix.Enabled = false;
            editBasicInformationButton.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BasicInfoToolTip = new ToolTip();
        }

        private void createCharacterButton_Click(object sender, EventArgs e)
        {
            character = new Character();
            document = new XmlDocument();
            basicInfoPanel.Enabled = true;
            characterNameLabel.ForeColor = Color.Red;
            classLabel.ForeColor = Color.Red;
            raceLabel.ForeColor = Color.Red;
            subraceLabel.ForeColor = Color.Red;
            backgroundLabel.ForeColor = Color.Red;
            alignmentLabel.ForeColor = Color.Red;
            ageLabel.ForeColor = Color.Red;
            basicHeightLabel.ForeColor = Color.Red;
            basicWeightLabel.ForeColor = Color.Red;
            sexLabel.ForeColor = Color.Red;
            xpLabel.ForeColor = Color.Red;
            checkIfBasicInfoVerified();
            //additionalInfoTabControl.Enabled = true;
        }

	    private void saveBasicInfoButton_Click(object sender, EventArgs e)
	    {			
			character.name = characterNameBox.Text;
			character.age = int.Parse(ageTextBox.Text);
			string race = raceComboBox.SelectedItem.ToString();
			switch (race.ToLower())
			{
				case "dwarf":
					character.race = new Dwarf();                    
					speedLabel.Text += " 25 base (Dwarf)";
					languagesLabel.Text += " Common, Dwarvish (Dwarf)";
                    //TODO: Fix subraces.                    
					//switch (subrace.ToLower())
					//{
					//	case "hill dwarf":
					//		//Dwarven Toughness: Your hit point maximum increases by 1, and it increases by 1 every time you gain a level
					//		//character.abilityScores.Wisdom[0] += 1;
     //                       //character.race.Subrace = 
					//		abilityScoreIncreaseLabel.Text += " +1 Wisd (Hill Dwarf)";
					//		break;
					//	case "mountain dwarf":
					//		//Dwarven Armor Training: You have proficiency with light and medium armor.
					//		//character.abilityScores.Strength[0] += 2;
					//		abilityScoreIncreaseLabel.Text += " +2 Str (Mntn Dwarf)";
					//		break;
					//}
					break;
                case "elf":
                    character.race = new Elf();
                    //TODO: fix this shit so that it's a part of each class and not typed here manually
                    speedLabel.Text += " 30 base (Elf)";
                    languagesLabel.Text += " Common, Elvish (Elf)";
                    break;
                case "halfling":
                    character.race = new Halfling();
                    speedLabel.Text += " 25 base (Halfling)";
                    languagesLabel.Text += " Common, Halfling (Halfling)";
                    break;
                case "human":
                    character.race = new Human();
                    speedLabel.Text += " 30 base (Human)";
                    languagesLabel.Text += " Common (Human)";
                    break;
                case "dragonborn":
                    character.race = new Dragonborn();
                    speedLabel.Text += " 30 base (Dragonborn)";
                    break;
                case "gnome":
                    character.race = new Gnome();
                    speedLabel.Text += " 25 base (Gnome)";
                    break;
                case "half elf":
                    character.race = new HalfElf();
                    speedLabel.Text += " 30 base (Half Elf)";
                    break;
                case "half orc":
                    character.race = new HalfOrc();
                    speedLabel.Text += " 30 base (Half Orc)";
                    break;
			}
            character.race.Subrace = (subraceComboBox.SelectedItem.ToString() != "NONE" ? subraceComboBox.SelectedItem.ToString() : "");
            character.race.AddSubraceBonuses(character.race.Subrace);
            character.alignment = alignmentComboBox.SelectedItem.ToString();
            character.weight = int.Parse(weightTextBox.Text);
            character.height = int.Parse(heightTextBox.Text);
            character.sex = sexComboBox.SelectedItem.ToString();
            character.experiencePoints = int.Parse(xpTextBox.Text);
            character.DetermineLevel();
            levelLabel.Text = character.level.ToString();
            abilityScoreIncreaseLabel.Text += character.race.AbilityIncreasePrintString();

            additionalInfoTabControl.Enabled = true;
            saveBasicInfoButton.Enabled = false;
            characterNameBox.Enabled = false;
            classComboBox.Enabled = false;
            raceComboBox.Enabled = false;
            subraceComboBox.Enabled = false;
            backgroundComboBox.Enabled = false;
            alignmentComboBox.Enabled = false;
            ageTextBox.Enabled = false;
            heightTextBox.Enabled = false;
            weightTextBox.Enabled = false;
            sexComboBox.Enabled = false;
            xpTextBox.Enabled = false;
            editBasicInformationButton.Enabled = true;
        }

        private void rollStatsButton_Click(object sender, EventArgs e)
        {
            abilityValuesComboOne.Enabled = true;
            abilityValuesComboTwo.Enabled = true;
            abilityValuesComboThree.Enabled = true;
            abilityValuesComboFour.Enabled = true;
            abilityValuesComboFive.Enabled = true;
            abilityValuesComboSix.Enabled = true;

            int[] stats = character.abilityScores.RollStats();
            abilityValueLabelOne.Text = stats[0].ToString();
            abilityValueLabelTwo.Text = stats[1].ToString();
            abilityValueLabelThree.Text = stats[2].ToString();
            abilityValueLabelFour.Text = stats[3].ToString();
            abilityValueLabelFive.Text = stats[4].ToString();
            abilityValueLabelSix.Text = stats[5].ToString();
        }

        private void removeTagFromAll(int currentComboBox, string tag)
        {
            abilityValuesComboOne.Items.Remove(tag);
            abilityValuesComboTwo.Items.Remove(tag);
            abilityValuesComboThree.Items.Remove(tag);
            abilityValuesComboFour.Items.Remove(tag);
            abilityValuesComboFive.Items.Remove(tag);
            abilityValuesComboSix.Items.Remove(tag);

            switch (currentComboBox)
            {
                case 1:
                    abilityValuesComboOne.Items.Add(tag);
                    abilityValuesComboOne.SelectedItem = tag;
                    break;
                case 2:
                    abilityValuesComboTwo.Items.Add(tag);
                    abilityValuesComboTwo.SelectedItem = tag;
                    break;
                case 3:
                    abilityValuesComboThree.Items.Add(tag);
                    abilityValuesComboThree.SelectedItem = tag;
                    break;
                case 4:
                    abilityValuesComboFour.Items.Add(tag);
                    abilityValuesComboFour.SelectedItem = tag;
                    break;
                case 5:
                    abilityValuesComboFive.Items.Add(tag);
                    abilityValuesComboFive.SelectedItem = tag;
                    break;
                case 6:
                    abilityValuesComboSix.Items.Add(tag);
                    abilityValuesComboSix.SelectedItem = tag;
                    break;
            }
        }

        private Tuple<Button, Label, ComboBox, Label> getSaveTuple(Button sender)
        {
            foreach (Tuple<Button, Label, ComboBox, Label> l in abilityScoreFormTuples)
            {
                if (l.Item1 == sender)
                {
                    return l;
                }
            }

            return null;
        }

        private Tuple<Button, Label, ComboBox, Label> getSaveTuple(ComboBox sender)
        {
            foreach (Tuple<Button, Label, ComboBox, Label> l in abilityScoreFormTuples)
            {
                if (l.Item3 == sender)
                {
                    return l;
                }
            }

            return null;
        }

        //TODO: Make the save buttons only clickable when the associated combobox has an item selected
        private void saveAbilityRoll_handler(object sender, EventArgs e)
        {
            //int tmp = triple.IndexOf()
            Tuple<Button, Label, ComboBox, Label> tuple = getSaveTuple((Button) sender);
            string ability = tuple.Item3.Text;
            rollStatsButton.Enabled = false;
            character.abilityScores.SetStat(ability, int.Parse(tuple.Item2.Text));
            removeTagFromAll(saveButtons.IndexOf((Button)sender) + 1, ability);
            tuple.Item4.Text = "(" + character.abilityScores.Scores[ability][1].ToString() + ")";
            tuple.Item3.Enabled = false;
            ((Button) sender).Enabled = false;
        }

        private void abilityValuesComboBoxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tuple<Button, Label, ComboBox, Label> tup = getSaveTuple((ComboBox) sender);
            int tmp = abilityScoreFormTuples.IndexOf(tup);
            tup.Item2.Text = character.abilityScores.finalStats[abilityScoreFormTuples.IndexOf(tup)].ToString();
            int oldStat = int.Parse(tup.Item2.Text);
            string statSelected = ((ComboBox) sender).SelectedItem.ToString();
            string characterAbilityIncrease = character.race.AbilityScoreIncrease.Item1;
            string subRaceAbilityIncrease = (character.race.SubraceAbilityScoreIncrease != null) ? character.race.SubraceAbilityScoreIncrease.Item1 : null;
            if (statSelected.Equals(characterAbilityIncrease))
            {
                tup.Item2.Text = (oldStat + character.race.AbilityScoreIncrease.Item2).ToString();
            }

            if (statSelected.Equals(subRaceAbilityIncrease))
                tup.Item2.Text = (oldStat + character.race.SubraceAbilityScoreIncrease.Item2).ToString();
            if (character.race is Human)
                tup.Item2.Text = (oldStat + 1).ToString();
        }

        private void raceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            subraceLabel.ForeColor = Color.Red;
            raceLabel.ForeColor = Color.Black;
            subraceComboBox.Items.Clear();
            string selectedRace = raceComboBox.SelectedItem.ToString();
            List<string> subraceList = Race.SubraceDictionary[selectedRace];
            foreach (string s in subraceList)
            {
                subraceComboBox.Items.Add(s);
            }
            validBasicInfo[2] = true;
            checkIfBasicInfoVerified();
        }

        private void characterNameBox_TextChanged(object sender, EventArgs e)
        {
            string text = characterNameBox.Text;
            if (text.Contains(" "))
            {
                string[] split = text.Split(' ');
                for (int i = 0; i < split.Length; i++)
                {
                    if (!split[i].All(char.IsLetter))
                    {
                        characterNameLabel.ForeColor = Color.Red;
                        validBasicInfo[0] = false;
                    }
                    else
                    {
                        characterNameLabel.ForeColor = Color.Black;
                        validBasicInfo[0] = true;
                    }
                }
            }
            else
            {
                if (!text.All(char.IsLetter))
                {
                    characterNameLabel.ForeColor = Color.Red;
                    validBasicInfo[0] = false;
                }
                else
                {
                    characterNameLabel.ForeColor = Color.Black;
                    validBasicInfo[0] = true;
                }
            }
            if (text.Length == 0)
            {
                characterNameLabel.ForeColor = Color.Red;
                validBasicInfo[0] = false;
            }
            checkIfBasicInfoVerified();
        }

        private void classComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            classLabel.ForeColor = Color.Black;
            validBasicInfo[1] = true;
            checkIfBasicInfoVerified();
        }

        private void subraceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            subraceLabel.ForeColor = Color.Black;
            validBasicInfo[3] = true;
            checkIfBasicInfoVerified();
        }

        private void backgroundComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            backgroundLabel.ForeColor = Color.Black;
            validBasicInfo[4] = true;
            checkIfBasicInfoVerified();
        }

        private void alignmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            alignmentLabel.ForeColor = Color.Black;
            validBasicInfo[5] = true;
            checkIfBasicInfoVerified();
        }

        private void sexComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sexLabel.ForeColor = Color.Black;
            validBasicInfo[9] = true;
            checkIfBasicInfoVerified();
        }

        private void ageTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = ageTextBox.Text;
            if (!text.All(char.IsDigit))
            {
                ageLabel.ForeColor = Color.Red;
                validBasicInfo[6] = false;
            }
            else
            {
                ageLabel.ForeColor = Color.Black;
                validBasicInfo[6] = true;
            }
            if (text.Length == 0)
            {
                ageLabel.ForeColor = Color.Red;
                validBasicInfo[6] = false;
            }
            checkIfBasicInfoVerified();
        }

        private void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = heightTextBox.Text;
            if (!text.All(char.IsDigit))
            {
                basicHeightLabel.ForeColor = Color.Red;
                validBasicInfo[6] = false;
            }
            else
            {
                basicHeightLabel.ForeColor = Color.Black;
                validBasicInfo[7] = true;
            }
            if (text.Length == 0)
            {
                basicHeightLabel.ForeColor = Color.Red;
                validBasicInfo[7] = false;
            }
            checkIfBasicInfoVerified();
        }

        private void weightTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = weightTextBox.Text;
            if (!text.All(char.IsDigit))
            {
                basicWeightLabel.ForeColor = Color.Red;
                validBasicInfo[8] = false;
            }
            else
            {
                basicWeightLabel.ForeColor = Color.Black;
                validBasicInfo[8] = true;
            }
            if (text.Length == 0)
            {
                basicWeightLabel.ForeColor = Color.Red;
                validBasicInfo[8] = false;
            }
            checkIfBasicInfoVerified();
        }

        private void xpTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = xpTextBox.Text;
            if (!text.All(char.IsDigit))
            {
                xpLabel.ForeColor = Color.Red;
                validBasicInfo[10] = false;
            }
            else
            {
                xpLabel.ForeColor = Color.Black;
                validBasicInfo[10] = true;
            }
            if (text.Length == 0)
            {
                xpLabel.ForeColor = Color.Red;
                validBasicInfo[10] = false;
            }
            checkIfBasicInfoVerified();
        }

        private void checkIfBasicInfoVerified()
        {
            int j = 0;
            for (int i = 0; i < validBasicInfo.Length; i++)
            {
                //Console.WriteLine("{0} j before -- {1}: {2}", j, i, validBasicInfo[i]);
                if (!validBasicInfo[i])
                    saveBasicInfoButton.Enabled = false;
                else
                    j++;
                //Console.WriteLine("{0} j after", j);
            }
            if (j == 11)
                saveBasicInfoButton.Enabled = true;
        }

        private void editBasicInformationButton_Click(object sender, EventArgs e)
        {
            additionalInfoTabControl.Enabled = false;
            saveBasicInfoButton.Enabled = true;
            characterNameBox.Enabled = true;
            classComboBox.Enabled = true;
            raceComboBox.Enabled = true;
            subraceComboBox.Enabled = true;
            backgroundComboBox.Enabled = true;
            alignmentComboBox.Enabled = true;
            ageTextBox.Enabled = true;
            heightTextBox.Enabled = true;
            weightTextBox.Enabled = true;
            sexComboBox.Enabled = true;
            xpTextBox.Enabled = true;
            editBasicInformationButton.Enabled = false;

            abilityScoreIncreaseLabel.Text = "Ability Score Increases:";
            speedLabel.Text = "Speed:";
            languagesLabel.Text = "Languages:";
        }

        
    }
}
