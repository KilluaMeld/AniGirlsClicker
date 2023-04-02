using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextForLanguage : MonoBehaviour
{
    [SerializeField] int _index;
    void Start()
    {
        SetLanguage();
    }
    public void SetLanguage()
    {
        TextMeshProUGUI _this = this.gameObject.GetComponent<TextMeshProUGUI>();
        Game GameScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>();
        if (GameScript.Language == "ru_RU")
        {
            _this.font = GameScript.RUSFont;
        }
        else
        {
            _this.font = GameScript.ENGFont;
        }
        _this.text = GameObject.FindObjectOfType<TranslateMeneger>().GetAnyTranslate(_index);
    }
}
    