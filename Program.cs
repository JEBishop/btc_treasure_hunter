using System;
using NBitcoin;
using btc_treasure_hunter.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;

namespace btc_treasure_hunter
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            while(1) {
                Wallet wallet = new Wallet(new Key());
                int balance = await sendRequest(wallet);
                if(balance > 0) {
                    Console.WriteLine("Private Key: " + wallet.private_key);
                    Console.WriteLine("Public Key: " + wallet.public_key); 
                    Console.WriteLine("Public Key Address: " + wallet.mainnet_address); 
                    Console.WriteLine("Public Hash: " + wallet.public_key.Hash); 
                    Console.WriteLine("WIF: " + wallet.wif);
                }   
            }
        }

        private static async Task<int> sendRequest(Wallet w) {
            var stringTask = client.GetStringAsync("https://api.blockcypher.com/v1/btc/main/addrs/" + w.mainnet_address + "/balance");
            var msg = await stringTask;
            var responseObj = JObject.Parse(msg);
            return responseObj.SelectToken("balance").Value<int>();
        }
    }
}