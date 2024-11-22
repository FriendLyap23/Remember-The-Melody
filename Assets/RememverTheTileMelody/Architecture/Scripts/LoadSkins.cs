using UnityEngine;
using Zenject;

public class LoadSkins : MonoBehaviour
{
    private Shop _shop;
    private IStoragePurchases _storagePurchases;

    [Inject]
    public void Constructor(Shop shop, IStoragePurchases storagePurchases)
    {
        _shop = shop;
        _storagePurchases = storagePurchases;
    }

    public void Save(int number, bool value)
    {
        _shop._skins = _storagePurchases.SetSkin(number, value);

        _storagePurchases.SetLastSelectedSkin(number);

        if (number == 0)
            _shop.IsFirstSkin = _storagePurchases.GetFirstSkin(value);
        else if (number == 1)
            _shop.IsSecondSkin = _storagePurchases.GetSecondSkin(value);
        else if (number == 2)
            _shop.IsThirdSkin = _storagePurchases.GetThirdSkin(value);
    }

    public void Load()
    {
        _storagePurchases.GetFirstSkin();
        _storagePurchases.GetSecondSkin();
        _storagePurchases.GetThirdSkin();
    }
}
