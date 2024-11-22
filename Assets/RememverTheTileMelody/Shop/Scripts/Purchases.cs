using System;
using UnityEngine;
using Zenject;

public class Purchases : MonoBehaviour
{
    private Shop _shop;
    private UIPurchases _uiPurchases;
    private IStoragePurchases _storagePurchases;

    [SerializeField] private int _idskin;

    public event Action<int, bool> OnSkinBought;

    public LoadSkins _load;

    [Inject]
    public void Constructor(Shop shop, UIPurchases uIPurchases, IStoragePurchases storagePurchases, LoadSkins load)
    {
        _shop = shop;
        _uiPurchases = uIPurchases;
        _storagePurchases = storagePurchases;
        _load = load;
    }

    private void Start()
    {
        LoadSavedData();
    }

    public void ChangeSkin()
    {
        if (GetSkinState())
        {
            _shop.IDSelectedSkin = _idskin;
            _uiPurchases.SelectedShow(gameObject);
            _load.Save(_idskin, true);
            int lastSkinId = _storagePurchases.GetLastSelectedSkin();
            _idskin = lastSkinId;
        }
    }

    private void LoadSavedData()
    {
        bool isSelected = _shop.IDSelectedSkin == _idskin;
        _uiPurchases.UpdateUI(isSelected);
    }

    public bool GetSkinState()
    {
        switch (_idskin)
        {
            case 0:
                return _storagePurchases.GetFirstSkin();
            case 1:
                return _storagePurchases.GetSecondSkin();
            case 2:
                return _storagePurchases.GetThirdSkin();
            default:
                Debug.LogError("Incorrect skin ID");
                return false;
        }
    }
}
