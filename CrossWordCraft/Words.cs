using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossWordCraft
{
    namespace Model
    {
        //Вспомогательный класс для сравнения слов по длине при их сортировке.
        public class WordComparer : IComparer<Word>
        {
            private int m_Direction;
            public WordComparer(int _Direction) { m_Direction = _Direction; }

            public int Compare(Word x, Word y)
            {
                if (m_Direction > 0)
                    return x.Length - y.Length;
                else
                    return y.Length - x.Length; 
            }
        }

        //Ориентация слова кроссворда
        public enum EWordDirection
        {
            wdHorizontal = 0,
            wdVertical = 1
        }

        //Класс "Слово кроссворда"
        //Класс совместно с классом "Коллекция слов кроссворда" используется процедурой автоматического заполнения шаблона кроссворда - генератором кроссворда
        //Представляет из себя массив символов с привязкой к сетке кроссворда.
        public class Word
        {
            //Ориентация
            public EWordDirection Direction { get; private set; }
            //Координаты
            public int X { get; private set; }
            public int Y { get; private set; }
            //Индекс
            public int Index { get; internal set; }
            //Признак, заполнено ли слово (используется генератором)
            public bool IsDefined { get; internal set; }
            //Скрытые конструкторы: базовый и конструктор копирования, используемый функцией Clone
            private Word(int x, int y, EWordDirection direction) { X = x; Y = y; Direction = direction; IsDefined = false; }
            private Word(int x, int y, EWordDirection direction, string value) : this(x, y, direction) { m_Length = value.Length; Value = value; }
            //Конструктор, используемый классом Grid при формировании списка слов кроссворда
            public Word(int x, int y, EWordDirection direction, int length) : this(x, y, direction) { m_Length = length; Null(); }
            //Копирование слова. Используется для копировании варианта кроссворда при удачном заполнении шаблона.
            public Word Copy() { return new Word(this.X, this.Y, this.Direction, this.Value); }
            //Обнуление слова с сохранение его длины
            public void Null() { Value = new string(' ', Length); }

            //Буфер слова
            private StringBuilder m_Builder;
            //Значение слова
            public string Value
            {
                get { return m_Builder.ToString(); }
                //Модификатор доступен только в рамках проекта
                internal set
                {
                    if (value.Length != Length)
                        throw new InvalidOperationException("Длина аргумента свойства 'Value' должна соответствовать значению свойства 'Length'");

                    if (m_Builder == null)
                        m_Builder = new StringBuilder(value);
                    else
                    {
                        m_Builder.Clear();
                        m_Builder.Append(value);
                    }
                }
            }
            //Значение символа слова
            public char this[int index]
            {
                get { return m_Builder[index]; }
                //Модификатор доступен только в рамках проекта
                internal set { m_Builder[index] = value; }
            }

            //Длина слова. Является постоянной величиной, определяемой в конструкторе.
            private readonly int m_Length;
            public int Length
            {
                get { return m_Length; }
            }

        }

        //Класс "Пересечение 2-х слов кроссворда"
        //Класс используется генератором. Все пересечения вычисляются в ходе выполнения метода Prepare класса "Коллекция слов кроссворда" 
        internal class WordIntersection
        {
            //Координаты пересечения
            internal int X { get; set; }
            internal int Y { get; set; }
            //Слово по горизонтали
            internal Word WordH { get; set; }
            //Слово по вертикали
            internal Word WordV { get; set; }
            //Функция возвращает второе - пересеченное слово
            internal Word CrossedBy(Word _word)
            {
                if (_word == WordH)
                    return WordV;
                else
                    if (_word == WordV)
                        return WordH;

                return null;
            }
            //Уникальный ключ пересечения. Используется для хранения пересечений в словаре.
            internal string Key { get { return GetKey(X, Y); } }
            //Статический метод вычисления ключа по координатам.
            internal static string GetKey(int x, int y) { return string.Format("{0},{1}", x, y); }
        }

        //Класс "Коллекция слов кроссворда"
        //Представляет собой коллекцию всех слов кроссворда, а также, вариант его заполнения.
        public class Words : List<Word>
        {
            //Все пересечения
            private Dictionary<string, WordIntersection> m_Intersections;
            //Слова по горизонтали
            private Words m_WordsH;
            //Слова по вертикали
            private Words m_WordsV;

            //Конструктор по умолчанию
            public Words() : base() { }

            //Доступ к коллекции слов по горизонтали
            public Words HorizontalWords { get { return m_WordsH; } }
            //Доступ к коллекции слов по вертикали
            public Words VerticalWords { get { return m_WordsV; } }

            //Выделение слов по горизонтали и вертикали в отдельные списки, вычисление пересечений слов.
            internal void Prepare()
            {
                m_Intersections = new Dictionary<string, WordIntersection>();
                m_WordsH = new Words();
                m_WordsV = new Words();

                foreach (Word _Word in this)
                    if (_Word.Direction == EWordDirection.wdHorizontal)
                        m_WordsH.Add(_Word);
                    else
                        m_WordsV.Add(_Word);

                foreach (Word _WordH in m_WordsH)
                    foreach (Word _WordV in m_WordsV)
                        if (_WordH.X <= _WordV.X && _WordH.X + _WordH.Length >= _WordV.X)
                            if (_WordV.Y <= _WordH.Y && _WordV.Y + _WordV.Length >= _WordH.Y)
                            {
                                WordIntersection _Intersection = new WordIntersection();
                                _Intersection.X = _WordV.X;
                                _Intersection.Y = _WordH.Y;
                                _Intersection.WordH = _WordH;
                                _Intersection.WordV = _WordV;
                                m_Intersections.Add(_Intersection.Key, _Intersection);
                            }
            }
            //Проверка, можно ли слову присвоить указанное значение 
            public bool CanAssign(Word _Word, ContentItem _value, ref int _FirstNonEqualIndex)
            {
                _FirstNonEqualIndex = -1;

                for (int i = 0; i < _Word.Length; i++)
                {
                    char _s = _Word[i];
                    if (_s != ' ' && _s != _value[i])
                    {
                        _FirstNonEqualIndex = i;
                        return false;
                    }
                }

                return true;
            }

            //Присвоение слову значения с возможным обновлением пересекаемых слов: в местах пересечений для пересекамых слов заполняются соответствующие
            //значению _value символы. Если пересекаемое слово уже заполнено (IsDefine == true), то ничего обновлять не нужно.
            public void AssignValue(Word _Word, string _value, bool _UpdateCrosses)
            {
                _Word.Value = _value;
                _Word.IsDefined = true;

                if (!_UpdateCrosses)
                    return;

                int x = _Word.X;
                int y = _Word.Y;

                int xp = 0;
                int yp = 0;

                if (_Word.Direction == EWordDirection.wdHorizontal)
                {
                    xp = 1;
                    yp = 0;
                }
                else
                {
                    xp = 0;
                    yp = 1;
                }

                for (int i = 0; i < _Word.Length; i++)
                {
                    string _Key = WordIntersection.GetKey(x, y);

                    if (m_Intersections.ContainsKey(_Key))
                    {
                        WordIntersection _Intersection = m_Intersections[_Key];
                        Word _CrossedWord = _Intersection.CrossedBy(_Word);

                        if (!_CrossedWord.IsDefined)
                            if (_CrossedWord.Direction == EWordDirection.wdHorizontal)
                                _CrossedWord[x - _CrossedWord.X] = _Word[i];
                            else
                                _CrossedWord[y - _CrossedWord.Y] = _Word[i];
                    }

                    x += xp;
                    y += yp;
                }
            }

            //Очистка значения слова с сохранением символов в местах пересечений. Значения символов определяются по соответствующим пересечениям.
            public void ClearValue(Word _Word, bool _UpdateCrosses)
            {
                _Word.Null();
                _Word.IsDefined = false;

                if (!_UpdateCrosses)
                    return;

                int x = _Word.X;
                int y = _Word.Y;

                int xp = 0;
                int yp = 0;

                if (_Word.Direction == EWordDirection.wdHorizontal)
                {
                    xp = 1;
                    yp = 0;
                }
                else
                {
                    xp = 0;
                    yp = 1;
                }

                for (int i = 0; i < _Word.Length; i++)
                {
                    string _Key = WordIntersection.GetKey(x, y);

                    if (m_Intersections.ContainsKey(_Key))
                    {
                        WordIntersection _Intersection = m_Intersections[_Key];
                        Word _CrossedWord = _Intersection.CrossedBy(_Word);

                        if (_CrossedWord.IsDefined)
                            if (_CrossedWord.Direction == EWordDirection.wdHorizontal)
                                _Word[i] = _CrossedWord[x - _CrossedWord.X];
                            else
                                _Word[i] = _CrossedWord[y - _CrossedWord.Y];
                    }

                    x += xp;
                    y += yp;
                }
            }

            //Получение индекса пересеченного слова по номеру символа
            internal int GetCrossedIndex(Word _Word, int _Index)
            {
                int x = _Word.X;
                int y = _Word.Y;

                int xp = 0;
                int yp = 0;

                if (_Word.Direction == EWordDirection.wdHorizontal)
                {
                    xp = 1;
                    yp = 0;
                }
                else
                {
                    xp = 0;
                    yp = 1;
                }

                x = x + xp * _Index;
                y = y + yp * _Index;

                string _Key = WordIntersection.GetKey(x, y);

                if (m_Intersections.ContainsKey(_Key))
                    return m_Intersections[_Key].CrossedBy(_Word).Index;

                return -1;
            }

            //Копирование коллекции слов.
            //Используется при добавлении текущего варианта в коллекцию результатов генерации кроссворда
            public Words Copy()
            {
                Words _Copy = new Words();
                foreach (Word _Word in this)
                    _Copy.Add(_Word.Copy());

                return _Copy;
            }
        }
    }
}
