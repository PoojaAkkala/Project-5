using Calculator.Data;
using Calculator.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Amazon.SimpleWorkflow.Model;

namespace Calculator
{
    public partial class OrderViewModel 
    {
        
        Order history = new Order();
        private OrderDataBase data;
        BillModel billModel = new BillModel();
        private BillDataBase billdata;
        ObservableCollection<Order> items;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Order> Items { get => items; }
        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        
        public OrderViewModel()
        {
            initiateData();
            items = new ObservableCollection<Order>();
             

        }
       
        public async void Add(string item,string sum)
        {
            
            
            history.Calc = item;

            data = new OrderDataBase();
            await data.SaveItemAsync(history);
            billdata = new BillDataBase();
            await billdata.DeleteAllAsync();
            billModel.Bill = sum;
            await billdata.SaveItemAsync(billModel);
            OnPropertyChanged("Items");
            OnPropertyChanged("Items");
            OnPropertyChanged();
            OnPropertyChanged();
           

        }
        public async Task initiateData()
        {
            data = new OrderDataBase();
            var res = await data.GetItemsAsync();
            items = new ObservableCollection<Order>();
            res.ForEach(items.Add);
           
  
        }

        
    }
}
