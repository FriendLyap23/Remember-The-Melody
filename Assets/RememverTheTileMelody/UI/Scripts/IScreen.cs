using UnityEngine;

public interface IScreen
{
    public GameObject _screen { get; set; }

    public void ToggleScreen(bool enable);
}
