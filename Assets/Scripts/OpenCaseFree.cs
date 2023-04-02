using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCaseFree : MonoBehaviour
{
    public Sprite[] PotionsSprite;
    public Sprite[] ChestsSprite;
    public Sprite[] GoldSprite;
    public Sprite[] CrystalSprite;
    public GameObject CasePanel;
    public GameObject CaseSlotsPrefab;
    public GameObject CasePanelParent;
    public GameObject[] prise;
    public GameObject Line;
    public Vector3 vector;
    public GameObject iconAds;
    public TimerAds _timerAds;

    [SerializeField] private Game GameScript;
    [SerializeField] private GiveItems GiveItemsScript;
    [SerializeField] private GameObject Case;
    [SerializeField] GameObject _chestOpenPrefab;
    [SerializeField] GameObject _parentPanel;
    [SerializeField] private Sprite priseSprite;
    [SerializeField] private int PriseCount;
    private float speed = -500;
    private float velosity = 3;
    private bool startOpenCase = false;
    // Start is called before the first frame update
    void Start()
    {
        GameScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>();
        GiveItemsScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GiveItems>();

    }
    public void OpenCasePanel()
    {
        CasePanel.SetActive(!CasePanel.activeSelf);
    }

    public void StartOpenBttn()
    {
        _timerAds = iconAds.GetComponent<TimerAds>();
        if (_timerAds.adsReady == true)
        {
            startOpenCase = true;
            Line.GetComponent<RectTransform>().anchoredPosition = new Vector2(8812, 0);
            speed = -500;
            velosity = UnityEngine.Random.Range(80, 90f);
            CasePanel.SetActive(!CasePanel.activeSelf);
            _timerAds.startTimer();

            GiveItemsScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GiveItems>();
            for (int i = 0; i < 50; i++)
            {
                    GameObject.Instantiate(prise[UnityEngine.Random.Range(0, prise.Length)], CasePanelParent.transform);
            }
        }

    }
    GameObject[] ForDelete;
    IEnumerator StartOpen(int a)
    {
        ForDelete = GameObject.FindGameObjectsWithTag("PrisesFreeCase");
        if (a == 0)
        {
            GiveItemsScript.Chest1(1);
            priseSprite = ChestsSprite[0];
            PriseCount = 1;
        }
        else if (a == 1)
        {
            GiveItemsScript.Chest2(1);
            priseSprite = ChestsSprite[1];
            PriseCount = 1;

        }
        else if (a == 2)
        {
            GiveItemsScript.Chest3(1);
            priseSprite = ChestsSprite[2];
            PriseCount = 1;

        }
        else if (a == 3)
        {
            GiveItemsScript.Chest4(1);
            priseSprite = ChestsSprite[3];
            PriseCount = 1;

        }
        else if (a == 4)
        {
            GiveItemsScript.Chest5(1);
            priseSprite = ChestsSprite[4];
            PriseCount = 1;

        }
        else if (a == 5)
        {
            GiveItemsScript.Chest6(1);
            priseSprite = ChestsSprite[5];
            PriseCount = 1;

        }
        else if (a == 6)
        {
            GiveItemsScript.Chest7(1);
            priseSprite = ChestsSprite[6];
            PriseCount = 1;

        }
        else if (a == 7)
        {
            GiveItemsScript.Chest8(1);
            priseSprite = ChestsSprite[7];
            PriseCount = 1;

        }
        else if (a == 8)
        {
            GiveItemsScript.SpeedPotion1Level(1);
            priseSprite = PotionsSprite[0];
            PriseCount = 1;

        }
        else if (a == 9)
        {
            GiveItemsScript.SpeedPotion2Level(1);
            priseSprite = PotionsSprite[1];
            PriseCount = 1;

        }
        else if (a == 10)
        {
            GiveItemsScript.SpeedPotion3Level(1);
            priseSprite = PotionsSprite[2];
            PriseCount = 1;
        }
        else if (a == 11)
        {
            GiveItemsScript.SpeedPotion4Level(1);
            priseSprite = PotionsSprite[3];
            PriseCount = 1;
        }
        else if (a == 12)
        {
            GiveItemsScript.BaksPotion1Level(1);
            priseSprite = PotionsSprite[4];
            PriseCount = 1;
        }
        else if (a == 13)
        {
            GiveItemsScript.BaksPotion2Level(1);
            priseSprite = PotionsSprite[5];
            PriseCount = 1;
        }
        else if (a == 14)
        {
            GiveItemsScript.BaksPotion3Level(1);
            priseSprite = PotionsSprite[6];
            PriseCount = 1;
        }
        else if (a == 15)
        {
            GiveItemsScript.BaksPotion4Level(1);
            priseSprite = PotionsSprite[7];
            PriseCount = 1;
        }
        else if (a == 16)
        {
            GiveItemsScript.AutiClickPotion1Level(1);
            priseSprite = PotionsSprite[8];
            PriseCount = 1;
        }
        else if (a == 17)
        {
            GiveItemsScript.AutiClickPotion2Level(1);
            priseSprite = PotionsSprite[9];
            PriseCount = 1;
        }
        else if (a == 18)
        {
            GiveItemsScript.AutiClickPotion3Level(1);
            priseSprite = PotionsSprite[10];
            PriseCount = 1;
        }
        else if (a == 19)
        {
            GiveItemsScript.AutiClickPotion4Level(1);
            priseSprite = PotionsSprite[11];
            PriseCount = 1;
        }
        else if (a == 20)
        {
            GiveItemsScript.GoldBalance(10000 * (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().level * 10));
            priseSprite = GoldSprite[2];
            PriseCount = Convert.ToInt32(10000 * (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().level * 10));
        }
        else if (a == 21)
        {
            GiveItemsScript.CrystalBalance(100);
            priseSprite = CrystalSprite[2];
            PriseCount = 100;
        }

        yield return new WaitForSeconds(2);


        Case = Instantiate(_chestOpenPrefab, _parentPanel.transform) as GameObject;
        Case.GetComponent<ChestView>().SetInfo(priseSprite,PriseCount);
        for(int i = 0; i < ForDelete.Length; i++)
        {
            Destroy(ForDelete[i]);
        }
        OpenCasePanel();
    }
    
    // Update is called once per frame
    void Update()
    {
        //Line.GetComponent.<RectTransform>().aa.Translate(vector*Time.deltaTime);
        //Line.GetComponent<Transform>().position = Vector3.Lerp(Line.transform.position, new Vector3(0,0,0), 5 * Time.deltaTime);
        RaycastHit2D hit = Physics2D.Raycast(Vector2.down, Vector2.up);
        if (speed == 0 && startOpenCase == true)
        {
            if (hit.collider != null)
            {
                startOpenCase = false;
                StartCoroutine(StartOpen(hit.collider.gameObject.GetComponent<IndexPrise>().Index));
            }
            else
            {
                speed = -10;
            }
        }
        speed = Mathf.MoveTowards(speed, 0, velosity*Time.deltaTime);
        Line.transform.Translate(new Vector2(speed, 0) * Time.deltaTime);
    }
}
