using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossWordCraft
{
    static public class Environment
    {
        //Вывод сообщения об ошибке
        public static void ErrorMessage(Exception ex, string caption)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message, caption, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}
