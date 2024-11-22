using System.Collections.Generic;

public interface IStoragePurchases
{
    public Dictionary<int, bool> GetSkin();
    public Dictionary<int, bool> SetSkin(int number,bool value);

    public bool GetFirstSkin();
    public bool GetSecondSkin();
    public bool GetThirdSkin();

    public bool GetFirstSkin(bool value);
    public bool GetSecondSkin(bool value);
    public bool GetThirdSkin(bool value);

    int GetLastSelectedSkin();
    void SetLastSelectedSkin(int skinId);
}
