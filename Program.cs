﻿using System;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace WindowsFormsApp3 
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1()); // Form1'in çağrıldığı yer
		}
	}
}
