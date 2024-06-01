using GB.OEF._05.CL.Container;
using GB.OEF._05.CL.Entiteit;
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
using System.Windows.Shapes;

using GB.OEF._05.CL.Container;
using GB.OEF._05.CL.Entiteit;

namespace GB.OEF._05.OPL
{
    public partial class Formulier : Window
    {
        private ParamContainer _paramContainer = new ParamContainer();
        public Dagboek oDagboek;


        private int _dbID = 0;
        public Formulier()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CBxSnelheid.ItemsSource = null;
            CBxSnelheid.ItemsSource = _paramContainer.ParameterLijst();
        }

        public void ZetVelden(Dagboek dagboek)
        {
            oDagboek = dagboek;

            DPrDatum.SelectedDate = dagboek.Datum;
            TBxGewicht.Text = dagboek.Gewicht.ToString();
            TBxTijd.Text = dagboek.Tijd.ToString();
            CBxSnelheid.SelectedIndex = _paramContainer.ParameterIndex(dagboek.ParamID);
        }

        private void BtnBewaar_Click(object sender, RoutedEventArgs e)
        {
            oDagboek.Datum = DPrDatum.SelectedDate.Value;
            Parameter param = (Parameter)CBxSnelheid.SelectedItem;
            oDagboek.ParamID = param.ParamID;
            oDagboek.Gewicht = int.Parse(TBxGewicht.Text);
            oDagboek.Tijd = int.Parse(TBxTijd.Text);

            this.DialogResult = true;
        }

        private void BtnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
