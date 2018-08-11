 public interface IWareHouse
 {
    void EquipArmy(IArmy army);
    void AddAmmmunition(string ammunition, int quanity);
    bool TryEquipSoldier(ISoldier soldier);
 }

