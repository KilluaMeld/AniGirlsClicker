using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsController : MonoBehaviour
{
    public Game gameScript;
/*    public GameObject imgPanel;*/
    public GameObject CliclPanel;
    public Click ClickScript;
    [SerializeField] private float _startTimeHero;
    [SerializeField] private GameObject[] _listHero;
    [SerializeField] private GameObject[] _listPotions_Speed;
    [SerializeField] private GameObject[] _listPotions_Baks;
    [SerializeField] private GameObject[] _listPotions_AutoClick;
    
    [SerializeField] public bool _activePotions_Speed = false;
    [SerializeField] private bool _activePotions_Baks = false;
    [SerializeField] private bool _activePotions_AutoClick = false;
    void AchivePlus()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().AchPanel.PlusPotions();
    }
    IEnumerator Potion_speedEnd()
    {
        _activePotions_Speed = true;
        for (int i = 0; i < _listPotions_Speed.Length; i++)
        {
            _listPotions_Speed[i].GetComponent<Potions>().startcorutin();
        }
        yield return new WaitForSeconds(60);
        for (int i = 0; i < _listHero.Length; i++)
        {
            _listHero[i].GetComponent<HeroScript>().time = 3-gameScript.bonusAtShop[1];
        }
        _activePotions_Speed = false;
    }
    IEnumerator Potion_baksEnd()
    {
        _activePotions_Baks = true;
        for (int i = 0; i < _listPotions_Baks.Length; i++)
        {
            _listPotions_Baks[i].GetComponent<Potions>().startcorutin();
        }
        yield return new WaitForSeconds(60);
        StopCoroutine(Potion_baks_Level_1());
        StopCoroutine(Potion_baks_Level_2());
        StopCoroutine(Potion_baks_Level_3());
        StopCoroutine(Potion_baks_Level_4());
        for (int i = 0; i < _listHero.Length; i++)
        {
                _listHero[i].GetComponent<HeroScript>().Time_baks = 0;
        }
        _activePotions_Baks = false;
    }
    IEnumerator Potion_baks_Level_1()
    {
        while (_activePotions_Baks)
        {
            for (int i = 0; i < _listHero.Length; i++)
            {
                if (_listHero[i].GetComponent<HeroScript>().lvl >0)
                {
                    _listHero[i].GetComponent<HeroScript>().Time_baks = _listHero[i].GetComponent<HeroScript>().baks * 0.1;
                    gameScript.balance += _listHero[i].GetComponent<HeroScript>().Time_baks;
                }
            }
            yield return new WaitForSeconds(_listHero[1].GetComponent<HeroScript>().time);
        }
    }
    IEnumerator Potion_baks_Level_2()
    {
        while (_activePotions_Baks)
        {
            for (int i = 0; i < _listHero.Length; i++)
            {
                if (_listHero[i].GetComponent<HeroScript>().lvl > 0)
                {
                    _listHero[i].GetComponent<HeroScript>().Time_baks = _listHero[i].GetComponent<HeroScript>().baks * 0.2;
                    gameScript.balance += _listHero[i].GetComponent<HeroScript>().Time_baks;
                }
            }
            yield return new WaitForSeconds(_listHero[1].GetComponent<HeroScript>().time);
        }
    }
    IEnumerator Potion_baks_Level_3()
    {
        while (_activePotions_Baks)
        {
            for (int i = 0; i < _listHero.Length; i++)
            {
                if (_listHero[i].GetComponent<HeroScript>().lvl > 0)
                {
                    _listHero[i].GetComponent<HeroScript>().Time_baks = _listHero[i].GetComponent<HeroScript>().baks * 0.3;
                }
            }
            yield return new WaitForSeconds(_listHero[1].GetComponent<HeroScript>().time);
        }
    }
    IEnumerator Potion_baks_Level_4()
    {
        while (_activePotions_Baks)
        {
            for (int i = 0; i < _listHero.Length; i++)
            {
                if (_listHero[i].GetComponent<HeroScript>().lvl > 0)
                {
                    _listHero[i].GetComponent<HeroScript>().Time_baks = _listHero[i].GetComponent<HeroScript>().baks * 0.4;
                    gameScript.balance += _listHero[i].GetComponent<HeroScript>().Time_baks;
                }
            }
            yield return new WaitForSeconds(_listHero[0].GetComponent<HeroScript>().time);
        }
    }
    IEnumerator Potion_AutoClickEnd_All()
    {
        _activePotions_AutoClick = true;
        for (int i = 0; i < _listPotions_AutoClick.Length; i++)
        {
            _listPotions_AutoClick[i].GetComponent<Potions>().startcorutin();
        }
        yield return new WaitForSeconds(60);
        StopCoroutine(Potion_AutoClickEnd_Level_1());
        StopCoroutine(Potion_AutoClickEnd_Level_2());
        StopCoroutine(Potion_AutoClickEnd_Level_3());
        StopCoroutine(Potion_AutoClickEnd_Level_4());
        _activePotions_AutoClick = false;
    }
    IEnumerator Potion_AutoClickEnd_Level_1()
    {
        while (_activePotions_AutoClick)
        {
            yield return new WaitForSeconds(1);
            ClickScript.ClickOnButton();
        }
    }
    IEnumerator Potion_AutoClickEnd_Level_2()
    {
        while (_activePotions_AutoClick)
        {
            yield return new WaitForSeconds(0.75f);
            ClickScript.ClickOnButton();
        }
    }
    IEnumerator Potion_AutoClickEnd_Level_3()
    {
        while (_activePotions_AutoClick)
        {
            yield return new WaitForSeconds(0.5f);
            ClickScript.ClickOnButton();
        }
    }
    IEnumerator Potion_AutoClickEnd_Level_4()
    {
        while (_activePotions_AutoClick)
        {
            yield return new WaitForSeconds(0.2f);
            ClickScript.ClickOnButton();
        }
    }
    public void Potion_id_0(int id)
    {
        if (_activePotions_Speed == false)
        {
            _listPotions_Speed[0].GetComponent<Potions>().startcorutineEffect();
            gameScript.potions[id]--;
            AchivePlus();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(4);
            StopCoroutine(Potion_speedEnd());
            for (int i = 0; i < _listHero.Length; i++)
            {
                _listHero[i].GetComponent<HeroScript>().time = _listHero[i].GetComponent<HeroScript>().time / 100 * 90;
            }
            StartCoroutine(Potion_speedEnd());
        }
    }
    public void Potion_id_1(int id)
    {
        if (_activePotions_Speed == false)
        {
            _listPotions_Speed[1].GetComponent<Potions>().startcorutineEffect();
            gameScript.potions[id]--;
            AchivePlus();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(4);
            StopCoroutine(Potion_speedEnd());
            for (int i = 0; i < _listHero.Length; i++)
            {
                _listHero[i].GetComponent<HeroScript>().time = _listHero[i].GetComponent<HeroScript>().time / 100 * 75;
            }
            StartCoroutine(Potion_speedEnd());
        }
    }
    public void Potion_id_2(int id)
    {
        if (_activePotions_Speed == false)
        {
            gameScript.potions[id]--;
            _listPotions_Speed[2].GetComponent<Potions>().startcorutineEffect();
            AchivePlus();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(4);
            StopCoroutine(Potion_speedEnd());
            for (int i = 0; i < _listHero.Length; i++)
            {
                _listHero[i].GetComponent<HeroScript>().time = _listHero[i].GetComponent<HeroScript>().time / 100 * 50 ;
            }
            StartCoroutine(Potion_speedEnd());
        }
    }
    public void Potion_id_3(int id)
    {
        if (_activePotions_Speed == false)
        {
            gameScript.potions[id]--;
            _listPotions_Speed[3].GetComponent<Potions>().startcorutineEffect();
            AchivePlus();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(4);
            StopCoroutine(Potion_speedEnd());
            for (int i = 0; i < _listHero.Length; i++)
            {
                _listHero[i].GetComponent<HeroScript>().time = _listHero[i].GetComponent<HeroScript>().time/ 100 * 25;
            }
            StartCoroutine(Potion_speedEnd());
        }
    }
    public void Potion_id_4(int id)
    {
        if (_activePotions_Baks == false)
        {
            gameScript.potions[id]--;
            _listPotions_Baks[0].GetComponent<Potions>().startcorutineEffect();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(4);
            AchivePlus();
            StartCoroutine(Potion_baksEnd());
            StopCoroutine(Potion_baksEnd());
            StartCoroutine(Potion_baks_Level_1());
        }
    }
    public void Potion_id_5(int id)
    {
        if (_activePotions_Baks == false)
        {
            gameScript.potions[id]--;
            _listPotions_Baks[1].GetComponent<Potions>().startcorutineEffect();
            AchivePlus();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(4);
            StartCoroutine(Potion_baksEnd());
            StopCoroutine(Potion_baksEnd());
            StartCoroutine(Potion_baks_Level_2());
        }
    }
    public void Potion_id_6(int id)
    {
        if (_activePotions_Baks == false)
        {
            gameScript.potions[id]--;
            _listPotions_Baks[2].GetComponent<Potions>().startcorutineEffect();
            AchivePlus();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(4);
            StopCoroutine(Potion_baksEnd());
            StartCoroutine(Potion_baksEnd());
            StartCoroutine(Potion_baks_Level_3());
        }
    }
    public void Potion_id_7(int id)
    {
        if (_activePotions_Baks == false)
        {
            gameScript.potions[id]--;
            _listPotions_Baks[3].GetComponent<Potions>().startcorutineEffect();
            AchivePlus();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(4);
            StartCoroutine(Potion_baksEnd());
            StopCoroutine(Potion_baksEnd());
            StartCoroutine(Potion_baks_Level_4());
        }
    }
    public void Potion_id_8(int id)
    {
        if (_activePotions_AutoClick == false)
        {
            gameScript.potions[id]--;
            _listPotions_AutoClick[0].GetComponent<Potions>().startcorutineEffect();
            AchivePlus();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(4);
            StartCoroutine(Potion_AutoClickEnd_All());
            StopCoroutine(Potion_AutoClickEnd_Level_1());
            StartCoroutine(Potion_AutoClickEnd_Level_1());
        }
    }
    public void Potion_id_9(int id)
    {
        if (_activePotions_AutoClick == false)
        {
            gameScript.potions[id]--;
            _listPotions_AutoClick[1].GetComponent<Potions>().startcorutineEffect();
            AchivePlus();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(4);
            StartCoroutine(Potion_AutoClickEnd_All());
            StopCoroutine(Potion_AutoClickEnd_Level_2());
            StartCoroutine(Potion_AutoClickEnd_Level_2());
        }
    }
    public void Potion_id_10(int id)
    {
        if (_activePotions_AutoClick == false)
        {
            gameScript.potions[id]--;
            _listPotions_AutoClick[2].GetComponent<Potions>().startcorutineEffect();
            AchivePlus();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(4);
            StartCoroutine(Potion_AutoClickEnd_All());
            StopCoroutine(Potion_AutoClickEnd_Level_3());
            StartCoroutine(Potion_AutoClickEnd_Level_3());

        }
    }
    public void Potion_id_11(int id)
    {
        if (_activePotions_AutoClick == false)
        {
            gameScript.potions[id]--;
            _listPotions_AutoClick[3].GetComponent<Potions>().startcorutineEffect();
            AchivePlus();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(4);
            StartCoroutine(Potion_AutoClickEnd_All());
            StopCoroutine(Potion_AutoClickEnd_Level_3());
            StartCoroutine(Potion_AutoClickEnd_Level_4());

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>();
        _listHero = GameObject.FindGameObjectsWithTag("Hero");
        _listPotions_Speed = GameObject.FindGameObjectsWithTag("Potion_Speed");
        _listPotions_Baks = GameObject.FindGameObjectsWithTag("Potion_Baks");
        _listPotions_AutoClick = GameObject.FindGameObjectsWithTag("Potion_AutoClick");
        ClickScript = CliclPanel.GetComponent<Click>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
