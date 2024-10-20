using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
	public partial class Form1 : Form
	{
		MySqlConnection con = new MySqlConnection("Server=localhost;Database=form;User ID=root;Password=7H~:TD8muNk3Zin;");

		public Form1()
		{
			InitializeComponent();
			AddPlaceholderText();
			InitializeListView(); // ListView'i başlat
			ApplyCustomStyles();  // Özelleştirilmiş tasarımı uygula
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			LoadStudentData();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			// No control will be focused
			this.ActiveControl = null;
		}

		private void InitializeListView()
		{
			lstOgrenciListesi.View = View.Details;
			lstOgrenciListesi.Columns.Clear(); // Sütunları temizle
			lstOgrenciListesi.Columns.Add("ID", 0); // ID sütununun genişliğini sıfır yaparak gizliyoruz
			lstOgrenciListesi.Columns.Add("İsim", 184);
			lstOgrenciListesi.Columns.Add("Okul No", 184);
			lstOgrenciListesi.Columns.Add("Sınav Notu", 184);
			lstOgrenciListesi.Columns.Add("Bölüm", 184);

			lstOgrenciListesi.FullRowSelect = true;
			lstOgrenciListesi.GridLines = true;

			// Attach the event handler
			lstOgrenciListesi.SelectedIndexChanged += new System.EventHandler(this.lstOgrenciListesi_SelectedIndexChanged);
		}

		private void ApplyCustomStyles()
		{
			// Form renkleri
			this.BackColor = Color.FromArgb(243, 238, 245);  // Hafif pastel arka plan
			this.Font = new Font("Segoe UI", 10);

			// ListView başlıkları için stil
			lstOgrenciListesi.OwnerDraw = true; // Elle çizim moduna geçiyoruz
			lstOgrenciListesi.DrawColumnHeader += (sender, e) =>
			{
				// Başlık için rengi ve yazı stilini ayarlıyoruz
				e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds); // Başlık arka plan rengi
				e.Graphics.DrawString(e.Header.Text, this.Font, Brushes.Black, e.Bounds); // Yazı rengi
			};

			lstOgrenciListesi.DrawItem += (sender, e) => e.DrawDefault = true;  // Varsayılan liste öğesi stili

			// Buton tasarımları
			StyleButton(btnVerEkle, Color.FromArgb(60, 179, 113));  // Yeşilimsi renk
			StyleButton(btnVerSil, Color.FromArgb(255, 59, 59));    // Kırmızımsı renk
			StyleButton(btnVerGuncelle, Color.FromArgb(74, 127, 188));  // Mavimsi renk
		}

		private void StyleButton(Button button, Color backgroundColor)
		{
			button.BackColor = backgroundColor;
			button.FlatStyle = FlatStyle.Flat;
			button.FlatAppearance.BorderSize = 0;
			button.ForeColor = Color.White;
			button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
		}

		private void LoadStudentData()
		{
			try
			{
				if (con.State == System.Data.ConnectionState.Closed)
					con.Open();

				string query = "SELECT ID, Isim, Okul_no, Sinav_notu, Bolum FROM ogrenciler";
				MySqlCommand cmd = new MySqlCommand(query, con);
				MySqlDataReader reader = cmd.ExecuteReader();

				lstOgrenciListesi.Items.Clear(); // Mevcut öğeleri temizle

				while (reader.Read())
				{
					ListViewItem item = new ListViewItem(reader["ID"].ToString()); // ID'yi ilk sütuna ekle ama görünmeyecek
					item.SubItems.Add(reader["Isim"].ToString());
					item.SubItems.Add(reader["Okul_no"].ToString());
					item.SubItems.Add(reader["Sinav_notu"].ToString());
					item.SubItems.Add(reader["Bolum"].ToString());
					lstOgrenciListesi.Items.Add(item); // Öğeyi ListView'e ekle
				}

				reader.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Hata: " + ex.Message);
			}
			finally
			{
				if (con.State == System.Data.ConnectionState.Open)
					con.Close();
			}
		}

		private void AddPlaceholderText()
		{
			SetPlaceholderText(txtIsim, "İsim");
			SetPlaceholderText(txtOkulNo, "Okul No");
			SetPlaceholderText(txtSinavNotu, "Sınav Notu");
			SetPlaceholderText(txtBolum, "Bölüm");
		}

		private void SetPlaceholderText(TextBox textBox, string placeholder)
		{
			textBox.ForeColor = Color.Gray; // Yer tutucu rengi
			textBox.Text = placeholder;

			textBox.Enter += (s, e) =>
			{
				if (textBox.Text == placeholder)
				{
					textBox.Text = "";
					textBox.ForeColor = Color.Black; // Metin rengi
				}
			};

			textBox.Leave += (s, e) =>
			{
				if (string.IsNullOrWhiteSpace(textBox.Text))
				{
					textBox.Text = placeholder;
					textBox.ForeColor = Color.Gray; // Yer tutucu rengi
				}
			};
		}

		private void btnVerEkle_Click(object sender, EventArgs e)
		{
			try
			{
				if (con.State == System.Data.ConnectionState.Closed)
					con.Open();

				string query = "INSERT INTO ogrenciler (Isim, Okul_no, Sinav_notu, Bolum) VALUES (@isim, @okul_no, @sinav_notu, @bolum)";
				MySqlCommand cmd = new MySqlCommand(query, con);
				cmd.Parameters.AddWithValue("@isim", txtIsim.Text);
				cmd.Parameters.AddWithValue("@okul_no", txtOkulNo.Text);
				cmd.Parameters.AddWithValue("@sinav_notu", txtSinavNotu.Text);
				cmd.Parameters.AddWithValue("@bolum", txtBolum.Text);

				cmd.ExecuteNonQuery();
				MessageBox.Show("Veri Eklendi.");

				LoadStudentData(); // Veri eklendiğinde listeyi anında güncelle
			}
			catch (Exception ex)
			{
				MessageBox.Show("Hata: " + ex.Message);
			}
			finally
			{
				if (con.State == System.Data.ConnectionState.Open)
					con.Close();
			}
		}

		private void btnVerSil_Click(object sender, EventArgs e)
		{
			if (lstOgrenciListesi.SelectedItems.Count > 0)
			{
				ListViewItem selectedItem = lstOgrenciListesi.SelectedItems[0]; // İlk seçili öğeyi alıyoruz
				string id = selectedItem.SubItems[0].Text; // Seçilen öğenin ID'sini alıyoruz

				try
				{
					if (con.State == System.Data.ConnectionState.Closed)
						con.Open();

					string query = "DELETE FROM ogrenciler WHERE ID = @id";
					MySqlCommand cmd = new MySqlCommand(query, con);
					cmd.Parameters.AddWithValue("@id", id); // Seçilen ID'yi silme sorgusuna ekliyoruz

					cmd.ExecuteNonQuery();
					MessageBox.Show("Veri Silindi.");

					LoadStudentData(); // Veri silindikten sonra listeyi güncelle
				}
				catch (Exception ex)
				{
					MessageBox.Show("Hata: " + ex.Message);
				}
				finally
				{
					if (con.State == System.Data.ConnectionState.Open)
						con.Close();
				}
			}
			else
			{
				MessageBox.Show("Lütfen silmek için bir öğrenci seçin.");
			}
		}

		private void btnVerGuncelle_Click(object sender, EventArgs e)
		{
			if (lstOgrenciListesi.SelectedItems.Count > 0)
			{
				ListViewItem selectedItem = lstOgrenciListesi.SelectedItems[0]; // Seçilen öğeyi alıyoruz
				string id = selectedItem.SubItems[0].Text; // Seçilen öğrencinin ID'sini alıyoruz

				try
				{
					if (con.State == System.Data.ConnectionState.Closed)
						con.Open();

					// Güncellenmiş sorgu
					string query = "UPDATE ogrenciler SET Isim = @isim, Okul_no = @okul_no, Sinav_notu = @sinav_notu, Bolum = @bolum WHERE ID = @id";
					MySqlCommand cmd = new MySqlCommand(query, con);
					cmd.Parameters.AddWithValue("@id", id); // Güncellenecek kaydı belirlemek için ID'yi kullan
					cmd.Parameters.AddWithValue("@isim", txtIsim.Text); // İsim parametresi
					cmd.Parameters.AddWithValue("@okul_no", txtOkulNo.Text);
					cmd.Parameters.AddWithValue("@sinav_notu", txtSinavNotu.Text.Replace(',', '.'));
					cmd.Parameters.AddWithValue("@bolum", txtBolum.Text);

					int rowsAffected = cmd.ExecuteNonQuery();
					if (rowsAffected > 0) // Herhangi bir satır etkilenmişse
					{
						MessageBox.Show("Veri Güncellendi.");
						LoadStudentData(); // Değişiklikleri yansıtmak için listeyi güncelle
					}
					else
					{
						MessageBox.Show("Güncelleme işlemi başarısız oldu. Lütfen verilerinizi kontrol edin.");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Hata: " + ex.Message);
				}
				finally
				{
					if (con.State == System.Data.ConnectionState.Open)
						con.Close();
				}
			}
			else
			{
				MessageBox.Show("Lütfen güncellemek için bir öğrenci seçin.");
			}
		}




		private void lstOgrenciListesi_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstOgrenciListesi.SelectedItems.Count > 0)
			{
				ListViewItem selectedItem = lstOgrenciListesi.SelectedItems[0]; // Get the selected item
				txtIsim.Text = selectedItem.SubItems[1].Text; // Set the name
				txtOkulNo.Text = selectedItem.SubItems[2].Text; // Set the school number
				txtSinavNotu.Text = selectedItem.SubItems[3].Text; // Set the exam score
				txtBolum.Text = selectedItem.SubItems[4].Text; // Set the department
			}
		}
	}
}
