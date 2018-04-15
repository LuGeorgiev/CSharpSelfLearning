using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class Inventory
    {
        public long Capacity { get; set; }
        public long GoldAmount { get; set; } = 0;
        public long GemsAmount { get; set; } = 0;
        public long CashAmount { get; set; } = 0;
        public Dictionary<string,long> GemTypes { get; set; }
        public Dictionary<string,long> CashTypes { get; set; }

        public Inventory(long capacity)
        {
            this.Capacity = capacity;
            this.GemTypes = new Dictionary<string, long>();
            this.CashTypes = new Dictionary<string, long>();
        }

        public void AddGold(long goldAmount)
        {
            long currentAmount = this.GoldAmount + this.GemsAmount + this.CashAmount;
            if (this.Capacity>=currentAmount+goldAmount)
            {
                this.GoldAmount += goldAmount;
            }
        }

        public void AddGems(long gemsAmount, string gemName)
        {
            bool hasSpace = this.GoldAmount + this.GemsAmount + this.CashAmount + gemsAmount <= this.Capacity;
            bool lessThanGold = this.GoldAmount >= this.GemsAmount + gemsAmount;
            if (!hasSpace||!lessThanGold)
            {
                return;
            }

            if (!GemTypes.ContainsKey(gemName))
            {
                GemTypes[gemName] = 0;
            }
            GemTypes[gemName] += gemsAmount;
            this.GemsAmount += gemsAmount;
        }

        public void AddCash(long cashAmount, string cashName)
        {
            bool hasSpace = this.GoldAmount + this.GemsAmount + this.CashAmount + cashAmount <= Capacity;
            bool lessThanGems = this.GemsAmount >= this.CashAmount + cashAmount;
            if (!hasSpace || !lessThanGems)
            {
                return;
            }

            if (!CashTypes.ContainsKey(cashName))
            {
                CashTypes[cashName] = 0;
            }
            CashTypes[cashName] += cashAmount;
            this.CashAmount += cashAmount;
        }

        internal void PrintInventory()
        {
            if (this.GoldAmount>0)
            {
                Console.WriteLine($"<Gold> ${this.GoldAmount}");
                Console.WriteLine($"##Gold - {this.GoldAmount}");
            }

            if (this.GemsAmount>0)
            {
                Console.WriteLine($"<Gem> ${this.GemsAmount}");
                var sortedGems = GemTypes
                    .OrderByDescending(x => x.Key);
                foreach (var gem in sortedGems)
                {
                    Console.WriteLine($"##{gem.Key} - {gem.Value}");
                }
            }

            if (this.CashAmount>0)
            {
                Console.WriteLine($"<Cash> ${this.CashAmount}");
                var sortedCash = CashTypes
                    .OrderByDescending(x => x.Key);
                foreach (var type in sortedCash)
                {
                    Console.WriteLine($"##{type.Key} - {type.Value}");
                }
            }

        }

    }
}
