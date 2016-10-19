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
using DnD_Character_Sheet.Character_Classes;

namespace DnD_Character_Sheet
{    
    public partial class Form1 : Form
    {
        ToolTip BasicInfoToolTip;
        List<String> abilities = new List<string>(new string[] { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" });
        List<Tuple<Label, string, Label>> skillsDictionary = new List<Tuple<Label, string, Label>>();
        List<Button> saveButtons = new List<Button>();
        List<Label> abilityLabels = new List<Label>();
        List<ComboBox> abilityCombos = new List<ComboBox>();
        Dictionary<string, Label> savingThrowLabels = new Dictionary<string, Label>();
        List<FlowLayoutPanel> startingEquipmentPanels = new List<FlowLayoutPanel>();
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

            skillsDictionary.Add(new Tuple<Label, string, Label>(acrobaticsLabel, "Acrobatics", acrobaticsValueLabel));
            skillsDictionary.Add(new Tuple<Label, string, Label>(animalHandlingLabel, "Animal Handling", animalHandlingValueLabel));
            skillsDictionary.Add(new Tuple<Label, string, Label>(arcanaLabel, "Arcana", arcanaValueLabel));
            skillsDictionary.Add(new Tuple<Label, string, Label>(athleticsLabel, "Athletics", athleticsValueLabel));
            skillsDictionary.Add(new Tuple<Label, string, Label>(deceptionLabel, "Deception", deceptionValueLabel));
            skillsDictionary.Add(new Tuple<Label, string, Label>(historyLabel, "History", historyValueLabel));
            skillsDictionary.Add(new Tuple<Label, string, Label>(insightLabel, "Insight", insightValueLabel));
            skillsDictionary.Add(new Tuple<Label, string, Label>(intimidationLabel, "Intimidation", intimidationValueLabel));
            skillsDictionary.Add(new Tuple<Label, string, Label>(investigationLabel, "Investigation", investigationValueLabel));
            skillsDictionary.Add(new Tuple<Label, string, Label>(medicineLabel, "Medicine", medicineValueLabel));
            skillsDictionary.Add(new Tuple<Label, string, Label>(natureLabel, "Nature", natureValueLabel));
            skillsDictionary.Add(new Tuple<Label, string, Label>(perceptionLabel, "Perception", perceptionValueLabel));
            skillsDictionary.Add(new Tuple<Label, string, Label>(performanceLabel, "Performance", performanceValueLabel));
            skillsDictionary.Add(new Tuple<Label, string, Label>(persuasionLabel, "Persuasion", persuasionValueLabel));
            skillsDictionary.Add(new Tuple<Label, string, Label>(religionLabel, "Religion", religionValueLabel));
            skillsDictionary.Add(new Tuple<Label, string, Label>(sleightOfHandLabel, "Sleight of Hand", sleightOfHandValueLabel));
            skillsDictionary.Add(new Tuple<Label, string, Label>(stealthLabel, "Stealth", stealthValueLabel));
            skillsDictionary.Add(new Tuple<Label, string, Label>(survivalLabel, "Survival", survivalValueLabel));

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

            savingThrowLabels.Add("Strength", strengthSavingThrowValueLabel);
            savingThrowLabels.Add("Dexterity", dexteritySavingThrowValueLabel);
            savingThrowLabels.Add("Constitution", constitutionSavingThrowValueLabel);
            savingThrowLabels.Add("Intelligence", intelligenceSavingThrowValueLabel);
            savingThrowLabels.Add("Wisdom", wisdomSavingThrowValueLabel);
            savingThrowLabels.Add("Charisma", charismaSavingThrowValueLabel);

            startingEquipmentPanels.Add(startingEquipmentPanelOne);
            startingEquipmentPanels.Add(startingEquipmentPanelTwo);
            startingEquipmentPanels.Add(startingEquipmentPanelThree);
            startingEquipmentPanels.Add(startingEquipmentPanelFour);
            startingEquipmentPanels.Add(startingEquipmentPanelFive);
            startingEquipmentPanels.Add(startingEquipmentPanelSix);

            tableLayoutPanel2.BorderStyle = BorderStyle.FixedSingle;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BasicInfoToolTip = new ToolTip();
            BasicInfoToolTip.SetToolTip(classLevelBreakdownLabel, "Click on a Feature to Learn More About It.");
        }

        //TODO change this so that it will default to the Race and Class Features tab so that the use can see the features of
        //each race/class when making their new character
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

            extraLanguageComboBox.Visible = false;
            extraLanguageComboBox.Enabled = false;
            addExtraLanguageButton.Visible = false;
            addExtraLanguageButton.Enabled = false;

            checkIfBasicInfoVerified();
            //additionalInfoTabControl.Enabled = true;
        }

