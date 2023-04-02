using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Click : MonoBehaviour
{
    public GameObject cam;
    public Game GameScript;
    public GameObject text;
    public GameObject textParant;
    public GameObject X2_Panel;

    [SerializeField] private bool _x2Click;
    [SerializeField] private bool _ExpLineFill;

    private AchiveStatistic _achPanel;
    private DayReward _dayReward;



    [SerializeField] public GameObject MainBossImg;
    [SerializeField] SoundsManager _sm;
    void Start()
    {
        GameScript = cam.GetComponent<Game>();
        _dayReward = GameObject.FindGameObjectWithTag("ExercisesPanel").GetComponent<DayReward>();

        _achPanel = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().AchPanel;
        _sm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>();
        UpdateLevelsLine();
        createClickView();
        UpdateLeveltext();
    }

    IEnumerator x2_click_active()
    {
        _x2Click = true;
        yield return new WaitForSeconds(120);
        _x2Click = false;
    }
    public void X2_click()
    {
        if (X2_Panel.GetComponent<TimerAds>().adsReady == true)
        {
            StartCoroutine(x2_click_active());
            X2_Panel.GetComponent<TimerAds>().startTimer();
        }
    }

    double PlusBalanceGold()
    {
        return GameScript.AllDps + (GameScript.level * 0.1f) + (GameScript.prestige * 0.1f);
    }
    double PlusBalanceCrystal()
    {
        return GameScript.AllDps + (GameScript.level * 0.1f) + (GameScript.prestige * 0.1f);
    }
    double PlusExp(double exp)
    {
        return exp;
    }


    public void ClickOnButton()
    {
        _achPanel.PlusClicks();
        _dayReward.PlusClicks();
        if (_x2Click == true)
        {
            _achPanel.PlusClicks();
            _dayReward.PlusClicks();
        }
        GameScript.levelProgress += PlusExp(1);
        GameScript.balance += PlusBalanceGold();
        if (GameScript.Status == 1)
        {
            GameScript.levelProgress += PlusExp(1);
            GameScript.balance += PlusBalanceGold();
        }
        checklvl(); 
        LineFill();
        ClickView();
        GameScript.UpdateBalanceText();
        UpdateLeveltext();
    } 
    


    
    public void ClickTap()
    {
        _achPanel.PlusClicks();
        _dayReward.PlusClicks();
        if (_x2Click == true)
        {
            _achPanel.PlusClicks();
            _dayReward.PlusClicks();
        }
        GameScript.levelProgress += PlusExp(1);
        GameScript.balance += PlusBalanceGold();
        if (GameScript.Status == 1)
        {
            GameScript.levelProgress += PlusExp(1);
            GameScript.balance += PlusBalanceGold();
        }
        checklvl();
        LineFill();
        ClickView();
        GameScript.UpdateBalanceText();
        UpdateLeveltext();
    }
    public GameObject clickeffect;
    public GameObject clickText;

    int counter = 0;
    ClickViewImage[] clickViewGM = new ClickViewImage[20];
    void createClickView()
    {
        for (int i = 0; i < 20; i++)
        {
            clickViewGM[i] = GameObject.Instantiate(text, textParant.transform).GetComponent<ClickViewImage>();
        }
    }
    public void ClickView()
    {

        clickViewGM[counter].Reload();
        counter++;
        if(counter >= 20)
        {
            counter = 0;
        }
        //clickText = GameObject.Instantiate(text,textParant.transform) as GameObject;

        //GameObject.Instantiate(text, textParant.transform);
    }

/*    public void ClickViewEffect()
    {
        Vector3 MousePos = Input.mousePosition;
        Vector2 qqq = Camera.main.ScreenToWorldPoint(new Vector3(MousePos.x, MousePos.y, 0));
        Debug.Log(MousePos);
        Debug.Log(GameObject.FindObjectOfType<CanvasScaler>().matchWidthOrHeight);
        GameObject ef = GameObject.Instantiate(clickeffect, textParant.transform) as GameObject;
        ef.GetComponent<RectTransform>().anchoredPosition = new Vector2(MousePos.x*GameObject.FindObjectOfType<CanvasScaler>().scaleFactor, MousePos.y *GameObject.FindObjectOfType<CanvasScaler>().scaleFactor);
       // ef.GetComponent<RectTransform>().anchoredPosition = new Vector2(MousePos.x/(Screen.width/720), MousePos.y / (Screen.height / 1280));
        clickText.GetComponent<RectTransform>().anchoredPosition = new Vector2(MousePos.x / (Screen.width / 720), MousePos.y / (Screen.height / 1280));
    }*/
    public void checklvl()
    {
        if(GameScript.levelProgress >= GameScript.onNextLevelProgress)
        {
            GameScript.level++;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(2);
            GameScript.levelProgress = 0;
            switch (GameScript.level)
            {
                case 1: GameScript.onNextLevelProgress = 100; break;
                case 2: GameScript.onNextLevelProgress = 250; break;
                case 3: GameScript.onNextLevelProgress = 500; break;
                case 4: GameScript.onNextLevelProgress = 750; break;
                case 5: GameScript.onNextLevelProgress = 1000; break;
                case 6: GameScript.onNextLevelProgress = 1250; break;
                case 7: GameScript.onNextLevelProgress = 1500; break;
                case 8: GameScript.onNextLevelProgress = 1750; break;
                case 9: GameScript.onNextLevelProgress = 2000; break;
                case 10: GameScript.onNextLevelProgress = 5000; break;
                default: GameScript.onNextLevelProgress = 7500; break;
            }
            UpdateLevelsLine();
            GiveItemForLevel[] listPrise = GameObject.FindObjectsOfType<GiveItemForLevel>();
            for (int i = 0; i < listPrise.Length; i++)
            {
                listPrise[i].checkPrise();
            }
            if (GameScript.ChooseStar)
            {
                GameObject Case = Instantiate(_otzivPrefab, _parentPanel.transform) as GameObject;
            }
        }
    }
    [SerializeField] GameObject _otzivPrefab;
    [SerializeField] GameObject _parentPanel;
    [SerializeField] GameObject[] LineLevels;
    [SerializeField] RectTransform contentTransform;
    [SerializeField] TextMeshProUGUI _currentLevel;
    void UpdateLevelsLine()
    {
        for (int i = 0; i < LineLevels.Length; i++)
        {
            if (i < GameScript.level)
            {
                LineLevels[i].GetComponent<Image>().fillAmount = Convert.ToSingle(1);
            }
            else
            {
                LineLevels[i].GetComponent<Image>().fillAmount = Convert.ToSingle(0);
            }
        }
        LineLevels[Convert.ToInt32(GameScript.level)].GetComponent<Image>().fillAmount = Convert.ToSingle(GameScript.levelProgress / GameScript.onNextLevelProgress);
        if (GameScript.level > 2)
        {
            contentTransform.anchoredPosition = new Vector2(((Convert.ToSingle(GameScript.level) -2)*171)*(-1), 0);

        }

    }
    void UpdateLeveltext()
    {
        _currentLevel.text = $"Current Level: {GameScript.level.ToString()}\n{GameScript.levelProgress}/{GameScript.onNextLevelProgress}";
    }
    public void LineFill()
    {
    
        LineLevels[Convert.ToInt32(GameScript.level)].GetComponent<Image>().fillAmount = Convert.ToSingle(GameScript.levelProgress / GameScript.onNextLevelProgress);
        _currentLevel.text = "Current Level: " + GameScript.level.ToString();
    }
    void Update()
    {
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
                NotDigit = digitF.ToString("0.0");
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
