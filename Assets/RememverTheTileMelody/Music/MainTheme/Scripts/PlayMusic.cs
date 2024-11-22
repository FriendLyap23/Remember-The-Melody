using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public void Start()
    {
        MainMusic.Instance.ToggleMusic();
    }
}
