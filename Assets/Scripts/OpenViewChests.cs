using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class OpenViewChests : MonoBehaviour
{
    [SerializeField] private GameObject _itemImage;
    [SerializeField] private TextMeshProUGUI _countItem;

    public void SetInfo(Sprite image, int count)
    {
        _itemImage.GetComponent<Image>().sprite = image;
        _countItem.GetComponent<TextMeshProUGUI>().text = digitInTextBalance(Convert.ToDouble(count));
    }
    public void SetInfo(Sprite image)
    {
        _itemImage.GetComponent<Image>().sprite = image;
        _countItem.GetComponent<TextMeshProUGUI>().color = new Color32(0, 0, 0, 0);
    }
    public void SetInfo(Sprite image, string text)
    {
        _itemImage.GetComponent<Image>().sprite = image;
        _countItem.GetComponent<TextMeshProUGUI>().text = text;
    }
    public void SetInfo(Image image, string text)
    {
        _itemImage.GetComponent<Image>().sprite = image.sprite;
        _itemImage.GetComponent<Image>().color = image.color;
        _countItem.GetComponent<TextMeshProUGUI>().text = text;
    }


    public void SeletePanel()
    {
        GameObject.FindObjectOfType<OpenChest>().NextStep = true;
        Destroy(this.gameObject);
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
            if (digitF % 2 == 0)
            {
                NotDigit = digitF.ToString("0");
            }
            else
            {
                NotDigit = digitF.ToString("0");
            }
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
}
