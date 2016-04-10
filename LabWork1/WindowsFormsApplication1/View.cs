using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using System.IO;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private DataTable _datatable;

        public Form1()
        {
            InitializeComponent();
            CreateDatatable();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void CreateDatatable()
        {

            _datatable = new DataTable();
            var column0 = new DataColumn("Тип издания")
            {
                Caption = "Type",
                DataType = typeof(string),
                ReadOnly = true
            };
            var column2 = new DataColumn("Год публикации")
            {
                Caption = "YearPublishing",
                DataType = typeof(int),
                ReadOnly = true
            };

            var column4 = new DataColumn("Описание")
            {
                Caption = "Description",
                DataType = typeof(string),
                ReadOnly = true
            };

            _datatable.Columns.Add(column0);
            _datatable.Columns.Add(column2);
            _datatable.Columns.Add(column4);
            dataGridView1.DataSource = _datatable;

        }

        public class ListCatalog
        {
            public static List<ICatalogue> list = new List<ICatalogue>();
        }

        private void новыйФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Все не сохраннёные данные могут быть потеряны. Создать новый файл?", "New", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (result == DialogResult.Yes)
                {
                    _datatable.Rows.Clear();
                    ListCatalog.list.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить обьект?", "Удалить", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    dataGridView1.Rows.RemoveAt(cell.RowIndex);
                }
            }
        }

        private void открытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            serializer.Formatting = Newtonsoft.Json.Formatting.Indented;

            var OpenFileDialog = new OpenFileDialog();
            if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            var fileName = OpenFileDialog.FileName;

            using (StreamReader streamreader = new StreamReader(fileName))
            {
                using (Newtonsoft.Json.JsonReader jReader = new Newtonsoft.Json.JsonTextReader(streamreader))
                {
                    ListCatalog.list = serializer.Deserialize<List<ICatalogue>>(jReader);

                    for (int i = 0; i < ListCatalog.list.Count; i++)
                    {
                        var catalog = ListCatalog.list[i];
                        var row = _datatable.NewRow();
                        row[0] = catalog.Name;
                        row[1] = catalog.YearPublishing;
                        row[2] = catalog.GetDescription();
                        _datatable.Rows.Add(row);
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ModelView c = new ModelView();
            ICatalogue catalog = null;
            c.ShowDialog();
            if (c.DialogResult == DialogResult.OK)
            {
                catalog = c.Catalog;
                ListCatalog.list.Add(catalog);
                var row = _datatable.NewRow();
                row[0] = catalog.Name;
                row[1] = catalog.YearPublishing;
                row[2] = catalog.GetDescription();
                _datatable.Rows.Add(row);
                dataGridView1.Update();
            }
        }


        public ICatalogue Catalog { get; set; }
        private int _catalog;
        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            int style;
            for (int i = 0; i < 3; i++)
            {
                style = rnd.Next(0, 3);
                Model.ICatalogue catalogModel = null;
                switch (_catalog)
                {
                    case 0:
                        catalogModel = new Standard(Convert.ToString("ГОСТ 1759. 5 – 87"), Convert.ToString("Гайки. Механические свойства и методы"), Convert.ToString("Взамен ГОСТ 1759 – 70"), Convert.ToString("Введ. с 01.01.89 по 01.01.94"), Convert.ToString("Москва"),Convert.ToInt32("1998"), Convert.ToInt32("14"));
                        break;
                    case 1:
                        catalogModel = new ElectronicResource(Convert.ToString("Родников А.Р"), Convert.ToString("Логистика [Электронный ресурс]"), Convert.ToString("терминологический словарь"), Convert.ToString("А.Р. Родников"), Convert.ToString("Электронные данные"), Convert.ToString("Москва: ИНФРА - М"), Convert.ToInt32("2000"), Convert.ToString("1 эл. опт. диск  (CD- ROM)"));
                        break;
                    case 2:
                        catalogModel = new Dissertation(Convert.ToString("Александров А.А"),Convert.ToString("Анализ и оценка оперативной обстановки в республике, крае, области (правовые и организационные аспекты)"), Convert.ToString("автореф. дис. на соиск. учен. степ. канд. юрид. наук"), Convert.ToString("12.00.11"), Convert.ToString("Александров Александр Александрович"), Convert.ToString("Москва"), Convert.ToInt32("2004"), Convert.ToInt32("2004"));
                        break;

                }
                Catalog = catalogModel;
                DialogResult = DialogResult.OK;
                _catalog = (rnd.Next(0, 3));
                ICatalogue catalog = null;
                catalog = Catalog;
                ListCatalog.list.Add(catalog);
                var row = _datatable.NewRow();
                row[0] = catalog.Name;
                row[1] = catalog.YearPublishing;
                row[2] = catalog.GetDescription();
                _datatable.Rows.Add(row);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.TypeNameHandling = TypeNameHandling.Auto;
            serializer.Formatting = Formatting.Indented;

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Catalog | *.catalog";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            var fileName = saveFileDialog.FileName;

            using (StreamWriter streamwriter = new StreamWriter(fileName))
            {
                using (Newtonsoft.Json.JsonWriter jWriter = new Newtonsoft.Json.JsonTextWriter(streamwriter))
                {
                    serializer.Serialize(jWriter, ListCatalog.list);
                }
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Закрыть программу?", "Завершение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) Application.Exit();
        }
    }
}
