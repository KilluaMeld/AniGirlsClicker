using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackMoveSkinChange : MonoBehaviour
{
    [SerializeField] Image[] _skinsButtons;
    [SerializeField] Image _clickPanel;
    [SerializeField] Game GameScript;
    void Awake()
    {
        GameScript = GameObject.FindObjectOfType<Game>();
    }
    void Start()
    {
        CheckHaveColor();
    }
    void CheckHaveColor()
    {
        for (int i = 0; i < GameScript.ClickSkin.Length; i++)
        {
            if (GameScript.ClickSkin[i] == false)
            {
                _skinsButtons[i].color = new Color32(70, 70, 70, 255);
            }
            else
            {
                _skinsButtons[i].color = new Color32(255, 255, 255, 255);
            }
        }
    }
    public void ChangeColor(int id)
    {
        if (GameScript.ClickSkin[id])
        {
            _clickPanel.sprite = GameScript.ClickSkinSprite[id];
        }
        else
        {
            GameObject ef = GameObject.Instantiate(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().WrongStepPrefab, GameObject.FindGameObjectWithTag("PanelForNewItems").transform) as GameObject;
            if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().Language == "ru_RU")
            {
                ef.GetComponent<WrongStep>().SetText($"У вас нет в наличии этой скина");
            }
            else
            {
                ef.GetComponent<WrongStep>().SetText($"You don't have this skin");
            }
        }
    }
}
