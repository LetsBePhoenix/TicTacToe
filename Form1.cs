using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
// Eigene Klassen
namespace TTT
{
    public partial class Form1 : Form
    {
        public int Player1_Wins = 0;
        public int Player2_Wins = 0;
        public int Patt_Wins = 0;
        public string Player1_Value;
        public string Player2_Value;
        public int Player = 1;
        public int Zeile;
        public int Spalte;
        public static int[,] Field = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        public Random random = new Random();
        
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Player");
            comboBox1.Items.Add("Bot1");
            comboBox1.Items.Add("Bot2");
            comboBox1.Items.Add("Bot3");
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.Add("Player");
            comboBox2.Items.Add("Bot1");
            comboBox2.Items.Add("Bot2");
            comboBox2.Items.Add("Bot3");
            comboBox2.SelectedIndex = 3;
            Player1_Value = comboBox1.SelectedItem.ToString();
            Player2_Value = comboBox2.SelectedItem.ToString();
        }
        
        private void RenewField()
        {
            switch(Field[0,0])
            {
                case 1:
                    button2.Text = "X";
                    break;
                case 2:
                    button2.Text = "O";
                    break;
                default:
                    button2.Text = "";
                    break;
            }
            switch (Field[0, 1])
            {
                case 1:
                    button3.Text = "X";
                    break;
                case 2:
                    button3.Text = "O";
                    break;
                default:
                    button3.Text = "";
                    break;
            }
            switch (Field[0, 2])
            {
                case 1:
                    button4.Text = "X";
                    break;
                case 2:
                    button4.Text = "O";
                    break;
                default:
                    button4.Text = "";
                    break;
            }
            switch (Field[1, 0])
            {
                case 1:
                    button5.Text = "X";
                    break;
                case 2:
                    button5.Text = "O";
                    break;
                default:
                    button5.Text = "";
                    break;
            }
            switch (Field[1, 1])
            {
                case 1:
                    button6.Text = "X";
                    break;
                case 2:
                    button6.Text = "O";
                    break;
                default:
                    button6.Text = "";
                    break;
            }
            switch (Field[1, 2])
            {
                case 1:
                    button7.Text = "X";
                    break;
                case 2:
                    button7.Text = "O";
                    break;
                default:
                    button7.Text = "";
                    break;
            }
            switch (Field[2, 0])
            {
                case 1:
                    button8.Text = "X";
                    break;
                case 2:
                    button8.Text = "O";
                    break;
                default:
                    button8.Text = "";
                    break;
            }
            switch (Field[2, 1])
            {
                case 1:
                    button9.Text = "X";
                    break;
                case 2:
                    button9.Text = "O";
                    break;
                default:
                    button9.Text = "";
                    break;
            }
            switch (Field[2, 2])
            {
                case 1:
                    button10.Text = "X";
                    break;
                case 2:
                    button10.Text = "O";
                    break;
                default:
                    button10.Text = "";
                    break;
            }
            label5.Text = Convert.ToString(Player1_Wins);
            label6.Text = Convert.ToString(Player2_Wins);
            label8.Text = Convert.ToString(Patt_Wins);
        }
        
        // Bot0 = Player
        private void Bot0()
        {
            if (Field[Zeile, Spalte] == 0)
            {
                Field[Zeile, Spalte] = Player;
                Player = OtherPlayer();
            }
            else
            {
                
            }
        }
        
        private void Bot1()
        {
            Zeile = random.Next(0, 3);
            Spalte = random.Next(0, 3);
            if (Field[Zeile, Spalte] == 0)
            {
                Field[Zeile, Spalte] = Player;
                Player = OtherPlayer();
            }
            else
            {
                Play();
            }
        }
        
        private void Bot2()
        {
            int place;
            Zeile = random.Next(0, 3);
            Spalte = random.Next(0, 3);
            if (Field[Zeile, Spalte] == Player)
            {
                place = random.Next(0, 8);
                try
                {
                    switch (place)
                    {
                        case 0:
                            Zeile--;
                            Spalte--;
                            break;
                        case 1:
                            Spalte--;
                            break;
                        case 2:
                            Zeile--;
                            Spalte++;
                            break;
                        case 3:
                            Spalte--;
                            break;
                        case 4:
                            Spalte++;
                            break;
                        case 5:
                            Zeile++;
                            Spalte++;
                            break;
                        case 6:
                            Zeile++;
                            break;
                        case 7:
                            Zeile++;
                            Spalte--;
                            break;
                    }
                }
                catch (Exception)
                {
                    Play();
                }
            }
            else
            {
                Zeile = random.Next(0, 3);
                Spalte = random.Next(0, 3);
                if (Field[Zeile, Spalte] == 0)
                {
                    Field[Zeile, Spalte] = Player;
                    Player = OtherPlayer();
                }
                else
                {
                    Play();
                }
            }
        }
        
