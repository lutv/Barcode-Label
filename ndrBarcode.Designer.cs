namespace ndr
{
    partial class ndrBarcode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ndrBarcode));
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.warna_filter = new System.Windows.Forms.ComboBox();
            this.warna = new System.Windows.Forms.Label();
            this.nama = new System.Windows.Forms.Label();
            this.nama_filter = new System.Windows.Forms.TextBox();
            this.barcode_filter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.count = new System.Windows.Forms.Label();
            this.Testlabel = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelConnection = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.jumlah_print = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.labelprinter = new System.Windows.Forms.Label();
            this.printer_sel = new System.Windows.Forms.ComboBox();
            this.clearFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jumlah_print)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView2, "dataGridView2");
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.TabStop = false;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_ColumnHeaderMouseClick);
            // 
            // warna_filter
            // 
            this.warna_filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.warna_filter.FormattingEnabled = true;
            resources.ApplyResources(this.warna_filter, "warna_filter");
            this.warna_filter.Name = "warna_filter";
            this.warna_filter.SelectionChangeCommitted += new System.EventHandler(this.warna_filter_SelectedIndexChanged);
            // 
            // warna
            // 
            resources.ApplyResources(this.warna, "warna");
            this.warna.Name = "warna";
            this.warna.UseMnemonic = false;
            // 
            // nama
            // 
            resources.ApplyResources(this.nama, "nama");
            this.nama.Name = "nama";
            // 
            // nama_filter
            // 
            resources.ApplyResources(this.nama_filter, "nama_filter");
            this.nama_filter.Name = "nama_filter";
            this.nama_filter.TextChanged += new System.EventHandler(this.nama_filter_TextChanged);
            // 
            // barcode_filter
            // 
            resources.ApplyResources(this.barcode_filter, "barcode_filter");
            this.barcode_filter.Name = "barcode_filter";
            this.barcode_filter.TextChanged += new System.EventHandler(this.barcode_filter_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // date
            // 
            resources.ApplyResources(this.date, "date");
            this.date.Name = "date";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // count
            // 
            resources.ApplyResources(this.count, "count");
            this.count.Name = "count";
            // 
            // Testlabel
            // 
            resources.ApplyResources(this.Testlabel, "Testlabel");
            this.Testlabel.Name = "Testlabel";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // labelConnection
            // 
            resources.ApplyResources(this.labelConnection, "labelConnection");
            this.labelConnection.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelConnection.Name = "labelConnection";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // jumlah_print
            // 
            resources.ApplyResources(this.jumlah_print, "jumlah_print");
            this.jumlah_print.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.jumlah_print.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.jumlah_print.Name = "jumlah_print";
            this.jumlah_print.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.jumlah_print.KeyDown += new System.Windows.Forms.KeyEventHandler(this.jumlah_print_KeyDown);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelprinter
            // 
            resources.ApplyResources(this.labelprinter, "labelprinter");
            this.labelprinter.Name = "labelprinter";
            // 
            // printer_sel
            // 
            this.printer_sel.FormattingEnabled = true;
            resources.ApplyResources(this.printer_sel, "printer_sel");
            this.printer_sel.Name = "printer_sel";
            this.printer_sel.SelectedValueChanged += new System.EventHandler(this.printer_sel_SelectedIndexChanged);
            // 
            // clearFilter
            // 
            this.clearFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.clearFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.clearFilter, "clearFilter");
            this.clearFilter.Name = "clearFilter";
            this.clearFilter.TabStop = false;
            this.clearFilter.UseVisualStyleBackColor = true;
            this.clearFilter.Click += new System.EventHandler(this.clearFilter_Click);
            // 
            // ndrBarcode
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.clearFilter);
            this.Controls.Add(this.printer_sel);
            this.Controls.Add(this.labelprinter);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.jumlah_print);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelConnection);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Testlabel);
            this.Controls.Add(this.count);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.barcode_filter);
            this.Controls.Add(this.nama_filter);
            this.Controls.Add(this.nama);
            this.Controls.Add(this.warna);
            this.Controls.Add(this.warna_filter);
            this.Controls.Add(this.dataGridView2);
            this.Name = "ndrBarcode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ndrBarcode_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jumlah_print)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox warna_filter;
        private System.Windows.Forms.Label warna;
        private System.Windows.Forms.Label nama;
        private System.Windows.Forms.TextBox nama_filter;
        private System.Windows.Forms.TextBox barcode_filter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label count;
        private System.Windows.Forms.Label Testlabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelConnection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown jumlah_print;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelprinter;
        private System.Windows.Forms.ComboBox printer_sel;
        private System.Windows.Forms.Button clearFilter;
    }
}

