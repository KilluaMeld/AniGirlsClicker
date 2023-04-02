using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchiveStatistic : MonoBehaviour
{
    public int[] _potionsAchive_CountUse = new int[5];
    [SerializeField] int[] _potionsAchive_CountUseNeed = new int[5] {5,10,20,50,100};
    public bool[] _potionsAchive_Bool_ForDelete = new bool[5];
    public bool[] _potionsAchive_Bool_CompliteAchive = new bool[5];
    [SerializeField] Image[] _potionsAchive_Line;
    [SerializeField] TextMeshProUGUI[] _potionsAchive_LineText;
    [SerializeField] int[] _potionsAchive_Reward = new int[5] {100,250,1000,5000,7500 };
    [SerializeField] GameObject[] _potionsAchive_RewardText = new GameObject[5];
    [SerializeField] GameObject[] _potionsAchive_Claim;

    //--------------------------------------------------

    public int[] _chestsAchive_CountUse = new int[5];
    [SerializeField] int[] _chestsAchive_CountUseNeed = new int[5] { 5, 10, 20, 50, 100 };
    public bool[] _chestsAchive_Bool_ForDelete = new bool[5];
    public bool[] _chestsAchive_Bool_CompliteAchive = new bool[5];
    [SerializeField] Image[] _chestsAchive_Line;
    [SerializeField] TextMeshProUGUI[] _chestsAchive_LineText;
    [SerializeField] int[] _chestsAchive_Reward = new int[5] { 100, 250, 1000, 5000, 7500 };
    [SerializeField] GameObject[] _chestsAchive_RewardText = new GameObject[5];
    [SerializeField] GameObject[] _chestsAchive_Claim;

    //--------------------------------------------------

    public int[] _clicksAchive_CountUse = new int[10];
    [SerializeField] int[] _clicksAchive_CountUseNeed = new int[10] { 1000, 25000,50000, 100000,500000, 1000000,5000000, 10000000,50000000, 100000000 };
    public bool[] _clicksAchive_Bool_ForDelete = new bool[10];
    public bool[] _clicksAchive_Bool_CompliteAchive = new bool[10];
    [SerializeField] Image[] _clicksAchive_Line;
    [SerializeField] TextMeshProUGUI[] _clicksAchive_LineText;
    [SerializeField] int[] _clicksAchive_Reward = new int[10] { 250, 500, 1000, 2500, 5000,7500,10000,15000,20000,30000 };
    [SerializeField] GameObject[] _clicksAchive_RewardText;
    [SerializeField] GameObject[] _clicksAchive_Claim;

    //--------------------------------------------------

    public int[] _heroesAchive_CountUse = new int[6];
    [SerializeField] int[] _heroesAchive_CountUseNeed = new int[6] { 1,5,10,15,20,31};
    public bool[] _heroesAchive_Bool_ForDelete = new bool[6];
    public bool[] _heroesAchive_Bool_CompliteAchive = new bool[6];
    [SerializeField] Image[] _heroesAchive_Line;
    [SerializeField] TextMeshProUGUI[] _heroesAchive_LineText;
    [SerializeField] int[] _heroesAchive_Reward = new int[6] { 1000,3000,7500,10000,40000,90000 };
    [SerializeField] GameObject[] _heroesAchive_RewardText;
    [SerializeField] GameObject[] _heroesAchive_Claim;

    //--------------------------------------------------



    [SerializeField] Game GameScript;

    private void Start()
    {
        GameScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>();
        CheckPotion();
        CheckChest();
        CheckClicks();
        CheckHeros();
        UpdateTextAchivmentsCount();
    }
    [SerializeField] TextMeshProUGUI _textAch;
    [SerializeField] int _countAch;
    void UpdateTextAchivmentsCount()
    {
        _countAch = 0;
        

                
        for (int i = 0; i < _potionsAchive_Bool_CompliteAchive.Length; i++)
        {
            if(_potionsAchive_Bool_CompliteAchive[i] == true)
            {
                _countAch++;
            }

        }
        for (int i = 0; i < _potionsAchive_Bool_CompliteAchive.Length; i++)
        {
            if (_chestsAchive_Bool_CompliteAchive[i] == true)
            {
                _countAch++;
            }

        }
        for (int i = 0; i < _potionsAchive_Bool_CompliteAchive.Length; i++)
        {
            if (_clicksAchive_Bool_CompliteAchive[i] == true)
            {
                _countAch++;
            }

        }
        for (int i = 0; i < _potionsAchive_Bool_CompliteAchive.Length; i++)
        {
            if (_heroesAchive_Bool_CompliteAchive[i] == true)
            {
                _countAch++;
            }

        }

        _textAch.text = $"Achivments {_countAch.ToString()}/26";
    }
    void WrongClaim()
    {
        GameObject ef = GameObject.Instantiate(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().WrongStepPrefab, GameObject.FindGameObjectWithTag("PanelForNewItems").transform) as GameObject;
        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().Language == "ru_RU")
        {
            ef.GetComponent<WrongStep>().SetText($"Достиение не выполнено");
        }
        else
        {
            ef.GetComponent<WrongStep>().SetText($"Achievement not completed");
        }
    }
    public void PlusPotions()
    {
        for (int i = 0; i < _potionsAchive_CountUse.Length; i++)
        {
            _potionsAchive_CountUse[i]++;
        }
        CheckPotion();
        UpdateTextAchivmentsCount();
    }
    public void CheckPotion()
    {
        for (int i = 0;i< _potionsAchive_CountUse.Length; i++)
        {
            if (_potionsAchive_Bool_ForDelete[i] == false)
            {

                if (_potionsAchive_CountUse[i] > _potionsAchive_CountUseNeed[i])
                {
                    _potionsAchive_CountUse[i] = _potionsAchive_CountUseNeed[i];
                }
                _potionsAchive_Line[i].fillAmount = _potionsAchive_CountUse[i] / _potionsAchive_CountUseNeed[i];
                Debug.Log(_potionsAchive_CountUse[i] / _potionsAchive_CountUseNeed[i]);
                _potionsAchive_LineText[i].text = $"{_potionsAchive_CountUse[i]}/{_potionsAchive_CountUseNeed[i]}";
                if (_potionsAchive_CountUse[i] >= _potionsAchive_CountUseNeed[i])
                {
                    _potionsAchive_Claim[i].SetActive(true);
                    _potionsAchive_Claim[i].GetComponent<Image>().color = new Color32(255, 224,26,255);
                    _potionsAchive_Bool_CompliteAchive[i] = true;
                }
                else
                {
                    _potionsAchive_Claim[i].SetActive(true);
                    _potionsAchive_Claim[i].GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                    _potionsAchive_Bool_CompliteAchive[i] = false;
                }
            }
            else
            {
                _potionsAchive_Claim[i].SetActive(false);
                _potionsAchive_RewardText[i].SetActive(false);
            }
        }






    }

    public void Claim(int claimInt)
    {
                if(_potionsAchive_Bool_CompliteAchive[claimInt] == true) 
                { 
                    GameScript.balanceCrystal += _potionsAchive_Reward[claimInt];
                    _potionsAchive_Bool_ForDelete[claimInt] = true;
                    CheckPotion(); 
                }
                else
                {
                    WrongClaim();
                }
              
    }
    public void PlusChests()
    {
        for (int i = 0; i < _chestsAchive_CountUse.Length; i++)
        {
            _chestsAchive_CountUse[i]++;
        }
        CheckChest();
        UpdateTextAchivmentsCount();
    }
    public void CheckChest()
    {
        for (int i = 0; i < _chestsAchive_CountUse.Length; i++)
        {
            if (_chestsAchive_Bool_ForDelete[i] == false)
            {

                if (_chestsAchive_CountUse[i] > _chestsAchive_CountUseNeed[i])
                {
                    _chestsAchive_CountUse[i] = _chestsAchive_CountUseNeed[i];
                }
                _chestsAchive_Line[i].fillAmount = _chestsAchive_CountUse[i] / _chestsAchive_CountUseNeed[i];
               // Debug.Log(_chestsAchive_CountUse[i] / _chestsAchive_CountUseNeed[i]);
                _chestsAchive_LineText[i].text = $"{_chestsAchive_CountUse[i]}/{_chestsAchive_CountUseNeed[i]}";
                if (_chestsAchive_CountUse[i] >= _chestsAchive_CountUseNeed[i])
                {
                    _chestsAchive_Claim[i].SetActive(true);
                    _chestsAchive_Claim[i].GetComponent<Image>().color = new Color32(255, 224, 26, 255);
                    _chestsAchive_Bool_CompliteAchive[i] = true;
                }
                else
                {
                    _chestsAchive_Claim[i].SetActive(true);
                    _chestsAchive_Claim[i].GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                    _chestsAchive_Bool_CompliteAchive[i] = false;
                }
            }
            else
            {
                _chestsAchive_Claim[i].SetActive(false);
                _chestsAchive_RewardText[i].SetActive(false);
            }
        }






    }

    public void ClaimChest(int claimInt)
    {
                if (_chestsAchive_Bool_CompliteAchive[claimInt] == true)
                {
                    GameScript.balanceCrystal += _chestsAchive_Reward[claimInt];
                _chestsAchive_Bool_ForDelete[claimInt] = true;
                CheckChest();
                }
                else
                {
                    WrongClaim();
                }
               
    }






    public void PlusClicks()
    {
        for (int i = 0; i < _clicksAchive_CountUse.Length; i++)
        {
            _clicksAchive_CountUse[i]++;
        }
        CheckClicks();
        UpdateTextAchivmentsCount();
    }
    public void CheckClicks()
    {
        for (int i = 0; i < _clicksAchive_CountUse.Length; i++)
        {
            if (_clicksAchive_Bool_ForDelete[i] == false)
            {

                if (_clicksAchive_CountUse[i] > _clicksAchive_CountUseNeed[i])
                {
                    _clicksAchive_CountUse[i] = _clicksAchive_CountUseNeed[i];
                }
                _clicksAchive_Line[i].fillAmount = _clicksAchive_CountUse[i] / _clicksAchive_CountUseNeed[i];
               // Debug.Log(_clicksAchive_CountUse[i] / _clicksAchive_CountUseNeed[i]);
                _clicksAchive_LineText[i].text = $"{_clicksAchive_CountUse[i]}/{_clicksAchive_CountUseNeed[i]}";
                if (_clicksAchive_CountUse[i] >= _clicksAchive_CountUseNeed[i])
                {
                    _clicksAchive_Claim[i].SetActive(true);
                    _clicksAchive_Claim[i].GetComponent<Image>().color = new Color32(255, 224, 26, 255);
                    _clicksAchive_Bool_CompliteAchive[i] = true;
                }
                else
                {
                    _clicksAchive_Claim[i].SetActive(true);
                    _clicksAchive_Claim[i].GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                    _clicksAchive_Bool_CompliteAchive[i] = false;
                }
            }
            else
            {
                _clicksAchive_Claim[i].SetActive(false);
                _clicksAchive_RewardText[i].SetActive(false);
            }
        }






    }

    public void Claim_clicks(int claimInt)
    {

                if (_clicksAchive_Bool_CompliteAchive[claimInt] == true)
                {
                    GameScript.balanceCrystal += _clicksAchive_Reward[claimInt];
                _clicksAchive_Bool_ForDelete[claimInt] = true;
                CheckClicks();
                }
                else
                {
                    WrongClaim();
                }
               
    }


    public void PlusHeros()
    {
        for (int i = 0; i < _heroesAchive_CountUse.Length; i++)
        {
            _heroesAchive_CountUse[i]++;
        }
        CheckHeros();
        UpdateTextAchivmentsCount();
    }
    public void CheckHeros()
    {
        for (int i = 0; i < _heroesAchive_CountUse.Length; i++)
        {
            if (_heroesAchive_Bool_ForDelete[i] == false)
            {

                if (_heroesAchive_CountUse[i] > _heroesAchive_CountUseNeed[i])
                {
                    _heroesAchive_CountUse[i] = _heroesAchive_CountUseNeed[i];
                }
                _heroesAchive_Line[i].fillAmount = _heroesAchive_CountUse[i] / _heroesAchive_CountUseNeed[i];
                Debug.Log(_heroesAchive_CountUse[i] / _heroesAchive_CountUseNeed[i]);
                _heroesAchive_LineText[i].text = $"{_heroesAchive_CountUse[i]}/{_heroesAchive_CountUseNeed[i]}";
                if (_heroesAchive_CountUse[i] >= _heroesAchive_CountUseNeed[i])
                {
                    _heroesAchive_Claim[i].SetActive(true);
                    _heroesAchive_Claim[i].GetComponent<Image>().color = new Color32(255, 224, 26, 255);
                    _heroesAchive_Bool_CompliteAchive[i] = true;
                }
                else
                {
                    _heroesAchive_Claim[i].SetActive(true);
                    _heroesAchive_Claim[i].GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                    _heroesAchive_Bool_CompliteAchive[i] = false;
                }
            }
            else
            {
                _heroesAchive_Line[i].fillAmount = _heroesAchive_CountUse[i] / _heroesAchive_CountUseNeed[i];
                _heroesAchive_LineText[i].text = $"{_heroesAchive_CountUse[i]}/{_heroesAchive_CountUseNeed[i]}";
                _heroesAchive_Claim[i].SetActive(false);
                _heroesAchive_RewardText[i].SetActive(false);
            }
        }






    }

    public void Claim_heroes(int claimInt)
    {
                if (_heroesAchive_Bool_CompliteAchive[claimInt] == true)
                {
                    GameScript.balanceCrystal += _heroesAchive_Reward[claimInt];
                _heroesAchive_Bool_ForDelete[claimInt] = true;
                CheckHeros();
                }
                else
                {
                    WrongClaim();
                }
        
    }


}
