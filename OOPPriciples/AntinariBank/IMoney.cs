

namespace AntinariBank
{
    interface IMoney
    {
        decimal CalculateIntrestAmount(int months);
        void DepositeMoney(decimal amount);
        void WithdrawMoney(decimal amount);
    }
}
