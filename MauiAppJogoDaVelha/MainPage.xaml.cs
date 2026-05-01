namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "✈️";
        bool isDarkTheme = true;
        public MainPage()
        {
            InitializeComponent();
        }
        private void BtnMudarTema_Clicked(object sender, EventArgs e)
        {
            var dicionarios = Application.Current.Resources.MergedDictionaries;

            var temaAtual = dicionarios.FirstOrDefault(d => d.GetType() == typeof(DarkTheme) || d.GetType() == typeof(LightTheme));

            if (temaAtual != null)
            {
                
                {
                    dicionarios.Remove(temaAtual);
                }

                
                if (isDarkTheme)
                {
                    dicionarios.Add(new LightTheme());
                    isDarkTheme = false;
                }
                else
                {
                    dicionarios.Add(new DarkTheme());
                    isDarkTheme = true;
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.IsEnabled = false;
            if (vez == "✈️")
            {
                btn.Text = "✈️";
                
            }
            else
            {
                btn.Text = "🚁";
                
            }
            
            if (VerificarVitoria(vez))
            {
                DisplayAlert("Parabéns!", $"O {vez} ganhou!", "OK");
                Zerar();
                return;
            }

            
            if (VerificarEmpate())
            {
                DisplayAlert("Deu Velha!", "O Jogo Empatou!", "OK");
                Zerar();
                return;
            }
            vez = (vez == "✈️") ? "🚁" : "✈️";
        }
        bool VerificarVitoria(string jogador)
        {
            if (btn10.Text == jogador && btn11.Text == jogador && btn12.Text == jogador) return true;
            if (btn20.Text == jogador && btn21.Text == jogador && btn22.Text == jogador) return true;
            if (btn30.Text == jogador && btn31.Text == jogador && btn32.Text == jogador) return true;

            // Verificando Colunas
            if (btn10.Text == jogador && btn20.Text == jogador && btn30.Text == jogador) return true;
            if (btn11.Text == jogador && btn21.Text == jogador && btn31.Text == jogador) return true;
            if (btn12.Text == jogador && btn22.Text == jogador && btn32.Text == jogador) return true;

            // Verificando Diagonais
            if (btn10.Text == jogador && btn21.Text == jogador && btn32.Text == jogador) return true;
            if (btn30.Text == jogador && btn21.Text == jogador && btn12.Text == jogador) return true;

            return false;
        }

        bool VerificarEmpate()
        {
            // Se todos os botões não estiverem habilitados e ninguém ganhou, é empate
            return !btn10.IsEnabled && !btn11.IsEnabled && !btn12.IsEnabled &&
                   !btn20.IsEnabled && !btn21.IsEnabled && !btn22.IsEnabled &&
                   !btn30.IsEnabled && !btn31.IsEnabled && !btn32.IsEnabled;
        }

        void Zerar()
        {
            // Limpa o texto
            btn10.Text = ""; btn11.Text = ""; btn12.Text = "";
            btn20.Text = ""; btn21.Text = ""; btn22.Text = "";
            btn30.Text = ""; btn31.Text = ""; btn32.Text = "";

            // Reabilita os botões
            btn10.IsEnabled = true; btn11.IsEnabled = true; btn12.IsEnabled = true;
            btn20.IsEnabled = true; btn21.IsEnabled = true; btn22.IsEnabled = true;
            btn30.IsEnabled = true; btn31.IsEnabled = true; btn32.IsEnabled = true;

            // Volta a vez para o X começar novamente
            vez = "✈️";
        }
        
        

    }
}
