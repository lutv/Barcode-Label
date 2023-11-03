using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seagull.BarTender.Print;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Linq.Expressions;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Reflection;
using System.Web;

namespace ndr
{
    public partial class ndrBarcode : Form
    {
        private static string filtered_nama = "";
        private static string filtered_barcode = "";
        private static string filtered_date = "";
        private static string filtered_varian = "";
        private static string sync_api = "";
        private static string pass_nama = "";
        private static string pass_barcode = "";
        private static string pass_harga = "";
        private static string pass_jml = "";
        private static string click_history = "";
        private static string printer;
        private const string appName = "Nadiraa Barcode Printing";
        private static bool head_click = false;
        private static string userName = Environment.UserName;
        private static string[] multi_print;
        #region Enumerations
        // Indexes into our image list for the label browser.
        enum ImageIndex { LoadingFormatImage = 0, FailureToLoadFormatImage = 1 };
        #endregion
        Queue<int> generationQueue;

        public ndrBarcode()
        {
            InitializeComponent();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            string data = "all";
            loadData(data);
            count.Text = string.Format("Row Count : " + dataGridView2.RowCount.ToString());
            dataGridView2.Columns["id"].Visible = false;
            dataGridView2.Columns["product_tmpl_id"].Visible = false;
            dataGridView2.Columns["create_date"].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView2.Columns["last_update"].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView2.Columns["nama"].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView2.Columns["barcode"].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView2.Columns["varian"].SortMode = DataGridViewColumnSortMode.Automatic;
            loadWarna();
            Timer myTimer = new Timer(20000);
            myTimer.Elapsed +=  api_loadAsync;
            myTimer.Enabled = true;
            ComplexCalculationAsync();

        }
        void do_sync(object sender, DoWorkEventArgs e)
        {

            labelConnection.Invoke((MethodInvoker)async delegate
            {
                labelConnection.Text = "Loading...";
            });
            sync_product();
            
        }
        void do_sync_completed(object sender, RunWorkerCompletedEventArgs e)
        {
            labelConnection.Invoke((MethodInvoker)async delegate
            {
                labelConnection.Text = sync_api.ToString();
            });
        }

        public async Task ComplexCalculationAsync()
        {
            // Create a task to run asynchronously
            await Task.Run(() =>
            {
                Printers printers = new Printers();
                printer_sel.Invoke((MethodInvoker)async delegate
                {
                    foreach (Printer printer in printers)
                    {
                        printer_sel.Items.Add(printer.PrinterName);
                    }

                    if (printers.Count > 0)
                    {
                        // Automatically select the default printer.
                        printer_sel.SelectedItem = printers.Default.PrinterName;
                    }
                });
            });
             labelprinter.Text = printer.ToString();
        }
        private void api_loadAsync(object sender, EventArgs e)
        {
            BackgroundWorker formatLoader = new BackgroundWorker();
            formatLoader.DoWork += new DoWorkEventHandler(do_sync);
            formatLoader.RunWorkerCompleted += new RunWorkerCompletedEventHandler(do_sync_completed);
            formatLoader.RunWorkerAsync();

        }
        public void loadData(string case_data)
        {
            if (case_data == "all"){
                AllData();
                count.Text = string.Format("Row Count : " + dataGridView2.RowCount.ToString());
                return;
            }
            if (case_data == "filtered")
            {
                filteredData();
                count.Text = string.Format("Row Count : " + dataGridView2.RowCount.ToString());
                return;
            }
        }
        void AllData()
        {
            var database = new Database();
            if (database.connect_db())
            {
                string query = "SELECT * FROM tb_produk";
                MySqlCommand mySqlCommand = new MySqlCommand(query);
                mySqlCommand.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dt;

                dataGridView2.DataSource = bindingSource;
                //dataGridView2.Columns["date"].SortMode = DataGridViewColumnSortMode.Automatic;

                database.close_db();
            }
            else
            {
                MessageBox.Show("Database error");
            }
        }
        void filteredData()
        {
            var database = new Database();
            if (database.connect_db())
            {
                string query = "SELECT * FROM tb_produk WHERE "+get_filtered_query()+"";
                MySqlCommand mySqlCommand = new MySqlCommand(query);
                mySqlCommand.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dt;

                dataGridView2.DataSource = bindingSource;
                //dataGridView2.Columns["date"].SortMode = DataGridViewColumnSortMode.Automatic;

                database.close_db();
            }
            else
            {
                MessageBox.Show("Database error");
            }
        }
        void loadWarna()
        {
            var database = new Database();
            if (database.connect_db())
            {
                string query = "SELECT * FROM tb_produk GROUP BY varian";
                MySqlCommand mySqlCommand = new MySqlCommand(query);
                mySqlCommand.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dt;

                warna_filter.DataSource= bindingSource;
                warna_filter.DisplayMember = "varian";
                warna_filter.ValueMember = "varian";
            }
            else
            {
                MessageBox.Show("Database error");
            }
        }
        string get_filtered_query()
        {
            string filtered_query = "";
            filtered_query = string.Format(filtered_nama.Trim() + " " + filtered_barcode.Trim() + " " + filtered_varian.Trim() + " " + filtered_date.Trim());
            int and2 = filtered_query.LastIndexOf("AND");
           if (and2 >=0)
            {
                string new_filter = filtered_query.Remove(and2, 3);
                filtered_query = new_filter.Trim();
                
            }
                return filtered_query;
        }
        private void nama_filter_TextChanged(object sender, EventArgs e)
        {
            filtered_nama= "nama LIKE '%"+string.Format(nama_filter.Text)+"%' AND";
            string data = "filtered";
           // Testlabel.Text = get_filtered_query().ToString();
            loadData(data);
        }

