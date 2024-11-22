using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SequenceClicks : MonoBehaviour, ISequence, IInitialization
{
    [SerializeField] private float _showDelay;
    [SerializeField] private Image _panel;

    private List<int> _sequence = new List<int>();
    private List<AudioSource> _audioSources = new List<AudioSource>();

    private BlockInterations _blockInterations;
    private Tiles _tiles;

    public int _currentStep { get; private set; }
    public int _totalStep { get; private set; }
    public int _recordStep { get; private set; }

    public event Action OnIncorrectPressed;
    public event Action OnUpdateCurrentStep;

    private IRecordStepStorage _storage;

    [Inject]
    public void Constructor(Tiles tiles, BlockInterations blockInterations, IRecordStepStorage storage)
    {
        _tiles = tiles;
        _blockInterations = blockInterations;

        _storage = storage;
        _recordStep = _storage.GetValue();
    }

    public void Initialization()
    {
        _currentStep = 0;
        _totalStep = 0;

        OnUpdateCurrentStep?.Invoke();
        StartCoroutine(ShowSequence());
    }

    private IEnumerator ShowSequence()
    {
        _blockInterations.EnableTileInteraction(_tiles._currentTiles.Select(t => t.eventTrigger).ToList(), false);
        _sequence.Add(UnityEngine.Random.Range(0, _tiles._currentTiles.Count));

        foreach (int index in _sequence)
        {
            _panel.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _tiles._currentTiles[index].image.color = Color.red;
            yield return new WaitForSeconds(_showDelay);
            _tiles._currentTiles[index].image.color = Color.white;
            _panel.gameObject.SetActive(false);
        }

        _blockInterations.EnableTileInteraction(_tiles._currentTiles.Select(t => t.eventTrigger).ToList(), true);
    }

    public void OnTileClicked(int tileIndex)
    {
        if (tileIndex == _sequence[_currentStep])
        {
            _currentStep++;
            if (_currentStep >= _sequence.Count)
            {
                _currentStep = 0;
                _totalStep++;

                OnUpdateCurrentStep?.Invoke();
                StartCoroutine(ShowSequence());
            } 
        }
        else
        {
            if (_totalStep > _recordStep) 
            {
                _recordStep = _storage.GetValue();
                _recordStep = _totalStep;
                _storage.SetValue(_recordStep);
            }

            OnIncorrectPressed?.Invoke();
            OnUpdateCurrentStep?.Invoke();
        }
    }
}
