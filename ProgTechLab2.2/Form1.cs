namespace ProgTechLab2._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            txtInputNumbers.Text = Properties.Settings.Default.inputNumbers.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputNumbers;

            try
            {
                inputNumbers = this.txtInputNumbers.Text;
            }
            catch
            {
                return;
            }

            Properties.Settings.Default.inputNumbers = inputNumbers;
            Properties.Settings.Default.Save();

            MessageBox.Show(Logic.Check(inputNumbers));
        }

        public class Logic
        {
            public static string Check(string inputNumbers)
            {
                char separators = ' ';
                string[] strArray = inputNumbers.Split(separators);
                int[] numbersArray = new int[strArray.Length];

                for (int i = 0; i < strArray.Length; i++)
                {
                    numbersArray[i] = Convert.ToInt32(strArray[i]);
                }
                string outMessage = "";
                bool IsPositive = true;
                if (numbersArray[0] < 0)
                {
                    IsPositive = false;
                }
                int changeCounter = 0;
                foreach (var checkEl in numbersArray)
                {
                    if ((IsPositive) && (checkEl < 0))
                    {
                        changeCounter++;
                        IsPositive = false;
                    }
                    else if ((!IsPositive) && (checkEl > 0))
                    {
                        changeCounter++;
                        IsPositive = true;
                    }
                }
                outMessage = $"Знак изменился {changeCounter} раз";
                return outMessage;
            }
        }
    }
}