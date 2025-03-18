using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Polymorphism_1___Bankrekening;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // Polymorfisme: behandel de zichtrekening en spaarrekening alsof het een abstracte Bankrekening is
    // Van Bankrekening kan geen constructor opgeroepen worden, want dat is een abstracte class.
    // Van Zichtrekening en Spaarrekening kan wel een constructor opgeroepen worden.
    private Bankrekening _zichtRekening;
    private Bankrekening _spaarRekening;

    public MainWindow()
    {
        InitializeComponent();

        // Zichtrekening initialiseren (Polymorfisme)
        _zichtRekening = new Zichtrekening(2000.0, "PXL Digital | Campus PXL Hasselt", "Elfde­Liniestraat 26, 3500 Hasselt");
        CurrentAccountDescriptionLabel.Content = $"{_zichtRekening.Name}, {_zichtRekening.Adress}";
        CurrentAccountBalanceValueLabel.Content = $"{_zichtRekening.CurrentBalance:c}";
        CurrentAccountInterestValueLabel.Content = $"{_zichtRekening.CalculateInterest():c}";

        // Spaarrekening initialiseren.
        _spaarRekening = new Spaarrekening(9500.0, _zichtRekening.Name, _zichtRekening.Adress);
        SavingsAccountDescriptionLabel.Content = $"{_spaarRekening.Name}, {_spaarRekening.Adress}";
        SavingsAccountBalanceValueLabel.Content = $"{_spaarRekening.CurrentBalance:c}";
        SavingsAccountInterestValueLabel.Content = $"{_spaarRekening.CalculateInterest():c}";

        //Uitbreiding generics
        Rekening<Bankrekening> rek = new Rekening<Bankrekening>();
        rek.Add(_zichtRekening);
        rek.Add(_spaarRekening);
        //string str = rek.ShowList();
    }

    private void balanceButton_Click(object sender, RoutedEventArgs e)
    {
        double amount;
        bool isNumber = double.TryParse(amountTextBox.Text, out amount);
        if (!isNumber)
        {
            MessageBox.Show("Geef een correct getal in!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            return;
        }

        if (amount < 0)
        {
            _spaarRekening.CreditBalance(Math.Abs(amount));
            try
            {
                _zichtRekening.CreditBalance(-amount);
            }
            catch (BankException ex)  // Foutmelding bij saldo < 0
            {
                MessageBox.Show(ex.Message, "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
        else
        {
            _spaarRekening.DebetBalance(amount);
            _zichtRekening.DebetBalance(amount);
        }

        CurrentAccountBalanceValueLabel.Content = $"{_zichtRekening.CurrentBalance:c}";
        SavingsAccountBalanceValueLabel.Content = $"{_spaarRekening.CurrentBalance:c}";
    }

    private void interestButton_Click(object sender, RoutedEventArgs e)
    {
        CurrentAccountInterestValueLabel.Content = $"{_zichtRekening.CalculateInterest():c}";
        SavingsAccountInterestValueLabel.Content = $"{_spaarRekening.CalculateInterest():c}";
    }

    private void closeButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}