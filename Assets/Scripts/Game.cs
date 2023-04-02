using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Random = System.Random;
using System;
using System.IO;
using GoogleMobileAds.Api;
using System.Reflection;
using System.Net.Mail;
using TMPro;
using System;
using System.IO;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    public bool FirstLoadGame = true;

    [Header("Sprites")]
    public Sprite[] PotionsSprite;
    public Sprite[] ChestsSprite;
    public Sprite[] GoldSprite;
    public Sprite[] CrystalSprite;
    public GameObject[] HerosList;
    public GameObject[] BossList;

    public AchiveStatistic AchPanel;

    public int Status = 1; // 0 - Defoult, 1 - Vip;
    public double prestige;
    [Header("Баланс золота")]
    public double balance;
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI perSecText;
    [Header("Баланс Кристалов")]
    public double balanceCrystal;
    public TextMeshProUGUI balanceCrystalText;
    [Header("DPS")]
    [SerializeField] private float _noviceDPS;
    public double AllDps;
    public TextMeshProUGUI dpsTextBox;
    [Header("Левел")]
    public double levelProgress = 0;
    public double onNextLevelProgress = 1000;
    public double level = 1;
    public GiveItemForLevel[] listPriseForLevel;
    public bool[] listTakesPriseForLevel;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI onNextLevelText;
    public GameObject levelLine;
    [Header("Инвентарь")]
    public int[] potions = new int[12];
    public int[] chests = new int[8];


    [Header("Saves")]
    [SerializeField] public double[] HeroSaveLevel;
    public int[] bonusLevel = new int[3];

    public float[] bonusAtShop = new float[3];

    public bool ChooseStar = true;


    public string Language = "";
    public TMP_FontAsset RUSFont;
    public TMP_FontAsset ENGFont;
    public GameObject WrongStepPrefab;
    public GameObject _LanguageFirstOpenPrefab;
    public GameObject _parentPanel;
    [Header("Colors")]
    public bool[] GameTheme = new bool[6];
    public int CurGameTheme = 0;

    public bool[] ClickSkin;
    public Sprite[] ClickSkinSprite;
    public int CurClickSkin = 0;

    public bool[] BackMoveSkin;
    public Sprite[] BackMoveSkinSprite;
    public int CurBackMoveSkin = 0;

    public Save sv = new Save();

    private void Awake()
    {
        HeroSaveLevel = new double[HerosList.Length];
        //Debug.Log(HerosList.Length);
        //Debug.Log(HeroSaveLevel.Length);
        if (PlayerPrefs.HasKey("AppSave"))
        {
            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("AppSave"));
            Status = sv.Status;
            prestige = sv.prestige;
            balance = sv.balance;
            balanceCrystal = sv.balanceCrystal;
            levelProgress = sv.levelProgress;
            onNextLevelProgress = sv.onNextLevelProgress;
            level = sv.level;
            potions = sv.potions;
            chests = sv.chests;
            HeroSaveLevel = sv.HeroSaveLevel;
            Language = sv.Language;
            ChooseStar = sv.ChooseStar;
            for (int i = 0; i < HerosList.Length; i++)
            {
                HerosList[i].GetComponent<HeroScript>().lvl = HeroSaveLevel[i];
            }
            bonusLevel = sv.bonusLevel;
            this.gameObject.GetComponent<SoundsManager>().MusicToggle = sv.MusicToggle;
            this.gameObject.GetComponent<SoundsManager>().SoundToggle = sv.SoundToggle;
            this.gameObject.GetComponent<SoundsManager>().PlaySong();


            AchPanel._potionsAchive_CountUse = sv._potionsAchive_CountUse;
            AchPanel._potionsAchive_Bool_ForDelete = sv._potionsAchive_Bool_ForDelete;
            AchPanel._potionsAchive_Bool_CompliteAchive = sv._potionsAchive_Bool_CompliteAchive;

            AchPanel._chestsAchive_CountUse = sv._chestsAchive_CountUse;
            AchPanel._chestsAchive_Bool_ForDelete = sv._chestsAchive_Bool_ForDelete;
            AchPanel._chestsAchive_Bool_CompliteAchive = sv._chestsAchive_Bool_CompliteAchive;

            AchPanel._clicksAchive_CountUse = sv._clicksAchive_CountUse;
            AchPanel._clicksAchive_Bool_ForDelete = sv._clicksAchive_Bool_ForDelete;
            AchPanel._clicksAchive_Bool_CompliteAchive = sv._clicksAchive_Bool_CompliteAchive;

            AchPanel._heroesAchive_CountUse = sv._heroesAchive_CountUse;
            AchPanel._heroesAchive_Bool_ForDelete = sv._heroesAchive_Bool_ForDelete;
            AchPanel._heroesAchive_Bool_CompliteAchive = sv._heroesAchive_Bool_CompliteAchive;


            listTakesPriseForLevel = sv.listTakesPriseForLevel;
            for (int i = 0; i < listPriseForLevel.Length; i++)
            {
                listPriseForLevel[i].TakeItem = listTakesPriseForLevel[i];
                listPriseForLevel[i].checkPrise();
            }

                GameTheme = sv.GameTheme;
                CurGameTheme= sv.CurGameTheme;

                ClickSkin = sv.ClickSkin;
                CurClickSkin = sv.CurClickSkin;



}
        if (Language =="")
        {
            GameObject.Instantiate(_LanguageFirstOpenPrefab, _parentPanel.transform);
        }

        GameObject.FindObjectOfType<GameTheme>().CheckHaveColor();
        GameObject.FindObjectOfType<GameTheme>().ChangeColor(CurGameTheme);
        GameObject.FindObjectOfType<ClickSkinChange>().CheckHaveColor();
        GameObject.FindObjectOfType<ClickSkinChange>().ChangeColor(CurClickSkin);

        afk();

        //Первый запуск игры
        if (FirstLoadGame == true)
        {

            //this.GetComponent<InAppManager.InAppManager>().RestorePurchases();
            FirstLoadGame = false;

        }
    }
    void afk()
    {
        int d = 0, h = 0, m = 0, s = 0;
        Debug.Log(DateTime.Now);
        DateTime dr = new DateTime(2001, 12, 26, 12, 30, 00);
        DateTime now = DateTime.Now;
        TimeSpan proshlo = now.Subtract(dr);
        d = proshlo.Days;
        h += d * 24;
        h += proshlo.Minutes;
        s += h * 60;
        s += proshlo.Seconds;
        int mil = s * 1000000;


    }


