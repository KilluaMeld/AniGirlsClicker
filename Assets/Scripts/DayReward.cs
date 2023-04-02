using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DayReward : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI[] _ex = new TextMeshProUGUI[3];
    [SerializeField] private GameObject[] _fillPanel = new GameObject[3];
    [SerializeField] private  GameObject[] _reward = new GameObject[3];
    [SerializeField] private TextMeshProUGUI[] _textList = new TextMeshProUGUI[3];
    [SerializeField] private Game GameScript;

    [SerializeField] public string[] _exList = new string[] 
    { 
    "Click 100 Times",//ex0
    "Click 1000 Times",
    "Click 10000 Times"
    };
    [SerializeField] private Sprite[] _rewardList;




    [SerializeField] private float[] _countClicks = new float[3];
    [SerializeField] private int[] _countLevels = new int[3];
    [SerializeField] private int[] _countPotions = new int[3];
    [SerializeField] private int[] _countChests = new int[3];
    public int[] _activeExercise = new int[3];


    void Start()
    {
        GameScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>();
        _activeExercise[0] = 1;
        _activeExercise[1] = 2;
        _activeExercise[2] = 0;


        //Уст  задание

        SetViewExercise();

    }

    public void GetExercise(int numberEx)
    {
        int a = UnityEngine.Random.Range(0, _exList.Length);
        ReloadLogicForExercise(numberEx, a);


    }
    public void ReloadLogicForExercise(int numberEx, int NumberExInList)
    {
        switch (NumberExInList)
        {
            case 1:
                _countClicks[numberEx] = 0;
                break;

        }
    }
    public void FillLineExercise()
    {
        for (int i = 0; i < _activeExercise.Length; i++) {
            switch (_activeExercise[i])
            {
                case 1:
                    _fillPanel[i].GetComponent<Image>().fillAmount = _countClicks[i] / 1000;
                    _fillPanel[i].GetComponent<Image>().fillAmount = _countClicks[i] / 1000;
                    _textList[i].GetComponent<TextMeshProUGUI>().text = $"{_countClicks[i]}/1000";
                    break;
            } 
        }
    }
    public void SetViewExercise()
    {
        for (int i = 0; i < 3; i++)
        {
            if (_activeExercise[i] == 999)
            {
                GetExercise(_activeExercise[i]);
                _ex[i].text = _exList[_activeExercise[i]];
                _reward[i].GetComponent<Image>().sprite = _rewardList[_activeExercise[i]];
            }
            else
            {
                _ex[i].text = _exList[_activeExercise[i]];
                _reward[i].GetComponent<Image>().sprite = _rewardList[_activeExercise[i]];
            }
        }

    }




    public void PlusClicks()
    {
        for(int i = 0; i < _countClicks.Length; i++)
        {
            _countClicks[i]++;
        }
        FillLineExercise();
    }
    public void PlusLevels()
    {
        for (int i = 0; i < _countLevels.Length; i++)
        {
            _countLevels[i]++;
        }
        FillLineExercise();
    }
    public void PlusPotions()
    {
        for (int i = 0; i < _countPotions.Length; i++)
        {
            _countPotions[i]++;
        }
        FillLineExercise();
    }
    public void PlusChests()
    {
        for (int i = 0; i < _countChests.Length; i++)
        {
            _countChests[i]++;
        }
        FillLineExercise();
    }




    /*    public void SetViewExercise()
        {
            _ex[0].text = _exList[_activeExercise[0]];
            _reward[0].GetComponent<Image>().sprite = _rewardList[_activeExercise[0]];
            _icon[0].GetComponent<Image>().sprite = _iconList[_activeExercise[0]];

            _ex[1].text = _exList[_activeExercise[1]];
            _reward[1].GetComponent<Image>().sprite = _rewardList[_activeExercise[1]];
            _icon[1].GetComponent<Image>().sprite = _iconList[_activeExercise[1]];

            _ex[2].text = _exList[_activeExercise[2]];
            _reward[2].GetComponent<Image>().sprite = _rewardList[_activeExercise[2]];
            _icon[2].GetComponent<Image>().sprite = _iconList[_activeExercise[2]];
        }*/



}