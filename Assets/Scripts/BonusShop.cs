using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BonusShop : MonoBehaviour
{
    [SerializeField] Game GameScript;
    [SerializeField] GiveItems ShopAdmin;
    [SerializeField] GameObject[] Heroes;
    [SerializeField] HeroScript[] HeroesScript;
    [SerializeField] double _bonusGoldPrice;
    [SerializeField] GameObject _fillPanelGold;
    [SerializeField] TextMeshProUGUI _fillPanelTextGold;
    [SerializeField] TextMeshProUGUI _priceGold;
    [SerializeField] TextMeshProUGUI _bonusGold;
    [SerializeField] GameObject _bonusGoldPriceAndPlus;
    [SerializeField] GameObject _bonusGoldButton;

    [SerializeField] double _bonusSpeedPrice;
    [SerializeField] GameObject _fillPanelSpeed;
    [SerializeField] TextMeshProUGUI _fillPanelTextSpeed;
    [SerializeField] TextMeshProUGUI _priceSpeed;
    [SerializeField] TextMeshProUGUI _bonusSpeed;
    [SerializeField] GameObject _bonusSpeedPriceAndPlus;
    [SerializeField] GameObject _bonusSpeedButton;

    [SerializeField] double _bonusDMGPrice;
    [SerializeField] GameObject _fillPanelDMG;
    [SerializeField] TextMeshProUGUI _fillPanelTextDMG;
    [SerializeField] TextMeshProUGUI _priceDMG;
    [SerializeField] TextMeshProUGUI _bonusDMG;
    [SerializeField] GameObject _bonusDMGPriceAndPlus;
    [SerializeField] GameObject _bonusDMGButton;

    [SerializeField] SoundsManager _sm; 
    // Start is called before the first frame update
    void Start()
    {
        _sm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>();
        GameScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>();
        ShopAdmin = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GiveItems>();
        Heroes = GameObject.FindGameObjectsWithTag("Hero");
        HeroesScript = new HeroScript[Heroes.Length];
        for(int i = 0; i < Heroes.Length; i++)
        {
            HeroesScript[i] = Heroes[i].GetComponent<HeroScript>();
        }


        _fillPanelTextGold.text = GameScript.bonusLevel[0] + "/10";
        _fillPanelTextSpeed.text = GameScript.bonusLevel[1] + "/10";
        _fillPanelTextDMG.text = GameScript.bonusLevel[2] + "/10";

        _priceGold.text = digitInTextBalance(_bonusGoldPrice);
        _priceSpeed.text = digitInTextBalance(_bonusSpeedPrice);
        _priceDMG.text = digitInTextBalance(_bonusDMGPrice);

        _bonusGold.text = "+" + GameScript.bonusLevel[0].ToString() + "%";
        _bonusSpeed.text = (3 - GameScript.bonusLevel[1]).ToString() + "/3 Sec";
        _bonusDMG.text = "+" + GameScript.bonusLevel[2].ToString() + "%";

        _fillPanelGold.GetComponent<Image>().fillAmount = 0;
        _fillPanelSpeed.GetComponent<Image>().fillAmount = 0;
        _fillPanelDMG.GetComponent<Image>().fillAmount = 0;
        CheckSave();




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
    void CheckSave()
    {
        int lvlGold = GameScript.bonusLevel[0];
        int lvlSpeed = GameScript.bonusLevel[1];
        int lvlDMG = GameScript.bonusLevel[2];

        if (lvlGold > 0)
        {
            for (int i = 0; i < lvlGold; i++)
            {
                _bonusGoldPrice = _bonusGoldPrice * 1.1f;
                GameScript.bonusAtShop[0] += 5;
                _bonusGold.text = "+" + GameScript.bonusAtShop[0].ToString() + "%";
                _priceGold.text = digitInTextBalance(_bonusGoldPrice);
                _fillPanelGold.GetComponent<Image>().fillAmount += 0.1f;
            }
            if (GameScript.bonusLevel[0] >= 10)
            {
                _bonusGoldPriceAndPlus.SetActive(false);
                _bonusGoldButton.SetActive(false);

            }
        }

        if (lvlSpeed > 0)
        {
            for (int i = 0; i < lvlSpeed; i++)
            {
                _bonusSpeedPrice = _bonusSpeedPrice * 1.1f;
                GameScript.bonusAtShop[1] += 0.15f;
                _bonusSpeed.text = (3 - GameScript.bonusAtShop[1]).ToString() + "/3 Sec";
                _priceSpeed.text = digitInTextBalance(_bonusSpeedPrice);
                _fillPanelSpeed.GetComponent<Image>().fillAmount += 0.1f;
                if (GameObject.FindGameObjectWithTag("PotionsController").GetComponent<PotionsController>()._activePotions_Speed == false)
                {
                    for (int qwe = 0; qwe < HeroesScript.Length; qwe++)
                    {
                        HeroesScript[qwe].time -= 0.15f;
                    }
                }
            }
            if (GameScript.bonusLevel[1] >= 10)
            {
                _bonusSpeedPriceAndPlus.SetActive(false);
                _bonusSpeedButton.SetActive(false);
            }
        }

        if (lvlDMG > 0)
        {
            for (int i = 0; i < lvlDMG; i++)
            {
                _bonusDMGPrice = _bonusDMGPrice * 1.1f;
                GameScript.bonusAtShop[2] += 5;
                _bonusDMG.text = "+" + GameScript.bonusAtShop[2].ToString() + "%";
                _priceDMG.text = digitInTextBalance(_bonusDMGPrice);
                _fillPanelDMG.GetComponent<Image>().fillAmount += 0.1f;
                GameScript.UpdateInfoDPS();
            }
            if (GameScript.bonusLevel[2] >= 10)
            {
                _bonusDMGPriceAndPlus.SetActive(false);
                _bonusDMGButton.SetActive(false);
            }
        }
    }
    public void GoldBonus()
    {
        if (GameScript.bonusLevel[0] < 10)
        {
            if (GameScript.balanceCrystal >= _bonusGoldPrice)
            {
                GameScript.balanceCrystal -= _bonusGoldPrice;
                _sm.PlaySound(1);
                _bonusGoldPrice = _bonusGoldPrice * 1.1f;
                GameScript.bonusLevel[0]++;
                GameScript.bonusAtShop[0] += 5;
                _bonusGold.text = "+" + GameScript.bonusAtShop[0].ToString() + "%";
                _priceGold.text = digitInTextBalance(_bonusGoldPrice);
                _fillPanelGold.GetComponent<Image>().fillAmount += 0.1f;
                _fillPanelTextGold.text = GameScript.bonusLevel[0] + "/10";
                if (GameScript.bonusLevel[0] >= 10)
            {
                _bonusGoldPriceAndPlus.SetActive(false);
                    _bonusGoldButton.SetActive(false);
                }
        }
            else
            {
                NoCrystal();
            }
        }
    }

    public void SpeedBonus()
    {
        if (GameScript.bonusLevel[1] < 10)
        {
            if (GameScript.balanceCrystal >= _bonusSpeedPrice)
            {
                GameScript.balanceCrystal -= _bonusSpeedPrice;
                _sm.PlaySound(1);
                _bonusSpeedPrice = _bonusSpeedPrice * 1.1f;
                GameScript.bonusLevel[1]++;
                GameScript.bonusAtShop[1] += 0.15f;
                _bonusSpeed.text = (3 - GameScript.bonusAtShop[1]).ToString() + "/3 Sec";
                _priceSpeed.text = digitInTextBalance(_bonusSpeedPrice);
                _fillPanelSpeed.GetComponent<Image>().fillAmount += 0.1f;
                _fillPanelTextSpeed.text = GameScript.bonusLevel[1] + "/10";
                if (GameObject.FindGameObjectWithTag("PotionsController").GetComponent<PotionsController>()._activePotions_Speed == false)
                {
                    for (int qwe = 0; qwe < HeroesScript.Length; qwe++)
                    {
                        HeroesScript[qwe].time -= 0.15f;
                    }
                }
                if (GameScript.bonusLevel[1] >= 10)
                {
                    _bonusSpeedPriceAndPlus.SetActive(false);
                    _bonusSpeedButton.SetActive(false);
                }
            }
            else
            {
                NoCrystal();
            }
        }
    }
    public void DMGBonus()
    {
        if (GameScript.bonusLevel[2] < 10)
        {
            if (GameScript.balanceCrystal >= _bonusDMGPrice)
            {
                GameScript.balanceCrystal -= _bonusDMGPrice;
                _sm.PlaySound(1);
                _bonusDMGPrice = _bonusDMGPrice * 1.1f;
                GameScript.bonusLevel[2]++;
                GameScript.bonusAtShop[2] += 5;
                _bonusDMG.text = "+" + GameScript.bonusAtShop[2].ToString() + "%";
                _priceDMG.text = digitInTextBalance(_bonusDMGPrice);
                _fillPanelDMG.GetComponent<Image>().fillAmount += 0.1f;
                _fillPanelTextDMG.text = GameScript.bonusLevel[2] + "/10";
                if (GameScript.bonusLevel[2] >= 10)
                {
                    _bonusDMGPriceAndPlus.SetActive(false);
                    _bonusDMGButton.SetActive(false);
                }
                GameScript.UpdateInfoDPS();
                for(int i =0;i< Heroes.Length; i++)
                {
                    Heroes[i].GetComponent<HeroScript>().UpdateInfoHero();
                }
            }
            else
            {
                NoCrystal();
            }
        }
    }

    public void BuyPremium()
    {
        ShopAdmin.BaksPotion4Level(2);
        CreateBuyView(GameScript.PotionsSprite[7], 2);

        ShopAdmin.AutiClickPotion4Level(2);
        CreateBuyView(GameScript.PotionsSprite[11], 2);

        ShopAdmin.SpeedPotion4Level(2);
        CreateBuyView(GameScript.PotionsSprite[3], 2);
        ShopAdmin.Chest8(2);
        CreateBuyView(GameScript.ChestsSprite[7], 2);
        GameScript.Status = 1;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Ads>().DestrBanner();
        _SpeshialPanel.GetComponent<DestroyPremium>().DestroyPanel();
        Debug.Log(this.GetComponent<RectTransform>().sizeDelta);
       // this.GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<RectTransform>().sizeDelta.x, this.GetComponent<RectTransform>().sizeDelta.y-_SpeshialPanel.GetComponent<RectTransform>().sizeDelta.y);
    }
    [SerializeField] GameObject _chestOpenPrefab;
    [SerializeField] GameObject _parentPanel;
    [SerializeField] GameObject _SpeshialPanel;
    void CreateBuyView(Sprite image, int count)
    {
        GameObject View = Instantiate(_chestOpenPrefab, _parentPanel.transform) as GameObject;
        View.GetComponent<ChestView>().SetInfo(image, count);
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
}
