using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTheme : MonoBehaviour
{

    public Image[] InColor1;
    public Image[] _inColorButtons;
    [SerializeField] Color32[] _color32;
    [SerializeField] Color32[] _color32DarkForLocked;
    [SerializeField] GameObject[] _lockText;
    [SerializeField] Game GameScript;
    void Awake()
    {
        GameScript = GameObject.FindObjectOfType<Game>();
    }
    void Start()
    {
        CheckHaveColor();
    }
    public void CheckHaveColor()
    {
        for (int i = 0; i < GameScript.GameTheme.Length; i++)
        {
            if (GameScript.GameTheme[i] == false )
            {
                _inColorButtons[i].color = _color32DarkForLocked[i];
                _lockText[i].SetActive(true);
            }
            else
            {
                _inColorButtons[i].color = _color32[i];
                _lockText[i].SetActive(false);
            }
        }
    }
    public void ChangeColor(int id)
    {
        if (GameScript.GameTheme[id])
        {
            GameScript.CurGameTheme = id;
            {
                for (int i = 0; i < InColor1.Length; i++)
                {
                    InColor1[i].color = _color32[id];
                }
            }
        }
        else
        {
            GameObject ef = GameObject.Instantiate(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().WrongStepPrefab, GameObject.FindGameObjectWithTag("PanelForNewItems").transform) as GameObject;
            if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().Language == "ru_RU")
            {
                ef.GetComponent<WrongStep>().SetText($"У вас нет в наличии\nэтой темы");
            }
            else
            {
                ef.GetComponent<WrongStep>().SetText($"You don't have\nthis theme");
            }
        }
    }

}
