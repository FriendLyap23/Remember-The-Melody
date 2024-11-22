using TMPro;
using UnityEngine;
using YG;
using Zenject;

public class RecordScoreText : MonoBehaviour
{
    private SequenceClicks _sequenceClicks;

    [field: SerializeField] public TMP_Text _text { get; set; }

    [Inject]
    private void Constructor(SequenceClicks sequenceClicks)
    {
        _sequenceClicks = sequenceClicks;
    }

    private void OnEnable()
    {
        _sequenceClicks.OnUpdateCurrentStep += UpdateUI;
    }

    public void UpdateUI()
    {
        _text.text = _sequenceClicks._recordStep.ToString();
        YandexGame.NewLeaderboardScores("LeaderBoardRTM", _sequenceClicks._recordStep);  
    }
    private void OnDisable()
    {
        _sequenceClicks.OnUpdateCurrentStep -= UpdateUI;
    }
}
