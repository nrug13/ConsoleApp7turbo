using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CarSite
{
    class Car
    {
        public string Marka { get; set; }
        public string Model { get; set; }

        public int Id { get; set; }
        static int nextId;
        public int ModelId { get; set; }

        public int Year { get; set; }
        public int Price { get; set; }
        public string ban { get; set; }
        public string color { get; set; }
        public string yanacaq { get; set; }

        enum Ban
        {
            hibrid=1, sedan
        }

        enum Color
        {
            Ağ = 1, Qara = 2, Qırmızı = 3, Göy = 4
        }

        enum Yanacaq
        {
            Dizel=1, benzin
        }

        public Car()
        {
            ModelId = Interlocked.Increment(ref nextId);
        }

        public Car(string marka, string model, int year, int price, string ban, string color, string yanacaq) : this()
        {
            Marka = marka;
            Model = model;
            //ModelId = modelId;
            Year = year;
            Price = price;
            if (ban == "1")
                this.ban = Convert.ToString(Ban.hibrid);
            else if (ban == "2")
                this.ban = Convert.ToString(Ban.sedan);
           

            if (color =="1")
                this.color = Convert.ToString(Color.Ağ);
            else if (color == "2")
                this.color = Convert.ToString(Color.Qara);
            else if (color == "3")
                this.color = Convert.ToString(Color.Qırmızı);
            else if (color == "4")
                this.color = Convert.ToString(Color.Göy);
           

            if (yanacaq == "1")
                this.yanacaq = Convert.ToString(Yanacaq.Dizel);
          else  if (yanacaq == "2")
                this.yanacaq = Convert.ToString(Yanacaq.benzin);
          
        }

        public override string ToString()
        {
            return ModelId.ToString() + "\t"  + Marka.ToString() + "\t" + Model.ToString() +  "\t" + Year.ToString() + "\t" +
                Price.ToString() + "\t" + ban.ToString() + "\t" + color.ToString() + "\t"+ yanacaq.ToString();
        }
    }

}
