using AeroportShatohin.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AeroportShatohin
{
    public partial class Aero : Form
    {
        public DbContextOptions<ApplicationContext> options;
        public Aero()
        {
            InitializeComponent();
            DTG.AutoGenerateColumns = false;
            options = DataBaseHellper.Option();
            DTG.DataSource = ReadDb(options);
            CalculateStats();

        }
        #region CrReUpRe
        private static void CreateDB(InfoAirFlightes Info)
        {
            using (ApplicationContext db = new ApplicationContext(DataBaseHellper.Option()))
            {
                Flight getsid = new Flight();
                Info.Flight.Id = getsid.Id;
                Info.Flight.Result = (Info.Flight.ColPas * Info.Flight.Pass + Info.Flight.ColBuil * Info.Flight.Build) * ((100.0m + Info.Flight.Percent) / 100.0m);
                db.ADB.Add(Info.Flight);
                db.SaveChanges();
            }
        }
        private List<Flight> ReadDb(DbContextOptions<ApplicationContext> options)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                return db.ADB.
                    OrderByDescending(x => x.Id)
                    .ToList();
            }
        }
        private static void UpDateDb(Flight aiFlDb)
        {
            using (ApplicationContext db = new ApplicationContext(DataBaseHellper.Option()))
            {
                var AiFlDb = db.ADB.FirstOrDefault(u => u.Id == aiFlDb.Id);
                if (AiFlDb != null)
                {
                    AiFlDb.Id = aiFlDb.Id;
                    AiFlDb.Numfl = aiFlDb.Numfl;
                    AiFlDb.TypeAir = aiFlDb.TypeAir;
                    AiFlDb.TimeIn = aiFlDb.TimeIn;
                    AiFlDb.ColPas = aiFlDb.ColPas;
                    AiFlDb.ColBuil = aiFlDb.ColBuil;
                    AiFlDb.Pass = aiFlDb.Pass;
                    AiFlDb.Build = aiFlDb.Build;
                    AiFlDb.Percent = aiFlDb.Percent;
                    db.SaveChanges();
                }
            }
        }
        private static void RemoveDB(DbContextOptions<ApplicationContext> options, Flight tours)
        {
            using (var db = new ApplicationContext(options))
            {
                var rect = db.ADB.FirstOrDefault(u => u.Id == tours.Id);
                if (rect != null)
                {
                    db.ADB.Remove(rect);
                    db.SaveChanges();
                }

            }
        }
        public void repeat()
        {
            using (ApplicationContext db = new ApplicationContext(DataBaseHellper.Option()))
            {
                toolStripStatusLabel1.Text = "Колличество рейсов: " + Convert.ToString(db.ADB.ToList().Count());
                toolStripStatusLabel2.Text = "Количество пассажиров: " + Convert.ToString(db.ADB.ToList().Count());
                toolStripStatusLabel3.Text = "Количество экипажа: " + Convert.ToString(db.ADB.ToList().Count());
                toolStripStatusLabel3.Text = "Сумма всей выручки" + Convert.ToString(db.ADB.ToList().Sum(x => (x.ColPas * x.Pass + x.ColBuil * x.Build) * (100.0m + x.Percent) / 100.0m));
            }
        }

        #endregion
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ChangeMenu.Enabled = DeleteMenu.Enabled = Change.Enabled = Delete.Enabled = DTG.SelectedRows.Count > 0;
        }
        public void CalculateStats()
        {
            var count = ReadDb(options).Count;
            var Res = 0.0m;
            var Pass = 0.0m;
            var ColB = 0.0m;
            toolStripStatusLabel1.Text = $"Column flights: " + count;
            foreach (var plane in ReadDb(options))
            {
                Pass += plane.ColPas;
                ColB += plane.ColBuil;
                Res += (plane.ColPas * plane.Pass + plane.ColBuil * plane.Build) * ((100.0m + plane.Percent) / 100.0m);
            }
            toolStripStatusLabel2.Text = $"Total revenue: " + Res;
            toolStripStatusLabel3.Text = $"Quantity passanger: " + Pass;
            toolStripStatusLabel4.Text = $"Quantity crew:" + ColB;
        }

        private void dataGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DTG.Columns[e.ColumnIndex].Name == "Result")
            {
                var flight = (Flight)DTG.Rows[e.RowIndex].DataBoundItem;
            }
        }
        private void Add_Click(object sender, EventArgs e)
        {
            var infoForm = new InfoAirFlightes();
            infoForm.Text = "Edith Flights";
            if (infoForm.ShowDialog(this) == DialogResult.OK)
            {
                CreateDB(infoForm);
                CalculateStats();
                DTG.DataSource = ReadDb(options);
            }
        }

        private void Change_Click(object sender, EventArgs e)
        {
            var data = (Flight)DTG.Rows[DTG.SelectedRows[0].Index].DataBoundItem;
            var infoForm = new InfoAirFlightes(data);
            infoForm.Text = "Edith Flights";
            if (infoForm.ShowDialog(this) == DialogResult.OK)
            {
                data.Numfl = infoForm.Flight.Numfl;
                data.TypeAir = infoForm.Flight.TypeAir;
                data.ColPas = infoForm.Flight.ColPas;
                data.ColBuil = infoForm.Flight.ColBuil;
                data.Pass = infoForm.Flight.Pass;
                data.Build = infoForm.Flight.Build;
                data.Percent = infoForm.Flight.Percent;
                data.TimeIn = infoForm.Flight.TimeIn;
                data.Result = (data.ColPas * data.Pass + data.ColBuil * data.Build) * ((100.0m + data.Percent) / 100.0m);
                UpDateDb(data);
                CalculateStats();
                DTG.DataSource = ReadDb(options);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var data = (Flight)DTG.Rows[DTG.SelectedRows[0].Index].DataBoundItem;
            if (MessageBox.Show($"Do you really want to delete the flight number '{data.Numfl}'?",
                "Delete record",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                RemoveDB(options, data);
                CalculateStats();
                DTG.DataSource = ReadDb(options);
            }
        }
        #region menu
        private void AddMenu_Click_1(object sender, EventArgs e)
        {
            Add_Click(sender, e);
        }

        private void ChangeMenu_Click(object sender, EventArgs e)
        {
            Change_Click(sender, e);
        }

        private void DeleteMenu_Click(object sender, EventArgs e)
        {
            Delete_Click(sender, e);
        }

        private void AboutProgrammMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Press OK", "Airport",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
