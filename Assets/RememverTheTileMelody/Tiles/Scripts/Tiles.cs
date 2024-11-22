using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Tiles : MonoBehaviour, IInitialization
{
    public List<Tile> _currentTiles { get; private set; }
    [SerializeField] private List<Tile> _otherTiles;

    private Shop _shop;

    [Inject]
    public void Constructor(Shop shop)
    {
        _shop = shop;
    }

    public void Initialization()
    {
        _currentTiles = new List<Tile>();

        foreach (var item in _otherTiles)
            item.image.sprite = _shop._sprites[_shop.IDSelectedSkin];

        AddTiles(4);
    }

    public void AddTiles(int count)
    {
        count = Mathf.Min(count, _otherTiles.Count);

        List<Tile> tilesToMove = _otherTiles.GetRange(0, count);

        _currentTiles.AddRange(tilesToMove);
        tilesToMove.Clear();
        _otherTiles.RemoveRange(0,count);
    }
}
