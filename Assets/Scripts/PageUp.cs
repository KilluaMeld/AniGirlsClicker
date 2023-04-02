using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageUp : MonoBehaviour
{
    [SerializeField] RectTransform _contentRect;
    [SerializeField] GameObject _buttonOnUp;
    public void CheckContent()
    {
        if(_contentRect.anchoredPosition.y > 1000)
        {
            _buttonOnUp.SetActive(true);
        }
        else
        {
            _buttonOnUp.SetActive(false);
        }
    }
    public void SetContent()
    {
        _contentRect.anchoredPosition = new Vector2(0, 0);
    }
}
