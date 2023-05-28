using ShipsGame.Klasy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipsGame.Okna
{
    public partial class UstawienieStatkow : Form
    {
        int myszX;
        int myszY;

        bool poziom;
        // true - poziomo
        // false - pionowo

        int indexAktualnegoStatku;
        bool[] rozmieszczoneStatki = new bool[4];

        public UstawienieStatkow()
        {
            InitializeComponent();

            poziom = true;
            indexAktualnegoStatku = 2;

            lblNazwaGracza.Visible = false;
            btnDalej.Enabled = false;

            Gra.Uzytkownik = new Gracz();
            Gra.Komputer = new Gracz();
        }

        private void planszaGracza_MouseMove(object sender, MouseEventArgs e)
        {
            if (indexAktualnegoStatku < rozmieszczoneStatki.Length)
            {
                myszX = Koordynaty.PobierzKomorke(e.Location.X);
                myszY = Koordynaty.PobierzKomorke(e.Location.Y);

                planszaGracza.Refresh();

                // true - poziomo
                // false - pionowo
                if (poziom)
                {
                    for (int i = 0; i < Gra.RoziaryStatkow[indexAktualnegoStatku]; i++)
                    {
                        if (myszX + i <= Gracz.OSTATNI_INDEX_PLANSZY)
                            Rysowanie.RysujObramowanie(myszX + i, myszY, indexAktualnegoStatku, planszaGracza);
                        else
                            break;
                    }
                }
                else
                {
                    for (int i = 0; i < Gra.RoziaryStatkow[indexAktualnegoStatku]; i++)
                    {
                        if (myszY + i <= Gracz.OSTATNI_INDEX_PLANSZY)
                            Rysowanie.RysujObramowanie(myszX, myszY + i, indexAktualnegoStatku, planszaGracza);
                        else
                            break;
                    }
                }
            }
        }

        private void btnObrot_Click(object sender, EventArgs e)
        {
            // ! -> nie 
            // fałsz = nie prawda 
            // prawda = nie fałsz
            poziom = !poziom;
        }
    }
}
