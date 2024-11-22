using System.Collections.Generic;
using UnityEngine;
using YG;

public class PurchasesStorage : IStoragePurchases
{
    private int _lastSelectedSkin;

    public Dictionary<int, bool> GetSkin()
    {
        if (YandexGame.savesData == null)
        {
            Debug.LogError("YandexGame.savesData is null");
            return new Dictionary<int, bool>();
        }

        return YandexGame.savesData._skins;
    }

    public Dictionary<int, bool> SetSkin(int number, bool value)
    {
        if (YandexGame.savesData._skins.ContainsKey(number))
        {
            YandexGame.savesData._skins[number] = value;
        }
        else
        {
            YandexGame.savesData._skins.Add(number, value);
        }

        YandexGame.SaveProgress();
        return YandexGame.savesData._skins;
    }

    public bool GetFirstSkin()
    {
        return YandexGame.savesData.valueOne;
    }

    public bool GetSecondSkin()
    {
        return YandexGame.savesData.valueSecond;
    }

    public bool GetThirdSkin()
    {
        return YandexGame.savesData.valueThird;
    }

    public bool GetFirstSkin(bool value)
    {
        YandexGame.savesData.valueOne = value;
        YandexGame.SaveProgress();
        return value;
    }

    public bool GetSecondSkin(bool value)
    {
        YandexGame.savesData.valueSecond = value;
        YandexGame.SaveProgress();
        return value;
    }

    public bool GetThirdSkin(bool value)
    {
        YandexGame.savesData.valueThird = value;
        YandexGame.SaveProgress();
        return value;
    }

    public int GetLastSelectedSkin()
    {
        return _lastSelectedSkin; 
    }

    public void SetLastSelectedSkin(int skinId)
    {
        _lastSelectedSkin = skinId;
    }
}
