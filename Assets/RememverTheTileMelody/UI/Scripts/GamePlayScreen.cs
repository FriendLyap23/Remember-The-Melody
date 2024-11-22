using UnityEngine;

public class GamePlayScreen : MonoBehaviour, IScreen
{
    [field: SerializeField] public GameObject _screen { get; set; }

    public void ToggleScreen(bool enable)
    {
        _screen.SetActive(enable);
    }
}