        private void loadCharacterButton_Click(object sender, EventArgs e)
        {
            character = new Character();
            resetClassAndRaceFeaturesTab();
            classComboBox.SelectedIndex = 3;
            raceComboBox.SelectedIndex = 0;

            backgroundComboBox.SelectedIndex = 0;
            alignmentComboBox.SelectedIndex = 0;
            sexComboBox.SelectedIndex = 0;
            characterNameBox_TextChanged(null, null);
            classComboBox_SelectedIndexChanged(null, null);
            raceComboBox_SelectedIndexChanged(null, null);
            subraceComboBox_SelectedIndexChanged(null, null);
            backgroundComboBox_SelectedIndexChanged(null, null);
            alignmentComboBox_SelectedIndexChanged(null, null);
            sexComboBox_SelectedIndexChanged(null, null);
            ageTextBox_TextChanged(null, null);
            heightTextBox_TextChanged(null, null);
            weightTextBox_TextChanged(null, null);
            xpTextBox_TextChanged(null, null);
            subraceComboBox.SelectedIndex = 0;
            additionalInfoTabControl.Enabled = true;
            editBasicInformationButton.Enabled = true;
            saveCharacter();
            fillClassAndRaceFeaturesTab();
        }

        private void saveCharacterToolStripButton_Click(object sender, EventArgs e)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            using (XmlWriter writer = XmlWriter.Create(character.Name + ".xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("CharacterInfo");
                writer.WriteStartElement("BasicInfo");
                writer.WriteElementString("Name", character.Name);
                writer.WriteElementString("Age", character.Age.ToString());
                writer.WriteElementString("Class", character.CharClass.ClassName);
                writer.WriteElementString("Race", character.Race.RaceName);
                writer.WriteElementString("Subrace", character.Race.Subrace);
                writer.WriteElementString("Background", "TODO");
                writer.WriteElementString("Alignment", character.Alignment);
                writer.WriteElementString("Height", character.Height.ToString());
                writer.WriteElementString("Weight", character.Weight.ToString());
                writer.WriteElementString("Sex", character.Sex);
                writer.WriteElementString("XP", character.ExperiencePoints.ToString());
                writer.WriteElementString("Level", character.Level.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Stats");
                writer.WriteElementString("Strength", character.AbilityScores.Scores["Strength"][0].ToString());
                writer.WriteElementString("Dexterity", character.AbilityScores.Scores["Dexterity"][0].ToString());
                writer.WriteElementString("Constitution", character.AbilityScores.Scores["Constitution"][0].ToString());
                writer.WriteElementString("Intelligence", character.AbilityScores.Scores["Intelligence"][0].ToString());
                writer.WriteElementString("Wisdom", character.AbilityScores.Scores["Wisdom"][0].ToString());
                writer.WriteElementString("Charisma", character.AbilityScores.Scores["Charisma"][0].ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Skills");
                foreach (var item in character.AbilityScores.SelectedSkills)
                {
                    writer.WriteElementString(item.Replace(" ", ""), item);
                }

                writer.WriteEndElement();

                writer.WriteStartElement("Spells");
                writer.WriteEndElement();

                writer.WriteStartElement("Equipment");
                writer.WriteEndElement();

                writer.WriteStartElement("Notes");
                writer.WriteEndElement();

                writer.WriteEndDocument();
            }
        }

        private void saveCharacter()
        {
            character.Name = characterNameBox.Text;
            character.Age = int.Parse(ageTextBox.Text);
            string charClass = classComboBox.SelectedItem.ToString();
            switch (charClass)
            {
                case "Barbarian":
                    character.CharClass = new Barbarian();
                    break;
                case "Bard":
                    character.CharClass = new Bard();
                    break;
                case "Cleric":
                    character.CharClass = new Cleric();
                    break;
                case "Druid":
                    character.CharClass = new Druid();
                    break;
                case "Fighter":
                    character.CharClass = new Fighter();
                    break;
                case "Monk":
                    character.CharClass = new Monk();
                    break;
                case "Paladin":
                    character.CharClass = new Paladin();
                    break;
                case "Ranger":
                    character.CharClass = new Ranger();
                    break;
                case "Rogue":
                    character.CharClass = new Rogue();
                    break;
                case "Sorcerer":
                    character.CharClass = new Sorcerer();
                    break;
                case "Warlock":
                    character.CharClass = new Warlock();
                    break;
                case "Wizard":
                    character.CharClass = new Wizard();
                    break;
            }
            string race = raceComboBox.SelectedItem.ToString();
            switch (race.ToLower())
            {
                case "dwarf":
                    character.Race = new Dwarf();
                    speedLabel.Text += " 25 base (Dwarf)";
                    languagesLabel.Text += " Common, Dwarvish (Dwarf)";
                    break;
                case "elf":
                    character.Race = new Elf();
                    //TODO: fix this shit so that it's a part of each class and not typed here manually
                    speedLabel.Text += " 30 base (Elf)";
                    //TODO move the languages field to the Race and Class Features tab; allow for drop down menu selection of languages
                    //(keep in mind how many the character may be able to speak?)
                    languagesLabel.Text += " Common, Elvish (Elf)";
                    break;
                case "halfling":
                    character.Race = new Halfling();
                    speedLabel.Text += " 25 base (Halfling)";
                    languagesLabel.Text += " Common, Halfling (Halfling)";
                    break;
                case "human":
                    character.Race = new Human();
                    speedLabel.Text += " 30 base (Human)";
                    languagesLabel.Text += " Common (Human)";
                    break;
                case "dragonborn":
                    character.Race = new Dragonborn();
                    speedLabel.Text += " 30 base (Dragonborn)";
                    break;
                case "gnome":
                    character.Race = new Gnome();
                    speedLabel.Text += " 25 base (Gnome)";
                    break;
                case "half-elf":
                    character.Race = new HalfElf();
                    speedLabel.Text += " 30 base (Half Elf)";
                    break;
                case "half-orc":
                    character.Race = new HalfOrc();
                    speedLabel.Text += " 30 base (Half Orc)";
                    break;
            }
            character.Race.Subrace = (subraceComboBox.SelectedItem.ToString() != "NONE" ? subraceComboBox.SelectedItem.ToString() : "");
            character.Race.AddSubraceBonuses(character.Race.Subrace);
            character.Alignment = alignmentComboBox.SelectedItem.ToString();
            character.Weight = int.Parse(weightTextBox.Text);
            character.Height = int.Parse(heightTextBox.Text);
            character.Sex = sexComboBox.SelectedItem.ToString();
            character.ExperiencePoints = int.Parse(xpTextBox.Text);
            character.DetermineLevel();
            character.CharClass.ProficiencyBonus = character.CharClass.FeaturesPerLevelTable[character.Level - 1].Item2;
        }

	    private void saveBasicInfoButton_Click(object sender, EventArgs e)
	    {
            saveCharacter();
            levelLabel.Text = character.Level.ToString();
            abilityScoreIncreaseLabel.Text += character.Race.AbilityIncreasePrintString();

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
            saveCharacterToolStripButton.Enabled = true;

            if (character.Race.CanHaveExtraLanguages)
            {
                addExtraLanguageButton.Enabled = true;
                addExtraLanguageButton.Visible = true;
                extraLanguageComboBox.Enabled = true;
                extraLanguageComboBox.Visible = true;
                foreach (var item in character.Race.Languages)
                {
                    extraLanguageComboBox.Items.Remove(item);
                }
            }

            var weapons = "";
            foreach (var item in character.CharClass.ProficientWeaponTypes)
            {
                weapons += item + ", ";
            }
            proficientWeaponsLabel.Text = weapons.Substring(0, weapons.Length - 2);

            var armor = "";
            foreach (var item in character.CharClass.ProficientArmors)
            {
                armor += item + ", ";
            }
            proficientArmorLabel.Text = armor.Substring(0, armor.Length - 2);

            var tools = "";
            foreach (var item in character.CharClass.ProficientTools)
            {
                tools += item + ", ";
            }
            proficientToolsLabel.Text = tools.Substring(0, tools.Length - 2);

            selectableSkillsNotificationLabel.Text = "Please Assign Your Ability Scores Before Selecting Your Proficient Skills.";
            proficiencyBonusValueLabel.Text = character.ProficiencyBonus.ToString();
            fillClassAndRaceFeaturesTab();
        }

        private void updateSkillsNotificationLabel()
        {
            string skills = "";
            for (int i = 0; i < character.CharClass.SelectableSkills.Count; i++)
            {
                if (i == character.CharClass.SelectableSkills.Count - 1)
                    skills += character.CharClass.SelectableSkills[i];
                else
                    skills += character.CharClass.SelectableSkills[i] + ", ";
            }
            selectableSkillsNotificationLabel.Text = "You May Select " + character.CharClass.NumberOfSelectableSkills + " Skills From the Above Highlighted Ones.";
        }

        private void rollStatsButton_Click(object sender, EventArgs e)
        {
            abilityValuesComboOne.Enabled = true;
            abilityValuesComboTwo.Enabled = true;
            abilityValuesComboThree.Enabled = true;
            abilityValuesComboFour.Enabled = true;
            abilityValuesComboFive.Enabled = true;
            abilityValuesComboSix.Enabled = true;

            int[] stats = character.AbilityScores.RollStats();
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
            // TODO after all save buttons have been clicked, enable the skills labels
            //int tmp = triple.IndexOf()
            Tuple<Button, Label, ComboBox, Label> tuple = getSaveTuple((Button) sender);
            string ability = tuple.Item3.Text;
            rollStatsButton.Enabled = false;
            character.AbilityScores.SetStat(ability, int.Parse(tuple.Item2.Text));
            removeTagFromAll(saveButtons.IndexOf((Button)sender) + 1, ability);
            tuple.Item4.Text = "(" + character.AbilityScores.Scores[ability][1].ToString() + ")";
            tuple.Item3.Enabled = false;
            ((Button) sender).Enabled = false;
            updateInitialSkillLabels(ability);
            if (character.AbilityScores.AllStatsChosen())
            {
                updateSkillsNotificationLabel();
                foreach (var i in skillsDictionary)
                {
                    i.Item1.Enabled = false;
                    i.Item3.Enabled = false;
                }
                foreach (var item in character.CharClass.SelectableSkills)
                {
                    var skill = skillsDictionary.Find(i => i.Item2.Equals(item));
                    if (skill != null)
                    {
                        Console.WriteLine(skill.Item2);
                        skill.Item1.Enabled = true;
                        skill.Item3.Enabled = true;
                    }
                }

                foreach (var item in savingThrowLabels.Keys)
                {
                    if (character.CharClass.SavingThrows.Contains(item))
                    {
                        savingThrowLabels[item].Text = (character.AbilityScores.Scores[item][1] + character.CharClass.ProficiencyBonus).ToString();
                        savingThrowLabels[item].Font = new Font(savingThrowLabels[item].Font, FontStyle.Bold);
                    }
                    else
                        savingThrowLabels[item].Text = (character.AbilityScores.Scores[item][1]).ToString();
                }
            }
        }

        private void updateInitialSkillLabels(string ability)
        {
            switch (ability)
            {
                case "Strength":
                    athleticsValueLabel.Text = character.AbilityScores.Scores["Strength"][1].ToString();
                    foreach (var item in character.AbilityScores.RelatedSkills["Strength"])
                        character.AbilityScores.SkillsDictionary[item] = character.AbilityScores.Scores["Strength"][1];
                    break;
                case "Dexterity":
                    acrobaticsValueLabel.Text = character.AbilityScores.Scores["Dexterity"][1].ToString();
                    sleightOfHandValueLabel.Text = character.AbilityScores.Scores["Dexterity"][1].ToString();
                    stealthValueLabel.Text = character.AbilityScores.Scores["Dexterity"][1].ToString();
                    foreach (var item in character.AbilityScores.RelatedSkills["Dexterity"])
                        character.AbilityScores.SkillsDictionary[item] = character.AbilityScores.Scores["Dexterity"][1];
                    break;
                case "Intelligence":
                    arcanaValueLabel.Text = character.AbilityScores.Scores["Intelligence"][1].ToString();
                    historyValueLabel.Text = character.AbilityScores.Scores["Intelligence"][1].ToString();
                    investigationValueLabel.Text = character.AbilityScores.Scores["Intelligence"][1].ToString();
                    natureValueLabel.Text = character.AbilityScores.Scores["Intelligence"][1].ToString();
                    religionValueLabel.Text = character.AbilityScores.Scores["Intelligence"][1].ToString();
                    foreach (var item in character.AbilityScores.RelatedSkills["Intelligence"])
                        character.AbilityScores.SkillsDictionary[item] = character.AbilityScores.Scores["Intelligence"][1];
                    break;
                case "Wisdom":
                    animalHandlingValueLabel.Text = character.AbilityScores.Scores["Wisdom"][1].ToString();
                    insightValueLabel.Text = character.AbilityScores.Scores["Wisdom"][1].ToString();
                    medicineValueLabel.Text = character.AbilityScores.Scores["Wisdom"][1].ToString();
                    perceptionValueLabel.Text = character.AbilityScores.Scores["Wisdom"][1].ToString();
                    survivalValueLabel.Text = character.AbilityScores.Scores["Wisdom"][1].ToString();
                    foreach (var item in character.AbilityScores.RelatedSkills["Wisdom"])
                        character.AbilityScores.SkillsDictionary[item] = character.AbilityScores.Scores["Wisdom"][1];
                    break;
                case "Charisma":
                    deceptionValueLabel.Text = character.AbilityScores.Scores["Charisma"][1].ToString();
                    intimidationValueLabel.Text = character.AbilityScores.Scores["Charisma"][1].ToString();
                    performanceValueLabel.Text = character.AbilityScores.Scores["Charisma"][1].ToString();
                    persuasionValueLabel.Text = character.AbilityScores.Scores["Charisma"][1].ToString();
                    foreach (var item in character.AbilityScores.RelatedSkills["Charisma"])
                        character.AbilityScores.SkillsDictionary[item] = character.AbilityScores.Scores["Charisma"][1];
                    break;
                default:
                    break;
            }
        }

        private void updateSkillsLabels()
        {
            athleticsValueLabel.Text = character.AbilityScores.SkillsDictionary["Athletics"].ToString();
            acrobaticsValueLabel.Text = character.AbilityScores.SkillsDictionary["Acrobatics"].ToString();
            sleightOfHandValueLabel.Text = character.AbilityScores.SkillsDictionary["Sleight of Hand"].ToString();
            stealthValueLabel.Text = character.AbilityScores.SkillsDictionary["Stealth"].ToString();
            arcanaValueLabel.Text = character.AbilityScores.SkillsDictionary["Arcana"].ToString();
            historyValueLabel.Text = character.AbilityScores.SkillsDictionary["History"].ToString();
            investigationValueLabel.Text = character.AbilityScores.SkillsDictionary["Investigation"].ToString();
            natureValueLabel.Text = character.AbilityScores.SkillsDictionary["Nature"].ToString();
            religionValueLabel.Text = character.AbilityScores.SkillsDictionary["Religion"].ToString();
            animalHandlingValueLabel.Text = character.AbilityScores.SkillsDictionary["Animal Handling"].ToString();
            insightValueLabel.Text = character.AbilityScores.SkillsDictionary["Insight"].ToString();
            medicineValueLabel.Text = character.AbilityScores.SkillsDictionary["Medicine"].ToString();
            perceptionValueLabel.Text = character.AbilityScores.SkillsDictionary["Perception"].ToString();
            survivalValueLabel.Text = character.AbilityScores.SkillsDictionary["Survival"].ToString();
            deceptionValueLabel.Text = character.AbilityScores.SkillsDictionary["Deception"].ToString();
            intimidationValueLabel.Text = character.AbilityScores.SkillsDictionary["Intimidation"].ToString();
            performanceValueLabel.Text = character.AbilityScores.SkillsDictionary["Performance"].ToString();
            persuasionValueLabel.Text = character.AbilityScores.SkillsDictionary["Persuasion"].ToString();
        }

        private void abilityValuesComboBoxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tuple<Button, Label, ComboBox, Label> tup = getSaveTuple((ComboBox) sender);
            int tmp = abilityScoreFormTuples.IndexOf(tup);
            tup.Item2.Text = character.AbilityScores.finalStats[abilityScoreFormTuples.IndexOf(tup)].ToString();
            int oldStat = int.Parse(tup.Item2.Text);
            string statSelected = ((ComboBox) sender).SelectedItem.ToString();
            string characterAbilityIncrease = character.Race.AbilityScoreIncrease.Item1;
            string subRaceAbilityIncrease = (character.Race.SubraceAbilityScoreIncrease != null) ? character.Race.SubraceAbilityScoreIncrease.Item1 : null;
            if (statSelected.Equals(characterAbilityIncrease))
            {
                tup.Item2.Text = (oldStat + character.Race.AbilityScoreIncrease.Item2).ToString();
            }

            if (statSelected.Equals(subRaceAbilityIncrease))
                tup.Item2.Text = (oldStat + character.Race.SubraceAbilityScoreIncrease.Item2).ToString();
            if (character.Race is Human)
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
            //selectableSkillsNotificationLabel.Text = Barbarian.
            //selectableSkillsNotificationLabel.Text = classComboBox.SelectedItem.ToString() + " can select " +  + " skills to be proficient in from "
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

        //TODO change it so that pressing this button also clears the previous stat selections, but does not get rid of the current values
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

            resetClassAndRaceFeaturesTab();
        }

        private void resetClassAndRaceFeaturesTab()
        {
            classLevelBreakdownLabel.Text = "Please Select a Class to See the Level Breakdown";
            raceFeaturesLabel.Text = "Race Features List";
            classFeaturesLabel.Text = "Class Features List";
            selectedFeatureTitleLabel.Text = "Select a Feature to Learn More About It";
            classFeaturesListView.Columns.Clear();
            classFeaturesListView.Columns.Add("Level");
            classFeaturesListView.Columns.Add("Proficiency Bonus");
            classFeaturesListView.Columns.Add("Features");
        }

        private void fillClassAndRaceFeaturesTab()
        {
            classLevelBreakdownLabel.Text = character.CharClass.ClassName + " Level Breakdown";
            raceFeaturesLabel.Text = character.Race.RaceName + " Features List";
            classFeaturesLabel.Text = character.CharClass.ClassName + " Features List";

            List<string>[] additionalStatsLists = new List<string>[character.CharClass.AdditionalFeaturesTable.Keys.Count];
            Console.WriteLine(character.CharClass.AdditionalFeaturesTable.Keys.Count);

            int j = 0;
            //TODO change this so that if a new class is picked it will reset the table to the default 3 values (lvl, p.b., features)
            foreach (string s in character.CharClass.AdditionalFeaturesTable.Keys)
            {
                classFeaturesListView.Columns.Add(s);
                additionalStatsLists[j++] = character.CharClass.AdditionalFeaturesTable[s];
            }

            for (int i = 0; i < 20; i++)
            {
                ListViewItem l = new ListViewItem(character.CharClass.FeaturesPerLevelTable[i].Item1.ToString());
                l.SubItems.Add(character.CharClass.FeaturesPerLevelTable[i].Item2.ToString());
                l.SubItems.Add(character.CharClass.FeaturesPerLevelTable[i].Item3);

                for (int k = 0; k < j; k++)
                    l.SubItems.Add(additionalStatsLists[k][i]);

                classFeaturesListView.Items.Add(l);
            }

            for (int i = 0; i < 20; i++)
            {
                ListViewItem l = new ListViewItem((i + 1).ToString());
                l.SubItems.Add(character.CharClass.SpellSlotsPerLevel[i, 0]);
                l.SubItems.Add(character.CharClass.SpellSlotsPerLevel[i, 1]);
                l.SubItems.Add(character.CharClass.SpellSlotsPerLevel[i, 2]);
                l.SubItems.Add(character.CharClass.SpellSlotsPerLevel[i, 3]);
                l.SubItems.Add(character.CharClass.SpellSlotsPerLevel[i, 4]);
                l.SubItems.Add(character.CharClass.SpellSlotsPerLevel[i, 5]);
                l.SubItems.Add(character.CharClass.SpellSlotsPerLevel[i, 6]);
                l.SubItems.Add(character.CharClass.SpellSlotsPerLevel[i, 7]);
                l.SubItems.Add(character.CharClass.SpellSlotsPerLevel[i, 8]);

                spellSlotsPerLevelListView.Items.Add(l);
            }

            foreach (string key in character.CharClass.FeaturesDictionary.Keys)
                classFeaturesListBox.Items.Add(key);

            foreach (string key in character.Race.FeaturesDictionary.Keys)
                raceFeaturesListBox.Items.Add(key);

            foreach (string key in character.Race.SubraceFeaturesDictionary.Keys)
                raceFeaturesListBox.Items.Add(key);
        }

        private void classFeaturesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFeatureTitleLabel.Text = classFeaturesListBox.SelectedItem.ToString();
            selectedFeatureDescriptionLabel.Text = character.CharClass.FeaturesDictionary[classFeaturesListBox.SelectedItem.ToString()];
        }

