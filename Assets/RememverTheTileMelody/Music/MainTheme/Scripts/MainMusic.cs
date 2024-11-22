using UnityEngine;
using UnityEngine.UI;

public class MainMusic : MonoBehaviour
{
    public static MainMusic Instance { get; private set; }

    [SerializeField] private AudioSource _mainThemeSource;

    [SerializeField] private Image _image;
    [SerializeField] private Sprite _musicOffSprite;
    [SerializeField] private Sprite _musicOnSprite;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        PlayMusic();
    }

    public void ToggleMusic()
    {
        if (_mainThemeSource.isPlaying)
        {
            StopMusic();
            _image.sprite = _musicOffSprite;
        }
        else 
        {
            PlayMusic();
            _image.sprite = _musicOnSprite;
        }
    }

    public void StopMusic() 
    {
        _mainThemeSource.Stop();
    }

    public void PlayMusic() 
    {
        if (!_mainThemeSource.isPlaying)
            _mainThemeSource.Play();
    }
}
