using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Localization_Demo
{
    partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<MainWindowModel>? games;

        public MainWindowViewModel()
        {
            InitGames();

            WeakReferenceMessenger.Default.Register<RefreshMessage>(this, (obj, message) =>
            {
                InitGames();
            });
        }

        public void InitGames()
        {
            Games = new()
            {
                new MainWindowModel(){ ID = (int)Application.Current.FindResource("GameIDCyberpunk"), Name = (string)Application.Current.FindResource("GameNameCyberpunk") },
                new MainWindowModel(){ ID = (int)Application.Current.FindResource("GameIDWitcher3"), Name = (string)Application.Current.FindResource("GameNameWitcher3") }
            };
        }
    }
}
