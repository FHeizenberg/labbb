namespace huita1
{
    public partial class Form4 : Form
    {
        public static int n = 4;
        private double[,] array = new double[n, n];
        public double[] Vi = new double[n];
        double[] result = new double[n];

        public Form4()
        {
            InitializeComponent();

            dataGridView1.Rows.Add("Студент 1", 1, "0,2", "3", "0,14");
            dataGridView1.Rows.Add("Студент 2", "", 1, "7", "0,33");
            dataGridView1.Rows.Add("Студент 3", "", "", 1, "0,11");
            dataGridView1.Rows.Add("Студент 4", "", "", "", 1);
            dataGridView1.Rows.Add("Cуммы", "", "", "", "");
            dataGridView1.Rows.Add("Весовые коэффициенты", "", "", "", "");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Таблица дополнена";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0 + i; j < n; j++)
                {
                    array[i, j] = Convert.ToDouble(dataGridView1.Rows[i].Cells[j + 1].Value.ObjectToDouble());
                }
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var value = 1.0 / array[j, i];
                    dataGridView1.Rows[i].Cells[j + 1].Value = Math.Round(value, 3);
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0 + i; j < n; j++)
                {
                    array[i, j] = Convert.ToDouble(dataGridView1.Rows[i].Cells[j + 1].Value.ObjectToDouble());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = "Данные записаны";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i] += Convert.ToDouble(dataGridView1.Rows[j].Cells[i + 1].Value.ObjectToDouble());
                }

                dataGridView1.Rows[n].Cells[i + 1].Value = result[i];
            }

            for (int i = 0; i < n; i++)
            {
                Vi[i] = array[i, n - 1] / result[n - 1];
                dataGridView1.Rows[n + 1].Cells[i + 1].Value = Math.Round(Vi[i], 3);
            }

            Program.f1.checkBox3.Checked = true;
            Program.f1.DinamicVi = Vi;
        }
    }
}