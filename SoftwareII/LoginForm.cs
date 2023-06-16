using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareII
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginFormCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class userLoginInput
        {
            public string username { get; set; }
            public string password { get; set; }


            public userLoginInput(string username, string password)
            {
                this.username = username;
                this.password = password;
            }
        }

        private static readonly Dictionary<string, Dictionary<string, string>> Translations = new Dictionary<string, Dictionary<string, string>>
        {
            {
                "fr", new Dictionary<string, string> // French translations
                {
                    {"Login successful for {0}", "Connexion réussie pour {0}"},
                    {"Incorrect password", "Mot de passe incorrect"},
                    {"Could not find user", "Impossible de trouver l'utilisateur"},
                }
            },
            {
                "de", new Dictionary<string, string> // German translations
                {
                    {"Login successful for {0}", "Anmeldung erfolgreich für {0}"},
                    {"Incorrect password", "Falsches Passwort"},
                    {"Could not find user", "Benutzer konnte nicht gefunden werden"},
                }
            },
            {
                "it", new Dictionary<string, string> // Italian translations
                {
                    {"Login successful for {0}", "Accesso riuscito per {0}"},
                    {"Incorrect password", "Password errata"},
                    {"Could not find user", "Impossibile trovare l'utente"},
                }
            },
            {
                "es", new Dictionary<string, string> // Spanish translations
                {
                    {"Login successful for {0}", "Inicio de sesión exitoso para {0}"},
                    {"Incorrect password", "Contraseña incorrecta"},
                    {"Could not find user", "No se pudo encontrar al usuario"},
                }
            },
            {
                "pl", new Dictionary<string, string> // Polish translations
                {
                    {"Login successful for {0}", "Logowanie dla {0} powiodło się"},
                    {"Incorrect password", "Nieprawidłowe hasło"},
                    {"Could not find user", "Nie udało się znaleźć użytkownika"},
                }
            },
        };



        private void LoginFormLoginbutton_Click(object sender, EventArgs e)
        {
            userLoginInput userInput = new userLoginInput(LoginFormUsernameTextBox.Text, LoginFormPasswordTextBox.Text);

            List<User> users = Database.GetUsers();

            // Using LINQ to find the user
            User user = users.FirstOrDefault(u => u.UserName == userInput.username);

            string language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            if (user != null)
            {
                // User found, now check password
                if (user.Password == userInput.password)
                {
                    string message = $"Login successful for {user.UserName}";
                    MessageBox.Show(message + "\n" + GetTranslation(language, message, user.UserName));
                    Database.loggedInUser = user;
                }
                else
                {
                    string message = "Incorrect password";
                    MessageBox.Show(message + "\n" + GetTranslation(language, message));
                    LoginFormPasswordTextBox.Text = "";
                    Database.loggedInUser = null;
                }
            }
            else
            {
                string message = "Could not find user";
                MessageBox.Show(message + "\n" + GetTranslation(language, message));
                Database.loggedInUser = null;
            }
        }

        // Helper method to get translation
        private string GetTranslation(string language, string message, params object[] args)
        {
            if (Translations.TryGetValue(language, out var messages))
            {
                if (messages.TryGetValue(message, out var translation))
                {
                    return string.Format(translation, args);
                }
            }
            return "";
        }





    }
}
