namespace P05_KingsGambit.Contracts
{
    public delegate void SubordinateDeathEventHandler();
    public interface ISubordinate:INamable,IMortal
    {
        event SubordinateDeathEventHandler DeathEvent;
        string Action { get; }
        void ReactToAttack();
    }
}