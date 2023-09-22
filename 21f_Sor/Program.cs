using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21f_Sor
{
	internal class Program
	{

		class Sor{
			class Elem
			{
				public Elem elozo;
				public string tartalom;

				// Fejelem létrehozása
				public Elem() 
				{
					this.elozo = this;
					this.tartalom = "fejelem";
				}

				/// <summary>
				/// Beszúrjuk az adott elem elé az új tartalmú Elemet
				/// </summary>
				public Elem(Elem ez, string t)
				{
					this.tartalom = t;
					this.elozo = ez.elozo;
					ez.elozo = this;
				}

				public void Kiveszi_az_elozot() 
				{
					this.elozo = this.elozo.elozo;
				}
			}
			Elem fejelem;
			public int Count;
			Elem elso_elem;

			public Sor()
			{
				this.fejelem = new Elem();
				this.Count = 0;
				elso_elem = fejelem;
			}

			public void Enqueue(string tartalom)
			{
				Elem uj_elem = new Elem(elso_elem, tartalom);
				elso_elem = uj_elem;
				Count++;
			}

			public string Dequeue()
			{
				if (Empty())
				{
					throw new Exception("üres a sor!");
				}
				string result = fejelem.elozo.tartalom;
				fejelem.Kiveszi_az_elozot();
				Count--;
				return result;
			}
			public string Peek()
			{
				if (Empty())
				{
					throw new Exception("üres a sor!");
				}
				return fejelem.elozo.tartalom;
			}

			public bool Empty()
			{
				return fejelem.elozo == fejelem;
				return elso_elem == fejelem;
				return Count == 0;
			}
		}

		static void Main(string[] args)
		{
			Sor sor = new Sor();

            Console.WriteLine("almát berakjuk a sorba");
            sor.Enqueue("alma"); // belerakás -- "sorbaállít"?
			Console.WriteLine("körtét berakjuk a sorba");
			sor.Enqueue("körte");
			Console.WriteLine("répát berakjuk a sorba");
			sor.Enqueue("répa");
			Console.WriteLine("krumplikáspaprit berakjuk a sorba");
			sor.Enqueue("krumplikáspapri");

            Console.WriteLine("kiveszegetjük az elemeket a sorból");

            Console.WriteLine(sor.Dequeue()); // kivesszük a sorból
			Console.WriteLine(sor.Dequeue()); // kivesszük a sorból
			Console.WriteLine(sor.Dequeue()); // kivesszük a sorból
			Console.WriteLine(sor.Dequeue()); // kivesszük a sorból
			//Console.WriteLine(sor.Dequeue()); // kivesszük a sorból

			Console.WriteLine("most veremmel ugyanez:"); 

			Stack<string> verem = new Stack<string>();
			Console.WriteLine("almát berakjuk a verembe");
			verem.Push("alma"); // belerakás -- "sorbaállít"?
			Console.WriteLine("körtét berakjuk a verembe");
			verem.Push("körte");
			Console.WriteLine("répát berakjuk a verembe");
			verem.Push("répa");
			Console.WriteLine("krumplikáspaprit berakjuk a verembe");
			verem.Push("krumplikáspapri");
			Console.WriteLine("kiveszegetjük az elemeket a sorból");
			Console.WriteLine(verem.Pop());
			Console.WriteLine(verem.Pop());
			Console.WriteLine(verem.Pop());
			Console.WriteLine(verem.Pop());
//			Console.WriteLine(verem.Pop());

			Console.ReadKey();
		}
	}
}
