using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    private void Start()
    {
        var musicManager = MainMusic.Instance;

        if (musicManager != null)
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(musicManager.ToggleMusic);
        }
        else
        {
            Debug.LogError("MainMusic instance not found!");
        }
    }
}
