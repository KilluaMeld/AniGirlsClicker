using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelInfoPotionsUpdate : MonoBehaviour
{
    [SerializeField] int _index;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _info;
    [SerializeField] private TextMeshProUGUI _buttonAccept;
    [SerializeField] private TextMeshProUGUI _buttonCancel;
    [SerializeField] private Game GameScript;
    [SerializeField] private GameObject _imgPanel;
    [SerializeField] private PotionsController _potionsController;
    [SerializeField] private TranslateMeneger _translateMeneger;


    // Start is called before the first frame update
    void Start()
    {
        _potionsController = GameObject.FindGameObjectWithTag("PotionsController").GetComponent<PotionsController>();
        _translateMeneger = GameObject.FindObjectOfType<TranslateMeneger>();
    }


    public void SetInfo(int index)
    {
        _translateMeneger = GameObject.FindObjectOfType<TranslateMeneger>();
        GameScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>();
        _index = index;
        _imgPanel.GetComponent<Image>().sprite = GameScript.PotionsSprite[index];
        if (GameScript.Language == "ru_RU")
        {
            _name.font = GameScript.RUSFont;
            _info.font = GameScript.RUSFont;
            _buttonAccept.font = GameScript.RUSFont;
            _buttonCancel.font = GameScript.RUSFont;
        }
        else
        {
            _name.font = GameScript.ENGFont;
            _info.font = GameScript.ENGFont;
            _buttonAccept.font = GameScript.ENGFont;
            _buttonCancel.font = GameScript.ENGFont;
        }
        _buttonAccept.text = _translateMeneger.GetAnyTranslate(3);
        _buttonCancel.text = _translateMeneger.GetAnyTranslate(2);
        _name.text = _translateMeneger.GetPotionsTranslate(index, 0);
        _info.text = _translateMeneger.GetPotionsTranslate(index, 1);
    }
    
    public void Destr()
    {
        Destroy(this.gameObject);
    }
    void WrongUsePotion()
    {
            GameObject ef = GameObject.Instantiate(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().WrongStepPrefab, GameObject.FindGameObjectWithTag("PanelForNewItems").transform) as GameObject;
            if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().Language == "ru_RU")
            {
                ef.GetComponent<WrongStep>().SetText($"У вас нет этого зелья");
            }
            else
            {
                ef.GetComponent<WrongStep>().SetText($"You don't have this potion");
            }
    }
    public void UsePotion()
    {

        switch (_index)
        {
            case 0:
                if (GameScript.potions[_index] > 0)
                {
                    _potionsController.Potion_id_0(_index);

                }
                else
                {
                    WrongUsePotion();
                }

                break;
            case 1:
                if (GameScript.potions[_index] > 0)
                {
                    _potionsController.Potion_id_1(_index);
                }
                else
                {
                    WrongUsePotion();
                }
                break;
            case 2:
                if (GameScript.potions[_index] > 0)
                {
                    _potionsController.Potion_id_2(_index);
                }
                else
                {
                    WrongUsePotion();
                }
                break;
            case 3:
                if (GameScript.potions[_index] > 0)
                {
                    _potionsController.Potion_id_3(_index);
                }
                else
                {
                    WrongUsePotion();
                }
                break;
            case 4:
                if (GameScript.potions[_index] > 0)
                {
                    _potionsController.Potion_id_4(_index);
                }
                else
                {
                    WrongUsePotion();
                }
                break;
            case 5:
                if (GameScript.potions[_index] > 0)
                {
                    _potionsController.Potion_id_5(_index);
                }
                else
                {
                    WrongUsePotion();
                }
                break;
            case 6:
                if (GameScript.potions[_index] > 0)
                {
                    _potionsController.Potion_id_6(_index);
                }
                else
                {
                    WrongUsePotion();
                }
                break;
            case 7:
                if (GameScript.potions[_index] > 0)
                {
                    _potionsController.Potion_id_7(_index);
                }
                else
                {
                    WrongUsePotion();
                }
                break;
            case 8:
                if (GameScript.potions[_index] > 0)
                {
                    _potionsController.Potion_id_8(_index);
                }
                else
                {
                    WrongUsePotion();
                }
                break;
            case 9:
                if (GameScript.potions[_index] > 0)
                {
                    _potionsController.Potion_id_9(_index);
                }
                else
                {
                    WrongUsePotion();
                }
                break;
            case 10:
                if (GameScript.potions[_index] > 0)
                {
                    _potionsController.Potion_id_10(_index);
                }
                else
                {
                    WrongUsePotion();
                }
                break;
            case 11:
                if (GameScript.potions[_index] > 0)
                {
                    _potionsController.Potion_id_11(_index);
                }
                else
                {
                    WrongUsePotion();
                }
                break;
        }
        Destr();
    }
}