        private void raceFeaturesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFeatureTitleLabel.Text = raceFeaturesListBox.SelectedItem.ToString();
            if (character.Race.FeaturesDictionary.ContainsKey(raceFeaturesListBox.SelectedItem.ToString()))
                selectedFeatureDescriptionLabel.Text = character.Race.FeaturesDictionary[raceFeaturesListBox.SelectedItem.ToString()];
            else
                selectedFeatureDescriptionLabel.Text = character.Race.SubraceFeaturesDictionary[raceFeaturesListBox.SelectedItem.ToString()];
        }

        private void updateSkillLabels()
        {
            foreach (var item in skillsDictionary)
            {
                item.Item1.Enabled = true;
                item.Item3.Enabled = true;
            }
            selectableSkillsNotificationLabel.Text = "";
        }

        private void skillsLabel_click(object sender, EventArgs e)
        {
            if (character.CharClass.NumberOfSelectableSkills > 0)
            {
                var tuple = skillsDictionary.Find(i => i.Item1.Equals((Label)sender));
                var skill = tuple.Item2;
                
                if (character.CharClass.SelectableSkills.Contains(skill))
                {
                    character.AbilityScores.SelectedSkills.Add(skill);
                    character.AbilityScores.SkillsDictionary[skill] += character.CharClass.ProficiencyBonus;
                    updateSkillsLabels();
                    ((Label)sender).Enabled = false;
                    tuple.Item3.Enabled = false;
                    character.CharClass.NumberOfSelectableSkills--;
                    character.CharClass.SelectableSkills.Remove(skill);
                    updateSkillsNotificationLabel();
                    ((Label)sender).Font = new Font(((Label)sender).Font, FontStyle.Bold | FontStyle.Underline);
                    tuple.Item3.Font = new Font(tuple.Item3.Font, FontStyle.Bold);
                    if (character.CharClass.NumberOfSelectableSkills == 0)
                        updateSkillLabels();
                }
            }
        }

