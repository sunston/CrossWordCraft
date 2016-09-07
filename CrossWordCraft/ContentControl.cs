using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using CrossWordCraft.Model;   

namespace CrossWordCraft
{
    //Элемент управление содержимым кроссворда
    public partial class ContentControl : UserControl
    {
        //Событие завершения асинхронного процесса генерации кроссворда
        public event EventHandler<EventArgs> AsyncGenerationCompleted;

        //Связанный шаблон
        private TemplateControl m_Template;
        public TemplateControl Template { get { return m_Template; } set { m_Template = value; } }
        //Список свойств
        private ContentProperties m_Properties;
        public ContentProperties Properties { get { return m_Properties; } }
        //Содержимое для наполнения кроссворда
        private Content m_Content;
        //Конструктор
        public ContentControl()
        {
            InitializeComponent();
            m_Properties = new ContentProperties(this.PropertiesListView);
            m_Content = new Content(); 
        }


        //Отображение свойств шаблона
        private void AppendTemplateStatistics()
        {
            Words words = Template.Grid.CreateWords();
            this.Properties.Add("Слов в шаблоне", words.Count.ToString());

            int hcount = 0;
            int vcount = 0;
            foreach (Word word in words)
                if (word.Direction == EWordDirection.wdHorizontal)
                    hcount++;
                else
                    vcount++;

            this.Properties.Add(" - по горизонтали", hcount.ToString());
            this.Properties.Add(" - по вертикали", vcount.ToString());
        }
        //Отображение свойств загруженного содержимого
        private void AppendContentStatistics()
        {
            List<int> _Groups = new List<int>();  
            int _wordcount = 0;
            foreach (KeyValuePair<int, List<ContentItem>> _entry in m_Content.Groups)
            {
                _wordcount += _entry.Value.Count;
                _Groups.Add(_entry.Key);    
            }

            this.Properties.Add("Загружено слов", _wordcount.ToString());
            _Groups.Sort();
  
            foreach (int _length in _Groups)
                this.Properties.Add(" - длина "+_length.ToString()  , m_Content.GetContent(_length).Count.ToString());
        }
        //Обновление списка со свойствами
        private void ShowProperties()
        {
            this.Properties.Clear();
            this.AppendTemplateStatistics();
            this.AppendContentStatistics();
        }

        //Загрузка содержимого
        public void Open()
        {
            OpenFileDialog _dialog = new OpenFileDialog();
            _dialog.Filter = "Text files (*.txt)|*.txt";
            _dialog.ShowDialog();

            if (_dialog.FileName.Trim().Length == 0)
                return;

            Open(_dialog.FileName);
        }
        //Загрузка содержимого по имени файла
        public void Open(string _Filename)
        {
            m_Content.Clear();
            m_Content.Append(System.IO.File.ReadAllText(_Filename, Encoding.Default));
            ShowProperties();
        }

        //Запуск генерации в обычном режиме
        public void Generate()
        {
            ShowProperties();
            GenerateCall();
            AfterGenerate();
        }

