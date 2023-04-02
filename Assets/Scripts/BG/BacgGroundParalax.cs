using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacgGroundParalax : MonoBehaviour
{
    [SerializeField] RectTransform _bg;
    [SerializeField] float _speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //_bg.anchoredPosition = new Vector2(Mathf.Repeat(_speed * Time.time, 360.5f), -Mathf.Repeat(_speed*(569.5f/ 360.5f) * Time.time, 569.5f));
        _bg.anchoredPosition = new Vector2(Mathf.Repeat(_speed * Time.time, 721), -Mathf.Repeat(_speed*(1139.3f/ 721f) * Time.time, 1139.3f));
    }
}