        private void addExtraLanguageButton_Click(object sender, EventArgs e)
        {
            character.Race.Languages.Add(extraLanguageComboBox.SelectedItem.ToString());
            var old = languagesLabel.Text.ToString();
            languagesLabel.Text = old + ", " + extraLanguageComboBox.SelectedItem.ToString() + " (Extra Language)";
            ((Button)sender).Enabled = false;
            extraLanguageComboBox.Enabled = false;

        }

        private void groupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Black);
        }

        private void DrawGroupBox(GroupBox box, Graphics g, Color borderColour)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(Color.Black);
                Brush borderBrush = new SolidBrush(borderColour);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                           box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                           box.ClientRectangle.Width - 1,
                                           box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Clear text and border
                g.Clear(this.BackColor);

                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }

        private void weaponsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            allEquipmentListView.Columns.Clear();
            allEquipmentListView.Items.Clear();

            if (((RadioButton)sender).Checked == true)
            {
                ColumnHeader nameHeader, damageHeader, weightHeader, propertiesHeader;
                nameHeader = new ColumnHeader();
                nameHeader.Text = "Name";
                damageHeader = new ColumnHeader();
                damageHeader.Text = "Damage";
                weightHeader = new ColumnHeader();
                weightHeader.Text = "Weight";
                propertiesHeader = new ColumnHeader();
                propertiesHeader.Text = "Properties";

                allEquipmentListView.Columns.Add(nameHeader);
                allEquipmentListView.Columns.Add(damageHeader);
                allEquipmentListView.Columns.Add(weightHeader);
                allEquipmentListView.Columns.Add(propertiesHeader);

                ListViewItem l = new ListViewItem("---Simple Melee Weapons---");
                allEquipmentListView.Items.Add(l);

                foreach (var item in Equipment.SimpleMeleeWeaponsTuple)
                {
                    l = new ListViewItem(item.Item1);
                    l.SubItems.Add(item.Item2);
                    l.SubItems.Add(item.Item3);
                    l.SubItems.Add(item.Item4);

                    allEquipmentListView.Items.Add(l);
                }

                l = new ListViewItem("---Simple Ranged Weapons---");
                allEquipmentListView.Items.Add(l);

                foreach (var item in Equipment.SimpleRangedWeaponsTuple)
                {
                    l = new ListViewItem(item.Item1);
                    l.SubItems.Add(item.Item2);
                    l.SubItems.Add(item.Item3);
                    l.SubItems.Add(item.Item4);

                    allEquipmentListView.Items.Add(l);
                }

                l = new ListViewItem("---Martial Melee Weapons---");
                allEquipmentListView.Items.Add(l);

                foreach (var item in Equipment.MartialMeleeWeaponsTuple)
                {
                    l = new ListViewItem(item.Item1);
                    l.SubItems.Add(item.Item2);
                    l.SubItems.Add(item.Item3);
                    l.SubItems.Add(item.Item4);

                    allEquipmentListView.Items.Add(l);
                }

                l = new ListViewItem("---Martial Ranged Weapons---");
                allEquipmentListView.Items.Add(l);

                foreach (var item in Equipment.MartialRangedWeaponsTuple)
                {
                    l = new ListViewItem(item.Item1);
                    l.SubItems.Add(item.Item2);
                    l.SubItems.Add(item.Item3);
                    l.SubItems.Add(item.Item4);

                    allEquipmentListView.Items.Add(l);
                }

                //allEquipmentListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                allEquipmentListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void armorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            allEquipmentListView.Columns.Clear();
            allEquipmentListView.Items.Clear();

            if (((RadioButton)sender).Checked == true)
            {
                ColumnHeader nameHeader, armorClassHeader, strengthHeader, stealthHeader, weightHeader;
                nameHeader = new ColumnHeader();
                nameHeader.Text = "Name";
                armorClassHeader = new ColumnHeader();
                armorClassHeader.Text = "Armor Class";
                strengthHeader = new ColumnHeader();
                strengthHeader.Text = "Strength";
                stealthHeader = new ColumnHeader();
                stealthHeader.Text = "Stealth";
                weightHeader = new ColumnHeader();
                weightHeader.Text = "Weight";

                allEquipmentListView.Columns.Add(nameHeader);
                allEquipmentListView.Columns.Add(armorClassHeader);
                allEquipmentListView.Columns.Add(strengthHeader);
                allEquipmentListView.Columns.Add(stealthHeader);
                allEquipmentListView.Columns.Add(weightHeader);

                ListViewItem l = new ListViewItem("---Light Armor---");
                allEquipmentListView.Items.Add(l);

                foreach (var item in Equipment.LightArmorTuple)
                {
                    l = new ListViewItem(item.Item1);
                    l.SubItems.Add(item.Item2);
                    l.SubItems.Add(item.Item3);
                    l.SubItems.Add(item.Item4);
                    l.SubItems.Add(item.Item5);

                    allEquipmentListView.Items.Add(l);
                }

                l = new ListViewItem("---Medium Armor---");
                allEquipmentListView.Items.Add(l);

                foreach (var item in Equipment.MediumArmorTuple)
                {
                    l = new ListViewItem(item.Item1);
                    l.SubItems.Add(item.Item2);
                    l.SubItems.Add(item.Item3);
                    l.SubItems.Add(item.Item4);
                    l.SubItems.Add(item.Item5);

                    allEquipmentListView.Items.Add(l);
                }

                l = new ListViewItem("---Heavy Armor---");
                allEquipmentListView.Items.Add(l);

                foreach (var item in Equipment.HeavyArmorTuple)
                {
                    l = new ListViewItem(item.Item1);
                    l.SubItems.Add(item.Item2);
                    l.SubItems.Add(item.Item3);
                    l.SubItems.Add(item.Item4);
                    l.SubItems.Add(item.Item5);

                    allEquipmentListView.Items.Add(l);
                }

                l = new ListViewItem("---Shields---");
                allEquipmentListView.Items.Add(l);

                foreach (var item in Equipment.ShieldTuple)
                {
                    l = new ListViewItem(item.Item1);
                    l.SubItems.Add(item.Item2);
                    l.SubItems.Add(item.Item3);
                    l.SubItems.Add(item.Item4);
                    l.SubItems.Add(item.Item5);

                    allEquipmentListView.Items.Add(l);
                }

                allEquipmentListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void packRadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                packListBox.Items.Clear();
                switch (((RadioButton)sender).Text)
                {
                    case "Burglar's Pack":
                        Equipment.BurglarsPack.ForEach(i => packListBox.Items.Add(i));
                        break;
                    case "Diplomat's Pack":
                        Equipment.DiplomatsPack.ForEach(i => packListBox.Items.Add(i));
                        break;
                    case "Dungeoneer's Pack":
                        Equipment.DungeoneersPack.ForEach(i => packListBox.Items.Add(i));
                        break;
                    case "Entertainer's Pack":
                        Equipment.EntertainersPack.ForEach(i => packListBox.Items.Add(i));
                        break;
                    case "Explorer's Pack":
                        Equipment.ExplorersPack.ForEach(i => packListBox.Items.Add(i));
                        break;
                    case "Priest's Pack":
                        Equipment.PriestsPack.ForEach(i => packListBox.Items.Add(i));
                        break;
                    case "Scholar's Pack":
                        Equipment.ScholarsPack.ForEach(i => packListBox.Items.Add(i));
                        break;
                    default:
                        break;
                }
            }
        }       

        // TODO remove this so that it just gets loaded automatically when the tab is loaded or something
        private void button1_Click(object sender, EventArgs e)
        {
            var panelIndex = 0;
            foreach (var item in character.CharClass.PotentialStartingEquipment)
            {
                if (item.Length == 1)
                {
                    character.CharClass.FinalStartingEquipment.Add(item[0]);
                    updateSelectedEquipment();
                }

                else
                {
                    foreach (var i in item)
                    {
                        RadioButton r = new RadioButton();
                        Console.WriteLine(i);
                        r.Text = i;
                        r.AutoSize = true;
                        startingEquipmentPanels[panelIndex].Controls.Add(r);
                    }
                    Button b = new Button();
                    b.Text = "Select Equipment";
                    startingEquipmentPanels[panelIndex].Controls.Add(b);
                    b.Click += addEquipmentButton_Click;
                    panelIndex++;
                }
            }
        }

        private void addEquipmentButton_Click(object sender, EventArgs e)
        {
            var parent = ((Button)sender).Parent;
            var radios = new List<RadioButton>();

            foreach (var item in parent.Controls)
            {
                Console.WriteLine(item);
                if (item is RadioButton)
                    radios.Add(item as RadioButton);
            }

            if ((radios.Count(i => i.Checked == true)) == 1)
            {
                RadioButton clicked = radios.Find(i => (i.Checked == true));                
                ((Button)sender).Enabled = false;
                radios.ForEach(i => i.Enabled = false);

                if (clicked.Text.Contains("Any"))
                {
                    weaponSelectListBox.Visible = true;
                    addAnyWeaponButton.Visible = true;
                    addAnyWeaponButton.Enabled = true;
                    fillWeaponSelectListBox(clicked.Text);
                    // TODO disable all of the remaining buttons and radiobuttons until the weapon selection has been finished.
                    Console.WriteLine(clicked.Text);
                }

                else
                {
                    character.CharClass.FinalStartingEquipment.Add(clicked.Text);
                    updateSelectedEquipment();
                }
            }
        }

        private void fillWeaponSelectListBox(string text)
        {
            weaponSelectListBox.Items.Clear();
            switch (text)
            {
                case "Any Simple Weapon":
                    addAnyWeaponButton.Text = "Add Weapon to Starting Equipment";
                    Equipment.SimpleMeleeWeapons.ForEach(i => weaponSelectListBox.Items.Add(i));
                    Equipment.SimpleRangedWeapons.ForEach(i => weaponSelectListBox.Items.Add(i));
                    break;
                case "Any Martial Weapon":
                    addAnyWeaponButton.Text = "Add Weapon to Starting Equipment";
                    Equipment.MartialMeleeWeapons.ForEach(i => weaponSelectListBox.Items.Add(i));
                    Equipment.MartialRangedWeapons.ForEach(i => weaponSelectListBox.Items.Add(i));
                    break;
                case "Any Simple Melee Weapon":
                    addAnyWeaponButton.Text = "Add Weapon to Starting Equipment";
                    Equipment.SimpleMeleeWeapons.ForEach(i => weaponSelectListBox.Items.Add(i));
                    break;
                case "Any Martial Melee Weapon":
                    addAnyWeaponButton.Text = "Add Weapon to Starting Equipment";
                    Equipment.MartialMeleeWeapons.ForEach(i => weaponSelectListBox.Items.Add(i));
                    break;
                case "Any Simple Ranged Weapon":
                    addAnyWeaponButton.Text = "Add Weapon to Starting Equipment";
                    Equipment.SimpleRangedWeapons.ForEach(i => weaponSelectListBox.Items.Add(i));
                    break;
                case "Any Martial Ranged Weapon":
                    addAnyWeaponButton.Text = "Add Weapon to Starting Equipment";
                    Equipment.MartialRangedWeapons.ForEach(i => weaponSelectListBox.Items.Add(i));
                    break;
                case "Any Other Musical Instrument":
                    addAnyWeaponButton.Text = "Add Instrument to Starting Equipment";
                    Equipment.MusicalInstruments.ForEach(i => weaponSelectListBox.Items.Add(i));
                    break;
                default:
                    break;
            }
        }

        private void addAnyWeaponButton_Click(object sender, EventArgs e)
        {
            character.CharClass.FinalStartingEquipment.Add(weaponSelectListBox.SelectedItem.ToString());
            addAnyWeaponButton.Enabled = false;
            updateSelectedEquipment();
        }

        private void updateSelectedEquipment()
        {
            selectedEquipmentListBox.Items.Clear();
            List<string> armorList = new List<string>(), weaponList = new List<string>(), packList = new List<string>(), otherList = new List<string>();
            
            foreach (var item in character.CharClass.FinalStartingEquipment)
            {
                if ((Equipment.LightArmor.Contains(item)) || (Equipment.MediumArmor.Contains(item)) ||
                    (Equipment.HeavyArmor.Contains(item)) || (Equipment.Shield.Contains(item)))
                    armorList.Add(item);

                else if ((Equipment.SimpleMeleeWeapons.Contains(item)) || (Equipment.SimpleRangedWeapons.Contains(item)) ||
                    (Equipment.MartialMeleeWeapons.Contains(item)) || (Equipment.MartialRangedWeapons.Contains(item)))
                    weaponList.Add(item);

                else if (item.Contains("Pack"))
                {
                    switch (item)
                    {
                        case "Burglar's Pack":
                            packList.AddRange(Equipment.BurglarsPack);
                            break;
                        case "Diplomat's Pack":
                            packList.AddRange(Equipment.DiplomatsPack);
                            break;
                        case "Dungeoneer's Pack":
                            packList.AddRange(Equipment.DungeoneersPack);
                            break;
                        case "Entertainer's Pack":
                            packList.AddRange(Equipment.EntertainersPack);
                            break;
                        case "Explorer's Pack":
                            packList.AddRange(Equipment.ExplorersPack);
                            break;
                        case "Priest's Pack":
                            packList.AddRange(Equipment.PriestsPack);
                            break;
                        case "Scholar's Pack":
                            packList.AddRange(Equipment.ScholarsPack);
                            break;
                        default:
                            break;
                    }
                }

                else
                    otherList.Add(item);

            }
            selectedEquipmentListBox.Items.Add("--- Armor ---");
            armorList.ForEach(i => selectedEquipmentListBox.Items.Add(i));
            selectedEquipmentListBox.Items.Add("--- Weapons ---");
            weaponList.ForEach(i => selectedEquipmentListBox.Items.Add(i));
            selectedEquipmentListBox.Items.Add("--- Pack Items ---");
            packList.ForEach(i => selectedEquipmentListBox.Items.Add(i));
            selectedEquipmentListBox.Items.Add("--- Other ---");
            otherList.ForEach(i => selectedEquipmentListBox.Items.Add(i));
        }
    }
}