        //Элементы окружения асинхронного запуска процесса генерации
        private delegate void GenerateCallDelegate();
        private ProceedingForm m_ProceedingForm;
        private System.Threading.Timer m_Timer;
        //Запуск генерации в асинхронном режиме
        public void AsyncGenerate()
        {
            ShowProperties();

            //Инициализация формы мониторинга процесса генерации
            m_ProceedingForm = new ProceedingForm();
            //Обработка нажатия на кнопку "Завершить..."
            m_ProceedingForm.StopButton.Click += new EventHandler((object obj, EventArgs Args) =>
                {
                    m_Content.StopGeneration();  
                });   
            //Обработка закрытия формы
            m_ProceedingForm.FormClosed  += new FormClosedEventHandler((object obj, FormClosedEventArgs Args) => 
            { 
                m_ProceedingForm = null;
                m_Timer = null;

                AfterGenerate();
            });
            //Инициализация и запуск таймера для периодического опроса m_Content о статусе процесса генерации
            m_Timer = new System.Threading.Timer(TimerHandler, null, 500, 500);

            //Открытие формы
            m_ProceedingForm.Show();

            //Запуск процесса генерации посредством асинхронного вызова делегата
            GenerateCallDelegate _invoke = GenerateCall;
            IAsyncResult _invokeResult = _invoke.BeginInvoke(AsyncGenerateCompleted, this);
        }
        //Обработка завершения процесса генерации
        private void AsyncGenerateCompleted(object state)
        {
            if (m_ProceedingForm == null)
                return;

            m_ProceedingForm.Invoke(new MethodInvoker(() =>
            {
                m_ProceedingForm.Close();

                if (AsyncGenerationCompleted != null)
                    AsyncGenerationCompleted(this, EventArgs.Empty);   
            }));
        }
        //Обработка срабатывания таймера
        private void TimerHandler(object sender)
        {
            if (m_ProceedingForm == null)
                return;

            m_ProceedingForm.Invoke(new MethodInvoker(() => 
                    {
                        m_ProceedingForm.VariantsCount = m_Content.Variants.Count;
                        m_ProceedingForm.OperationsCount = m_Content.OperationsCount;
                        m_ProceedingForm.Operation = m_Content.Operation;   

                        if (m_ProceedingForm.ProgressBar.Maximum != m_Content.ProgressMaxValue)
                            m_ProceedingForm.ProgressBar.Maximum = m_Content.ProgressMaxValue;

                        m_ProceedingForm.ProgressBar.Value = m_Content.ProgressValue;

                        if (m_ProceedingForm.DepthBar.Maximum != m_Content.MaxDepth)
                            m_ProceedingForm.DepthBar.Maximum = m_Content.MaxDepth;

                        m_ProceedingForm.DepthBar.Value = m_Content.CurrentDepth; 
                    }));  
        }
        //Запуск генерации кроссвордов
        private void GenerateCall()
        {
            if (MaxVariantsCountcheckBox.Checked)
                m_Content.Generate(m_Template.Grid, (int)MaxVariantsCountNumericUpDown.Value);
            else
                m_Content.Generate(m_Template.Grid);
        }
        //Обработка результатов процесса генерации
        private void AfterGenerate()
        {
            labelVariant.Text = string.Format("Найдено {0} вариантов", m_Content.Variants.Count);

            if (m_Content.Variants.Count > 0)
            {
                VariantsScrollBar.Minimum = 1;
                VariantsScrollBar.Maximum = m_Content.Variants.Count;
                VariantsScrollBar.Value = 1;
            }
            else
            {
                VariantsScrollBar.Minimum = 0;
                VariantsScrollBar.Maximum = 0;
                VariantsScrollBar.Value = 0;
            }

            VariantSelected(null, null); 
        }
        //Обработка выбора результата
        private void VariantSelected(object sender, EventArgs args)
        {
            if (VariantsScrollBar.Value == 0)
                return;

            labelVariant.Text = string.Format("{0} из {1} вариантов",VariantsScrollBar.Value, m_Content.Variants.Count);
            this.Template.DrawWords(m_Content.Variants[VariantsScrollBar.Value - 1]);  
        }

        private void MaxVariantsCountcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MaxVariantsCountNumericUpDown.Enabled = MaxVariantsCountcheckBox.Checked; 
        }
    }
    //Класс "Список свойств"
    public class ContentProperties
    {
        private ListView m_Properties;
        public ContentProperties(ListView properties) { m_Properties = properties; }
        
        public void Clear() { m_Properties.Items.Clear(); }
        public void Add(string property, string value)
        {
            ListViewItem _item = m_Properties.Items.Add("");
            _item.SubItems.Add(property);
            _item.SubItems.Add(value);
        }
    }
}
