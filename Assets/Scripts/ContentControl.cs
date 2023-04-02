using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentControl : MonoBehaviour
{
    [SerializeField] RectTransform[] _panelListRectTransform;
    void Start()
    {
        RectTransform thisRect = this.GetComponent<RectTransform>();
        thisRect.sizeDelta = new Vector2(thisRect.sizeDelta.x, 10);
        for (int i = 0; i < _panelListRectTransform.Length; i++)
        {
            thisRect.sizeDelta = new Vector2(thisRect.sizeDelta.x, thisRect.sizeDelta.y + _panelListRectTransform[i].sizeDelta.y +15);
        }
    }
}
