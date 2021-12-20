using System;
using NBitcoin;

namespace btc_treasure_hunter.Models {
    class Wallet {
        public PubKey public_key;
        public BitcoinSecret private_key;
        public KeyId public_key_hash;
        public BitcoinPubKeyAddress mainnet_address;
        public BitcoinSecret wif;

        public Wallet(Key privateKey) {
            private_key = privateKey.GetBitcoinSecret(Network.Main);
            public_key = privateKey.PubKey;
            public_key_hash = public_key.Hash;
            mainnet_address = public_key_hash.GetAddress(Network.Main);
            wif = privateKey.GetWif(Network.Main);
        }
    }
}