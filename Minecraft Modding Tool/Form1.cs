using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Modding_Tool
{
    public partial class Form1 : Form
    {
        public string outputPath;
        public string templatePath;
        public string modid;

        public BindingList<Item> items;

        private Item currentlySelectedItem;
        private bool swapping = false;

        public Form1()
        {
            InitializeComponent();

            items = new BindingList<Item>();
            items.AllowNew = true;
            items.AllowRemove = true;
            items.RaiseListChangedEvents = true;
            items.AllowEdit = false;

            itemListBox.DataSource = items;
            itemListBox.DisplayMember = "NotarizedName";
            templatePath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName + @"\Templates\";

            InitializeFields(null);
        }

        private void ChooseOutput(object sender, EventArgs e)
        {
            if (outputPathPicker.ShowDialog() == DialogResult.OK)
            {
                outputPathText.Text = outputPath = outputPathPicker.SelectedPath;
                modidText.Text = modid = new DirectoryInfo(outputPath).Name;
            }
        }

        private void InitializeFields(Item item)
        {
            swapping = true;
            if (item == null)
            {
                itemNameText.Enabled = false;
                displayNameText.Enabled = false;

                textureFileChooseButton.Enabled = false;

                blockCheckBox.Enabled = false;
                chestCheckBox.Enabled = false;
                stairsCheckBox.Enabled = false;
                fenceCheckBox.Enabled = false;
                itemCheckBox.Enabled = false;
                wallCheckBox.Enabled = false;
                slabCheckBox.Enabled = false;

                blockVariantDisplayText.Enabled = false;
                chestVariantDisplayText.Enabled = false;
                stairsVariantDisplayText.Enabled = false;
                fenceVariantDisplayText.Enabled = false;
                itemVariantDisplayText.Enabled = false;
                wallVariantDisplayText.Enabled = false;
                slabVariantDisplayText.Enabled = false;

                blockVariantRealText.Enabled = false;
                chestVariantRealText.Enabled = false;
                stairsVariantRealText.Enabled = false;
                fenceVariantRealText.Enabled = false;
                itemVariantRealText.Enabled = false;
                wallVariantRealText.Enabled = false;
                slabVariantRealText.Enabled = false;

                blockCheckBox.CheckState = CheckState.Unchecked;
                stairsCheckBox.CheckState = CheckState.Unchecked;
                slabCheckBox.CheckState = CheckState.Unchecked;
                wallCheckBox.CheckState = CheckState.Unchecked;
                fenceCheckBox.CheckState = CheckState.Unchecked;
                itemCheckBox.CheckState = CheckState.Unchecked;
                chestCheckBox.CheckState = CheckState.Unchecked;
                swapping = false;
                return;
            }
            itemNameText.Enabled = true;
            displayNameText.Enabled = true;
            textureFileChooseButton.Enabled = true;

            blockCheckBox.Enabled = true;
            chestCheckBox.Enabled = true;
            stairsCheckBox.Enabled = true;
            fenceCheckBox.Enabled = true;
            itemCheckBox.Enabled = true;
            wallCheckBox.Enabled = true;
            slabCheckBox.Enabled = true;

            itemNameText.Text = item.itemName;
            displayNameText.Text = item.displayName;
            realNameText.Text = item.NotarizedName;

            blockVariantDisplayText.Text = item.tags["Block"].displayName;
            chestVariantDisplayText.Text = item.tags["Chest"].displayName;
            stairsVariantDisplayText.Text = item.tags["Stairs"].displayName;
            fenceVariantDisplayText.Text = item.tags["Fence"].displayName;
            itemVariantDisplayText.Text = item.tags["Item"].displayName;
            wallVariantDisplayText.Text = item.tags["Wall"].displayName;
            slabVariantDisplayText.Text = item.tags["Slab"].displayName;

            blockVariantRealText.Text = item.tags["Block"].realName;
            chestVariantRealText.Text = item.tags["Chest"].realName;
            stairsVariantRealText.Text = item.tags["Stairs"].realName;
            fenceVariantRealText.Text = item.tags["Fence"].realName;
            itemVariantRealText.Text = item.tags["Item"].realName;
            wallVariantRealText.Text = item.tags["Wall"].realName;
            slabVariantRealText.Text = item.tags["Slab"].realName;

            textureFileText.Text = item.textureFile;

            blockCheckBox.CheckState = item.tags["Block"].exists ? CheckState.Checked : CheckState.Unchecked;
            stairsCheckBox.CheckState = item.tags["Stairs"].exists ? CheckState.Checked : CheckState.Unchecked;
            slabCheckBox.CheckState = item.tags["Slab"].exists ? CheckState.Checked : CheckState.Unchecked;
            wallCheckBox.CheckState = item.tags["Wall"].exists ? CheckState.Checked : CheckState.Unchecked;
            fenceCheckBox.CheckState = item.tags["Fence"].exists ? CheckState.Checked : CheckState.Unchecked;
            itemCheckBox.CheckState = item.tags["Item"].exists ? CheckState.Checked : CheckState.Unchecked;
            chestCheckBox.CheckState = item.tags["Chest"].exists ? CheckState.Checked : CheckState.Unchecked;

            blockVariantDisplayText.Enabled = item.tags["Block"].exists;
            chestVariantDisplayText.Enabled = item.tags["Chest"].exists;
            stairsVariantDisplayText.Enabled = item.tags["Stairs"].exists;
            fenceVariantDisplayText.Enabled = item.tags["Fence"].exists;
            itemVariantDisplayText.Enabled = item.tags["Item"].exists;
            wallVariantDisplayText.Enabled = item.tags["Wall"].exists;
            slabVariantDisplayText.Enabled = item.tags["Slab"].exists;

            blockVariantRealText.Enabled = item.tags["Block"].exists;
            chestVariantRealText.Enabled = item.tags["Chest"].exists;
            stairsVariantRealText.Enabled = item.tags["Stairs"].exists;
            fenceVariantRealText.Enabled = item.tags["Fence"].exists;
            itemVariantRealText.Enabled = item.tags["Item"].exists;
            wallVariantRealText.Enabled = item.tags["Wall"].exists;
            slabVariantRealText.Enabled = item.tags["Slab"].exists;

            swapping = false;
        }

        private void AddElement(object sender, EventArgs e)
        {
            items.Add(new Item());
            itemListBox.SetSelected(items.Count - 1, true);
        }

        private void RemoveElement(object sender, EventArgs e)
        {
            if (itemListBox.SelectedIndex < 0)
            {
                return;
            }

            items.RemoveAt(itemListBox.SelectedIndex);
        }

        private void GenerateJSON(object sender, EventArgs e)
        {
            if (items.Count == 0 || outputPath == string.Empty || outputPath == null)
            {
                return;
            }

            for (int i = 0; i < items.Count; i++)
            {
                GenerateItem(items[i]);
            }
            Prompt.ShowDialog("Generation Complete", "Update");
            items.Clear();
        }

        private void GenerateItem(Item item)
        {
            UpdateLang(item);

            if (item.tags["Block"].exists)
            {
                GenerateBlockModelJSON(item);
                GenerateBlockItemJSON(item);
                GenerateBlockBlockStateJSON(item);
            }
            if (item.tags["Item"].exists)
            {
            }
            if (item.tags["Stairs"].exists)
            {
                GenerateStairsModelJSON(item);
                GenerateStairsItemJSON(item);
                GenerateStairsBlockStateJSON(item);
            }
            if (item.tags["Slab"].exists)
            {
                GenerateSlabBlockStateJSON(item);
                GenerateSlabItemJSON(item);
                GenerateSlabModelJSON(item);
            }
            if (item.tags["Wall"].exists)
            {
            }
            if (item.tags["Chest"].exists)
            {
            }
            if (item.tags["Fence"].exists)
            {
            }
        }

        #region JSON File Gen

        #region Stairs

        public void GenerateStairsModelJSON(Item item)
        {
            string itemName = item.tags["Stairs"].realName;

            string name = itemName.Replace("_stairs", "");
            string textureName = Path.GetFileNameWithoutExtension(item.textureFile);
            string[] stairsModelTemplate = File.ReadAllLines(templatePath + "MB Stairs.json");
            for (int i = 0; i < stairsModelTemplate.Length; i++)
            {
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("MODID", modid);
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("NAME", textureName);
            }
            File.WriteAllLines(outputPath + @"\models\block\" + itemName + @".json", stairsModelTemplate);
            stairsModelTemplate = File.ReadAllLines(templatePath + "MB Stairs Inner.json");
            for (int i = 0; i < stairsModelTemplate.Length; i++)
            {
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("MODID", modid);
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("NAME", textureName);
            }
            File.WriteAllLines(outputPath + @"\models\block\" + name + "_inner_stairs" + @".json", stairsModelTemplate);
            stairsModelTemplate = File.ReadAllLines(templatePath + "MB Stairs Outer.json");
            for (int i = 0; i < stairsModelTemplate.Length; i++)
            {
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("MODID", modid);
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("NAME", textureName);
            }
            File.WriteAllLines(outputPath + @"\models\block\" + name + "_outer_stairs" + @".json", stairsModelTemplate);
        }

        public void GenerateStairsItemJSON(Item item)
        {
            string itemName = item.tags["Stairs"].realName;
            string textureName = Path.GetFileNameWithoutExtension(item.textureFile);

            string[] stairsModelTemplate = File.ReadAllLines(templatePath + "MI Stairs.json");
            for (int i = 0; i < stairsModelTemplate.Length; i++)
            {
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("MODID", modid);
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("NAME", textureName);
            }
            File.WriteAllLines(outputPath + @"\models\item\" + itemName + @".json", stairsModelTemplate);
        }

        public void GenerateStairsBlockStateJSON(Item item)
        {
            string itemName = item.tags["Stairs"].realName;

            string name = itemName.Replace("_stairs", "");
            string[] stairsModelTemplate = File.ReadAllLines(templatePath + "BS Stairs.json");
            for (int i = 0; i < stairsModelTemplate.Length; i++)
            {
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("MODID", modid);
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("NAMEreg", name + "_stairs");
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("NAMEout", name + "_outer_stairs");
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("NAMEin", name + "_inner_stairs");
            }
            File.WriteAllLines(outputPath + @"\blockstates\" + name + "_stairs" + @".json", stairsModelTemplate);
        }

        #endregion Stairs

        #region Block

        public void GenerateBlockModelJSON(Item item)
        {
            string itemName = item.tags["Block"].realName;

            string[] blockModelTemplate = File.ReadAllLines(templatePath + "MB Block.json");
            for (int i = 0; i < blockModelTemplate.Length; i++)
            {
                blockModelTemplate[i] = blockModelTemplate[i].Replace("MODID", modid);
                blockModelTemplate[i] = blockModelTemplate[i].Replace("NAME", Path.GetFileNameWithoutExtension(item.textureFile));
            }
            File.WriteAllLines(outputPath + @"\models\block\" + itemName + @".json", blockModelTemplate);
        }

        public void GenerateBlockItemJSON(Item item)
        {
            string itemName = item.tags["Block"].realName;
            string[] blockModelTemplate = File.ReadAllLines(templatePath + "MI Block.json");
            for (int i = 0; i < blockModelTemplate.Length; i++)
            {
                blockModelTemplate[i] = blockModelTemplate[i].Replace("MODID", modid);
                blockModelTemplate[i] = blockModelTemplate[i].Replace("NAME", itemName);
            }
            File.WriteAllLines(outputPath + @"\models\item\" + itemName + @".json", blockModelTemplate);
        }

        public void GenerateBlockBlockStateJSON(Item item)
        {
            string itemName = item.tags["Block"].realName;

            string[] blockModelTemplate = File.ReadAllLines(templatePath + "BS Block.json");
            for (int i = 0; i < blockModelTemplate.Length; i++)
            {
                blockModelTemplate[i] = blockModelTemplate[i].Replace("MODID", modid);
                blockModelTemplate[i] = blockModelTemplate[i].Replace("NAME", itemName);
            }
            File.WriteAllLines(outputPath + @"\blockstates\" + itemName + @".json", blockModelTemplate);
        }

        #endregion Block

        #region Slab

        public void GenerateSlabModelJSON(Item item)
        {
            string itemName = item.tags["Slab"].realName;
            string textureName = Path.GetFileNameWithoutExtension(item.textureFile);

            string[] doubleSlabModelTemplate = File.ReadAllLines(templatePath + "MB Double Slab.json");
            for (int i = 0; i < doubleSlabModelTemplate.Length; i++)
            {
                doubleSlabModelTemplate[i] = doubleSlabModelTemplate[i].Replace("MODID", modid);
                doubleSlabModelTemplate[i] = doubleSlabModelTemplate[i].Replace("NAME", textureName);
            }
            File.WriteAllLines(outputPath + @"\models\block\double_" + itemName + @".json", doubleSlabModelTemplate);

            string[] bottomSlabModelTemplate = File.ReadAllLines(templatePath + "MB Slab Bottom.json");
            for (int i = 0; i < bottomSlabModelTemplate.Length; i++)
            {
                bottomSlabModelTemplate[i] = bottomSlabModelTemplate[i].Replace("MODID", modid);
                bottomSlabModelTemplate[i] = bottomSlabModelTemplate[i].Replace("NAME", textureName);
            }
            File.WriteAllLines(outputPath + @"\models\block\bottom_" + itemName + @".json", bottomSlabModelTemplate);

            string[] upperSlabModelTemplate = File.ReadAllLines(templatePath + "MB Slab Upper.json");
            for (int i = 0; i < upperSlabModelTemplate.Length; i++)
            {
                upperSlabModelTemplate[i] = upperSlabModelTemplate[i].Replace("MODID", modid);
                upperSlabModelTemplate[i] = upperSlabModelTemplate[i].Replace("NAME", textureName);
            }
            File.WriteAllLines(outputPath + @"\models\block\upper_" + itemName + @".json", upperSlabModelTemplate);
        }

        public void GenerateSlabItemJSON(Item item)
        {
            string itemName = item.tags["Slab"].realName;
            string textureName = Path.GetFileNameWithoutExtension(item.textureFile);

            string[] slamItemTemplate = File.ReadAllLines(templatePath + "MI Slab.json");
            for (int i = 0; i < slamItemTemplate.Length; i++)
            {
                slamItemTemplate[i] = slamItemTemplate[i].Replace("MODID", modid);
                slamItemTemplate[i] = slamItemTemplate[i].Replace("NAME", textureName);
            }
            File.WriteAllLines(outputPath + @"\models\item\" + itemName + @".json", slamItemTemplate);
        }

        public void GenerateSlabBlockStateJSON(Item item)
        {
            string itemName = item.tags["Slab"].realName;

            string[] slabTemplate = File.ReadAllLines(templatePath + "BS Slab.json");
            for (int i = 0; i < slabTemplate.Length; i++)
            {
                slabTemplate[i] = slabTemplate[i].Replace("MODID", modid);
                slabTemplate[i] = slabTemplate[i].Replace("NAME", itemName);
            }
            File.WriteAllLines(outputPath + @"\blockstates\" + itemName + @".json", slabTemplate);

            string[] doubleSlabTemplate = File.ReadAllLines(templatePath + "BS Double Slab.json");
            for (int i = 0; i < doubleSlabTemplate.Length; i++)
            {
                doubleSlabTemplate[i] = doubleSlabTemplate[i].Replace("MODID", modid);
                doubleSlabTemplate[i] = doubleSlabTemplate[i].Replace("NAME", itemName);
            }
            File.WriteAllLines(outputPath + @"\blockstates\double_" + itemName + @".json", doubleSlabTemplate);
        }

        #endregion Slab

        #endregion JSON File Gen

        private void UpdateLang(Item item)
        {
            using (StreamWriter file = File.AppendText(outputPath + @"\lang\en_US.lang"))
            {
                file.WriteLine("");
                bool trigged = false;
                foreach (KeyValuePair<string, Item.ItemVariant> tag in item.tags)
                {
                    if (tag.Value.exists)
                    {
                        trigged = true;
                        file.WriteLine(String.Format("{0}.{1}.name={2}", tag.Key == "Item" ? "item" : "tile", tag.Value.realName, tag.Value.displayName));
                    }
                }
                if (!trigged)
                {
                    file.WriteLine(String.Format("{0}.{1}.name={2}", "item", item.NotarizedName, item.displayName));
                }
            }
        }

        private void itemNameText_TextChanged(object sender, EventArgs e)
        {
            currentlySelectedItem.itemName = itemNameText.Text;
            string[] tempDispName;
            if (!string.IsNullOrEmpty(itemNameText.Text))
            {
                tempDispName = currentlySelectedItem.itemName.ToLower().Split('_');
                currentlySelectedItem.displayName = tempDispName[0].Substring(0, 1).ToUpper() + tempDispName[0].Substring(1);
                for(int i = 1; i < tempDispName.Length; i++)
                {
                    currentlySelectedItem.displayName += ' ';
                    if (!string.IsNullOrEmpty(itemNameText.Text) && !string.IsNullOrEmpty(tempDispName[i]))
                        currentlySelectedItem.displayName += tempDispName[i].Substring(0, 1).ToUpper() + tempDispName[i].Substring(1);
                    else return; 
                }

                displayNameText.Text = currentlySelectedItem.displayName;
            }    
            else displayNameText.Text = currentlySelectedItem.displayName = null;

            currentlySelectedItem.NotarizedName = currentlySelectedItem.itemName.ToLower().Replace(" ", "_");
            realNameText.Text = currentlySelectedItem.NotarizedName;
            currentlySelectedItem.tags["Block"].realName = blockVariantRealText.Text = currentlySelectedItem.NotarizedName + "_block";
            currentlySelectedItem.tags["Chest"].realName = chestVariantRealText.Text = currentlySelectedItem.NotarizedName + "_chest";
            currentlySelectedItem.tags["Stairs"].realName = stairsVariantRealText.Text = currentlySelectedItem.NotarizedName + "_stairs";
            currentlySelectedItem.tags["Fence"].realName = fenceVariantRealText.Text = currentlySelectedItem.NotarizedName + "_fence";
            currentlySelectedItem.tags["Item"].realName = itemVariantRealText.Text = currentlySelectedItem.NotarizedName + "_item";
            currentlySelectedItem.tags["Wall"].realName = wallVariantRealText.Text = currentlySelectedItem.NotarizedName + "_wall";
            currentlySelectedItem.tags["Slab"].realName = slabVariantRealText.Text = currentlySelectedItem.NotarizedName + "_slab";
        }

        #region List Changes

        private void itemListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemListBox.SelectedIndex < 0)
            {
                InitializeFields(null);
            }
            else
            {
                currentlySelectedItem = items[itemListBox.SelectedIndex];

                InitializeFields(currentlySelectedItem);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            items.AddNew();
            items.RemoveAt(items.Count - 1);
        }

        #endregion List Changes

        #region Check Boxes

        private void blockCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (swapping)
            {
                return;
            }

            blockVariantDisplayText.Enabled = blockVariantRealText.Enabled = currentlySelectedItem.tags["Block"].exists = blockCheckBox.Checked;
        }

        private void itemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (swapping)
            {
                return;
            }

            itemVariantRealText.Enabled = itemVariantDisplayText.Enabled = currentlySelectedItem.tags["Item"].exists = itemCheckBox.Checked;
        }

        private void stairsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (swapping)
            {
                return;
            }

            stairsVariantDisplayText.Enabled = stairsVariantRealText.Enabled = currentlySelectedItem.tags["Stairs"].exists = stairsCheckBox.Checked;
        }

        private void slabCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (swapping)
            {
                return;
            }

            slabVariantDisplayText.Enabled = slabVariantRealText.Enabled = currentlySelectedItem.tags["Slab"].exists = slabCheckBox.Checked;
        }

        private void wallCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (swapping)
            {
                return;
            }

            wallVariantRealText.Enabled = wallVariantDisplayText.Enabled = currentlySelectedItem.tags["Wall"].exists = wallCheckBox.Checked;
        }

        private void fenceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (swapping)
            {
                return;
            }

            fenceVariantRealText.Enabled = fenceVariantDisplayText.Enabled = currentlySelectedItem.tags["Fence"].exists = fenceCheckBox.Checked;
        }

        private void chestCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (swapping)
            {
                return;
            }

            chestVariantRealText.Enabled = chestVariantDisplayText.Enabled = currentlySelectedItem.tags["Chest"].exists = chestCheckBox.Checked;
        }

        #endregion Check Boxes

        private void displayNameText_TextChanged(object sender, EventArgs e)
        {
            currentlySelectedItem.displayName = displayNameText.Text;
            currentlySelectedItem.tags["Block"].displayName = blockVariantDisplayText.Text = currentlySelectedItem.displayName + " Block";
            currentlySelectedItem.tags["Chest"].displayName = chestVariantDisplayText.Text = currentlySelectedItem.displayName + " Chest";
            currentlySelectedItem.tags["Stairs"].displayName = stairsVariantDisplayText.Text = currentlySelectedItem.displayName + " Stairs";
            currentlySelectedItem.tags["Fence"].displayName = fenceVariantDisplayText.Text = currentlySelectedItem.displayName + " Fence";
            currentlySelectedItem.tags["Item"].displayName = itemVariantDisplayText.Text = currentlySelectedItem.displayName + " Item";
            currentlySelectedItem.tags["Wall"].displayName = wallVariantDisplayText.Text = currentlySelectedItem.displayName + " Wall";
            currentlySelectedItem.tags["Slab"].displayName = slabVariantDisplayText.Text = currentlySelectedItem.displayName + " Slab";
        }

        private void textureFileChooseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textureFileText.Text = currentlySelectedItem.textureFile = openFileDialog1.FileName;
            }
        }

        #region Variant Real Text

        private void blockVariantRealText_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (swapping)
            {
                return;
            }

            if (e.KeyChar == ' ')
            {
                e.KeyChar = '_';
            }

            currentlySelectedItem.tags["Block"].realName = blockVariantRealText.Text;
            blockVariantRealText.Text = currentlySelectedItem.tags["Block"].realName;
        }

        private void itemVariantRealText_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (swapping)
            {
                return;
            }
            if (e.KeyChar == ' ')
            {
                e.KeyChar = '_';
            }

            currentlySelectedItem.tags["Item"].realName = itemVariantRealText.Text;

            itemVariantRealText.Text = currentlySelectedItem.tags["Item"].realName;
        }

        private void stairsVariantRealText_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (swapping)
            {
                return;
            }
            if (e.KeyChar == ' ')
            {
                e.KeyChar = '_';
            }

            currentlySelectedItem.tags["Stairs"].realName = stairsVariantRealText.Text;

            stairsVariantRealText.Text = currentlySelectedItem.tags["Stairs"].realName;
        }

        private void slabVariantRealText_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (swapping || e.Handled)
            {
                return;
            }
            if (e.KeyChar == ' ')
            {
                e.KeyChar = '_';
            }

            currentlySelectedItem.tags["Slab"].realName = slabVariantRealText.Text;

            slabVariantRealText.Text = currentlySelectedItem.tags["Slab"].realName;
        }

        private void wallVariantRealText_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (swapping)
            {
                return;
            }
            if (e.KeyChar == ' ')
            {
                e.KeyChar = '_';
            }

            currentlySelectedItem.tags["Wall"].realName = wallVariantRealText.Text;

            wallVariantRealText.Text = currentlySelectedItem.tags["Wall"].realName;
        }

        private void fenceVariantRealText_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (swapping)
            {
                return;
            }
            if (e.KeyChar == ' ')
            {
                e.KeyChar = '_';
            }

            currentlySelectedItem.tags["Fence"].realName = fenceVariantRealText.Text;

            fenceVariantRealText.Text = currentlySelectedItem.tags["Fence"].realName;
        }

        private void chestVariantRealText_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (swapping)
            {
                return;
            }
            if (e.KeyChar == ' ')
            {
                e.KeyChar = '_';
            }

            currentlySelectedItem.tags["Chest"].realName = chestVariantRealText.Text.Replace(" ", "_");

            chestVariantRealText.Text = currentlySelectedItem.tags["Chest"].realName;
        }

        #endregion Variant Real Text

        #region Variant Display Text

        private void blockVariantDisplayText_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (swapping)
            {
                return;
            }

            currentlySelectedItem.tags["Block"].displayName = blockVariantDisplayText.Text;

            blockVariantDisplayText.Text = currentlySelectedItem.tags["Block"].displayName;
        }

        private void itemVariantDisplayText_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (swapping)
            {
                return;
            }

            currentlySelectedItem.tags["Item"].displayName = itemVariantDisplayText.Text;

            itemVariantDisplayText.Text = currentlySelectedItem.tags["Item"].displayName;
        }

        private void stairsVariantDisplayText_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (swapping)
            {
                return;
            }

            currentlySelectedItem.tags["Stairs"].displayName = stairsVariantDisplayText.Text;

            stairsVariantDisplayText.Text = currentlySelectedItem.tags["Stairs"].displayName;
        }

        private void slabVariantDisplayText_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (swapping)
            {
                return;
            }

            currentlySelectedItem.tags["Slab"].displayName = slabVariantDisplayText.Text;

            slabVariantDisplayText.Text = currentlySelectedItem.tags["Slab"].displayName;
        }

        private void wallVariantDisplayText_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (swapping)
            {
                return;
            }

            currentlySelectedItem.tags["Wall"].displayName = wallVariantDisplayText.Text;

            wallVariantDisplayText.Text = currentlySelectedItem.tags["Wall"].displayName;
        }

        private void fenceVariantDisplayText_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (swapping)
            {
                return;
            }

            currentlySelectedItem.tags["Fence"].displayName = fenceVariantDisplayText.Text;

            fenceVariantDisplayText.Text = currentlySelectedItem.tags["Fence"].displayName;
        }

        private void chestVariantDisplayText_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (swapping)
            {
                return;
            }

            currentlySelectedItem.tags["Chest"].displayName = chestVariantDisplayText.Text;

            chestVariantDisplayText.Text = currentlySelectedItem.tags["Chest"].displayName;
        }

        #endregion Variant Display Text
    }

    public class Item
    {
        public string itemName;
        public string displayName;

        public string NotarizedName
        {
            get; set;
        }

        public string textureFile;

        public Dictionary<string, ItemVariant> tags = new Dictionary<string, ItemVariant>();

        public Item()
        {
            itemName = "Item";
            displayName = "displayName";
            NotarizedName = "item";

            tags.Add("Block", new ItemVariant(false, displayName + " Block"));
            tags.Add("Item", new ItemVariant(false, displayName + " Item"));
            tags.Add("Stairs", new ItemVariant(false, displayName + " Stairs"));
            tags.Add("Slab", new ItemVariant(false, displayName + " Slab"));
            tags.Add("Wall", new ItemVariant(false, displayName + " Wall"));
            tags.Add("Fence", new ItemVariant(false, displayName + " Fence"));
            tags.Add("Chest", new ItemVariant(false, displayName + " Chest"));
        }

        public class ItemVariant
        {
            public bool exists;
            public string displayName;
            public string realName;

            public ItemVariant(bool exists, string displayName)
            {
                this.exists = exists;
                this.displayName = displayName;
                realName = displayName.ToLower().Replace(" ", "_");
            }
        }
    }
}

public static class Prompt
{
    public static bool ShowDialog(string text, string caption)
    {
        Form prompt = new Form()
        {
            Width = 300,
            Height = 150,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = caption,
            StartPosition = FormStartPosition.CenterScreen
        };
        Label textLabel = new Label() { Left = 50, Width = 300, Top = 20, Text = text };
        Button confirmation = new Button() { Text = "Ok", Left = 90, Width = 100, Top = 70, DialogResult = DialogResult.OK };
        confirmation.Click += (sender, e) => { prompt.Close(); };
        prompt.Controls.Add(confirmation);
        prompt.Controls.Add(textLabel);
        prompt.AcceptButton = confirmation;

        return prompt.ShowDialog() == DialogResult.OK;
    }
}