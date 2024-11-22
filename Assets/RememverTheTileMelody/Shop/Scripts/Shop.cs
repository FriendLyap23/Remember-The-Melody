using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shop : MonoBehaviour
{
    public static Shop Instance { get; set; }
    public List<Sprite> _sprites;

    public Dictionary<int, bool> _skins = new Dictionary<int, bool>();

    public bool IsFirstSkin;
    public bool IsSecondSkin;
    public bool IsThirdSkin;

    private IStoragePurchases _storagePurchases;

    [Inject]
    public void Constructor(IStoragePurchases storagePurchases)
    {
        _storagePurchases = storagePurchases;
    }

    private int _idSelectedSkin;

    public int IDSelectedSkin
    {
        get { return _idSelectedSkin; }
        set
        {
            if (value < 0 || value >= _sprites.Count) Debug.LogError("Incorrect skin ID");
            else
                _idSelectedSkin = value;
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
