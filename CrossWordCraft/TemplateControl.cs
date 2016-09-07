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
    //Элемент управления шаблоном кроссворда
    public partial class TemplateControl : UserControl
    {
        //Признак "Обновление элемента"
        private bool m_Proceeding = false;
        //Файл шаблона
        private string m_Filename = string.Empty;
        public string Filename { get { return m_Filename; }}
        //Сетка
        private Grid m_Grid = null;
        public Grid Grid { get { return m_Grid; } }
        //Массив кнопок
        private Button[,] m_Buttons = null;
        //Признак, что нужно очистить текст кнопок после изменения статуса ячейки
        private bool m_ClearButtons = false;

        //Tag кнопки - ссылка на элемент сетки
        internal class TGridCell
        {
            internal int I { get; private set; }
            internal int J { get; private set; }
            internal TGridCell(int i, int j) { I = i; J = j; }
        };
        //Конструктор
        public TemplateControl()
        {
            InitializeComponent();
            //Создание нового шаблона
            New();
        }
        //Обновление пользовательского интерфейса
        internal void UpdateControl()
        {
            m_Proceeding = true;
            WidthNumericUpDown.Value = m_Grid.Width;
            HeightNumericUpDown.Value = m_Grid.Height;
            m_Proceeding = false;

            DrawTemplate();
        }
        private void DrawTemplate()
        {
            GridPanel.Controls.Clear();
            m_Buttons = new Button[m_Grid.Width, m_Grid.Height];

            int _x = 2;
            int _y = 2;

            for (int i = 0; i < m_Grid.Width; i++)
            {
                for (int j = 0; j < m_Grid.Height; j++)
                {
                    Button _CellButton = new Button();
                    _CellButton.Width = 24;
                    _CellButton.Height = 24;
                    _CellButton.Click += ButtonClicked;
                    _CellButton.Tag = new TGridCell(i, j);
                    _CellButton.Left = _x;
                    _CellButton.Top = _y;
                    _CellButton.FlatStyle = FlatStyle.Flat;
                    _CellButton.UseVisualStyleBackColor = false;
                    _CellButton.BackColor = (m_Grid[i, j]) ? Color.White : Color.Black;

                    GridPanel.Controls.Add(_CellButton);
                    m_Buttons[i, j] = _CellButton;

                    _y += 26;
                }
                _x += 26;
                _y = 2;
            }

            m_ClearButtons = false;
        }
        private void ClearButtons()
        {
            if (m_Buttons == null)
                return;

            for (int i = 0; i < m_Buttons.GetLength(0); i++)
                for (int j = 0; j < m_Buttons.GetLength(1); j++)
                    m_Buttons[i, j].Text = string.Empty;

            m_ClearButtons = false;
        }
        //Отображение варианта заполнения кроссворда
        public void DrawWords(Words _Words)
        {
            foreach (Word _Word in _Words)
            {
                int i = _Word.X;  
                int j = _Word.Y;  
                    
                int ii = 0;
                int jj = 0;

                if (_Word.Direction == EWordDirection.wdHorizontal)
                    ii = 1;
                else
                    jj = 1;

                for (int s = 0; s < _Word.Length; s++)
                    if (i < m_Buttons.GetLength(0) && j < m_Buttons.GetLength(1))
                    {
                        m_Buttons[i, j].Text = _Word[s].ToString();
                        i = i + ii;
                        j = j + jj;
                    }
            }

            m_ClearButtons = true;
        }

        //Создание нового шаблона
        public void New()
        {
            m_Filename = string.Empty;
            m_Grid = new Grid();
            UpdateControl();
        }
        //Сохранение шаблона
        public void Save()
        {
            if (m_Filename.Length == 0)
                SaveAs();
            else
                Save(m_Filename);
        }
        //Сохранение шаблона в новый файл
        public void SaveAs()
        {
            SaveFileDialog _dialog = new SaveFileDialog();
            _dialog.Filter = "CrossWordCraft files (*.csc)|*.csc";
            _dialog.ShowDialog();

            if (_dialog.FileName.Trim().Length == 0)
                return;

            Save(_dialog.FileName);
        }
        //Сохранение шаблона в указанный файл
        public void Save(string _Filename)
        {
            if (File.Exists(_Filename))
                File.Delete(_Filename);

            using (StreamWriter writer = File.CreateText(_Filename))
            {
                writer.WriteLine(m_Grid.Width);
                writer.WriteLine(m_Grid.Height);

                for (int i = 0; i < m_Grid.Height; i++)
                {
                    string _row = string.Empty;
 
                    for (int j = 0; j < m_Grid.Width; j++)
                        _row = _row + (m_Grid[j, i] ? "X" : " ");

                    writer.WriteLine(_row);  
                }
            }

            m_Filename = _Filename; 
        }
        //Открытие шаблона
        public void Open()
        {
            OpenFileDialog _dialog = new OpenFileDialog();
            _dialog.Filter = "CrossWordCraft files (*.csc)|*.csc";
            _dialog.ShowDialog();

            if (_dialog.FileName.Trim().Length == 0)
                return;

            Open(_dialog.FileName);
        }
        //Открытие шаблона из указанного файла
        public void Open(string _Filename)
        {
            using (StreamReader reader = File.OpenText(_Filename))
            {
                string valueWidth = reader.ReadLine();

                if (valueWidth == null)
                    return;

                string valueHeight = reader.ReadLine();

                if (valueHeight == null)
                    return;

                m_Grid = new Grid(System.Convert.ToInt32(valueWidth), System.Convert.ToInt32(valueHeight));

                string row = null;
                int i = 0;

                do
                {
                    row = reader.ReadLine();

                    if (row != null)
                    {
                        char[] _symbols = row.ToCharArray();
                        int _count = ((_symbols.Length < m_Grid.Width) ? _symbols.Length : m_Grid.Width);

                        for (int j = 0; j < _count; j++)
                            m_Grid[j, i] = _symbols[j] != ' ';

                        i++;
                    }
                } while (row != null);
            }

            m_Filename = _Filename; 
            UpdateControl();
        }
        //Обработка нажатия на кнопку-ячейку сетки
        private void ButtonClicked(object sender, EventArgs e)
        {
            Button _Button = (Button)sender;
            TGridCell _Cell = (TGridCell)_Button.Tag;
            m_Grid[_Cell.I, _Cell.J] = !m_Grid[_Cell.I, _Cell.J];
            _Button.BackColor = (m_Grid[_Cell.I, _Cell.J]) ? Color.White : Color.Black;

            if (m_ClearButtons)
                ClearButtons(); 
        }
        //Увеличение/уменьшение ширины
        private void WidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (m_Proceeding) return;

            m_Grid.Width = (int)WidthNumericUpDown.Value;
            DrawTemplate(); 
        }
        //Увеличение/уменьшение высоты
        private void HeightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (m_Proceeding) return;

            m_Grid.Height = (int)HeightNumericUpDown.Value;
            DrawTemplate(); 
        }
    }

    //Переопределение класса Panel для включения двойного буфера с целью избежать мигания при обновлении сетки.
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
            : base()
        {
            this.DoubleBuffered = true;
        }
    }

}
