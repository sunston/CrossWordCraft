using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrossWordCraft
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            UpdateControl();

            //Связывание элемента управления содержанием с шаблоном кроссворда
            Content.Template = Template;
            //Связывание события AsyncGenerationCompleted с обработчиком
            Content.AsyncGenerationCompleted += GenerationCompleted; 
        }

        //Обработка события 'Сохранение шаблона'
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Template.Save();
            }
            catch (Exception ex)
            {
                Environment.ErrorMessage(ex, "Сохранение шаблона");  
            }

            UpdateControl();
        }

        //Обработка события 'Сохранение шаблона как...'
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Template.SaveAs();
            }
            catch (Exception ex)
            {
                Environment.ErrorMessage(ex, "Сохранение шаблона");
            }

            UpdateControl();
        }

        //Обработка события 'Создание нового шаблона'
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Template.New();
            UpdateControl();
        }

        //Обработка события 'Открытие шаблона'
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Template.Open();
            }
            catch (Exception ex)
            {
                Environment.ErrorMessage(ex, "Открытие шаблона");
            }

            UpdateControl();
        }

        //Обработка события 'Выход'
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        //Обновление статусбара
        private void UpdateControl()
        {
            this.FilenameToolStripStatusLabel.Text = this.Template.Filename;
        }

        //Обработка события 'Генерация кроссворда'
        private void GenerateToolStripButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            try
            {
                this.Content.AsyncGenerate();
            }
            catch (Exception ex)
            {
                Environment.ErrorMessage(ex, "Запуск процесса генерации кроссвордов");
                this.Enabled = true;
            }
        }

        //Обработка события 'Генерация кроссворда завершена'
        private void GenerationCompleted(object sender, EventArgs e)
        {
            this.Enabled = true;
            this.Focus(); 
        }

        //Обработка события 'Чтение текста для наполнения кроссворда'
        private void ReadContentToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Content.Open();
            }
            catch (Exception ex)
            {
                Environment.ErrorMessage(ex, "Чтение текстового файла с содержанием кроссворда");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Splash _Splash = new Splash();
            _Splash.ShowDialog();  
        }
    }
}
