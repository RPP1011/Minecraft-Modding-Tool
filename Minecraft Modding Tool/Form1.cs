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

        private List<string> items = new List<string>();

        public Form1()
        {
            InitializeComponent();
            templatePath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName + @"\Templates\";
            listBox1.DataSource = items;
            comboBox1.Items.Add(new NameValue("Block", "Block"));
            comboBox1.Items.Add(new NameValue("Item", "Item"));
            comboBox1.Items.Add(new NameValue("Slab", "Slab"));
            comboBox1.Select(0, 0);
        }

        public class NameValue
        {
            private string dataName;
            private string dataValue;

            public NameValue(string dataName, string dataValue)
            {
                DataName = dataName;
                DataValue = dataValue;
            }

            public string DataName
            {
                get
                {
                    return dataName;
                }
                set
                {
                    dataName = value;
                }
            }

            public string DataValue
            {
                get
                {
                    return dataValue;
                }
                set
                {
                    dataValue = value;
                }
            }

            public override string ToString()
            {
                return dataName;
            }
        }

        private void ChooseOutput(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                outputPath = folderBrowserDialog1.SelectedPath;
                textBox1.Text = outputPath;
                string package = new DirectoryInfo(outputPath).Name;
                textBox3.Text = package;
                modid = package;
            }
        }

        private void AddElement(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty || textBox2.Text == "Name" || comboBox1.SelectedItem == null)
            {
                return;
            }

            if (textBox2.Text.Any(char.IsDigit))
            {
                Prompt.ShowDialog("Numbers aren't allowed in item names", "Invalid Name");
                return;
            }

            items.Add(textBox2.Text + "(" + ((NameValue)comboBox1.SelectedItem).DataValue + ")" + textBox4.Text);
            listBox1.DataSource = null;
            listBox1.DataSource = items;
            textBox2.Text = "Name";
            textBox4.Text = "Display Name";

            button4.Enabled = true;
        }

        private void RemoveElement(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }

            items.RemoveAt(listBox1.SelectedIndex);
            if (items.Count == 0)
            {
                button4.Enabled = false;
            }

            listBox1.DataSource = null;
            listBox1.DataSource = items;
        }

        private void GenerateJSON(object sender, EventArgs e)
        {
            if (items.Count == 0 || outputPath == string.Empty)
            {
                return;
            }
            progressBar1.Value = 0;

            for (int i = 0; i < items.Count; i++)
            {
                string[] parts = items[i].Split('(', ')');
                string displayName = parts[2];
                string type = parts[1];
                string name = parts[0].Replace(' ', '_').ToLower();

                GenerateItem(displayName, type, name);

                progressBar1.Value = (int)(i / (float)items.Count) * 100;
            }
            Prompt.ShowDialog("Generation Complete", "Update");
            progressBar1.Value = 0;
            items.Clear();
            listBox1.DataSource = null;
            listBox1.DataSource = items;
        }

        private void GenerateItem(string displayName, string type, string name)
        {
            if (type == "Item")
            {
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

        private void UpdateLang(string origName, string name, string type)
        {
            using (StreamWriter file = File.AppendText(outputPath + @"\lang\en_US.lang"))
            {
                file.WriteLine("");
                switch (type)
                {
                    case "Slab":
                        file.WriteLine(String.Format("tile.{0}.name={1}", name, origName));

                        break;

                    case "Block":
                        file.WriteLine(String.Format("tile.{0}.name={1}", name, origName));

                        break;

                    case "Item":

                        break;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = textBox2.Text;
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