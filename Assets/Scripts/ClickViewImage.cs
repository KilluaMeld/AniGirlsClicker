using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickViewImage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cam;
    public GameObject clickpanel;
    public Click clickScript;
    public Game GameScript;
    public int speed = 50;
    public Vector3 mousePos;
    public Vector3 randVect;
    public Vector3 mousePosClick;
    byte alpha = 255;
    void Start()
    {
        StartCoroutine(destr());
        randVect = new Vector3(0, 0, 0);
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        clickpanel = GameObject.FindGameObjectWithTag("ClickPanel");
        GameScript = cam.GetComponent<Game>();
        clickScript = clickpanel.GetComponent<Click>();


        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }
    public void Reload()
    {
        randVect = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        this.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        alpha = 255;
        StartCoroutine(destr());
    }
    IEnumerator destr()
    {
        yield return new WaitForSeconds(0.9f);
        while (alpha >= 30)
        {
            this.GetComponent<Image>().color = new Color32(255, 0, 0, alpha);
            alpha -= 30;
            yield return new WaitForSeconds(0.2f);
        }
        //Destroy(thiss);
    }
    void Update()
    {
        transform.Translate((randVect * Time.deltaTime) * 10);
    }
}
