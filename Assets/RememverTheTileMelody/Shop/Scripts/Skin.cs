using UnityEngine;
using Zenject;

public class Skin : MonoBehaviour
{
    private Shop _shop;

    [Inject]
    public void Constructor(Shop shop)
    {
        _shop = shop;
    }

    public void ChangeSkin(int ID) 
    {
        if (_shop._skins.ContainsKey(ID))
        {
            _shop.IDSelectedSkin = ID;      
        }
    }
}
