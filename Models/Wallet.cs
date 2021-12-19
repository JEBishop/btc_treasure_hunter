using System;
using NBitcoin;

namespace btc_treasure_hunter.Models {
    class Wallet {
        String address;
        float total_received;
        float total_sent;
        float balance;
        float unconfirmed_balance;
        float final_balance;
        int n_tx;
        int unconfirmed_n_tx;
        int final_n_tx;
    }
}