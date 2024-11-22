using TMPro;

public interface IUpdateUI
{
    [field: SerializeField] public TMP_Text _text { get; set; }

    public void UpdateUI();
}
