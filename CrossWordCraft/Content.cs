using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CrossWordCraft
{
    namespace Model
    {
        //Класс "Значение слова".
        public class ContentItem
        {
            //Признак, что значение уже использовано в текущем варианте заполнения кроссворда
            public bool Used { get; set; }
            //Конструкторы
            private ContentItem() { Used = false; }
            public ContentItem(string value) : this() { Value = value; }

            private string m_Value = string.Empty;
            //Значение
            public string Value 
            { 
                get {return m_Value; }
                set 
                { 
                    m_Value = value; 
                    
                    if (m_CharArray != null) 
                        m_CharArray = null; 
                } 
            }
            private char[] m_CharArray = null;
            //Массив символов
            public char[] Chars
            {
                get
                {
                    if (m_CharArray == null)
                        m_CharArray = Value.ToCharArray();

                    return m_CharArray; 
                }
            }
            //Символ
            public char this[int index]  { get { return this.Chars[index]; }}
        }

        //Класс "Исходные данные для генерации кроссворда"
        public class Content
        {
            //Словарь с разделами. Каждый раздел содержит слова одной длины
            Dictionary<int, List<ContentItem>> m_Content = null;
            public Dictionary<int, List<ContentItem>> Groups { get { return m_Content; } }

            //Коллекция вариантов заполнения кроссворда
            List<Words> m_Variants = null;
            public List<Words> Variants { get { return m_Variants; } }

            //Параметры управления и свойства статуса завершенности генерации
            private int m_MaxVariantsCount = 0;
            private bool m_ContinueGeneration = false;
            private long m_OperationsCount = 0;
            private int m_ProgressValue = 0;
            private int m_ProgressMaxValue = 0;
            private int m_CurrentDepth = 0;
            private int m_MaxDepth = 0;
            private Word m_CurrentWord;
            private ContentItem m_CurrentItem;
            

            public long OperationsCount { get { return m_OperationsCount; } }
            public int ProgressValue { get { return m_ProgressValue; } }
            public int ProgressMaxValue { get { return m_ProgressMaxValue; } }
            public int CurrentDepth { get { return m_CurrentDepth; } }
            public int MaxDepth { get { return m_MaxDepth; } }
            public string Operation 
            { 
                get 
                { 
                    if (m_CurrentWord == null || m_CurrentItem == null) 
                        return string.Empty; 

                    return string.Format("{0} ? {1}", m_CurrentWord.Value, m_CurrentItem.Value); 
                } 
            }

            //Конструктор
            public Content() { m_Content = new Dictionary<int, List<ContentItem>>(); m_Variants = new List<Words>(); }

            //Очистка
            public void Clear()
            {
                m_Content.Clear();
                m_Variants.Clear();
            }

            //Получение раздела словаря со значениями определенной длины
            public List<ContentItem> GetContent(int _length)
            {
                if (!m_Content.ContainsKey(_length))
                    return null;

                return m_Content[_length];
            }

            //Формирование словаря по текстовой строке
            public void Append(string _Text)
            {
                Regex _regex = new Regex("(?i)[а-я]{2,}"); //Минимальная длина слова - 2 символа
                MatchCollection _textMatches = _regex.Matches(_Text);

                foreach (Match _wordMatch in _textMatches)
                {
                    string _word = _wordMatch.Value.ToUpper();
                    List<ContentItem> _wordsl = null;

                    if (m_Content.ContainsKey(_word.Length))
                        _wordsl = m_Content[_word.Length];
                    else
                    {
                        _wordsl = new List<ContentItem>();
                        m_Content.Add(_word.Length, _wordsl);
                    }

                    bool _Exists = false;
                    IEnumerator<ContentItem> _items = _wordsl.GetEnumerator();
                    _items.Reset();
                    while (!_Exists && _items.MoveNext())
                    {
                        ContentItem _item = _items.Current;
                        if (_item.Value == _word)
                            _Exists = true;
                    }

                    if (!_Exists)
                        _wordsl.Add(new ContentItem(_word));
                }
            }

            //Остановка процесса генерации
            public void StopGeneration()
            {
                m_ContinueGeneration = false;
            }

            //Запуск процесса генерации по заданной сетке
            public void Generate(Grid _Grid)
            {
                this.Generate(_Grid, 0);  
            }

            public void Generate(Grid _Grid, int _MaxVariantsCount)
            {
                //Максимальное число вариантов; 0 - количество вариантов не ограничено
                m_MaxVariantsCount = _MaxVariantsCount;
 
                //Очистка коллекции вариантов
                m_Variants.Clear();

                //Формирование слок кроссворда по сетке
                Words _Words = _Grid.CreateWords();
                if (_Words.Count == 0)
                    return;

                //Установка для всех слов статуса 'не использовано'
                foreach (KeyValuePair<int, List<ContentItem>> _Group in m_Content)
                    foreach (ContentItem _Item in _Group.Value)
                        if (_Item.Used)
                            _Item.Used = false;

                //Запуск процесса генерации:
                m_ContinueGeneration = true;
                m_OperationsCount = 0;

                //Начинается генерации с преобладающего направления.
                if (_Words.HorizontalWords.Count < _Words.VerticalWords.Count)
                {
                    //Сортировка слов по горизонтали по убыванию
                    _Words.HorizontalWords.Sort(new WordComparer(-1));
                    //Сортировка слов по вертикали по возрастанию
                    _Words.VerticalWords.Sort(new WordComparer(1));
                    //Запуск генерации
                    GenerateFirstLine(_Words, _Words.VerticalWords.ToArray(), _Words.HorizontalWords.ToArray());
                }
                else
                {
                    //Сортировка слов по горизонтали по возрастанию
                    _Words.HorizontalWords.Sort(new WordComparer(1));
                    //Сортировка слов по вертикали по убыванию
                    _Words.VerticalWords.Sort(new WordComparer(-1));
                    //Запуск генерации
                    GenerateFirstLine(_Words, _Words.HorizontalWords.ToArray(), _Words.VerticalWords.ToArray());
                }
            }

            //Шаг 1. Расстановка слов в первом направлении
            private void GenerateFirstLine(Words _Words, Word[] _FirstLineWords, Word[] _SecondLineWords)
            {
                int _BackToIndex = -1;
                GenerateFirstLine(_Words, _FirstLineWords, _SecondLineWords, 0, ref _BackToIndex);
            }

            private void GenerateFirstLine(Words _Words, Word[] _FirstLineWords, Word[] _SecondLineWords, int _Index, ref int _BackToIndex)
            {
                if (!m_ContinueGeneration)
                    return;

                Word _Word = _FirstLineWords[_Index];
                _Word.Index = _Index;
  
                List<ContentItem> _Contents = this.GetContent(_Word.Length);

                if (_Contents == null)
                    return;

                if (_Index == 0)
                {
                    m_ProgressValue = 0;
                    m_ProgressMaxValue = _Contents.Count;
                }

                foreach (ContentItem _item in _Contents)
                {
                    m_OperationsCount++;
                    m_CurrentWord = _Word; m_CurrentItem = _item;  

                    if (_Index == 0)
                        m_ProgressValue++;

                    if (!_item.Used)
                    {
                        _Words.AssignValue(_Word, _item.Value, true);
                        _item.Used = true;

                        _BackToIndex = -1;

                        if (_Index == _FirstLineWords.Length - 1)
                            GenerateSecondLine(_Words, _SecondLineWords, 0, 0, ref _BackToIndex);
                        else
                            GenerateFirstLine(_Words, _FirstLineWords, _SecondLineWords, _Index + 1, ref _BackToIndex);

                        _Words.ClearValue(_Word, false);
                        _item.Used = false;

                        if (_BackToIndex != -1 && _BackToIndex < _Index)
                            return;
                        else
                            _BackToIndex = -1;
                    }
                }
            }

            //Шаг 2. Расстановка слов во втором направлении с учетом пересечений
            private void GenerateSecondLine(Words _Words, Word[] _SecondLineWords, int _Index, int _PrevWordLength, ref int _BackToFirstLineIndex)
            {
                if (!m_ContinueGeneration)
                    return;

                if (_SecondLineWords.Length == 0)
                {
                    if (m_MaxVariantsCount == 0 || m_Variants.Count < m_MaxVariantsCount)
                        m_Variants.Add(_Words.Copy());

                    if (m_Variants.Count == m_MaxVariantsCount)
                        StopGeneration(); 

                    return;
                }

                Word _Word = _SecondLineWords[_Index];
                List<ContentItem> _Contents = this.GetContent(_Word.Length);

                if (_Contents == null)
                    return;

                if (_Index == 0)
                {
                    m_CurrentDepth = 0;
                    m_MaxDepth = _SecondLineWords.Length;
                }

                m_CurrentDepth = _Index + 1;

                int _MaxFirstNonEqualIndex = -1;
                foreach (ContentItem _item in _Contents)
                {
                    m_OperationsCount++;
                    m_CurrentWord = _Word; m_CurrentItem = _item;

                    if (!_item.Used)
                    {
                        int _FirstNonEqualIndex = -1;
                        if (_Words.CanAssign(_Word, _item, ref _FirstNonEqualIndex))
                        {
                            _Words.AssignValue(_Word, _item.Value, false);
                            _item.Used = true;

                            _BackToFirstLineIndex = -1;

                            if (_Index == _SecondLineWords.Length - 1)
                            {
                                if (m_MaxVariantsCount == 0 || m_Variants.Count < m_MaxVariantsCount)
                                    m_Variants.Add(_Words.Copy());

                                if (m_Variants.Count == m_MaxVariantsCount)
                                    StopGeneration();
                            }
                            else
                                GenerateSecondLine(_Words, _SecondLineWords, _Index + 1, _Word.Length, ref _BackToFirstLineIndex);

                            _Words.ClearValue(_Word, true);
                            _item.Used = false;

                            if (_BackToFirstLineIndex != -1)
                                return;
                        }
                        else
                        {
                            if (_MaxFirstNonEqualIndex == -1 || _MaxFirstNonEqualIndex < _FirstNonEqualIndex)
                                _MaxFirstNonEqualIndex = _FirstNonEqualIndex; 
                        }
                    }
                }

                if (_MaxFirstNonEqualIndex != -1 && _PrevWordLength != _Word.Length)
                    _BackToFirstLineIndex = _Words.GetCrossedIndex(_Word, _MaxFirstNonEqualIndex);
            }
        }
    }
}
