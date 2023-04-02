using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeroBaksView : MonoBehaviour
{
    byte alpha = 255;
    void Start()
    {
        StartCoroutine(destr());
    }
    IEnumerator destr()
    {
        while (alpha >= 30)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(255, 200, 0, alpha);
            alpha -= 30;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.Translate((new Vector2(0,1) * Time.deltaTime) * 10);
    }
}

