namespace Deprem_Listeleme
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listViewDepremler = new System.Windows.Forms.ListView();
            this.columnHeaderTarihSaat = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderYer = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderBuyukluk = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderEnlem = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderBoylam = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDerinlik = new System.Windows.Forms.ColumnHeader();
            this.btnListele = new System.Windows.Forms.Button();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewDepremler
            // 
            this.listViewDepremler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTarihSaat,
            this.columnHeaderYer,
            this.columnHeaderBuyukluk,
            this.columnHeaderEnlem,
            this.columnHeaderBoylam,
            this.columnHeaderDerinlik});
            this.listViewDepremler.Location = new System.Drawing.Point(12, 12);
            this.listViewDepremler.Name = "listViewDepremler";
            this.listViewDepremler.Size = new System.Drawing.Size(760, 350);
            this.listViewDepremler.TabIndex = 0;
            this.listViewDepremler.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderTarihSaat
            // 
            this.columnHeaderTarihSaat.Text = "Tarih ve Saat";
            this.columnHeaderTarihSaat.Width = 160;
            // 
            // columnHeaderYer
            // 
            this.columnHeaderYer.Text = "Yer";
            this.columnHeaderYer.Width = 200;
            // 
            // columnHeaderBuyukluk
            // 
            this.columnHeaderBuyukluk.Text = "Büyüklük";
            this.columnHeaderBuyukluk.Width = 100;
            // 
            // columnHeaderEnlem
            // 
            this.columnHeaderEnlem.Text = "Enlem";
            this.columnHeaderEnlem.Width = 100;
            // 
            // columnHeaderBoylam
            // 
            this.columnHeaderBoylam.Text = "Boylam";
            this.columnHeaderBoylam.Width = 100;
            // 
            // columnHeaderDerinlik
            // 
            this.columnHeaderDerinlik.Text = "Derinlik";
            this.columnHeaderDerinlik.Width = 100;
            // 
            // btnListele
            // 
            this.btnListele.Location = new System.Drawing.Point(12, 380);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(100, 30);
            this.btnListele.TabIndex = 1;
            this.btnListele.Text = "Listele";
            this.btnListele.UseVisualStyleBackColor = true;
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // txtAra
            // 
            this.txtAra.Location = new System.Drawing.Point(130, 385);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(200, 20);
            this.txtAra.TabIndex = 2;
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(340, 380);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(100, 30);
            this.btnAra.TabIndex = 3;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(784, 421);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.txtAra);
            this.Controls.Add(this.btnListele);
            this.Controls.Add(this.listViewDepremler);
            this.Name = "Form1";
            this.Text = "Deprem Listeleme Uygulaması";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ListView listViewDepremler;
        private System.Windows.Forms.Button btnListele;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.ColumnHeader columnHeaderTarihSaat;
        private System.Windows.Forms.ColumnHeader columnHeaderYer;
        private System.Windows.Forms.ColumnHeader columnHeaderBuyukluk;
        private System.Windows.Forms.ColumnHeader columnHeaderEnlem;
        private System.Windows.Forms.ColumnHeader columnHeaderBoylam;
        private System.Windows.Forms.ColumnHeader columnHeaderDerinlik;
    }
}
