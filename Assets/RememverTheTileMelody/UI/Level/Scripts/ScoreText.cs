using TMPro;
using UnityEngine;
using Zenject;

public class ScoreText : MonoBehaviour, IUpdateUI
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
        _text.text = _sequenceClicks._totalStep.ToString();
    }
    private void OnDisable()
    {
        _sequenceClicks.OnUpdateCurrentStep -= UpdateUI;
    }
}
