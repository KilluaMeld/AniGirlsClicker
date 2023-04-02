using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WrongStep : MonoBehaviour
{
    byte alpha = 255;
    void Start()
    {
        StartCoroutine(destr());
        //«вукЌеудачиЌадо—делать
    }

    public void SetText(string text)
    {
        this.GetComponent<Text>().text = text;
    }
    IEnumerator destr()
    {
        while (alpha >= 30)
        {
            this.gameObject.GetComponent<Text>().color = new Color32(255, 0, 0, alpha);
            alpha -= 30;
            yield return new WaitForSeconds(0.3f);
        }
        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.Translate((new Vector2(0, 1) * Time.deltaTime) * 10);
    }
}
