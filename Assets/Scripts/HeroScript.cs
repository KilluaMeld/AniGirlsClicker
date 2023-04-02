using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
using System;
using System.IO;
using GoogleMobileAds.Api;
using System.Reflection;
using System.Net.Mail;
using TMPro;

public class HeroScript : MonoBehaviour
{
    public int index;
    [SerializeField] float _buyDamage;
    public string nameHero=null;
    public GameObject locked;


    public double lvl;
    public TextMeshProUGUI levelHero;

    public double priceBuyHero;
    public TextMeshProUGUI priceBuyHeroText;
    public double price;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI priceBuyText;

    //public double BeginBaks;
    public double baks;

   // public double BeginDps;
    public double dps;
    public TextMeshProUGUI dpsText;

    [SerializeField] private double prestige;
    public TextMeshProUGUI NameHeroTextMain;


    public double Time_baks;
    public float time;
    public GameObject progressBar;
    public GameObject cam;
    public Game GameScript;
    public GameObject x100;
    public GameObject x10;
    public GameObject x1;
    [SerializeField] private HistoryHero _historyHero;
    [SerializeField] private GameObject _forScript;



    [SerializeField] private GameObject _button;
    [SerializeField] private UnityEngine.Color _colorButton;
    [SerializeField] private UnityEngine.Color _colorButtonDark;

    [SerializeField] public GameObject _secretPanel;
    [SerializeField] public GameObject[] Heros;
    // Start is called before the first frame update
    double Price(double _price)
    {
        return _price * 1.15f;
    }
    double BaksAndDps(double _baks)
    {
        return _baks * 1.13f;
    }
    void CheckSecret()
    {
        
        if (lvl>0 && index!=(Heros.Length)-1)
        {
            Heros[(index)+1].GetComponent<HeroScript>()._secretPanel.SetActive(false);
        }
    }
    public void CheckSave()
    {
        price = Price(priceBuyHero);
        if (lvl > 0)
        {
            dps = _buyDamage; 
            baks = _buyDamage; 
            for (int i = 2; i <= lvl; i++)
            {
                price = Price(price);
                baks = BaksAndDps(baks);
                dps = BaksAndDps(dps);
            }
            UpdateInfoHero();
            CheckSecret();
        }
    }
    void Start()
    {
        priceBuyHeroText.color = new Color32(255,231,0,255);
        priceBuyHeroText.text = $"BUY HERO\n{digitInTextLevel(priceBuyHero)} Gold";
        GameScript = cam.GetComponent<Game>();
        prestige = GameScript.prestige;
        _colorButton = _button.GetComponent<Image>().color;
        progressBar.GetComponent<Image>().color = _colorButton;
        Heros = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().HerosList;
        //priceBuyText.text = $"BUY HERO\n{digitInTextLevel(priceBuyHero)} Gold";
        CheckSave();
    }
    double GetBaksOnBalance()
    {
        return baks + (baks / 100 * GameScript.bonusAtShop[0]) + Time_baks;
    }
    public void UpdateInfoHero()
    {
        GameScript.UpdateInfoDPS();
        priceText.text = "Price: " + digitInTextBalance(price);
        priceBuyHeroText.text = "Buy hero\n" + digitInTextBalance(priceBuyHero);
        levelHero.text = "Level: " + digitInTextLevel(lvl);
        dpsText.text = "DPS: " + digitInTextBalance(dps + (dps / 100 * GameScript.bonusAtShop[2]));
        if (lvl <= 0)
        {
            locked.SetActive(true);
        }
        else
        {
            locked.SetActive(false);
        }
    }
    [SerializeField] private GameObject _buyHeroPrefab;
    [SerializeField] GameObject _parentPanel;
    public void buyHero()
    {
        if (GameScript.balance >= priceBuyHero)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().AchPanel.PlusChests();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(3);
            GameScript.MinusGoldBalance(priceBuyHero);
            lvl++;
            dps = _buyDamage;
            baks = _buyDamage;
            GameObject.FindObjectOfType<Game>().AchPanel.PlusHeros();
            UpdateInfoHero();
            CheckSecret();
            GameObject UnlckPanel = GameObject.Instantiate(_buyHeroPrefab, _parentPanel.transform) as GameObject;
            UnlckPanel.GetComponent<BuyHeroPanel>().SetSprite(this.gameObject.GetComponent<Image>().sprite, locked.GetComponent<Image>().sprite,index, Heros[(index)+1].GetComponent<HeroScript>().locked.GetComponent<Image>().sprite);
        }
        else
        {
            NoGold();
        }
    }
    public void buy1()
    {
        if (GameScript.balance >= price)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(1);
            GameScript.MinusGoldBalance(price);
            price = Price(price);
            baks = BaksAndDps(baks);
            dps = BaksAndDps(dps);
            lvl++;
            UpdateInfoHero();
            Debug.Log("Level: " + lvl + ", Prise: " + price + ", Baks: " + baks + ", Dps: " + dps);
        }
        else
        {
            NoGold();
        }
    }
    void NoGold()
    {
        GameObject ef = GameObject.Instantiate(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().WrongStepPrefab, GameObject.FindGameObjectWithTag("PanelForNewItems").transform) as GameObject;
        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().Language == "ru_RU")
        {
            ef.GetComponent<WrongStep>().SetText($"Не хватает золота");
        }
        else
        {
            ef.GetComponent<WrongStep>().SetText($"Not enough gold");
        }
    }
    [SerializeField] private GameObject _plusBaks;
    [SerializeField] private GameObject _parentLine;
    float times = 0;
    public void FixedUpdate()
    {

        if (lvl > 0)
        {
            times += Time.deltaTime;
            progressBar.GetComponent<Image>().fillAmount = times / time;
            if (times >= time)
            {
                times = 0;
                GameScript.PlusGoldBalance(GetBaksOnBalance());
                GameScript.UpdateBalanceText();
                GameObject ef = GameObject.Instantiate(_plusBaks, _parentLine.transform) as GameObject;
                ef.GetComponent<TextMeshProUGUI>().text = "+" + digitInTextBalance(GetBaksOnBalance());
                ef.GetComponent<RectTransform>().anchoredPosition = new Vector2(40, 0);
            }
            CheckPrice();
        }
    }
    bool Reaady = true;
    public void CheckPrice()
    {

        if (Reaady == true)
        {
            Reaady = false;
            double timePrice = price;


            if (GameScript.balance <= price - 0.001f)
            {
                x1.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
            }
            else
            {
                x1.GetComponent<Image>().color = _colorButton;
            }

        }
        Reaady = true;
    }
    string digitInTextLevel(double digitF)
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
            NotDigit = digitF.ToString("0");
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
            NotDigit = digitF.ToString("0.00");
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

    }
}
