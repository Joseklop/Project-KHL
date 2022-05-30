using System;
using System.Collections.ObjectModel;
using ReactiveUI;
using Course.Models;
using Course.Models.Database;
using Course.Models.StaticTabs;

namespace Course.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            CreateContext();
            CreateTabs();
            CreateQueries();
            Content = Fv = new FirstViewModel(this);
            Sv = new SecondViewModel(this);
        }
        ViewModelBase content;
        public ViewModelBase Content
        {
            get { return content; }
            set { this.RaiseAndSetIfChanged(ref content, value); }
        }
        public void Change()
        {
            if (Content == Fv)
                Content = Sv;
            else if (Content == Sv)
                Content = Fv;
            else throw new InvalidOperationException();
        }

        ObservableCollection<MyTab> tabs;
        public ObservableCollection<MyTab> Tabs
        {
            get { return tabs; }
            set { this.RaiseAndSetIfChanged(ref tabs, value); }
        }

        ObservableCollection<Query> queries;
        public ObservableCollection<Query> Queries
        {
            get { return queries; }
            set { this.RaiseAndSetIfChanged(ref queries, value); }
        }

        public FirstViewModel Fv { get; }
        public SecondViewModel Sv { get; }

        DataContext data;

        public DataContext Data
        {
            get { return data; }
            set { this.RaiseAndSetIfChanged(ref data, value); }
        }
        private void CreateContext()
        {
            Data = new DataContext();
        }

        private void CreateTabs()
        {
            Tabs = new ObservableCollection<MyTab>();
            Tabs.Add(new PlayerTab("Игрок", Data.Players));
            Tabs.Add(new TeamTab("Команда", Data.Teams));
            Tabs.Add(new GameTab("Матч", Data.Games));
            Tabs.Add(new PlayerStatTab("Статистика игроков", Data.PlayerStats));
            Tabs.Add(new TeamStatTab("Статистика команд", Data.TeamStats));
        }
        private void CreateQueries()
        {
            Queries = new ObservableCollection<Query>();
        }
    }
}
