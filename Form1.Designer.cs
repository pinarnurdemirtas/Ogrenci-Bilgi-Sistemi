namespace WindowsFormsApp2
{
	partial class Form1
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox txtIsim;
		private System.Windows.Forms.TextBox txtOkulNo;
		private System.Windows.Forms.TextBox txtSinavNotu;
		private System.Windows.Forms.TextBox txtBolum;
		private System.Windows.Forms.TextBox txtArama; 
		private System.Windows.Forms.Button btnVerEkle;
		private System.Windows.Forms.Button btnVerSil;
		private System.Windows.Forms.Button btnVerGuncelle;
		private System.Windows.Forms.ListView lstOgrenciListesi;
		private System.Windows.Forms.ColumnHeader columnHeaderID;
		private System.Windows.Forms.ColumnHeader columnHeaderIsim;
		private System.Windows.Forms.ColumnHeader columnHeaderOkulNo;
		private System.Windows.Forms.ColumnHeader columnHeaderSinavNotu;
		private System.Windows.Forms.ColumnHeader columnHeaderBolum;
		private System.Windows.Forms.Label lblTitle; 

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
			this.txtIsim = new System.Windows.Forms.TextBox();
			this.txtOkulNo = new System.Windows.Forms.TextBox();
			this.txtSinavNotu = new System.Windows.Forms.TextBox();
			this.txtBolum = new System.Windows.Forms.TextBox();
			this.txtArama = new System.Windows.Forms.TextBox(); 
			this.btnVerEkle = new System.Windows.Forms.Button();
			this.btnVerSil = new System.Windows.Forms.Button();
			this.btnVerGuncelle = new System.Windows.Forms.Button();
			this.lstOgrenciListesi = new System.Windows.Forms.ListView();
			this.columnHeaderID = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderIsim = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderOkulNo = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderSinavNotu = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderBolum = new System.Windows.Forms.ColumnHeader();
			this.lblTitle = new System.Windows.Forms.Label(); 

			this.SuspendLayout();

			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.lblTitle.Location = new System.Drawing.Point(320, 10); 
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(260, 30); 
			this.lblTitle.TabIndex = 9;
			this.lblTitle.Text = "Öğrenci Bilgi Sistemi";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; 

			// 
			// txtIsim
			// 
			this.txtIsim.Location = new System.Drawing.Point(50, 65);
			this.txtIsim.Name = "txtIsim";
			this.txtIsim.Size = new System.Drawing.Size(200, 20);
			this.txtIsim.TabIndex = 0;

			// 
			// txtOkulNo
			// 
			this.txtOkulNo.Location = new System.Drawing.Point(50, 110);
			this.txtOkulNo.Name = "txtOkulNo";
			this.txtOkulNo.Size = new System.Drawing.Size(200, 20);
			this.txtOkulNo.TabIndex = 1;

			// 
			// txtSinavNotu
			// 
			this.txtSinavNotu.Location = new System.Drawing.Point(50, 155);
			this.txtSinavNotu.Name = "txtSinavNotu";
			this.txtSinavNotu.Size = new System.Drawing.Size(200, 20);
			this.txtSinavNotu.TabIndex = 2;

			// 
			// txtBolum
			// 
			this.txtBolum.Location = new System.Drawing.Point(50, 200);
			this.txtBolum.Name = "txtBolum";
			this.txtBolum.Size = new System.Drawing.Size(200, 20);
			this.txtBolum.TabIndex = 3;

			// 
			// txtArama
			// 
			this.txtArama.Location = new System.Drawing.Point(50, 250); 
			this.txtArama.Name = "txtArama";
			this.txtArama.Size = new System.Drawing.Size(200, 20);
			this.txtArama.TabIndex = 7;
			this.txtArama.TextChanged += new System.EventHandler(this.TxtArama_TextChanged);
			this.txtArama.BackColor = System.Drawing.Color.LightGray; 

			// 
			// btnVerEkle
			// 
			this.btnVerEkle.Location = new System.Drawing.Point(623, 65);
			this.btnVerEkle.Name = "btnVerEkle";
			this.btnVerEkle.Size = new System.Drawing.Size(160, 40);
			this.btnVerEkle.TabIndex = 4;
			this.btnVerEkle.Text = "Öğrenci Ekle";
			this.btnVerEkle.UseVisualStyleBackColor = true;
			this.btnVerEkle.Click += new System.EventHandler(this.btnVerEkle_Click);

			// 
			// btnVerSil
			// 
			this.btnVerSil.Location = new System.Drawing.Point(623, 125);
			this.btnVerSil.Name = "btnVerSil";
			this.btnVerSil.Size = new System.Drawing.Size(160, 40);
			this.btnVerSil.TabIndex = 5;
			this.btnVerSil.Text = "Öğrenci Sil";
			this.btnVerSil.UseVisualStyleBackColor = true;
			this.btnVerSil.Click += new System.EventHandler(this.btnVerSil_Click);

			// 
			// btnVerGuncelle
			// 
			this.btnVerGuncelle.Location = new System.Drawing.Point(623, 185);
			this.btnVerGuncelle.Name = "btnVerGuncelle";
			this.btnVerGuncelle.Size = new System.Drawing.Size(160, 40);
			this.btnVerGuncelle.TabIndex = 6;
			this.btnVerGuncelle.Text = "Öğrenci Güncelle";
			this.btnVerGuncelle.UseVisualStyleBackColor = true;
			this.btnVerGuncelle.Click += new System.EventHandler(this.btnVerGuncelle_Click);

			// 
			// lstOgrenciListesi
			// 
			this.lstOgrenciListesi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
				this.columnHeaderID,
				this.columnHeaderIsim,
				this.columnHeaderOkulNo,
				this.columnHeaderSinavNotu,
				this.columnHeaderBolum});
			this.lstOgrenciListesi.Location = new System.Drawing.Point(50, 300); 
			this.lstOgrenciListesi.Size = new System.Drawing.Size(740, 250);
			this.lstOgrenciListesi.TabIndex = 8;
			this.lstOgrenciListesi.View = System.Windows.Forms.View.Details; 
			this.lstOgrenciListesi.FullRowSelect = true; 
			this.lstOgrenciListesi.GridLines = true; 

			// 
			// columnHeaderID
			// 
			this.columnHeaderID.Text = "ID";
			this.columnHeaderID.Width = 50;

			// 
			// columnHeaderIsim
			// 
			this.columnHeaderIsim.Text = "İsim";
			this.columnHeaderIsim.Width = 150;

			// 
			// columnHeaderOkulNo
			// 
			this.columnHeaderOkulNo.Text = "Okul No";
			this.columnHeaderOkulNo.Width = 100;

			// 
			// columnHeaderSinavNotu
			// 
			this.columnHeaderSinavNotu.Text = "Sınav Notu";
			this.columnHeaderSinavNotu.Width = 100;

			// 
			// columnHeaderBolum
			// 
			this.columnHeaderBolum.Text = "Bölüm";
			this.columnHeaderBolum.Width = 150;

			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(850, 580);
			this.Controls.Add(this.lblTitle); 
			this.Controls.Add(this.txtIsim);
			this.Controls.Add(this.txtOkulNo);
			this.Controls.Add(this.txtSinavNotu);
			this.Controls.Add(this.txtBolum);
			this.Controls.Add(this.txtArama); 
			this.Controls.Add(this.btnVerEkle);
			this.Controls.Add(this.btnVerSil);
			this.Controls.Add(this.btnVerGuncelle);
			this.Controls.Add(this.lstOgrenciListesi); 
			this.Name = "Form1";
			this.Text = "Öğrenci Bilgi Formu";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
	}
}
