using System;
using System.Linq;
using System.Windows.Forms;

namespace Lotto_2024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                // Spielerzahlen aus den Textfeldern lesen
                int[] playerNumbers = new int[6]
                {
                    int.Parse(txtNumber1.Text),
                    int.Parse(txtNumber2.Text),
                    int.Parse(txtNumber3.Text),
                    int.Parse(txtNumber4.Text),
                    int.Parse(txtNumber5.Text),
                    int.Parse(txtNumber6.Text)
                };

                // Validierung: Zahlen zwischen 1 und 49 prüfen
                if (playerNumbers.Any(n => n < 1 || n > 49))
                {
                    MessageBox.Show("Alle Zahlen müssen zwischen 1 und 49 liegen!", "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validierung: Keine Duplikate zulassen
                if (playerNumbers.Distinct().Count() != 6)
                {
                    MessageBox.Show("Die Zahlen dürfen sich nicht wiederholen!", "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Zufallszahlen generieren (6 eindeutige Zahlen)
                Random random = new Random();
                int[] randomNumbers = Enumerable.Range(1, 49)
                                                .OrderBy(_ => random.Next())
                                                .Take(6)
                                                .OrderBy(n => n)
                                                .ToArray();

                // Zufallszahlen in den Textboxen anzeigen
                txtRandom1.Text = randomNumbers[0].ToString();
                txtRandom2.Text = randomNumbers[1].ToString();
                txtRandom3.Text = randomNumbers[2].ToString();
                txtRandom4.Text = randomNumbers[3].ToString();
                txtRandom5.Text = randomNumbers[4].ToString();
                txtRandom6.Text = randomNumbers[5].ToString();

                // Übereinstimmungen prüfen und anzeigen
                var matchingNumbers = playerNumbers.Intersect(randomNumbers).ToArray();
                lblResult.Text = matchingNumbers.Length > 0
                    ? $"Übereinstimmungen: {string.Join(", ", matchingNumbers)}"
                    : "Keine Übereinstimmungen.";
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte geben Sie in allen Feldern gültige Zahlen ein!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
