using GameOfThronesApi.Models;
using GameOfThronesApi.Services;
using Newtonsoft.Json;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GameOfThronesApi
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Character[] _characters;
        public MainWindow()
        {
            InitializeComponent();
            ShowData();
        }

        private void CharactersListDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedCharacterName = charactersList.SelectedItem.ToString();
            var selectedCharacter = _characters.FirstOrDefault(c => c.Name == selectedCharacterName);

            var characterWindow = new CharacterWindow(selectedCharacter);
            characterWindow.ShowDialog();
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CharacterNameTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var sortedCharacters = _characters.Select(c => c.Name).Where(c => c.ToLower().Contains(characterNameTextBox.Text.ToLower()));
            charactersList.ItemsSource = sortedCharacters;
        }

        private void ShowData()
        {
            string json = Downloader.DownloadDataJson("https://api.got.show/api/book/characters");
            _characters = JsonConvert.DeserializeObject<Character[]>(json);

            charactersList.ItemsSource = _characters.Select(c=>c.Name);
        }
    }
}
