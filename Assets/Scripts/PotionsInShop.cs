using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotionsInShop : MonoBehaviour
{
    [SerializeField] Game GameScript;
    [SerializeField] GiveItems ShopAdmin;
    [SerializeField] BuyAnimation AnimationShop;

    [SerializeField] int _index;
    [SerializeField] GameObject _image;
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _prise;
    [SerializeField] TextMeshProUGUI _descriptionText;

    [SerializeField] int lvl1SpeedPrice;
    [SerializeField] int lvl2SpeedPrice;
    [SerializeField] int lvl3SpeedPrice;
    [SerializeField] int lvl4SpeedPrice;

    [SerializeField] int lvl1GoldPrice;
    [SerializeField] int lvl2GoldPrice;
    [SerializeField] int lvl3GoldPrice;
    [SerializeField] int lvl4GoldPrice;

    [SerializeField] int lvl1AutoClickPrice;
    [SerializeField] int lvl2AutoClickPrice;
    [SerializeField] int lvl3AutoClickPrice;
    [SerializeField] int lvl4AutoClickPrice;


    [SerializeField] private GameObject Case;
    [SerializeField] GameObject _chestOpenPrefab;
    [SerializeField] GameObject _parentPanel;
    // Start is called before the first frame update
    void Awake()
    {
        _parentPanel = GameObject.FindGameObjectWithTag("PanelForNewItems");
        GameScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>();
        ShopAdmin = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GiveItems>();
      //  AnimationShop = this.gameObject.GetComponent<BuyAnimation>();
    }

    void CreateBuyView(Sprite image, int count)
    {
        Case = Instantiate(_chestOpenPrefab, _parentPanel.transform) as GameObject;
        Case.GetComponent<ChestView>().SetInfo(image, count);
    }
    public void SetInfo(int index, string name)
    {
        _index = index;
        _image.GetComponent<Image>().sprite = GameScript.PotionsSprite[index];
        _name.text = name;
        if (GameScript.Language == "ru_RU")
        {
            _descriptionText.font = GameScript.RUSFont;
        }
        else
        {
            _descriptionText.font = GameScript.ENGFont;
        }
        _descriptionText.text = GameObject.FindObjectOfType<TranslateMeneger>().GetPotionsTranslate(index,1);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(5);

        switch (index)
        {
            case 0:
                _prise.text = digitInTextBalance(lvl1SpeedPrice);
                break;
            case 1:
                _prise.text = digitInTextBalance(lvl2SpeedPrice);
                break;
            case 2:
                _prise.text = digitInTextBalance(lvl3SpeedPrice);
                break;
            case 3:
                _prise.text = digitInTextBalance(lvl4SpeedPrice);
                break;
            case 4:
                _prise.text = digitInTextBalance(lvl1GoldPrice);
                break;
            case 5:
                _prise.text = digitInTextBalance(lvl2GoldPrice);
                break;
            case 6:
                _prise.text = digitInTextBalance(lvl3GoldPrice);
                break;
            case 7:
                _prise.text = digitInTextBalance(lvl4GoldPrice);
                break;
            case 8:
                _prise.text = digitInTextBalance(lvl1AutoClickPrice);
                break;
            case 9:
                _prise.text = digitInTextBalance(lvl2AutoClickPrice);
                break;
            case 10:
                _prise.text = digitInTextBalance(lvl3AutoClickPrice);
                break;
            case 11:
                _prise.text = digitInTextBalance(lvl4AutoClickPrice);
                break;

        }
    }
    public void Destr()
    {
        Destroy(this.gameObject);
    }
    public void BuyPotion()
    {
        switch (_index)
        {
            case 0: Buy1LevelSpeed(); break;
            case 1: Buy2LevelSpeed(); break;
            case 2: Buy3LevelSpeed(); break;
            case 3: Buy4LevelSpeed(); break;
            case 4: Buy1LevelGold(); break;
            case 5: Buy2LevelGold(); break;
            case 6: Buy3LevelGold(); break;
            case 7: Buy4LevelGold(); break;
            case 8: Buy1LevelAutoClick(); break;
            case 9: Buy2LevelAutoClick(); break;
            case 10: Buy3LevelAutoClick(); break;
            case 11: Buy4LevelAutoClick(); break;
        }
        Destr();
    }
    public void Buy1LevelSpeed()
    {
        if (GameScript.balanceCrystal >= lvl1SpeedPrice)
        {
            GameScript.MinusCrystalBalance(lvl1SpeedPrice); 
            ShopAdmin.SpeedPotion1Level(1);

            CreateBuyView(GameScript.PotionsSprite[0], 1);

            // AnimationShop
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }
    public void Buy2LevelSpeed()
    {
        if (GameScript.balanceCrystal >= lvl2SpeedPrice)
        {
            GameScript.MinusCrystalBalance(lvl2SpeedPrice); 
            ShopAdmin.SpeedPotion2Level(1);
            CreateBuyView(GameScript.PotionsSprite[1], 1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }
    public void Buy3LevelSpeed()
    {
        if (GameScript.balanceCrystal >= lvl3SpeedPrice)
        {
            GameScript.MinusCrystalBalance(lvl3SpeedPrice); 
            ShopAdmin.SpeedPotion3Level(1);
            CreateBuyView(GameScript.PotionsSprite[2], 1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }
    public void Buy4LevelSpeed()
    {
        if (GameScript.balanceCrystal >= lvl4SpeedPrice)
        {
            GameScript.MinusCrystalBalance(lvl4SpeedPrice); 
            CreateBuyView(GameScript.PotionsSprite[3], 1);
            ShopAdmin.SpeedPotion4Level(1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }

    public void Buy1LevelGold()
    {
        if (GameScript.balanceCrystal >= lvl1GoldPrice)
        {
            GameScript.MinusCrystalBalance(lvl1GoldPrice); 
            ShopAdmin.BaksPotion1Level(1);
            CreateBuyView(GameScript.PotionsSprite[4], 1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }
    public void Buy2LevelGold()
    {
        if (GameScript.balanceCrystal >= lvl2GoldPrice)
        {
            GameScript.MinusCrystalBalance(lvl2GoldPrice); 
            ShopAdmin.BaksPotion2Level(1);
            CreateBuyView(GameScript.PotionsSprite[5], 1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }
    public void Buy3LevelGold()
    {
        if (GameScript.balanceCrystal >= lvl3GoldPrice)
        {
            GameScript.MinusCrystalBalance(lvl3GoldPrice); 
            ShopAdmin.BaksPotion3Level(1);
            CreateBuyView(GameScript.PotionsSprite[6], 1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }
    public void Buy4LevelGold()
    {
        if (GameScript.balanceCrystal >= lvl4GoldPrice)
        {
            GameScript.MinusCrystalBalance(lvl4GoldPrice); 
            ShopAdmin.BaksPotion4Level(1);
            CreateBuyView(GameScript.PotionsSprite[7], 1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }


    public void Buy1LevelAutoClick()
    {
        if (GameScript.balanceCrystal >= lvl1AutoClickPrice)
        {
            GameScript.MinusCrystalBalance(lvl1AutoClickPrice); 
            ShopAdmin.AutiClickPotion1Level(1);
            CreateBuyView(GameScript.PotionsSprite[8], 1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }
    public void Buy2LevelAutoClick()
    {
        if (GameScript.balanceCrystal >= lvl2AutoClickPrice)
        {
            GameScript.MinusCrystalBalance(lvl2AutoClickPrice); 
            ShopAdmin.AutiClickPotion2Level(1);
            CreateBuyView(GameScript.PotionsSprite[9], 1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }
    public void Buy3LevelAutoClick()
    {
        if (GameScript.balanceCrystal >= lvl3AutoClickPrice)
        {
            GameScript.MinusCrystalBalance(lvl3AutoClickPrice); 
            ShopAdmin.AutiClickPotion3Level(1);
            CreateBuyView(GameScript.PotionsSprite[10], 1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }
    public void Buy4LevelAutoClick()
    {
        if (GameScript.balanceCrystal >= lvl4AutoClickPrice)
        {
            GameScript.MinusCrystalBalance(lvl4AutoClickPrice); 
            ShopAdmin.AutiClickPotion4Level(1);
            CreateBuyView(GameScript.PotionsSprite[11], 1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
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
    void NoCrystal()
    {
        GameObject ef = GameObject.Instantiate(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().WrongStepPrefab, GameObject.FindGameObjectWithTag("PanelForNewItems").transform) as GameObject;
        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().Language == "ru_RU")
        {
            ef.GetComponent<WrongStep>().SetText($"Нехватает кристалов");
        }
        else
        {
            ef.GetComponent<WrongStep>().SetText($"Not enough crystals");
        }
    }
}
