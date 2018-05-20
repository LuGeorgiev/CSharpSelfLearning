namespace P02_KingsGambit.Contracts
{
    public interface ISubordinate:INamable,IMortal
    {
        string Action { get; }
        void ReactToAttack();
    }
}