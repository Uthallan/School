using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
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
            string languageCode = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            LanguageLabel.Text = "Language: " + languageCode;

            switch (languageCode)
            {
                case "en":
                    LogsButton.Text = "Logs";
                    UserNameLabel.Text = "User Name";
                    PasswordLabel.Text = "Password";
                    LoginFormLoginbutton.Text = "Login";
                    LoginFormCancelButton.Text = "Cancel";
                    break;

                case "frc":
                    // Translation for French Canadian
                    LogsButton.Text = "Journaux";
                    UserNameLabel.Text = "Nom d'utilisateur";
                    PasswordLabel.Text = "Mot de passe";
                    LoginFormLoginbutton.Text = "Connexion";
                    LoginFormCancelButton.Text = "Annuler";
                    break;

                case "fr":
                    // Translation for French
                    LogsButton.Text = "Journaux";
                    UserNameLabel.Text = "Nom d'utilisateur";
                    PasswordLabel.Text = "Mot de passe";
                    LoginFormLoginbutton.Text = "Connexion";
                    LoginFormCancelButton.Text = "Annuler";
                    break;

                case "de":
                    // Translation for German
                    LogsButton.Text = "Protokolle";
                    UserNameLabel.Text = "Benutzername";
                    PasswordLabel.Text = "Passwort";
                    LoginFormLoginbutton.Text = "Anmelden";
                    LoginFormCancelButton.Text = "Abbrechen";
                    break;

                case "it":
                    // Translation for Italian
                    LogsButton.Text = "Registri";
                    UserNameLabel.Text = "Nome utente";
                    PasswordLabel.Text = "Parola d'ordine";
                    LoginFormLoginbutton.Text = "Accedi";
                    LoginFormCancelButton.Text = "Annulla";
                    break;

                case "es":
                    // Translation for Spanish
                    LogsButton.Text = "Registros";
                    UserNameLabel.Text = "Nombre de usuario";
                    PasswordLabel.Text = "Contraseña";
                    LoginFormLoginbutton.Text = "Iniciar sesión";
                    LoginFormCancelButton.Text = "Cancelar";
                    break;

                case "pl":
                    // Translation for Polish
                    LogsButton.Text = "Dzienniki";
                    UserNameLabel.Text = "Nazwa użytkownika";
                    PasswordLabel.Text = "Hasło";
                    LoginFormLoginbutton.Text = "Zaloguj";
                    LoginFormCancelButton.Text = "Anuluj";
                    break;

                default:
                    // Default translation for unsupported languages
                    LogsButton.Text = "Logs";
                    UserNameLabel.Text = "Username";
                    PasswordLabel.Text = "Password";
                    LoginFormLoginbutton.Text = "Login";
                    LoginFormCancelButton.Text = "Cancel";
                    break;
            }
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
                "frc", new Dictionary<string, string> // French translations
                {
                    {"Login successful", "Connexion réussie"},
                    {"Incorrect password", "Mot de passe incorrect"},
                    {"Could not find user", "Impossible de trouver l'utilisateur"},
                }
            },
            {
                "fr", new Dictionary<string, string> // French translations
                {
                    {"Login successful", "Connexion réussie"},
                    {"Incorrect password", "Mot de passe incorrect"},
                    {"Could not find user", "Impossible de trouver l'utilisateur"},
                }
            },
            {
                "de", new Dictionary<string, string> // German translations
                {
                    {"Login successful", "Anmeldung erfolgreich"},
                    {"Incorrect password", "Falsches Passwort"},
                    {"Could not find user", "Benutzer konnte nicht gefunden werden"},
                }
            },
            {
                "it", new Dictionary<string, string> // Italian translations
                {
                    {"Login successful", "Accesso riuscito"},
                    {"Incorrect password", "Password errata"},
                    {"Could not find user", "Impossibile trovare l'utente"},
                }
            },
            {
                "es", new Dictionary<string, string> // Spanish translations
                {
                    {"Login successful", "Inicio de sesión exitoso"},
                    {"Incorrect password", "Contraseña incorrecta"},
                    {"Could not find user", "No se pudo encontrar al usuario"},
                }
            },
            {
                "pl", new Dictionary<string, string> // Polish translations
                {
                    {"Login successful", "Logowanie powiodło się"},
                    {"Incorrect password", "Nieprawidłowe hasło"},
                    {"Could not find user", "Nie udało się znaleźć użytkownika"},
                }
            },
        };

        public void UpcomingAppointments(int userId)
        {
            // Get all appointments for the user
            List<Appointment> userAppointments = Database.GetAppointments().Where(a => a.UserId == userId).ToList();

            // Get current date and time
            DateTime currentDateTime = DateTime.Now;

            // Check for appointments within the next 15 minutes
            foreach (Appointment appointment in userAppointments)
            {
                // Convert appointment start time to local time
                DateTime localStartTime = appointment.Start;

                // If there's an appointment within the next 15 minutes, show an alert
                if ((localStartTime - currentDateTime).TotalMinutes <= 15 && localStartTime >= DateTime.Now)
                {
                    MessageBox.Show("You have an appointment at " + localStartTime.ToString() + ". Please prepare for it.");
                }
            }

            if (userAppointments.Count == 0)
            {
                MessageBox.Show("You have no appointments in the next 15 minutes");
            }
        }




        private void LoginFormLoginbutton_Click(object sender, EventArgs e)
        {
            userLoginInput userInput = new userLoginInput(LoginFormUsernameTextBox.Text, LoginFormPasswordTextBox.Text);

            List<User> users = Database.GetUsers();

            // Using LINQ to find the user
            User user = users.FirstOrDefault(u => u.UserName == userInput.username);

            string language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            // Define the log file path
            string logFilePath = "./userLogins.txt";

            if (user != null)
            {
                // User found, now check password
                if (user.Password == userInput.password)
                {
                    string message = "Login successful";

                    // Log the successful login
                    using (StreamWriter writer = new StreamWriter(logFilePath, true))
                    {
                        writer.WriteLine($"{DateTime.Now}: {message}");
                    }

                    MessageBox.Show(message + "\n" + GetTranslation(language, message, user.UserName));
                    Database.loggedInUser = user;
                    UpcomingAppointments(user.UserId);
                    this.Close();
                }
                else
                {
                    string message = "Incorrect password";

                    // Log the unsuccessful login
                    using (StreamWriter writer = new StreamWriter(logFilePath, true))
                    {
                        writer.WriteLine($"{DateTime.Now}: {message} for user {user.UserName}");
                    }

                    MessageBox.Show(message + "\n" + GetTranslation(language, message));
                    LoginFormPasswordTextBox.Text = "";
                    Database.loggedInUser = null;
                }
            }
            else
            {
                string message = "Could not find user";

                // Log the unsuccessful login
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message} for user {userInput.username}");
                }

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

        private void LogsButton_Click(object sender, EventArgs e)
        {
            string logFilePath = "./userLogins.txt";

            if (File.Exists(logFilePath))
            {
                string logContent = File.ReadAllText(logFilePath);

                MessageBox.Show(logContent);
            }
            else
            {
                MessageBox.Show("No logs are available.");
            }
        }



    }
}
