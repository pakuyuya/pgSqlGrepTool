using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// @see https://smdn.jp/programming/tips/activate_window_by_hotkey/
// お借りします

namespace pkSqlGrepTool.appcore
{
    public class HotKey
    {
        [DllImport("user32", SetLastError = true)]
        private static extern int RegisterHotKey(IntPtr hWnd,
                                                 int id,
                                                 int fsModifier,
                                                 int vk);

        [DllImport("user32", SetLastError = true)]
        private static extern int UnregisterHotKey(IntPtr hWnd,
                                                   int id);

        public HotKey(IntPtr hWnd, int id, Keys key)
        {
            this.hWnd = hWnd;
            this.id = id;

            // Keys列挙体の値をWin32仮想キーコードと修飾キーに分離
            int keycode = (int)(key & Keys.KeyCode);
            int modifiers = (int)(key & Keys.Modifiers) >> 16;

            this.lParam = new IntPtr(modifiers | keycode << 16);

            if (RegisterHotKey(hWnd, id, modifiers, keycode) == 0)
                // ホットキーの登録に失敗
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public void Unregister()
        {
            if (hWnd == IntPtr.Zero)
                return;

            if (UnregisterHotKey(hWnd, id) == 0)
                // ホットキーの解除に失敗
                throw new Win32Exception(Marshal.GetLastWin32Error());

            hWnd = IntPtr.Zero;
        }

        public IntPtr LParam
        {
            get { return lParam; }
        }

        private IntPtr hWnd; // ホットキーの入力メッセージを受信するウィンドウのhWnd
        private readonly int id; // ホットキーのID(0x0000〜0xBFFF)
        private readonly IntPtr lParam; // WndProcメソッドで押下されたホットキーを識別するためのlParam値
    }
}
