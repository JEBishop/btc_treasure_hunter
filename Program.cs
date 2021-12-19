using System;
using NBitcoin;
using btc_treasure_hunter.Models;

namespace btc_treasure_hunter
{
    class Program
    {
        static void Main(string[] args)
        {
            Address addr = new Address(new Key());
            Console.WriteLine("Private Key: " + addr.private_key.ToString());
            Console.WriteLine("Public Key: " + addr.public_key); // 0251036303164f6c458e9f7abecb4e55e5ce9ec2b2f1d06d633c9653a07976560c
            Console.WriteLine("Public Key Address: " + addr.public_key.GetAddress(ScriptPubKeyType.Legacy, Network.Main)); // 1PUYsjwfNmX64wS368ZR5FMouTtUmvtmTY
            Console.WriteLine("Public Hash: " + addr.public_key.Hash); // f6889b21b5540353a29ed18c45ea0031280c42cf
            Console.WriteLine("WIF: " + addr.wif);
        }
    }
}