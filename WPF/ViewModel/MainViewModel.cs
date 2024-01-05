using Mecalux_WPF.Models;
using Record_Book_MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Mecalux_WPF.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            TextStatistics = new TextStatistics() {};
            OrderedText = string.Empty;
            orderOptions = new ObservableCollection<string>();
            TextOrderApiCaller = new TextOrderApiCaller();

            RefreshOrderOptionsCommand = new RelayCommand(RefreshOrderOptions, CanRefreshOrderOption);
            OrderTextCommand = new RelayCommand(OrderText, CanOrderText);
            CalculateStatisticsCommand = new RelayCommand(CalculateStatistics, CanCalculateStatistics);
        }

        public TextStatistics textStatistics { get; set; }
        public TextStatistics TextStatistics
        {
            get
            {
                return textStatistics;
            }
            set
            {
                textStatistics = value;
                NotifyPropertyChanged("TextStatistics");
            }
        }
        public string TextToOrder { get; set; }
        public string SelectedOrderOption { get; set; }
        public string orderedText { get; set; }
        public string OrderedText
        {
            get
            {
                return orderedText;
            }
            set
            {
                orderedText = value;
                NotifyPropertyChanged("OrderedText");
            }
        }
        public ObservableCollection<string> orderOptions { get; set; }
        public ObservableCollection<string> OrderOptions
        {
            get
            {
                return orderOptions;
            }
            set
            {
                orderOptions = value;
                NotifyPropertyChanged("OrderOptions"); 
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public TextOrderApiCaller TextOrderApiCaller { get; set; }
        public ICommand RefreshOrderOptionsCommand { get; set; }
        public ICommand OrderTextCommand { get; set; }
        public ICommand CalculateStatisticsCommand { get; set; }


        private bool CanOrderText(object obj)
        {
            return true;
        }

        private void OrderText(object obj)
        {
            OrderedText = TextOrderApiCaller.OrderText(TextToOrder, SelectedOrderOption);
        }

        private bool CanRefreshOrderOption(object obj)
        {
            return true;
        }

        private void RefreshOrderOptions(object obj)
        {
            OrderOptions = new ObservableCollection<string>(TextOrderApiCaller.GetOrderTypes());
        }

        private void CalculateStatistics(object obj)
        {
            TextStatistics = TextOrderApiCaller.GetTextStatistics(TextToOrder);
        }

        private bool CanCalculateStatistics(object obj)
        {
            return true;
        }
    }
}
