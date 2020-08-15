using System;
using System.Windows.Forms;
using ConfigExample.Configuration;
using System.Configuration;

namespace ConfigExample {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SimpleSection simple = ConfigurationManager.GetSection("simple") as SimpleSection;

            //ComplexSection complex = ConfigurationManager.GetSection("complex") as ComplexSection;

            SampleSectionGroup sample = (SampleSectionGroup)ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).SectionGroups["sampleGroup"];
            SimpleSection simple = sample.Simple;
            ComplexSection complex = sample.Complex;

            textBoxResult.Text = string.Format("simple 's maxValue is {0},minValue is {1},enabled = {2}\r\n"
                + "complex's height is {3},firstName={4},lastName={5}\r\n"
                + "complex's children count is {6}", 
                simple.MaxValue,simple.MinValue,simple.Enable,
                complex.Height,
                complex.Child.FirstName,
                complex.Child.LastName,
                complex.Children.Count);

            foreach (ChildSection child in complex.Children)
            {
                textBoxResult.Text += string.Format("\r\n\tfirstName={0},lastName={1}", child.FirstName, child.LastName);
            }

            textBoxResult.Text += "\r\nNVs's count is " + complex.NVs.Count;
            foreach (string key in complex.NVs.AllKeys)
            {
                textBoxResult.Text += string.Format("\r\n\tkey={0},value={1}", key, complex.NVs[key].Value);
            }
        }
    }
}
