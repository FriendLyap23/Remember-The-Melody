using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Score : MonoBehaviour
{
    private SequenceClicks _sequenceClicks;
    private Tiles _tiles;

    private Dictionary<int, string> _stepActions = new Dictionary<int, string>()
    {
        { 2, "AnimationTile1"},
        { 3, "AnimationTile2"}
    };

    public event Action<string> OnAnimationTile;

    [Inject]
    public void Constructor(SequenceClicks sequenceClicks, Tiles tiles)
    {
        _sequenceClicks = sequenceClicks;
        _tiles = tiles;
    }

    private void OnEnable()
    {
        _sequenceClicks.OnUpdateCurrentStep += CheckStep;
    }

    private void CheckStep() 
    {
        if (_stepActions.ContainsKey(_sequenceClicks._totalStep))
        {
            string value = _stepActions[_sequenceClicks._totalStep];
            _tiles.AddTiles(4);
            OnAnimationTile?.Invoke(value);
        }
    }
}
