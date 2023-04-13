using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		//Колонки таблицы
		private DataGridViewColumn dataGridViewColumn1 = null;
		private DataGridViewColumn dataGridViewColumn2 = null;
		private DataGridViewColumn dataGridViewColumn3 = null;
		private DataGridViewColumn dataGridViewColumn4 = null;
		private DataGridViewColumn dataGridViewColumn5 = null;
		private SortedDictionary<string, Car> car = new SortedDictionary<string, Car>();

		public Form1()
		{
			InitializeComponent();
			initDataGridView();
		}

		//Инициализация таблицы
		private void initDataGridView()
		{
			dataGridView1.DataSource = null;
			dataGridView1.Columns.Add(getDataGridViewColumn1());
			dataGridView1.Columns.Add(getDataGridViewColumn2());
			dataGridView1.Columns.Add(getDataGridViewColumn3());
			dataGridView1.Columns.Add(getDataGridViewColumn4());
			dataGridView1.Columns.Add(getDataGridViewColumn5());
			dataGridView1.AutoResizeColumns();
		}
		//Динамическое создание первой колонки в таблице
		private DataGridViewColumn getDataGridViewColumn1()
		{
			if (dataGridViewColumn1 == null)
			{
				dataGridViewColumn1 = new DataGridViewTextBoxColumn();
				dataGridViewColumn1.Name = "";
				dataGridViewColumn1.HeaderText = "Номер";
				dataGridViewColumn1.ValueType = typeof(string);
				dataGridViewColumn1.Width = dataGridView1.Width / 5;
			}
			return dataGridViewColumn1;
		}
		//Динамическое создание второй колонки в таблице
		private DataGridViewColumn getDataGridViewColumn2()
		{
			if (dataGridViewColumn2 == null)
			{
				dataGridViewColumn2 = new DataGridViewTextBoxColumn();
				dataGridViewColumn2.Name = "";
				dataGridViewColumn2.HeaderText = "Цвет";
				dataGridViewColumn2.ValueType = typeof(string);
				dataGridViewColumn2.Width = dataGridView1.Width / 5;
			}
			return dataGridViewColumn2;
		}
		//Динамическое создание третей колонки в таблице
		private DataGridViewColumn getDataGridViewColumn3()
		{
			if (dataGridViewColumn3 == null)
			{
				dataGridViewColumn3 = new DataGridViewTextBoxColumn();
				dataGridViewColumn3.Name = "";
				dataGridViewColumn3.HeaderText = "Марка";
				dataGridViewColumn3.ValueType = typeof(string);
				dataGridViewColumn3.Width = dataGridView1.Width / 5;
			}
			return dataGridViewColumn3;
		}
		//Динамическое создание четвертой колонки в таблице
		private DataGridViewColumn getDataGridViewColumn4()
		{
			if (dataGridViewColumn4 == null)
			{
				dataGridViewColumn4 = new DataGridViewTextBoxColumn();
				dataGridViewColumn4.Name = "";
				dataGridViewColumn4.HeaderText = "Стоимость";
				dataGridViewColumn4.ValueType = typeof(string);
				dataGridViewColumn4.Width = dataGridView1.Width / 5;
			}
			return dataGridViewColumn4;
		}
		//Динамическое создание пятой колонки в таблице
		private DataGridViewColumn getDataGridViewColumn5()
		{
			if (dataGridViewColumn5 == null)
			{
				dataGridViewColumn5 = new DataGridViewTextBoxColumn();
				dataGridViewColumn5.Name = "";
				dataGridViewColumn5.HeaderText = "Максимальная скорость";
				dataGridViewColumn5.ValueType = typeof(string);
				dataGridViewColumn5.Width = dataGridView1.Width / 5;
			}
			return dataGridViewColumn5;
		}

		//проверка номера
		private bool cheakNumber(string number)
		{
			bool cheak = false;
			if (number.Length != 6)
			{
				cheak = true;
			}
			else
			{
				if (Char.IsNumber(number[0]))
				{
					cheak = true;
				}
				if (Char.IsLetter(number[1])) cheak = true;
				if (Char.IsLetter(number[2])) cheak = true;
				if (Char.IsLetter(number[3])) cheak = true;
				if (Char.IsNumber(number[0]))
				{
					cheak = true;
				}
				if (Char.IsNumber(number[0]))
				{
					cheak = true;
				}
			}
            return cheak;
		}

		private bool cheakString(string text)
		{
			bool cheak = false;
			for(int i = 0; i < text.Length; i++)
			{
                if (Char.IsNumber(text[i]))
                {
                    cheak = true;
                }
            }
			return cheak;
		}

		//Добавление комьютера в колекцию
		private void addPC(string number, string color, string max_s, string price, string model)
		{
			Car pc = new Car(number, color, max_s, price, model);
			car.Add(pc.getNumber(), pc);

			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";
			showListInGrid();
		}
		//Удаление комьютера с колекции
		private void deleteStudent(string value)
		{
			car.Remove(value);
			showListInGrid();
		}
		//Отображение колекции в таблице
		private void showListInGrid()
		{
			dataGridView1.Rows.Clear();
			foreach (KeyValuePair<string, Car> kvp in car)
			{
				DataGridViewRow row = new DataGridViewRow();
				row.CreateCells(dataGridView1);

				row.Cells[0].Value = kvp.Value.getNumber();
				row.Cells[1].Value = kvp.Value.getColor();
				row.Cells[2].Value = kvp.Value.getMax_s();
				row.Cells[3].Value = kvp.Value.getPrice();
				row.Cells[4].Value = kvp.Value.getModel();

				dataGridView1.Rows.Add(row);
			}
		}

		int countCar = 0;
		private void button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
			{
				MessageBox.Show("Заполните все поля.", "Внимание!");
				return;
			}
			if (cheakNumber(textBox1.Text))
			{
                MessageBox.Show("Введен некоректный номер машины.", "Внимание!");
                return;
            }
			if (cheakString(textBox2.Text))
			{
                MessageBox.Show("В поле цвет нужно использовать только буквы", "Внимание!");
                return;
            }
			if (cheakString(textBox5.Text))
			{
                MessageBox.Show("В поле марка нужно использовать только буквы", "Внимание!");
                return;
            }
			if (car.ContainsKey(textBox1.Text)) 
			{
				MessageBox.Show("Такая машина уже существует.", "Внимание!");
				return;
			}
			if (!double.TryParse(textBox3.Text, out _) || !double.TryParse(textBox4.Text, out _))
			{
				MessageBox.Show("На полях 'Максимальная скорость' и 'Стоимость' нужно ввести число.", "Внимание!");
				return;
			}
			countCar++;
			addPC(textBox1.Text, textBox2.Text, textBox5.Text, textBox4.Text, textBox3.Text);
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
			if (selectedRow == 0 && countCar == 0) { return; }
			if (selectedRow == countCar) { return; }

			string value = dataGridView1.Rows[selectedRow].Cells[0].Value.ToString();

			DialogResult dr = MessageBox.Show("Удалить машину?", "Внимание!", MessageBoxButtons.YesNo);
			if (dr == DialogResult.Yes)
			{
				try { deleteStudent(value); }
				catch (Exception) { }
			}
			countCar--;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string models = string.Join(", ", car.Keys);
			MessageBox.Show(models, "Список всех машин.");
		}

		private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
		{
			dataGridViewColumn1.Width = dataGridView1.Width / 5;
			dataGridViewColumn2.Width = dataGridView1.Width / 5;
			dataGridViewColumn3.Width = dataGridView1.Width / 5;
			dataGridViewColumn4.Width = dataGridView1.Width / 5;
			dataGridViewColumn5.Width = dataGridView1.Width / 5;
		}
	}
}
