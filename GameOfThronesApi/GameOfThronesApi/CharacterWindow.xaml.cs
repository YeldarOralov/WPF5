using GameOfThronesApi.Models;
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

namespace GameOfThronesApi
{
    /// <summary>
    /// Логика взаимодействия для CharacterWindow.xaml
    /// </summary>
    public partial class CharacterWindow : Window
    {
        public CharacterWindow(Character character)
        {
            InitializeComponent();

            if(character.Image is null)
            {
                characterImage.Source = new BitmapImage(new Uri(@"https://user-images.githubusercontent.com/24848110/33519396-7e56363c-d79d-11e7-969b-09782f5ccbab.png", UriKind.Relative));                
            }
            else
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(character.Image);
                bitmap.EndInit();

                characterImage.Source = bitmap;
            }

            nameTextBlock.Text = "Name: " + character.Name;
            genderTextBlock.Text = "Gender: " + character.Gender;
            houseTextBlock.Text = "House: " + character.House;
            birthTextBlock.Text = "Birth year: " + character.Birth;
            aliveTextBlock.Text = "Is alive: " + character.IsAlive;
            createdAtTextBlock.Text = "Created at: " + character.CreatedAt;
        }
    }
}
