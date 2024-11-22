using UnityEngine;

public class MusicStatus : MonoBehaviour, IInitialization
{
    public void Initialization()
    {
        MainMusic.Instance.StopMusic();
    }
}
