namespace CSharpAdvanced_G3_L6_WinForms
{
    public partial class Form1 : Form
    {
        int counter = 0;

        public Form1()
        {
            InitializeComponent();
            clickCounterLabel.Text = "0";
            clickCounterButton.Click += ClickCounterButtonClicked;
            clickCounterButton.Click += ClickCounterReduce;
            toggleLabel.Text = "The checkbox is unchecked";

            myCheckBox.CheckedChanged += CheckboxChanged;

            textBoxInput.TextChanged += TextBoxInput_TextChanged;
        }

        private void TextBoxInput_TextChanged(object sender, EventArgs e)
        {
            textBoxLabel.Text = textBoxInput.Text;
        }

        private void CheckboxChanged(object sender, EventArgs e)
        {
            if (myCheckBox.Checked)
            {
                toggleLabel.Text = "The checkbox is checked";
            }
            else
            {
                toggleLabel.Text = "The checkbox is unchecked";
            }
        }

        private void ClickCounterReduce(object sender, EventArgs e)
        {
            clickCounterLabel.Text = (--counter).ToString();
        }

        private void ClickCounterButtonClicked(object sender, EventArgs e)
        {
            counter++;
            clickCounterLabel.Text = (++counter).ToString();
        }
    }
}