        private void Bot3()
        {
            int WinTest;
            Zeile = random.Next(0, 3);
            Spalte = random.Next(0, 3);
            // Prüfe auf möglichkeit zu gewinnen
            // Zeilen
            for (int a = 0; a <= 2; a++)
            {
                // Zeilen auf 0 Testen
                if (Field[a, 0] == 0)
                {
                    WinTest = Field[a, 1] * 10 + Field[a, 2];
                }
                else
                {
                    WinTest = Field[a, 0] * 100 + Field[a, 1] * 10 + Field[a, 2];
                }
                // Spalte0
                if (OtherPlayer() * 10 + OtherPlayer() == WinTest)
                {
                    Zeile = a;
                    Spalte = 0;
                }
                // Spalte1
                else if (OtherPlayer() * 100 + OtherPlayer() == WinTest)
                {
                    Zeile = a;
                    Spalte = 1;
                }
                // Spalte2
                else if (OtherPlayer() * 100 + OtherPlayer() * 10 + 0 == WinTest)
                {
                    Zeile = a;
                    Spalte = 2;
                }
            }
            // Spalten
            for (int a = 0; a <= 2; a++)
            {
                // Spalten auf 0 Testen
                if (Field[0, a] == 0)
                {
                    WinTest = Field[1, a] * 10 + Field[2, a];
                }
                else
                {
                    WinTest = Field[0, a] * 100 + Field[1, a] * 10 + Field[2, a];
                }
                // Spalte0
                if (OtherPlayer() * 10 + OtherPlayer() == WinTest)
                {
                    Zeile = 0;
                    Spalte = a;
                }
                // Spalte1
                else if (OtherPlayer() * 100 + OtherPlayer() == WinTest)
                {
                    Zeile = 1;
                    Spalte = a;
                }
                // Spalte2
                else if (OtherPlayer() * 100 + OtherPlayer() * 10 + 0 == WinTest)
                {
                    Zeile = 2;
                    Spalte = a;
                }
            }
            // Schrägen
            if (Field[0, 0] == 0)
            {
                WinTest = Field[1, 1] * 10 + Field[2, 2];
            }
            else
            {
                WinTest = Field[0, 0] * 100 + Field[1, 1] * 10 + Field[2, 2];
            }
            if (OtherPlayer() * 10 + OtherPlayer() == WinTest)
            {
                Zeile = 0;
                Spalte = 0;
            }
            else if (OtherPlayer() * 100 + OtherPlayer() == WinTest)
            {
                Zeile = 1;
                Spalte = 1;
            }
            else if (OtherPlayer() * 100 + OtherPlayer() * 10 == WinTest)
            {
                Zeile = 2;
                Spalte = 2;
            }
            if (Field[0, 2] == 0)
            {
                WinTest = Field[1, 1] * 10 + Field[2, 0];
            }
            else
            {
                WinTest = Field[0, 2] * 100 + Field[1, 1] * 10 + Field[2, 0];
            }
            if (OtherPlayer() * 10 + OtherPlayer() == WinTest)
            {
                Zeile = 0;
                Spalte = 2;
            }
            else if (OtherPlayer() * 100 + OtherPlayer() == WinTest)
            {
                Zeile = 1;
                Spalte = 1;
            }
            else if (OtherPlayer() * 100 + OtherPlayer() * 10 == WinTest)
            {
                Zeile = 2;
                Spalte = 0;
            }
            // Prüfe ob Gegner gewinnt
            // Zeilen
            for (int a = 0; a <= 2; a++)
            {
                // Zeilen auf 0 Testen
                if (Field[a, 0] == 0)
                {
                    WinTest = Field[a, 1] * 10 + Field[a, 2];
                }
                else
                {
                    WinTest = Field[a, 0] * 100 + Field[a, 1] * 10 + Field[a, 2];
                }
                // Zeile0
                if (Player * 10 + Player == WinTest)
                {
                    Zeile = a;
                    Spalte = 0;
                }
                // Zeile1
                else if (Player * 100 + Player == WinTest)
                {
                    Zeile = a;
                    Spalte = 1;
                }
                // Zeile2
                else if (Player * 100 + Player * 10 == WinTest)
                {
                    Zeile = a;
                    Spalte = 2;
                }
            }
            // Spalten
            for (int a = 0; a <= 2; a++)
            {
                // Spalten auf 0 Testen
                if (Field[0, a] == 0)
                {
                    WinTest = Field[1, a] * 10 + Field[2, a];
                }
                else
                {
                    WinTest = Field[0, a] * 100 + Field[1, a] * 10 + Field[2, a];
                }
                // Spalte0
                if (Player * 10 + Player == WinTest)
                {
                    Zeile = 0;
                    Spalte = a;
                }
                // Spalte1
                else if (Player * 100 + Player == WinTest)
                {
                    Zeile = 1;
                    Spalte = a;
                }
                // Spalte2
                else if (Player * 100 + Player * 10 == WinTest)
                {
                    Zeile = 2;
                    Spalte = a;
                }
            }
            // Schrägen
            // Links oben nach rechts unten
            if (Field[0, 0] == 0)
            {
                WinTest = Field[1, 1] * 10 + Field[2, 2];
            }
            else
            {
                WinTest = Field[0, 0] * 100 + Field[1, 1] * 10 + Field[2, 2];
            }
            if (Player * 10 + Player == WinTest)
            {
                Zeile = 0;
                Spalte = 0;
            }
            else if (Player * 100 + Player == WinTest)
            {
                Zeile = 1;
                Spalte = 1;
            }
            else if (Player * 100 + Player * 10 == WinTest)
            {
                Zeile = 2;
                Spalte = 2;
            }
            // Links unten nach rechts oben
            if (Field[0, 2] == 0)
            {
                WinTest = Field[1, 1] * 10 + Field[2, 0];
            }
            else
            {
                WinTest = Field[0, 2] * 100 + Field[1, 1] * 10 + Field[2, 0];
            }
            if (Player * 10 + Player == WinTest)
            {
                Zeile = 0;
                Spalte = 2;
            }
            else if (Player * 100 + Player == WinTest)
            {
                Zeile = 1;
                Spalte = 1;
            }
            else if (Player * 100 + Player * 10 == WinTest)
            {
                Zeile = 2;
                Spalte = 0;
            }
            // Teste ob der Zug erlaubt ist
            if (Field[Zeile, Spalte] == 0)
            {
                Field[Zeile, Spalte] = Player;
                Player = OtherPlayer();
            }
            else
            {
                Play();
            }
        }
        