        private void barcode_filter_TextChanged(object sender, EventArgs e)
        {
            filtered_barcode = "barcode LIKE '%" + string.Format(barcode_filter.Text) + "%' AND";
            string data = "filtered";
           // Testlabel.Text = get_filtered_query().ToString();
            loadData(data);
        }

        private void warna_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtered_varian = " varian LIKE '%" + string.Format(warna_filter.SelectedValue.ToString()) + "%' AND";
            string data = "filtered";
           // Testlabel.Text = get_filtered_query().ToString();
            loadData(data);
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            filtered_date = " create_date LIKE '%" + string.Format(dateTimePicker1.Value.ToString("yyyy-MM-dd")) + "%' AND";
            string data = "filtered";
           // Testlabel.Text = get_filtered_query().ToString();
            loadData(data);
        }
        private void sync_product()
        {
            var sync_status = new Api();
            sync_api = sync_status.get_status();
        }
        void print_barcode()
        {
            var lb = $@"C:\Users\{userName}\Documents\BarTender\BarTender Documents\ndr.btw";
            using (Engine engine = new Engine(true))
            {
                bool success = true;
                lock (engine)
                {
                    LabelFormatDocument btformate = engine.Documents.Open(lb);
                        if (multi_print.Length != 1)
                        {
                            foreach (var item in multi_print)
                            {
                                btformate.SubStrings["nama"].Value = string.Format(dataGridView2.Rows[int.Parse(item)].Cells["nama"].Value.ToString() + " " + dataGridView2.Rows[int.Parse(item)].Cells["varian"].Value.ToString());
                                btformate.SubStrings["barcode"].Value = string.Format(dataGridView2.Rows[int.Parse(item)].Cells["barcode"].Value.ToString()); ;
                                btformate.SubStrings["price"].Value = string.Format(dataGridView2.Rows[int.Parse(item)].Cells["harga"].Value.ToString());
                                int copies = 1;
                                success = Int32.TryParse(jumlah_print.Text, out copies) && (copies >= 1);
                                if (!success)
                                    MessageBox.Show(this, "Identical Copies must be an integer greater than or equal to 1.");
                                else
                                {
                                    btformate.PrintSetup.IdenticalCopiesOfLabel = copies;
                                }
                                if (success)
                                {
                                    Cursor.Current = Cursors.WaitCursor;

                                    // Get the printer from the dropdown and assign it to the format.
                                    if (printer != null)
                                        btformate.PrintSetup.PrinterName = printer;

                                    Messages messages;
                                    int waitForCompletionTimeout = 10000; // 10 seconds
                                    Result result = btformate.Print(appName, waitForCompletionTimeout);
                                    string messageString = "\n\nMessages:";

                                    /*foreach (Seagull.BarTender.Print.Message message in messages)
                                    {
                                        messageString += "\n\n" + message.Text;
                                    }*/

                                    if (result == Result.Failure)
                                        MessageBox.Show(this, "Print Failed" + messageString, appName);
                                    /*else
                                        MessageBox.Show(this, "Label was successfully sent to printer." + messageString, appName);*/
                                }
                            }
                        }
                        else
                        {
                            btformate.SubStrings["nama"].Value = pass_nama;
                            btformate.SubStrings["barcode"].Value = pass_barcode;
                            btformate.SubStrings["price"].Value = pass_harga;
                            int copies = 1;
                            success = Int32.TryParse(jumlah_print.Text, out copies) && (copies >= 1);
                            if (!success)
                                MessageBox.Show(this, "Identical Copies must be an integer greater than or equal to 1.");
                            else
                            {
                                btformate.PrintSetup.IdenticalCopiesOfLabel = copies;
                            }
                            if (success)
                            {
                                Cursor.Current = Cursors.WaitCursor;

                                // Get the printer from the dropdown and assign it to the format.
                                if (printer != null)
                                    btformate.PrintSetup.PrinterName = printer;

                                Messages messages;
                                int waitForCompletionTimeout = 10000; // 10 seconds
                                Result result = btformate.Print(appName, waitForCompletionTimeout);
                                string messageString = "\n\nMessages:";

                                /*foreach (Seagull.BarTender.Print.Message message in messages)
                                {
                                    messageString += "\n\n" + message.Text;
                                }*/

                                if (result == Result.Failure)
                                    MessageBox.Show(this, "Print Failed" + messageString, appName);
                                /*else
                                    MessageBox.Show(this, "Label was successfully sent to printer." + messageString, appName);*/
                            }
                         }

                }
                engine.Stop();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            print_barcode();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string indexed = "";
                //Testlabel.Text = e.RowIndex.ToString();
                pass_nama = string.Format(dataGridView2.Rows[e.RowIndex].Cells["nama"].Value.ToString() + " " + dataGridView2.Rows[e.RowIndex].Cells["varian"].Value.ToString());
                pass_barcode = string.Format(dataGridView2.Rows[e.RowIndex].Cells["barcode"].Value.ToString());
                pass_harga = string.Format(dataGridView2.Rows[e.RowIndex].Cells["harga"].Value.ToString());
                if (dataGridView2.SelectedRows.Count > 1)
                {
                    for (int i = 0; i < dataGridView2.SelectedRows.Count; i++)
                    {
                        indexed = indexed + dataGridView2.SelectedRows[i].Index.ToString() + ",";
                    }
                    pass_multi_print(indexed.Trim());

                }
                else
                {
                    pass_multi_print(indexed.Trim());
                }
            }

        }
        private void pass_multi_print(string indexed)
        {
            int and2 = indexed.LastIndexOf(",");
            if (and2 >= 0)
            {
                string new_filter = indexed.Remove(and2);
                indexed = new_filter.Trim();

            }
            multi_print = indexed.Trim().Split(',');

        }

        private void ndrBarcode_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ComplexCalculationAsync().Dispose();
        }

        private void printer_sel_SelectedIndexChanged(object sender, EventArgs e)
        {
            printer = printer_sel.SelectedItem.ToString();
        }

        private void clearFilter_Click(object sender, EventArgs e)
        {
            string data = "all";
            loadData(data);
            nama_filter.Text = "";
            barcode_filter.Text = "";
            warna_filter.SelectedIndex = 0;
            warna_filter.SelectedValue = "";
            filtered_nama = "";
            filtered_barcode = "";
            filtered_varian = "";
            filtered_date = "";

        }
        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            head_click = true;
        }

        private void jumlah_print_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                print_barcode();
            }
        }
    }
}
