using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	class Car
	{
		private string number;
		private string color;
		private string max_s;
		private string price;
		private string model;


		public Car(string number, string color, string max_s, string price, string model)
		{
			this.number = number;
			this.color = color;
			this.max_s = max_s;
			this.price = price;
			this.model = model;
		}

		public string getNumber() { return this.number; }
		public string getColor() { return this.color; }
		public string getMax_s() { return this.max_s; }
		public string getPrice() { return this.price; }
		public string getModel() { return this.model; }


		public void setNumber(string number) { this.number = number; }
		public void setColor(string color) { this.color = color; }
		public void setMax_s(string max_s) { this.max_s = max_s; }
		public void setPrice(string price) { this.price = price; }
		public void setModel(string model) { this.model = model; }
	}
}
