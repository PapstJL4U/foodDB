using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Food=foodLib.foodLib;

namespace FoodGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Food.FileReader();
        }

        private void ButtonSuche_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSuche.Text))
            {   
                //raw input string
                string suche = $"{txtSuche.Text}";
                //seperate the input into individual terms
                string[] input = suche.Split(",");
                //does a food need all or only one ingredients?
                bool or = btOr.IsChecked==true;
                
                List<string> antwort = new List<string>();
                
                for(int i=0; i<input.Length; i++)
                {//no whitespace!
                    input[i] = input[i].TrimStart().TrimEnd();
                }

                if(input.Count()==1)
                {
                    antwort = Click_on_Single(input[0]);
                }
                else
                {
                    if(or)
                    {
                        antwort = Food.RezeptZutatOR(input);
                    }
                    else
                    {
                        antwort = Food.RezeptZutatAND(input);
                    }
                    
                }

                //AUSGABE ENDE
                Mausgabe(suche, antwort);
            }
            else
            {   
                string suche ="ZUFALL";
                var rez = foodLib.foodLib.RNGRezept();
                Ausgabe.Items.Add($"==Suche für: {suche}==");
                Ausgabe.Items.Add(rez);
            }
        }
        //Verarbeitet die Eingabe eine einzigen suchwortes
        private List<string> Click_on_Single(string ein_wort_suche)
        {
            List<string> rezept_name = Food.RezeptName(ein_wort_suche);
            List<string> rezept_zutat = Food.RezeptZutat(ein_wort_suche);
            var antwort = (rezept_zutat.Union(rezept_name)).ToList();

            return antwort;
        }

        private void Mausgabe(string eingabe, List<string> antwort)
        {
            Ausgabe.Items.Add($"==Suche für: {eingabe}==");
            foreach(string name in antwort)
            {   
                string zutaten = "";
                foreach(var v in Food.Rezepte()[name])
                {
                    zutaten = zutaten + " ";
                    zutaten = zutaten + v;
                }

                Ausgabe.Items.Add(name+": "+zutaten.Trim());
            }
        }

    }
}
