using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPurchases : MonoBehaviour
{
    [SerializeField] private Image _currentSelects;

    [SerializeField] private List<Image> _selects;

    public void SelectedShow(GameObject currentObject)
    {
        _currentSelects.gameObject.SetActive(true);

        for (int i = 0; i < _selects.Count; i++)
            _selects[i].gameObject.SetActive(false);
    }

    public void UpdateUI(bool isSelected)
    {
        _currentSelects.gameObject.SetActive(isSelected);
    }
}