        private void Play()
        {
            // Prüfe ob Spieler1 Gewonnen hat
            if (Field[0, 0] == 1 && Field[0, 1] == 1 && Field[0, 2] == 1 || Field[1, 0] == 1 && Field[1, 1] == 1 && Field[1, 2] == 1 || Field[2, 0] == 1 && Field[2, 1] == 1 && Field[2, 2] == 1 || Field[0, 0] == 1 && Field[1, 0] == 1 && Field[2, 0] == 1 || Field[0, 1] == 1 && Field[1, 1] == 1 && Field[2, 1] == 1 || Field[0, 2] == 1 && Field[1, 2] == 1 && Field[2, 2] == 1 || Field[0, 0] == 1 && Field[1, 1] == 1 && Field[2, 2] == 1 || Field[0, 2] == 1 && Field[1, 1] == 1 && Field[2, 0] == 1)
            {
                Field = new int[3, 3]
                {
                    {0,0,0},
                    {0,0,0},
                    {0,0,0}
                };
                Player1_Wins++;
            }
            // Prüfe ob Spieler2 Gewonnen hat
            else if (Field[0, 0] == 2 && Field[0, 1] == 2 && Field[0, 2] == 2 || Field[1, 0] == 2 && Field[1, 1] == 2 && Field[1, 2] == 2 || Field[2, 0] == 2 && Field[2, 1] == 2 && Field[2, 2] == 2 || Field[0, 0] == 2 && Field[1, 0] == 2 && Field[2, 0] == 2 || Field[0, 1] == 2 && Field[1, 1] == 2 && Field[2, 1] == 2 || Field[0, 2] == 2 && Field[1, 2] == 2 && Field[2, 2] == 2 || Field[0, 0] == 2 && Field[1, 1] == 2 && Field[2, 2] == 2 || Field[0, 2] == 2 && Field[1, 1] == 2 && Field[2, 0] == 2)
            {
                Field = new int[3, 3]
                {
                    {0,0,0},
                    {0,0,0},
                    {0,0,0}
                };
                Player2_Wins++;
            }
            // Prüfe ob es ein Unendschieden gibt
            else if (Field[0, 0] != 0 && Field[0, 1] != 0 && Field[0, 2] != 0 && Field[1, 0] != 0 && Field[1, 1] != 0 && Field[1, 2] != 0 && Field[2, 0] != 0 && Field[2, 1] != 0 && Field[2, 2] != 0)
            {
                Field = new int[3, 3]
                {
                    {0,0,0},
                    {0,0,0},
                    {0,0,0}
                };
                Patt_Wins++;
            }
            else
            {
                // Speiler1
                if(Player == 1)
                {
                    switch (Player1_Value)
                    {
                        case "Player":
                            Bot0();
                            break;
                        case "Bot1":
                            Bot1();
                            break;
                        case "Bot2":
                            Bot2();
                            break;
                        case "Bot3":
                            Bot3();
                            break;
                    }
                }
                // Speiler2
                else
                {
                    switch (Player2_Value)
                    {
                        case "Player":
                            Bot0();
                            break;
                        case "Bot1":
                            Bot1();
                            break;
                        case "Bot2":
                            Bot2();
                            break;
                        case "Bot3":
                            Bot3();
                            break;
                    }
                }
                
            }
            RenewField();
        }
        
