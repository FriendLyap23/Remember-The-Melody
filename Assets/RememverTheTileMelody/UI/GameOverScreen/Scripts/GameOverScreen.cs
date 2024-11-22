using UnityEngine;
using YG;
using Zenject;

public class GameOverScreen : GamePlayScreen
{
    private SequenceClicks _sequenceClicks;

    [SerializeField] private GameObject _panel;

    public bool _ads;

    [Inject]
    private void Constructor(SequenceClicks sequenceClicks) 
    {
        _sequenceClicks = sequenceClicks;
    }

    private void Awake()
    {
        _sequenceClicks.OnIncorrectPressed += EnableGameOverScreen;

        _panel.SetActive(false);
    }

    public void EnableGameOverScreen() 
    {
        ToggleScreen(true);
        _ads = true;
    }

    private void Update()
    {
        if (_ads == true)
        {
            _ads = false;
            YandexGame.FullscreenShow();
        }
    }

    private void OnDisable()
    {
        _sequenceClicks.OnIncorrectPressed -= EnableGameOverScreen;
    }
}
