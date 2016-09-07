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
    //Форма, отображающая статус процесса генерации
    public partial class ProceedingForm : Form
    {
        //Текущее число вариантов заполнения
        private int m_VariantsCount;
        //Количество выполненных элементарных операций сравнения.
        private long m_OperationsCount;

        public ProceedingForm()
        {
            InitializeComponent();
        }
        public Button StopButton
        {
            get { return buttonStop; }
        }

        public int VariantsCount
        {
            get { return m_VariantsCount; }
            set { m_VariantsCount = value; labelVariantsCount.Text = string.Format("{0} готовых вариантов ", m_VariantsCount); }
        }

        public long OperationsCount
        {
            get { return m_OperationsCount; }
            set { m_OperationsCount = value; labelOperationsCount.Text = string.Format("{0} операций перебора ", m_OperationsCount); }
        }

        public string Operation
        {
            get { return labelOperation.Text; }
            set { labelOperation.Text = value; }
        }

        //Степень завершенности всего процесса генерации
        public ProgressBar ProgressBar
        {
            get { return ProgressValueBar; }
        }
        //Степень завершенности текущего варианта
        public ProgressBar DepthBar
        {
            get { return CurrentDepthBar; }
        }
    }
}
