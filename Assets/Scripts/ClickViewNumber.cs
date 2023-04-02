using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickViewNumber : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI count;
    public GameObject cam;
    public GameObject clickpanel;
    public Click clickScript;
    public Game GameScript;
    public GameObject thiss;
    public int speed=50;
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


        thiss.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
    }
    public void Reload()
    {
        randVect = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
        thiss.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        count.text = digitInTextBalance(GameScript.getAllDps());
        thiss.GetComponent<TextMeshProUGUI>().color = new Color32(255, 0, 0, 255);
        alpha = 255;
        StartCoroutine(destr());
    }
    IEnumerator destr()
    {
        yield return new WaitForSeconds(0.9f);
        while (alpha >= 30)
        {
            thiss.GetComponent<TextMeshProUGUI>().color = new Color32(255, 0, 0, alpha);
            alpha -= 30;
            yield return new WaitForSeconds(0.2f);
        }
        //Destroy(thiss);
    }
    string digitInTextBalance(double digitF)
    {
        /*
K	Thousand	Тысяча	
M	Million	    Миллион	
B	Billion	    Миллиард	
T	Trillion	Триллион	
q	Quadrillion	Квадриллион	
Q	Quintillion	Квинтиллион	
s	Sextillion	Сикстиллион	
S	Septillion	Септиллион	
O	Octillion	Октиллион	
N	Nonillion	Нониллион	
d	Decillion	Дециллион

         */
        double d1000 = 1000;
        double d1000000 = 1000000;
        double d1000000000 = 1000000000;
        double d1000000000000 = 1000000000000;
        double d1000000000000000 = 1000000000000000;
        double d1000000000000000000 = 1000000000000000000;
        double notDigit;
        string NotDigit = "notwork";
        if (digitF < d1000)
        {
            NotDigit = digitF.ToString("0.0");
        }
        else if (digitF < 1000000)
        {
            notDigit = digitF / d1000;
            NotDigit = notDigit.ToString("0.000") + "K";
        }
        else if (digitF < 1000000000)
        {
            notDigit = digitF / d1000000;
            NotDigit = notDigit.ToString("0.000") + "M";
        }
        else if (digitF < 1000000000000)
        {
            notDigit = digitF / d1000000000;
            NotDigit = notDigit.ToString("0.000") + "B";
        }
        else if (digitF < 1000000000000000)
        {
            notDigit = digitF / d1000000000000;
            NotDigit = notDigit.ToString("0.000") + "T";
        }
        else if (digitF < 1000000000000000000)
        {
            notDigit = digitF / d1000000000000000;
            NotDigit = notDigit.ToString("0.000") + "q";
        }
        else if (digitF < d1000000000000000000 * 1000)
        {
            notDigit = digitF / 1000000000000000000;
            NotDigit = notDigit.ToString("0.000") + "Q";
        }
        else if (digitF < d1000000000000000000 * 1000000)
        {
            notDigit = digitF / (d1000000000000000000 * 1000);
            NotDigit = notDigit.ToString("0.000") + "s";
        }
        else if (digitF < d1000000000000000000 * 1000000000)
        {
            notDigit = digitF / (d1000000000000000000 * 1000000);
            NotDigit = notDigit.ToString("0.000") + "S";
        }
        else if (digitF < d1000000000000000000 * 1000000000000)
        {
            notDigit = digitF / (d1000000000000000000 * 1000000000);
            NotDigit = notDigit.ToString("0.000") + "O";
        }
        else if (digitF < d1000000000000000000 * d1000000000000000)
        {
            notDigit = digitF / (d1000000000000000000 * d1000000000000);
            NotDigit = notDigit.ToString("0.000") + "N";
        }
        else if (digitF < d1000000000000000000 * d1000000000000000000)
        {
            notDigit = digitF / (d1000000000000000000 * d1000000000000000);
            NotDigit = notDigit.ToString("0.000") + "d";
        }
        return NotDigit;
    }
    // Update is called once per frame

    void Update()
    {
        transform.Translate((randVect*Time.deltaTime)*10);
    }
}
