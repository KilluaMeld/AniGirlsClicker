using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyAnimation : MonoBehaviour
{
    byte alpha = 255;
    void Start()
    {
        StartCoroutine(destr());
    }
    public void SetPicture(Sprite picture)
    {
        this.gameObject.GetComponent<Image>().sprite = picture;
    }
    IEnumerator destr()
    {

        while (alpha >= 30)
        {
            this.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, alpha);
            alpha -= 30;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.Translate((GameObject.FindGameObjectWithTag("Inventory").transform.position * Time.deltaTime) * 10);
    }

}
