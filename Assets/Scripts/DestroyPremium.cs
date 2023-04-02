using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPremium : MonoBehaviour
{
    [SerializeField] GameObject ScrollPanel;
    void Start()
    {
        DestroyPanel();
    }
    public void DestroyPanel()
    {
        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().Status == 1)
        {
            ScrollPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(ScrollPanel.GetComponent<RectTransform>().sizeDelta.x, ScrollPanel.GetComponent<RectTransform>().sizeDelta.y - this.gameObject.GetComponent<RectTransform>().sizeDelta.y);
            Destroy(this.gameObject);
        }
    }
}
