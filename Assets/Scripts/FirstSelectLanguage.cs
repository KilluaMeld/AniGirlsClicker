using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstSelectLanguage : MonoBehaviour
{
    [SerializeField] Image _rusBack;
    [SerializeField] Image _engBack;
    [SerializeField] GameObject _button;
    public void SelectLang(string lang)
    {
        _button.SetActive(true);
        GameObject.FindObjectOfType<TranslateMeneger>().SetLanguage(lang);
        if(lang == "ru_RU")
        {
            _rusBack.color = new Color32(0, 255, 0, 255);
            _engBack.color = new Color32(0, 255, 0, 0);
        }
        else
        {
            _rusBack.color = new Color32(0, 255, 0, 0);
            _engBack.color = new Color32(0, 255, 0, 255);
        }
    }
    public void Destr()
    {
        Destroy(this.gameObject);
    }
}
