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

            textureFileText.Text = item.textureFile;

            blockCheckBox.CheckState = item.tags["Block"].exists ? CheckState.Checked : CheckState.Unchecked;
            stairsCheckBox.CheckState = item.tags["Stairs"].exists ? CheckState.Checked : CheckState.Unchecked;
            slabCheckBox.CheckState = item.tags["Slab"].exists ? CheckState.Checked : CheckState.Unchecked;
            wallCheckBox.CheckState = item.tags["Wall"].exists ? CheckState.Checked : CheckState.Unchecked;
            fenceCheckBox.CheckState = item.tags["Fence"].exists ? CheckState.Checked : CheckState.Unchecked;
            itemCheckBox.CheckState = item.tags["Item"].exists ? CheckState.Checked : CheckState.Unchecked;
            chestCheckBox.CheckState = item.tags["Chest"].exists ? CheckState.Checked : CheckState.Unchecked;
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
            if (type == "Item")
            {
            }
            else if (type == "Stairs")
            {
                GenerateStairsModelJSON(name, modid);
                GenerateStairsItemJSON(name, modid);
                GenerateStairsBlockStateJSON(name, modid);
            }
            else if (type == "Block")
            {
                GenerateBlockModelJSON(name, modid);
                GenerateBlockItemJSON(name, modid);
                GenerateBlockBlockStateJSON(name, modid);
            }
            else if (type == "Slab")
            {
                GenerateSlabBlockStateJSON(name, modid);
                GenerateSlabItemJSON(name, modid);
                GenerateSlabModelJSON(name, modid);
            }

            UpdateLang(displayName, name, type);
        }

        #region JSON File Gen

        public void GenerateStairsModelJSON(string itemName, string modid)
        {
            string name = itemName.Replace("_stairs", "");
            string[] stairsModelTemplate = File.ReadAllLines(templatePath + "MB Stairs.json");
            for (int i = 0; i < stairsModelTemplate.Length; i++)
            {
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("MODID", modid);
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("NAME", name + "_stairs");
            }
            File.WriteAllLines(outputPath + @"\models\block\" + itemName + @".json", stairsModelTemplate);
            stairsModelTemplate = File.ReadAllLines(templatePath + "MB Stairs Inner.json");
            for (int i = 0; i < stairsModelTemplate.Length; i++)
            {
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("MODID", modid);
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("NAME", name + "_inner_stairs");
            }
            File.WriteAllLines(outputPath + @"\models\block\" + name + "_inner_stairs" + @".json", stairsModelTemplate);
            stairsModelTemplate = File.ReadAllLines(templatePath + "MB Stairs Outer.json");
            for (int i = 0; i < stairsModelTemplate.Length; i++)
            {
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("MODID", modid);
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("NAME", name + "_outer_stairs");
            }
            File.WriteAllLines(outputPath + @"\models\block\" + name + "_outer_stairs" + @".json", stairsModelTemplate);
        }

        public void GenerateStairsItemJSON(string itemName, string modid)
        {
            string[] stairsModelTemplate = File.ReadAllLines(templatePath + "MI Stairs.json");
            for (int i = 0; i < stairsModelTemplate.Length; i++)
            {
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("MODID", modid);
                stairsModelTemplate[i] = stairsModelTemplate[i].Replace("NAME", itemName);
            }
            File.WriteAllLines(outputPath + @"\models\item\" + itemName + @".json", stairsModelTemplate);
        }

        public void GenerateStairsBlockStateJSON(string itemName, string modid)
        {
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

        public void GenerateBlockModelJSON(string itemName, string modid)
        {
            string[] blockModelTemplate = File.ReadAllLines(templatePath + "MB Block.json");
            for (int i = 0; i < blockModelTemplate.Length; i++)
            {
                blockModelTemplate[i] = blockModelTemplate[i].Replace("MODID", modid);
                blockModelTemplate[i] = blockModelTemplate[i].Replace("NAME", itemName);
            }
            File.WriteAllLines(outputPath + @"\models\block\" + itemName + @".json", blockModelTemplate);
        }

        public void GenerateBlockItemJSON(string itemName, string modid)
        {
            string[] blockModelTemplate = File.ReadAllLines(templatePath + "MI Block.json");
            for (int i = 0; i < blockModelTemplate.Length; i++)
            {
                blockModelTemplate[i] = blockModelTemplate[i].Replace("MODID", modid);
                blockModelTemplate[i] = blockModelTemplate[i].Replace("NAME", itemName);
            }
            File.WriteAllLines(outputPath + @"\models\item\" + itemName + @".json", blockModelTemplate);
        }

        public void GenerateBlockBlockStateJSON(string itemName, string modid)
        {
            string[] blockModelTemplate = File.ReadAllLines(templatePath + "BS Block.json");
            for (int i = 0; i < blockModelTemplate.Length; i++)
            {
                blockModelTemplate[i] = blockModelTemplate[i].Replace("MODID", modid);
                blockModelTemplate[i] = blockModelTemplate[i].Replace("NAME", itemName);
            }
            File.WriteAllLines(outputPath + @"\blockstates\" + itemName + @".json", blockModelTemplate);
        }

        public void GenerateSlabModelJSON(string itemName, string modid)
        {
            string[] doubleSlabModelTemplate = File.ReadAllLines(templatePath + "MB Double Slab.json");
            for (int i = 0; i < doubleSlabModelTemplate.Length; i++)
            {
                doubleSlabModelTemplate[i] = doubleSlabModelTemplate[i].Replace("MODID", modid);
                doubleSlabModelTemplate[i] = doubleSlabModelTemplate[i].Replace("NAME", itemName);
            }
            File.WriteAllLines(outputPath + @"\models\block\double_" + itemName + @".json", doubleSlabModelTemplate);

            string[] bottomSlabModelTemplate = File.ReadAllLines(templatePath + "MB Slab Bottom.json");
            for (int i = 0; i < bottomSlabModelTemplate.Length; i++)
            {
                bottomSlabModelTemplate[i] = bottomSlabModelTemplate[i].Replace("MODID", modid);
                bottomSlabModelTemplate[i] = bottomSlabModelTemplate[i].Replace("NAME", itemName);
            }
            File.WriteAllLines(outputPath + @"\models\block\bottom_" + itemName + @".json", bottomSlabModelTemplate);

            string[] upperSlabModelTemplate = File.ReadAllLines(templatePath + "MB Slab Upper.json");
            for (int i = 0; i < upperSlabModelTemplate.Length; i++)
            {
                upperSlabModelTemplate[i] = upperSlabModelTemplate[i].Replace("MODID", modid);
                upperSlabModelTemplate[i] = upperSlabModelTemplate[i].Replace("NAME", itemName);
            }
            File.WriteAllLines(outputPath + @"\models\block\upper_" + itemName + @".json", upperSlabModelTemplate);
        }

        public void GenerateSlabItemJSON(string itemName, string modid)
        {
            string[] slamItemTemplate = File.ReadAllLines(templatePath + "MI Slab.json");
            for (int i = 0; i < slamItemTemplate.Length; i++)
            {
                slamItemTemplate[i] = slamItemTemplate[i].Replace("MODID", modid);
                slamItemTemplate[i] = slamItemTemplate[i].Replace("NAME", itemName);
            }
            File.WriteAllLines(outputPath + @"\models\item\" + itemName + @".json", slamItemTemplate);
        }

        public void GenerateSlabBlockStateJSON(string itemName, string modid)
        {
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
                        file.WriteLine(String.Format("{0}.{1}.name={2}", tag.Key == "Item" ? "item" : "tile", item.NotarizedName + "_" + tag.Key.ToLower(), tag.Value.exists));
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

            currentlySelectedItem.NotarizedName = currentlySelectedItem.itemName.ToLower().Replace(" ", "_");
            realNameText.Text = currentlySelectedItem.NotarizedName;
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
            Console.WriteLine(currentlySelectedItem.displayName);

            currentlySelectedItem.tags["Block"].exists = blockCheckBox.Checked;
        }

        private void itemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (swapping)
            {
                return;
            }
            Console.WriteLine(currentlySelectedItem.displayName);

            currentlySelectedItem.tags["Item"].exists = itemCheckBox.Checked;
        }

        private void stairsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (swapping)
            {
                return;
            }
            Console.WriteLine(currentlySelectedItem.displayName);

            currentlySelectedItem.tags["Stairs"].exists = stairsCheckBox.Checked;
        }

        private void slabCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (swapping)
            {
                return;
            }
            Console.WriteLine(currentlySelectedItem.displayName);

            currentlySelectedItem.tags["Slab"].exists = slabCheckBox.Checked;
        }

        private void wallCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (swapping)
            {
                return;
            }
            Console.WriteLine(currentlySelectedItem.displayName);

            currentlySelectedItem.tags["Wall"].exists = wallCheckBox.Checked;
        }

        private void fenceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (swapping)
            {
                return;
            }
            Console.WriteLine(currentlySelectedItem.displayName);

            currentlySelectedItem.tags["Fence"].exists = fenceCheckBox.Checked;
        }

        private void chestCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (swapping)
            {
                return;
            }

            Console.WriteLine(currentlySelectedItem.displayName);
            currentlySelectedItem.tags["Chest"].exists = chestCheckBox.Checked;
        }

        #endregion Check Boxes

        private void displayNameText_TextChanged(object sender, EventArgs e)
        {
            currentlySelectedItem.displayName = displayNameText.Text;
        }

        private void textureFileChooseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textureFileText.Text = currentlySelectedItem.textureFile = openFileDialog1.FileName;
            }
        }
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

            public ItemVariant(bool exists, string displayName)
            {
                this.exists = exists;
                this.displayName = displayName;
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