using GB.OEF._05.CL.Container;
using GB.OEF._05.CL.Entiteit;
using System.Windows;
using System.Windows.Controls;

namespace GB.OEF._05.OPL
{
    public partial class MainWindow : Window
    {
        private DagboekContainer _dagboekContainer = new DagboekContainer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateLijst();
        }

        private void LBxDagboekItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnNieuw_Click(object sender, RoutedEventArgs e)
        {
            Dagboek dagboek = new Dagboek(0, DateTime.Today, 0, 0, 1);
            Formulier Frm = new Formulier();
            Frm.ZetVelden(dagboek);
            if (Frm.ShowDialog() == true)
            {
                dagboek = Frm.oDagboek;
                _dagboekContainer.Nieuw(dagboek);
                UpdateLijst();
            }
        }

        private void BtnBewerk_Click(object sender, RoutedEventArgs e)
        {
            if (LBxDagboekItems.SelectedIndex > -1)
            {
                DagboekItem dagboekItem = (DagboekItem)LBxDagboekItems.SelectedItem;
                Dagboek dagboek = _dagboekContainer.DagboekObject(dagboekItem.DbID);
                Formulier Frm = new Formulier();
                Frm.ZetVelden(dagboek);
                if (Frm.ShowDialog() == true)
                {
                    dagboek = Frm.oDagboek;
                    _dagboekContainer.Wijzig(dagboek);
                    UpdateLijst();
                }
            }

        }

        private void BtnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if (LBxDagboekItems.SelectedIndex > -1 && MessageBox.Show("Geselecteerde DagboekItem verwijderen?", "DagboekItem verwijderen ?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DagboekItem oDagboekItem = (DagboekItem)LBxDagboekItems.SelectedItem;
                int dagboekID = oDagboekItem.DbID;
                Dagboek oDagboek = _dagboekContainer.DagboekObject(dagboekID);
                _dagboekContainer.Verwijder(oDagboek);
                UpdateLijst();
            }
        }

        private void BtnAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateLijst()
        {
            LBxDagboekItems.ItemsSource = null;
            LBxDagboekItems.ItemsSource = _dagboekContainer.DagboekItemsLijst();
            LBxDagboekItems.SelectedIndex = -1;
            LblTotaal.Content = _dagboekContainer.Totaal().ToString();
        }
    }
}