using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adv06.WinApp
{
    // This class represents our form
	public partial class Form : System.Windows.Forms.Form
	{
        // This is a normal property counter
        public int Counter { get; set; }

        // This is the constructor for this class form where we set the counter to 0
        // And we Initialize the Component - Code that generates the UI and it's properties for us to see
        public Form()
        {
            Counter = 0;
            InitializeComponent();
        }

        // A method that changes the label under the button and increments the counter
        // This method also removes it self as a subscriber to the Click event and adds a different method
        // This method is connected to the click event in the InitializeComponent() method
        private void WhenButtonClicked(object sender, EventArgs e)
        {
            Counter += 1;
            lblResult.Text = $"I've been clicked {Counter} times!";

            if (Counter >= 10)
            {
                btnClickMe.Click -= WhenButtonClicked;
                btnClickMe.Click += WhenButtonClickedBy2;   
            }
        }

        // This method has the smae signature as the previous one
        // That is why we can replace the previous method with this one on the click event
        // This method changes the counter by 2 instead of by 1
        // When it gets to 30 it stops counting and disables the button
        private void WhenButtonClickedBy2(object sender, EventArgs e)
        {
            Counter += 2;
            lblResult.Text = $"I've been clicked {Counter} times!";

            if (Counter >= 30)
            {
                btnClickMe.Enabled = false;
            }
        }

		private void Form_Load(object sender, EventArgs e)
		{

		}
	}
}
