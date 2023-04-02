using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestInShop : MonoBehaviour
{
    [SerializeField] Game GameScript;
    [SerializeField] GiveItems ShopAdmin;

    [SerializeField] int _index;
    [SerializeField] GameObject _image;
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _prise;
    [SerializeField] TextMeshProUGUI _countItemsText;
    [SerializeField] int _countItems;

    [SerializeField] int Chest1Price;
    [SerializeField] int Chest2Price;
    [SerializeField] int Chest3Price;
    [SerializeField] int Chest4Price;
    [SerializeField] int Chest5Price;
    [SerializeField] int Chest6Price;
    [SerializeField] int Chest7Price;
    [SerializeField] int Chest8Price;


    [SerializeField] private GameObject Case;
    [SerializeField] GameObject _chestOpenPrefab;
    [SerializeField] GameObject _parentPanel;
    // Start is called before the first frame update
    void Awake()
    {
        _parentPanel = GameObject.FindGameObjectWithTag("PanelForNewItems");
        GameScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>();
        ShopAdmin = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GiveItems>();
    }


    void SetPotionDiscr(int a)
    {
        if (GameScript.Language == "ru_RU")
        {
            _countItemsText.font = GameScript.RUSFont;

            _countItemsText.text = $"Выпадение {a.ToString()} случайных предметов";
        }
        else
        {
            _countItemsText.font = GameScript.ENGFont;
            _countItemsText.text = $"Drop {a.ToString()} random items";
        }
    }
    void CreateBuyView(Sprite image, int count)
    {
        Case = Instantiate(_chestOpenPrefab, _parentPanel.transform) as GameObject;
        Case.GetComponent<ChestView>().SetInfo(image, count);
    }
    public void SetInfo(int index, string name)
    {
        _index = index;
        _image.GetComponent<Image>().sprite = GameScript.ChestsSprite[index];
        _name.text = name;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(5);

        switch (index)
        {
            case 0:
                _prise.text = digitInTextBalance(Chest1Price);
                SetPotionDiscr(1);
                break;           
            case 1:
                _prise.text = digitInTextBalance(Chest2Price);
                SetPotionDiscr(2);
                break;         
            case 2:
                _prise.text = digitInTextBalance(Chest3Price);
                SetPotionDiscr(3);
                break;          
            case 3:
                _prise.text = digitInTextBalance(Chest4Price);
                SetPotionDiscr(4);
                break;         
            case 4:
                _prise.text = digitInTextBalance(Chest5Price);
                SetPotionDiscr(5);
                break;        
            case 5:
                _prise.text = digitInTextBalance(Chest6Price);
                SetPotionDiscr(6);
                break;
            case 6:
                _prise.text = digitInTextBalance(Chest7Price);
                SetPotionDiscr(7);
                break;
            case 7:
                _prise.text = digitInTextBalance(Chest8Price);
                SetPotionDiscr(8);
                break;

        }
    }
    public void Destr()
    {
        Destroy(this.gameObject);
    }
    public void BuyChest()
    {
        switch (_index)
        {
            case 0: Buy1LevelChest(); break;
            case 1: Buy2LevelChest(); break;
            case 2: Buy3LevelChest(); break;
            case 3: Buy4LevelChest(); break;
            case 4: Buy5LevelChest(); break;
            case 5: Buy6LevelChest(); break;
            case 6: Buy7LevelChest(); break;
            case 7: Buy8LevelChest(); break;
        }
        Destr();
    }
    public void Buy1LevelChest()
    {
        if (GameScript.balanceCrystal >= Chest1Price)
        {
            GameScript.MinusCrystalBalance(Chest1Price);
            ShopAdmin.Chest1(1);
            CreateBuyView(GameScript.ChestsSprite[0], 1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }
    public void Buy2LevelChest()
    {
        if (GameScript.balanceCrystal >= Chest2Price)
        {
            GameScript.MinusCrystalBalance(Chest2Price);
            ShopAdmin.Chest2(1);
            CreateBuyView(GameScript.ChestsSprite[1], 1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }
    public void Buy3LevelChest()
    {
        if (GameScript.balanceCrystal >= Chest3Price)
        {
            GameScript.MinusCrystalBalance(Chest3Price);
            ShopAdmin.Chest3(1);
            CreateBuyView(GameScript.ChestsSprite[2], 1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }
    public void Buy4LevelChest()
    {
        if (GameScript.balanceCrystal >= Chest4Price)
        {
            GameScript.MinusCrystalBalance(Chest4Price);
            ShopAdmin.Chest4(1);
            CreateBuyView(GameScript.ChestsSprite[3], 1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }
    public void Buy5LevelChest()
    {
        if (GameScript.balanceCrystal >= Chest5Price)
        {
            GameScript.MinusCrystalBalance(Chest5Price);
            ShopAdmin.Chest5(1);
            CreateBuyView(GameScript.ChestsSprite[4], 1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }
    public void Buy6LevelChest()
    {
        if (GameScript.balanceCrystal >= Chest6Price)
        {
            GameScript.MinusCrystalBalance(Chest6Price);
            ShopAdmin.Chest6(1);
            CreateBuyView(GameScript.ChestsSprite[5], 1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }
    public void Buy7LevelChest()
    {
        if (GameScript.balanceCrystal >= Chest7Price)
        {
            GameScript.MinusCrystalBalance(Chest7Price);
            ShopAdmin.Chest7(1);
            CreateBuyView(GameScript.ChestsSprite[6], 1);
            //Запустить анимацию
        }
        else
        {
            NoCrystal();
        }
    }
    public void Buy8LevelChest()
    {
        if (GameScript.balanceCrystal >= Chest8Price)
        {
            GameScript.MinusCrystalBalance(Chest8Price);
            ShopAdmin.Chest8(1);
            CreateBuyView(GameScript.ChestsSprite[7], 1);
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
