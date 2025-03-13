namespace Test1.Models
{
    public class ProduktSklad
    {
        private double cena;

        public string Nazev { get; set; } = "";
        public double Cena { get => cena; set => cena = Math.Abs(value); }
        public int MnozstviNaSklade { get; set; }
        public double DPH { get; set; }
        public double CenaSDPH => Cena * (DPH / 100 + 1);
        public double CenaSDPHNaSklade => CenaSDPH * MnozstviNaSklade;
        public double CelkovaCenaNaSklade => Cena * MnozstviNaSklade;

        public string RozsahCena()
        {
            if (Cena < 0)
            {
                return "Nelze mít cenu menší než 0 Kč.";
            }
            else
            {
                return $"{Cena} Kč";
            }
        }

        public string RozsahSkladu()
        {
            if (MnozstviNaSklade < 0 || MnozstviNaSklade > 1000)
            {
                return "Množství musí být v rozsahu od 0 do 1000 ks.";
            }
            else
            {
                return $"{MnozstviNaSklade} ks";
            }
        }
        public static string PorovnaniBezDPH(ProduktSklad produkt1, ProduktSklad produkt2)
        {
            if (produkt1.cena < produkt2.cena)
            {
                return $"{produkt1.Nazev} s celkovou cenou {produkt1.CelkovaCenaNaSklade} je menší než {produkt2.Nazev} s celkovou cenou {produkt2.CelkovaCenaNaSklade}.";
            }
            else if (produkt1.cena > produkt2.cena)
            {
                return $"{produkt1.Nazev} s celkovou cenou {produkt1.CelkovaCenaNaSklade} je větší než {produkt2.Nazev} s celkovou cenou {produkt2.CelkovaCenaNaSklade}.";
            }
            else
            {
                return $"{produkt1.Nazev} s celkovou cenou bez DPH {produkt1.CelkovaCenaNaSklade} je stejně velký jako {produkt2.Nazev} s celkovou cenou bez DPH {produkt2.CelkovaCenaNaSklade}.";
            }
        }
        public static string PorovnaniSDPH(ProduktSklad produkt1, ProduktSklad produkt2)
        {
            if (produkt1.cena < produkt2.cena)
            {
                return $"{produkt1.Nazev} s celkovou cenou {produkt1.CenaSDPHNaSklade} je menší než {produkt2.Nazev} s celkovou cenou {produkt2.CenaSDPHNaSklade}.";
            }
            else if (produkt1.cena > produkt2.cena)
            {
                return $"{produkt1.Nazev} s celkovou cenou {produkt1.CenaSDPHNaSklade} je větší než {produkt2.Nazev} s celkovou cenou {produkt2.CenaSDPHNaSklade}.";
            }
            else
            {
                return $"{produkt1.Nazev} s celkovou cenou bez DPH {produkt1.CenaSDPHNaSklade} je stejně velký jako {produkt2.Nazev} s celkovou cenou bez DPH {produkt2.CenaSDPHNaSklade}.";
            }
        }
        public static string Podil(ProduktSklad produkt1, ProduktSklad produkt2)
        {
            double podil = 0;
            if (produkt1.CenaSDPHNaSklade > produkt2.CenaSDPHNaSklade)
            {
                podil = produkt1.CenaSDPHNaSklade / produkt2.CenaSDPHNaSklade;
                return $"{produkt1.Nazev} je o {podil*100} % dražší než {produkt2.Nazev}.";
            }
            else if (produkt1.CenaSDPHNaSklade < produkt2.CenaSDPHNaSklade)
            {
                podil = produkt2.CenaSDPHNaSklade / produkt1.CenaSDPHNaSklade;
                return $"{produkt1.Nazev} je o {podil*100} % levnější než {produkt2.Nazev}.";
            }
            else
            {
                return $"{produkt1.Nazev} je stejně drahý jako {produkt2.Nazev}.";
            }
        }
    }
}
