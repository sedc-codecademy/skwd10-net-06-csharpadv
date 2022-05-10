using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adv11.WinApp
{
	public partial class Form1 : Form
	{
		private string Message = "No message yet";
		public Form1()
		{
			InitializeComponent();
		}
		public void SendMessage(string message)
		{
			ResultLbl.Text = "Message sent with sync!";
			Thread.Sleep(7000);
			Message = message;
		}
		public async Task SendMessageAsync(string message)
		{
			ResultLbl.Text = "Message sent with async!";
			await Task.Run(() => // for making sync with async add await here
			{
				Thread.Sleep(7000);
				Message = message;
			});
			Message = message;
		}
		private async void AsyncBtn_Click(object sender, EventArgs e)
		{
			await SendMessageAsync("Hello SEDC from Async");
		}

		private void SyncBtn_Click(object sender, EventArgs e)
		{
			SendMessage("Hello SEDC from sync");
		}

		private void CheckBtn_Click(object sender, EventArgs e)
		{
			MessageLbl.Text = Message;
		}
	}
}
