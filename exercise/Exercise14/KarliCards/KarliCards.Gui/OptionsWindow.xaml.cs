﻿using System;
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
using System.IO;
using System.Xml.Serialization;
using Ch13CardLib;



namespace KarliCards.Gui
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    /// 
    public partial class OptionsWindow : Window
    {
        private GameOptions gameOptions;
        
        public OptionsWindow()
        {
            /*
            if (gameOptions == null)
            {

                if (File.Exists("GameOptions.xml"))
                {
                    using (var stream = File.OpenRead("GameOptions.xml"))
                    {
                        var serializer = new XmlSerializer(typeof(GameOptions));
                        gameOptions = serializer.Deserialize(stream) as GameOptions;
                    }
                }
            

            else
                gameOptions = new GameOptions();
            }
            */
                gameOptions = GameOptions.Create();
                DataContext = gameOptions;
                InitializeComponent();
        }

        private void DumbAIRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            gameOptions.ComputerSkill = ComputerSkillLevel.Dumb;
        }

        private void GoodAIRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            gameOptions.ComputerSkill = ComputerSkillLevel.Good;
        }

        private void CheatingAIRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            gameOptions.ComputerSkill = ComputerSkillLevel.Cheats;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            gameOptions.Save();
            Close();
            /*
            using (var stream = File.Open("GameOptions.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(GameOptions));
                serializer.Serialize(stream, gameOptions);
            }
            Close();
            */
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            gameOptions = null;
            Close();
        }


    }
    
}
