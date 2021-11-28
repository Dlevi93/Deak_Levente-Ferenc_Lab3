using System;
using System.Windows;
using System.Windows.Input;

namespace Deak_Levente_Ferenc_Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DoughnutMachine myDoughnutMachine;
        private int mRaisedGlazed;
        private int mRaisedSugar;
        private int mFilledLemon;
        private int mFilledChocolate;
        private int mFilledVanilla;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine = new DoughnutMachine();
            myDoughnutMachine.DoughnutComplete += DoughnutCompleteHandler;
        }

        private void glazedToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedToolStripMenuItem.IsChecked = true;

            sugarToolStripMenuItem.IsChecked = vanillaToolStripMenuItem.IsChecked
                = lemonToolStripMenuItem.IsChecked = chocolateToolStripMenuItem.IsChecked = false;

            myDoughnutMachine.MakeDoughnuts(DoughnutType.Glazed);
        }

        private void sugarToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            sugarToolStripMenuItem.IsChecked = true;

            glazedToolStripMenuItem.IsChecked = vanillaToolStripMenuItem.IsChecked
                = lemonToolStripMenuItem.IsChecked = chocolateToolStripMenuItem.IsChecked = false;

            myDoughnutMachine.MakeDoughnuts(DoughnutType.Sugar);
        }

        private void lemonToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            lemonToolStripMenuItem.IsChecked = true;

            glazedToolStripMenuItem.IsChecked = sugarToolStripMenuItem.IsChecked
                = chocolateToolStripMenuItem.IsChecked = vanillaToolStripMenuItem.IsChecked = false;

            myDoughnutMachine.MakeDoughnuts(DoughnutType.Lemon);
        }

        private void chocolateToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            chocolateToolStripMenuItem.IsChecked = true;

            glazedToolStripMenuItem.IsChecked = sugarToolStripMenuItem.IsChecked
                = lemonToolStripMenuItem.IsChecked = vanillaToolStripMenuItem.IsChecked = false;

            myDoughnutMachine.MakeDoughnuts(DoughnutType.Chocolate);
        }

        private void vanillaToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            vanillaToolStripMenuItem.IsChecked = true;

            glazedToolStripMenuItem.IsChecked = sugarToolStripMenuItem.IsChecked
                = lemonToolStripMenuItem.IsChecked = chocolateToolStripMenuItem.IsChecked = false;

            myDoughnutMachine.MakeDoughnuts(DoughnutType.Vanilla);
        }

        private void exitToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void stopToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine.Enabled = false;
        }

        private void DoughnutCompleteHandler()
        {
            switch (myDoughnutMachine.Flavor)
            {
                case DoughnutType.Glazed:
                    mRaisedGlazed++;
                    txtGlazedRaised.Text = mRaisedGlazed.ToString();
                    break;

                case DoughnutType.Sugar:
                    mRaisedSugar++;
                    txtSugarRaised.Text = mRaisedSugar.ToString();
                    break;
                case DoughnutType.Lemon:
                    mFilledLemon++;
                    txtLemonFilled.Text = mFilledLemon.ToString();
                    break;
                case DoughnutType.Chocolate:
                    mFilledChocolate++;
                    txtChocolateFilled.Text = mFilledChocolate.ToString();
                    break;
                case DoughnutType.Vanilla:
                    mFilledVanilla++;
                    txtVanillaFilled.Text = mFilledVanilla.ToString();
                    break;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Numai cifre se pot introduce!", "Input Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
