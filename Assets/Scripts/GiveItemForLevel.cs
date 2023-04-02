using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveItemForLevel : MonoBehaviour
{
    [SerializeField] GameObject _premPrefab;
    [SerializeField] int _level;
    [SerializeField] int _indexPrise;
    [SerializeField] int _countPrise;
    [SerializeField] GiveItems _giveItem;
    [SerializeField] Game GameScript;
    public bool TakeItem = false;
    private void Awake()
    {
        _giveItem = GameObject.FindObjectOfType<GiveItems>();
        GameScript = GameObject.FindObjectOfType<Game>();
    }
    private void Start()
    {
        checkPrise();
    }

    public void checkPrise()
    {
        GameScript = GameObject.FindObjectOfType<Game>();
        if (GameScript.level >= _level && TakeItem == false)
        {
            this.GetComponent<Image>().color = new Color32(255,255,255,255);
        }
        else
        {
            this.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
        }
    }

    private GameObject prise;
    [SerializeField] private GameObject _newItemPrefab;
    [SerializeField] private GameObject _parentPanel;
    void CreateBuyView(Sprite image, int count)
    {
        prise = Instantiate(_newItemPrefab, _parentPanel.transform) as GameObject;
        prise.GetComponent<ChestView>().SetInfo(image, count);
    }
    public void GivePrise()
    {
        if (GameScript.level >= _level && TakeItem == false)
        {
            switch (_indexPrise)
            {
                case 1: _giveItem.SpeedPotion1Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[0], _countPrise); break;
                case 2: _giveItem.SpeedPotion2Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[1], _countPrise); break;
                case 3: _giveItem.SpeedPotion3Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[2], _countPrise); break;
                case 4: _giveItem.SpeedPotion4Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[3], _countPrise); break;
                case 5: _giveItem.BaksPotion1Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[4], _countPrise); break;
                case 6: _giveItem.BaksPotion2Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[5], _countPrise); break;
                case 7: _giveItem.BaksPotion3Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[6], _countPrise); break;
                case 8: _giveItem.BaksPotion4Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[7], _countPrise); break;
                case 9: _giveItem.AutiClickPotion1Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[8], _countPrise); break;
                case 10: _giveItem.AutiClickPotion2Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[9], _countPrise); break;
                case 11: _giveItem.AutiClickPotion3Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[10], _countPrise); break;
                case 12: _giveItem.AutiClickPotion4Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[11], _countPrise); break;
                case 13: _giveItem.GoldBalance(_countPrise); CreateBuyView(GameScript.GoldSprite[2], _countPrise); break;
                case 14: _giveItem.CrystalBalance(_countPrise); CreateBuyView(GameScript.CrystalSprite[2], _countPrise); break;
                case 15: _giveItem.Chest1(_countPrise); CreateBuyView(GameScript.ChestsSprite[0], _countPrise); break;
                case 16: _giveItem.Chest2(_countPrise); CreateBuyView(GameScript.ChestsSprite[1], _countPrise); break;
                case 17: _giveItem.Chest3(_countPrise); CreateBuyView(GameScript.ChestsSprite[2], _countPrise); break;
                case 18: _giveItem.Chest4(_countPrise); CreateBuyView(GameScript.ChestsSprite[3], _countPrise); break;
                case 19: _giveItem.Chest5(_countPrise); CreateBuyView(GameScript.ChestsSprite[4], _countPrise); break;
                case 20: _giveItem.Chest6(_countPrise); CreateBuyView(GameScript.ChestsSprite[5], _countPrise); break;
                case 21: _giveItem.Chest7(_countPrise); CreateBuyView(GameScript.ChestsSprite[6], _countPrise); break;
                case 22: _giveItem.Chest8(_countPrise); CreateBuyView(GameScript.ChestsSprite[7], _countPrise); break;
                default:
                    break;
            }
            TakeItem = true;
            checkPrise();

        }
    }
    public void GivePrisePremium()
    {
        if (GameScript.level >= _level && TakeItem == false)
        {
            if (GameScript.Status == 1)
            {
                switch (_indexPrise)
                {
                    case 1: _giveItem.SpeedPotion1Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[0], _countPrise); break;
                    case 2: _giveItem.SpeedPotion2Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[1], _countPrise); break;
                    case 3: _giveItem.SpeedPotion3Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[2], _countPrise); break;
                    case 4: _giveItem.SpeedPotion4Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[3], _countPrise); break;
                    case 5: _giveItem.BaksPotion1Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[4], _countPrise); break;
                    case 6: _giveItem.BaksPotion2Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[5], _countPrise); break;
                    case 7: _giveItem.BaksPotion3Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[6], _countPrise); break;
                    case 8: _giveItem.BaksPotion4Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[7], _countPrise); break;
                    case 9: _giveItem.AutiClickPotion1Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[8], _countPrise); break;
                    case 10: _giveItem.AutiClickPotion2Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[9], _countPrise); break;
                    case 11: _giveItem.AutiClickPotion3Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[10], _countPrise); break;
                    case 12: _giveItem.AutiClickPotion4Level(_countPrise); CreateBuyView(GameScript.PotionsSprite[11], _countPrise); break;
                    case 13: _giveItem.GoldBalance(_countPrise); CreateBuyView(GameScript.GoldSprite[2], _countPrise); break;
                    case 14: _giveItem.CrystalBalance(_countPrise); CreateBuyView(GameScript.CrystalSprite[2], _countPrise); break;
                    case 15: _giveItem.Chest1(_countPrise); CreateBuyView(GameScript.ChestsSprite[0], _countPrise); break;
                    case 16: _giveItem.Chest2(_countPrise); CreateBuyView(GameScript.ChestsSprite[1], _countPrise); break;
                    case 17: _giveItem.Chest3(_countPrise); CreateBuyView(GameScript.ChestsSprite[2], _countPrise); break;
                    case 18: _giveItem.Chest4(_countPrise); CreateBuyView(GameScript.ChestsSprite[3], _countPrise); break;
                    case 19: _giveItem.Chest5(_countPrise); CreateBuyView(GameScript.ChestsSprite[4], _countPrise); break;
                    case 20: _giveItem.Chest6(_countPrise); CreateBuyView(GameScript.ChestsSprite[5], _countPrise); break;
                    case 21: _giveItem.Chest7(_countPrise); CreateBuyView(GameScript.ChestsSprite[6], _countPrise); break;
                    case 22: _giveItem.Chest8(_countPrise); CreateBuyView(GameScript.ChestsSprite[7], _countPrise); break;
                    default:
                        break;
                }
                TakeItem = true;
                checkPrise();
            }
            else
            {
                Instantiate(_premPrefab, _parentPanel.transform);
            }
        }
    }
}
