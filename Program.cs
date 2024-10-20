using System;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace WindowsFormsApp3 // Burayı kontrol et, Form1'in bulunduğu namespace ile aynı olmalı
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1()); // Burada Form1'in doğru bir şekilde çağrıldığından emin ol
		}
	}
}
