using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfView.common
{
    public static class Dialog
    {
        public static Boolean OnConfirma(String title, String textButtonConfirm)
        {
            MessageBoxResult result = MessageBox.Show(title,
                textButtonConfirm,
                MessageBoxButton.OKCancel,
                MessageBoxImage.Information);
            return result.Equals(MessageBoxResult.OK);
        }

        public static void OnInforma(String textContent)
        {
            MessageBox.Show(textContent);
        }
    }
}
