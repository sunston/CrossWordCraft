using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossWordCraft
{
    namespace Model
    {

        //Класс "Сетка кроссворда"
        //Класс используется для интерактивного создания и редактирования шаблона кроссворда, а также, для формировании слов кроссворда
        public class Grid
        {
            //Ширина и высота по-умолчанию
            private int m_Width = 16;
            private int m_Height = 16;
            //Сетка
            private bool[,] m_Grid;

            public Grid() { Resize(m_Width, m_Height); }
            public Grid(int _Width, int _Height) { Resize(_Width, _Height); }

            //Инициализация сетки
            private void Resize(int _Widht, int _Height)
            {
                if (m_Grid == null)
                {
                    m_Width = _Widht; m_Height = _Height;
                    m_Grid = new bool[m_Width, m_Height];
                    return;
                }

                //Копирование данных в новую сетку после изменения ее размера
                bool[,] _oldGrid = m_Grid;
                m_Grid = new bool[_Widht, _Height];

                int _copyWidth = (m_Width < _Widht) ? m_Width : _Widht;
                int _copyHeight = (m_Height < _Height) ? m_Height : _Height;

                for (int i = 0; i < _copyWidth; i++)
                    for (int j = 0; j < _copyHeight; j++)
                        m_Grid[i, j] = _oldGrid[i, j];

                m_Width = _Widht; m_Height = _Height;
            }

            //Ячейка сетки
            public bool this[int _x, int _y]
            {
                get { return m_Grid[_x, _y]; }
                set { m_Grid[_x, _y] = value; }
            }

            //Ширина
            public int Width
            {
                get { return m_Width; }
                set { Resize(value, this.Height); }
            }

            //Высота
            public int Height
            {
                get { return m_Height; }
                set { Resize(this.Width, value); }
            }

            //Формирование списка слов кроссворда по данным сетки кроссворда
            public Words CreateWords()
            {
                Words _words = new Words();

                //формирование слов по горизонтали
                for (int j = 0; j < this.Height; j++)
                {
                    int x = 0; //начало текущего слова
                    int l = 0; //длина текущего слова

                    for (int i = 0; i < this.Width; i++)
                        if (m_Grid[i, j])
                        {
                            if (l == 0)
                                x = i;

                            l++;
                        }
                        else
                        {
                            if (l > 1)
                                _words.Add(new Word(x, j, EWordDirection.wdHorizontal, l));

                            l = 0;
                        }

                    if (l > 1)
                        _words.Add(new Word(x, j, EWordDirection.wdHorizontal, l));
                }

                //формирование слов по вертикали
                for (int i = 0; i < Width; i++)
                {
                    int y = 0; //начало текущего слова
                    int l = 0; //длина текущего слова

                    for (int j = 0; j < Height; j++)
                        if (m_Grid[i, j])
                        {
                            if (l == 0)
                                y = j;

                            l++;
                        }
                        else
                        {
                            if (l > 1)
                                _words.Add(new Word(i, y, EWordDirection.wdVertical, l));

                            l = 0;
                        }

                    if (l > 1)
                        _words.Add(new Word(i, y, EWordDirection.wdVertical, l));
                }

                //Инициализация коллекции слов
                _words.Prepare();
                return _words;
            }
        }
    }
}
