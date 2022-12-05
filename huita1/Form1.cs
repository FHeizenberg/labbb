namespace huita1
{
    public partial class Form1 : Form
    {
        static int n = 6;
        static int n1 = 4;
        private double[,] array = new double[n, n];
        private double[] Wi = new double[n];
        double[] resultWeight = new double[n];


        public double[] VheshVi = new double[n1];

        public double[] BenzhVi = new double[n1];

        public double[] DinamicVi = new double[n1];

        public double[] ComfortVi = new double[n1];

        public double[] PriceVi = new double[n1];

        public double[] NadezhVi = new double[n1];
        private double[] _summs;

        public Form1()
        {
            Program.f1 = this; // ������ f1 ����� ������� �� ����� Form1

            InitializeComponent();

            dataGridView1.Rows.Add("������ ������������ �����", 1, "8", "6", "7", "3", "2");
            dataGridView1.Rows.Add("������������ ������", "", 1, "0,2", "2", "0,25", "0,125");
            dataGridView1.Rows.Add("������������", "", "", 1, "4", "0,5", "0,2");
            dataGridView1.Rows.Add("������������ ������������ �����", "", "", "", 1, "0,33", "0,167");
            dataGridView1.Rows.Add("�������������� �������", "", "", "", "", 1, "0,25");
            dataGridView1.Rows.Add("������ �������� �����", "", "", "", "", "", 1);
            dataGridView1.Rows.Add("C����", "", "", "", "", "", "");
            dataGridView1.Rows.Add("������� ������������", "", "", "", "", "", "");
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void CalcButt_Click(object sender, EventArgs e)
        {
            string message = "��� ������ ��������, ��������� ��������� �����������";

            _summs = new double[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var value = dataGridView1.Rows[j].Cells[i + 1].Value.ObjectToDouble();
                    value = value.Replace('.', ',');
                    _summs[i] += Convert.ToDouble(value);
                }

                dataGridView1.Rows[n].Cells[i + 1].Value = _summs[i];
            }

            for (int i = 0; i < n; i++)
            {
                var d = array[i, n - 1];
                var summ = _summs[n - 1];
                Wi[i] = d / summ;
                dataGridView1.Rows[n + 1].Cells[i + 1].Value = Math.Round(Wi[i], 3);
            }
            //MessageBox.Show(message);
        }

        private void TableCompl_Click(object sender, EventArgs e)
        {
            string message = "������� ���������";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0 + i; j < n; j++)
                {
                    var value = dataGridView1.Rows[i].Cells[j + 1].Value.ObjectToDouble();
                    value=value.Replace('.', ',');
                    var d = Convert.ToDouble(value);
                    array[i, j] = d;
                }
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var value = 1.0 / array[j, i];
                    dataGridView1.Rows[i].Cells[j + 1].Value = Math.Round(value, 3);
                    array[i, j] = Convert.ToDouble(value);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if ((checkBox1.Checked != true) || (checkBox2.Checked != true) || (checkBox3.Checked != true) ||
                (checkBox4.Checked != true) || (checkBox5.Checked != true) || (checkBox6.Checked != true))
            {
                string message = "��������� �� ��� ��������!!!";
            }
            else
            {
                Form8 results_form = new Form8(Wi, VheshVi, BenzhVi, DinamicVi,
                    ComfortVi, PriceVi, NadezhVi);
                results_form.Show(this);
            }
        }

        private void VneshVid_Click(object sender, EventArgs e)
        {
            Form2 vnesh_vid_form = new Form2(mass1: Wi);
            vnesh_vid_form.Show(this);
        }

        private void RashodBenza_Click(object sender, EventArgs e)
        {
            Form3 Rasxod_form = new Form3();
            Rasxod_form.Show(this);
        }

        private void Dinamica_Click(object sender, EventArgs e)
        {
            Form4 Dinamica_form = new Form4();
            Dinamica_form.Show(this);
        }

        private void Comfort_Click(object sender, EventArgs e)
        {
            {
                Form5 Comfort_form = new Form5();
                Comfort_form.Show(this);
            }
        }

        private void Price_Click(object sender, EventArgs e)
        {
            {
                Form6 Price_form = new Form6();
                Price_form.Show(this);
            }
        }

        private void Nadezh_Clicl(object sender, EventArgs e)
        {
            {
                Form7 Nadezh_form = new Form7();
                Nadezh_form.Show(this);
            }
        }
    }
}