using System.Text;

namespace CalculatorWinform
{
    public partial class Calculator : Form
    {
        private StringBuilder _commandHelper = new StringBuilder();
        private List<long> _numbers = new List<long>();
        public Calculator()
        {
            InitializeComponent();
        }
        private void EnableAllOperationButtons()
        {
            Minusbtn.Enabled = true;
            PlusBtn.Enabled = true;
            MultBtn.Enabled = true;
            DivBtn.Enabled = true;
            EqualBtn.Enabled = true;
        }

        private void DisableAllOperationButtons()
        {
            Minusbtn.Enabled = false;
            PlusBtn.Enabled = false;
            MultBtn.Enabled = false;
            DivBtn.Enabled = false;
            EqualBtn.Enabled = false;
        }

        private void AddDataToLabel(char data)
        {
            if (data == '+' || data == '-' || data == '/' || data == '*')
                label1.Text += " ";

            label1.Text += data;

            if (data == '+' || data == '-' || data == '/' || data == '*')
                label1.Text += " ";

        }
        private void RemoveZeroFromLabel()
        {
            if (label1.Text == "0")
                label1.Text = "";
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button0_Click(object sender, EventArgs e)
        {
            RemoveZeroFromLabel();
            EnableAllOperationButtons();
            AddDataToLabel('0');
        }


        private void button1_Click(object sender, EventArgs e)
        {
            RemoveZeroFromLabel();
            EnableAllOperationButtons();
            AddDataToLabel('1');
            button0.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveZeroFromLabel();
            EnableAllOperationButtons();
            AddDataToLabel('2');
            button0.Enabled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            RemoveZeroFromLabel();
            EnableAllOperationButtons();
            AddDataToLabel('3');
            button0.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemoveZeroFromLabel();
            EnableAllOperationButtons();
            AddDataToLabel('4');
            button0.Enabled = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            RemoveZeroFromLabel();
            EnableAllOperationButtons();
            AddDataToLabel('5');
            button0.Enabled = true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            RemoveZeroFromLabel();
            EnableAllOperationButtons();
            AddDataToLabel('6');
            button0.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RemoveZeroFromLabel();
            EnableAllOperationButtons();
            AddDataToLabel('7');
            button0.Enabled = true;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            RemoveZeroFromLabel();
            EnableAllOperationButtons();
            AddDataToLabel('8');
            button0.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RemoveZeroFromLabel();
            EnableAllOperationButtons();
            AddDataToLabel('9');
            button0.Enabled = true;

        }

        private void DivBtn_Click(object sender, EventArgs e)
        {
            button0.Enabled = false;
            AddDataToLabel('/');
            DisableAllOperationButtons();
        }

        private void MultBtn_Click(object sender, EventArgs e)
        {
            AddDataToLabel('*');
            DisableAllOperationButtons();
        }

        private void Minusbtn_Click(object sender, EventArgs e)
        {
            AddDataToLabel('-');
            DisableAllOperationButtons();
        }

        private void PlusBtn_Click(object sender, EventArgs e)
        {
            AddDataToLabel('+');
            DisableAllOperationButtons();
        }

        private void PickNumbers()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(label1.Text).Append(",");
            int i = 0;
            if (sb[0] == '-')
            {
                i = 1;
            }
            for (; i < sb.Length; i++)
            {
                if (sb[i] == '+' || sb[i] == '-' || sb[i] == '/' || sb[i] == '*')
                {
                    _commandHelper.Append(sb[i]);
                    sb[i] = ',';
                }
            }

            string temp = sb.ToString();
            foreach (string str in temp.Split(','))
            {
                if (long.TryParse(str, out long number))
                    _numbers.Add(number);
            }
        }

        private void EqualBtn_Click(object sender, EventArgs e)
        {
            button0.Enabled = false;
            PickNumbers();
            CalculatorHelper.DivMultCalculate(ref _numbers, ref _commandHelper);
            string result = CalculatorHelper.CalculateSameCommands(_numbers, _commandHelper);
            _numbers.Clear();
            _commandHelper.Clear();
            label1.Text = result;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (!(label1.Text.Length == 1 && label1.Text == "0"))
            {
                label1.Text = "0";
                DisableAllOperationButtons();
                button0.Enabled = false;
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length == 1)
                label1.Text = "0";
            else
            {
                if (label1.Text[label1.Text.Length - 1] == ' ')
                {
                    label1.Text = label1.Text.Substring(0, label1.Text.Length - 3);
                    label1.Enabled = true;
                    EnableAllOperationButtons();
                }
                else if (!(label1.Text.Length == 1 && label1.Text == "0"))
                {
                    label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);

                    if (label1.Text[label1.Text.Length - 1] == ' ')
                    {
                        label1.Enabled = false;
                        DisableAllOperationButtons();
                    }

                }
                if (label1.Text.Length == 0)
                    label1.Text = "0";
            }
        }
    }
}