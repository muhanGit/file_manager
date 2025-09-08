using System;
using System.Drawing;
using System.Windows.Forms;

namespace RemoteLoaderControl
{
    public static class MsgBox
    {
        public static Form MsgForm;

        public static void Show(string text)
        {
            MsgForm = new Form();
            MsgForm.Size = new Size(300, 150);
            MsgForm.StartPosition = FormStartPosition.CenterScreen;

            MsgForm.ShowIcon = false;
            MsgForm.MinimizeBox = false;
            MsgForm.MaximizeBox = false;

            Label lbl = new Label()
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            MsgForm.Controls.Add(lbl);

            MsgForm.Show();
        }

        public static void Close()
        {
            MsgForm?.Close();
        }
    }
}
