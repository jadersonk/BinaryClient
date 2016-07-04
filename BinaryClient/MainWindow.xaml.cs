﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BinaryClient.JSONTypes;
using Newtonsoft.Json;

namespace BinaryClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Stopwatch _watch = new Stopwatch();
        //        public List<Account> Accounts { get; } = new List<Account>();
        public ObservableCollection<Account> Accounts { get; } = new ObservableCollection<Account>();

        public MainWindow()
        {
            InitializeComponent();

            Accounts.Add(new Account("3EjSVBls8OS4NqJ"));
            DataAccounts.ItemsSource = Accounts;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonPut_Click(object sender, RoutedEventArgs e)
        {
            TextTime.Text = "";
            _watch.Start();

//            var priceProposalRequest = new PriceProposalRequest
//            {
//                proposal = 1,
//                amount = "100",
//                basis = "payout",
//                contract_type = "PUT",
//                currency = "USD",
//                duration = "60",
//                duration_unit = "s",
//                symbol = "R_100"
//            };
//            var jsonPriceProposalRequest = JsonConvert.SerializeObject(priceProposalRequest);
//            await _bws.SendRequest(jsonPriceProposalRequest);
//            var jsonPriceProposalResponse = await _bws.StartListen();
//            var priceProposal = JsonConvert.DeserializeObject<PriceProposalResponse>(jsonPriceProposalResponse);
//            var id = priceProposal.proposal.id;
//            var price = priceProposal.proposal.display_value;
//
//            await _bws.SendRequest($"{{\"buy\":\"{id}\", \"price\": {price}}}");
//            var jsonBuy = await _bws.StartListen();

            _watch.Stop();
            TextTime.Text = _watch.ElapsedMilliseconds.ToString();
        }

        private void buttonCall_Click(object sender, RoutedEventArgs e)
        {
            TextTime.Text = "";
            _watch.Start();

//            var priceProposalRequest = new PriceProposalRequest
//            {
//                proposal = 1,
//                amount = "71",
//                basis = "payout",
//                contract_type = "CALL",
//                currency = "USD",
//                duration = "60",
//                duration_unit = "s",
//                symbol = "R_100"
//            };
//            var jsonPriceProposalRequest = JsonConvert.SerializeObject(priceProposalRequest);
//            await _bws.SendRequest(jsonPriceProposalRequest);
//            var jsonPriceProposalResponse = await _bws.StartListen();
//            var priceProposal = JsonConvert.DeserializeObject<PriceProposalResponse>(jsonPriceProposalResponse);
//            var id = priceProposal.proposal.id;
//            var price = priceProposal.proposal.display_value;
//
//            await _bws.SendRequest($"{{\"buy\":\"{id}\", \"price\": {price}}}");
//            var jsonBuy = await _bws.StartListen();

            _watch.Stop();
            TextTime.Text = _watch.ElapsedMilliseconds.ToString();
        }

        private void DataGrid_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            LabelSelected.Content = $"Selected: {Accounts.Count(m => m.Selected)}";
        }
    }
}