        private int OtherPlayer()
        {
            if (Player == 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
        
        private void Btn_Settings(object sender, EventArgs e)
        {
            if (button1.Text == "Play")
            {
                button1.Text = "Settings";
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                button12.Visible = false;
                button11.Visible = false;
                // Feld Anzeigen
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                RenewField();
            }
            else
            {
                button1.Text = "Play";
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                button12.Visible = true;
                button11.Visible = true;
                // Feld Verstecken
                button3.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
            }
        }
        
        private void Cmd_Player1(object sender, EventArgs e)
        {
            Player1_Value = comboBox1.SelectedItem.ToString();
        }
        
        private void Cmd_Player2(object sender, EventArgs e)
        {
            Player2_Value = comboBox2.SelectedItem.ToString();
        }

        private void Btn_F1(object sender, EventArgs e)
        {
            Zeile = 0;
            Spalte = 0;
            Play();
        }

        private void Btn_F2(object sender, EventArgs e)
        {
            Zeile = 0;
            Spalte = 1;
            Play();
        }

        private void Btn_F3(object sender, EventArgs e)
        {
            Zeile = 0;
            Spalte = 2;
            Play();
        }

        private void Btn_F4(object sender, EventArgs e)
        {
            Zeile = 1;
            Spalte = 0;
            Play();
        }

        private void Btn_F5(object sender, EventArgs e)
        {
            Zeile = 1;
            Spalte = 1;
            Play();
        }

        private void Btn_F6(object sender, EventArgs e)
        {
            Zeile = 1;
            Spalte = 2;
            Play();
        }

        private void Btn_F7(object sender, EventArgs e)
        {
            Zeile = 2;
            Spalte = 0;
            Play();
        }

        private void Btn_F8(object sender, EventArgs e)
        {
            Zeile = 2;
            Spalte = 1;
            Play();
        }

        private void Btn_F9(object sender, EventArgs e)
        {
            Zeile = 2;
            Spalte = 2;
            Play();
        }

        private void Btn_RenewField(object sender, EventArgs e)
        {
            Player = 1;
            Field = new int[3, 3]
            {
                    {0,0,0},
                    {0,0,0},
                    {0,0,0}
            };
            RenewField();
        }

        private void Btn_ResetAll(object sender, EventArgs e)
        {
            Player = 1;
            Field = new int[3, 3]
            {
                    {0,0,0},
                    {0,0,0},
                    {0,0,0}
            };
            Player1_Wins = 0;
            Player2_Wins = 0;
            Patt_Wins = 0;
            RenewField();
        }

        private void Txt_X(object sender, EventArgs e)
        {

        }

        private void Txt_O(object sender, EventArgs e)
        {

        }

        private void Txt_Draw(object sender, EventArgs e)
        {

        }

        private void Txt_WinsX(object sender, EventArgs e)
        {

        }

        private void Txt_WinsO(object sender, EventArgs e)
        {

        }

        private void Txt_WinsXCount(object sender, EventArgs e)
        {

        }

        private void Txt_WinsOCount(object sender, EventArgs e)
        {

        }

        private void Txt_DrawCount(object sender, EventArgs e)
        {

        }
        
        // Nicht Benannt
        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