#if !UNITY_EDITOR
    private void OnApplicationPause(){
        for (int i = 0; i < HerosList.Length; i++)
        {
            HeroSaveLevel[i] = HerosList[i].GetComponent<HeroScript>().lvl;
        }
        listTakesPriseForLevel = new bool[listPriseForLevel.Length];
        for (int i = 0; i < listPriseForLevel.Length; i++)
        {
            listTakesPriseForLevel[i] = listPriseForLevel[i].TakeItem;
        }
        Save();
    }
#endif
    private void OnApplicationQuit()
    {
        for (int i = 0; i < HerosList.Length; i++)
        {
            HeroSaveLevel[i] = HerosList[i].GetComponent<HeroScript>().lvl;
            //Debug.Log(HeroSaveLevel[i]);
            //Debug.Log(HerosList[i].GetComponent<HeroScript>().lvl);
        }
        listTakesPriseForLevel = new bool[listPriseForLevel.Length];
        for (int i = 0; i < listPriseForLevel.Length; i++)
        {
            listTakesPriseForLevel[i] = listPriseForLevel[i].TakeItem;
        }
        Save();
    }
    public void MinusGoldBalance(double count)
    {
        balance -= count;
        UpdateBalanceText();
    }
    public void PlusGoldBalance(double count)
    {
        balance += count;
        UpdateBalanceText();
    }
    public void MinusCrystalBalance(double count)
    {
        balanceCrystal -= count;
        UpdateBalanceText();
    }
    public void PlusCrystalBalance(double count)
    {
        balanceCrystal += count;
        UpdateBalanceText();
    }
    private void Save()
    {
        sv.Status = Status;
        sv.prestige = prestige;
        sv.balance = balance;
        sv.balanceCrystal = balanceCrystal;
        sv.levelProgress = levelProgress;
        sv.onNextLevelProgress = onNextLevelProgress;
        sv.level = level;
        sv.potions = potions;
        sv.chests = chests;
        sv.HeroSaveLevel = HeroSaveLevel;
        sv.bonusLevel = bonusLevel;
        sv.MusicToggle = this.gameObject.GetComponent<SoundsManager>().MusicToggle;
        sv.SoundToggle = this.gameObject.GetComponent<SoundsManager>().SoundToggle;

        sv._potionsAchive_CountUse = AchPanel._potionsAchive_CountUse;
        sv._potionsAchive_Bool_ForDelete = AchPanel._potionsAchive_Bool_ForDelete;
        sv._potionsAchive_Bool_CompliteAchive = AchPanel._potionsAchive_Bool_CompliteAchive;

        sv._chestsAchive_CountUse = AchPanel._chestsAchive_CountUse;
        sv._chestsAchive_Bool_ForDelete = AchPanel._chestsAchive_Bool_ForDelete;
        sv._chestsAchive_Bool_CompliteAchive = AchPanel._chestsAchive_Bool_CompliteAchive;

        sv._clicksAchive_CountUse = AchPanel._clicksAchive_CountUse;
        sv._clicksAchive_Bool_ForDelete = AchPanel._clicksAchive_Bool_ForDelete;
        sv._clicksAchive_Bool_CompliteAchive = AchPanel._clicksAchive_Bool_CompliteAchive;

        sv._heroesAchive_CountUse = AchPanel._heroesAchive_CountUse;
        sv._heroesAchive_Bool_ForDelete = AchPanel._heroesAchive_Bool_ForDelete;
        sv._heroesAchive_Bool_CompliteAchive = AchPanel._heroesAchive_Bool_CompliteAchive;

        sv.Language = Language;
        sv.listTakesPriseForLevel = listTakesPriseForLevel;

        sv.GameTheme = GameTheme;
        sv.CurGameTheme = CurGameTheme;

        sv.ClickSkin = ClickSkin;
        sv.CurClickSkin = CurClickSkin;
        sv.ChooseStar = ChooseStar;


        PlayerPrefs.SetString("AppSave", JsonUtility.ToJson(sv));
        PlayerPrefs.Save();
    }
    void Start()
    {
        UpdateInfoDPS();
        UpdateBalanceText();
    }

    public void UpdateInfoDPS()
    {
        dpsTextBox.text = digitInTextDMG(getAllDps());
    }

    public double getAllDps()
    {
        AllDps = _noviceDPS;
        for (int i = 0; i < HerosList.Length; i++)
        {
            AllDps += HerosList[i].GetComponent<HeroScript>().dps;
        }
        return AllDps + (AllDps / 100 * bonusAtShop[2]);
    }
    //Покупкав гуглплее
    public void _5crystalBuyGP()
    {
        balanceCrystal += 5;
    }
    public void _10crystalBuyGP()
    {
        balanceCrystal += 10;
    }
    public void _20crystalBuyGP()
    {
        balanceCrystal += 20;
    }
    public void _50crystalBuyGP()
    {
        balanceCrystal += 50;
    }
    public void _100crystalBuyGP()
    {
        balanceCrystal += 100;
    }
    public void _250crystalBuyGP()
    {
        balanceCrystal += 250;
    }
    public void _500crystalBuyGP()
    {
        balanceCrystal += 500;
    }
    public void _1000crystalBuyGP()
    {
        balanceCrystal += 1000;
    }
    public void _2000crystalBuyGP()
    {
        balanceCrystal += 2000;
    }
    public void _5000crystalBuyGP()
    {
        balanceCrystal += 5000;
    }
    public void _10000crystalBuyGP()
    {
        balanceCrystal += 10000;
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
    string digitInTextDMG(double digitF)
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

    public void UpdateBalanceText()
    {
        balanceCrystalText.text = digitInTextBalance(balanceCrystal);
        balanceText.text = digitInTextBalance(balance);
    } 
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // getelmanMenu.SetActive(false);

        }

    }




}
[Serializable]
public class Save
{
    public int Status;
    public double prestige;
    public double balance;
    public double balanceCrystal;
    public double levelProgress;
    public double onNextLevelProgress;
    public double level;
    public bool[] listTakesPriseForLevel;
    public int[] potions = new int[12];
    public int[] chests = new int[8];
    public double[] HeroSaveLevel;
    public int[] bonusLevel = new int[3];
    public bool MusicToggle;
    public bool SoundToggle;

    public int[] _potionsAchive_CountUse = new int[5];
    public bool[] _potionsAchive_Bool_ForDelete = new bool[5];
    public bool[] _potionsAchive_Bool_CompliteAchive = new bool[5];


    public int[] _chestsAchive_CountUse = new int[5];
    public bool[] _chestsAchive_Bool_ForDelete = new bool[5];
    public bool[] _chestsAchive_Bool_CompliteAchive = new bool[5];

    public int[] _clicksAchive_CountUse = new int[10];
    public bool[] _clicksAchive_Bool_ForDelete = new bool[10];
    public bool[] _clicksAchive_Bool_CompliteAchive = new bool[10];

    public int[] _heroesAchive_CountUse = new int[6];
    public bool[] _heroesAchive_Bool_ForDelete = new bool[6];
    public bool[] _heroesAchive_Bool_CompliteAchive = new bool[6];

    public string Language;

    public bool[] GameTheme;
    public int CurGameTheme = 0;

    public bool[] ClickSkin;
    public int CurClickSkin = 0;
    public bool ChooseStar = true;
}


