using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenChest : MonoBehaviour
{
    [SerializeField] GameObject _image;

    [SerializeField] Game GameScript;

    [SerializeField] private int _index;
    [SerializeField] private string _name;
    [SerializeField] TextMeshProUGUI _nameText;

    [SerializeField] private int _countItem;
    [SerializeField] private int _countItemVIP;
    [SerializeField] TextMeshProUGUI _countItemText;

    [SerializeField] TextMeshProUGUI _buttonAccept;
    [SerializeField] TextMeshProUGUI _buttonCancel;

    [SerializeField] GameObject _chestOpenPrefab;
    [SerializeField] GameObject _parentPanel;

    void Start()
    {
        GameScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>();
        _parentPanel = GameObject.FindGameObjectWithTag("PanelForNewItems");

    }

    public void SetInfo(int index, string name, int countItem, int countItemVIP)
    {
        _index = index;
        _name = name;
        _countItem = countItem;
        _countItemVIP = countItemVIP;
        

        GameScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>();
        _image.GetComponent<Image>().sprite = GameScript.ChestsSprite[index];
        _nameText.text = name;
        if (GameScript.Status == 0)
        {
            _countItemText.text = $"From this chest you will receive {_countItem} Items";
        }
        else
        {
            _countItemText.text = $"From this chest you will receive {_countItemVIP} Items";
        }

        GameScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>();
        if (GameScript.Language == "ru_RU")
        {
            _buttonAccept.font = GameScript.RUSFont;
            _buttonCancel.font = GameScript.RUSFont;
        }
        else
        {
            _buttonAccept.font = GameScript.ENGFont;
            _buttonCancel.font = GameScript.ENGFont;
        }
        _buttonAccept.text = GameObject.FindObjectOfType<TranslateMeneger>().GetAnyTranslate(4);
        _buttonCancel.text = GameObject.FindObjectOfType<TranslateMeneger>().GetAnyTranslate(2);
    }
    public void Destr()
    {
        Destroy(this.gameObject);
    }

    public void ThisChestOnep()
    {
        if (GameScript.Status == 0)
        {
            Open(_index, _countItem);
        }
        else
        {
            Open(_index, _countItemVIP);
        }
    }
    void AchivePlus()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().AchPanel.PlusChests();
    }
    void Open(int index, int count)
    {
        StartCoroutine(OpenWithStop(index, count));
    }
    public bool NextStep;
    GameObject Case;
    IEnumerator OpenWithStop(int index, int countItem)
    {
        if (GameScript.chests[index] > 0)
        {
            GameScript.chests[index]--;
            AchivePlus();
            for (int i = 0; i < countItem; i++)
            {
                int rand = Random.Range(0, 1000);
                Debug.Log($"Рандом - {rand}");
                if (rand <= 900)
                {
                    int randPotion = Random.Range(0, 1000);
                    if (randPotion <= 400)
                    {
                        int[] idPotion = new int[3] { 0, 4, 8};
                        int idP = Random.Range(0, idPotion.Length);
                        GameScript.potions[idPotion[idP]]++;
                        Case = Instantiate(_chestOpenPrefab, _parentPanel.transform) as GameObject;
                        Case.GetComponent<OpenViewChests>().SetInfo(GameScript.PotionsSprite[idPotion[idP]]);
                    }
                    else if (randPotion <= 700)
                    {
                        int[] idPotion = new int[3] { 1, 5, 9 };
                        int idP = Random.Range(0, idPotion.Length);
                        GameScript.potions[idPotion[idP]]++;
                        Case = Instantiate(_chestOpenPrefab, _parentPanel.transform) as GameObject;
                        Case.GetComponent<OpenViewChests>().SetInfo(GameScript.PotionsSprite[idPotion[idP]]);
                    }
                    else if (randPotion <= 900)
                    {
                        int[] idPotion = new int[3] { 2, 6, 10 };
                        int idP = Random.Range(0, idPotion.Length);
                        GameScript.potions[idPotion[idP]]++;
                        Case = Instantiate(_chestOpenPrefab, _parentPanel.transform) as GameObject;
                        Case.GetComponent<OpenViewChests>().SetInfo(GameScript.PotionsSprite[idPotion[idP]]);
                    }
                    else
                    {
                        int[] idPotion = new int[3] { 3, 7, 11 };
                        int idP = Random.Range(0, idPotion.Length);
                        GameScript.potions[idPotion[idP]]++;
                        Case = Instantiate(_chestOpenPrefab, _parentPanel.transform) as GameObject;
                        Case.GetComponent<OpenViewChests>().SetInfo(GameScript.PotionsSprite[idPotion[idP]]);
                    }
                }
                else if (rand <= 950) 
                {
                    int idP = Random.Range(0, GameScript.GameTheme.Length);
                    if(GameScript.GameTheme[idP] == true)
                    {
                        GameScript.PlusCrystalBalance(50);
                        Case = Instantiate(_chestOpenPrefab, _parentPanel.transform) as GameObject;
                        Case.GetComponent<OpenViewChests>().SetInfo(GameScript.CrystalSprite[2], 50);
                    }
                    else
                    {
                        GameScript.GameTheme[idP] = true;
                        GameObject.FindObjectOfType<GameTheme>().CheckHaveColor();
                        Case = Instantiate(_chestOpenPrefab, _parentPanel.transform) as GameObject;
                        Case.GetComponent<OpenViewChests>().SetInfo(GameObject.FindObjectOfType<GameTheme>()._inColorButtons[idP], "NEW THEME");
                    }
                }
                else
                {
                    int idP = Random.Range(0, GameScript.ClickSkin.Length);
                    if (GameScript.ClickSkin[idP] == true)
                    {
                        GameScript.PlusCrystalBalance(50);
                        Case = Instantiate(_chestOpenPrefab, _parentPanel.transform) as GameObject;
                        Case.GetComponent<OpenViewChests>().SetInfo(GameScript.CrystalSprite[2], 50);
                    }
                    else
                    {
                        GameScript.ClickSkin[idP] = true;
                        GameObject.FindObjectOfType<ClickSkinChange>().CheckHaveColor();
                        Case = Instantiate(_chestOpenPrefab, _parentPanel.transform) as GameObject;
                        Case.GetComponent<OpenViewChests>().SetInfo(GameScript.ClickSkinSprite[idP], "NEW SKIN");
                    }


                }
                NextStep = false;
                yield return new WaitUntil(()=>NextStep == true);
            }
            Destr();
        }
        else
        {
            GameObject ef = GameObject.Instantiate(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().WrongStepPrefab, GameObject.FindGameObjectWithTag("PanelForNewItems").transform) as GameObject;
            if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().Language == "ru_RU")
            {
                ef.GetComponent<WrongStep>().SetText($"У вас нет этого сундука");
            }
            else
            {
                ef.GetComponent<WrongStep>().SetText($"You don't have this chest");
            }
        }
    }
    string digitInTextBalance(double digitF)
    {
        /*
K	Thousand	Тысяча	
M	Million	    Миллион	
B	Billion	    Миллиард	
T	Trillion	Триллион	
q	Quadrillion	Квадриллион	
Q	Quintillion	Квинтиллион	
s	Sextillion	Сикстиллион	
S	Septillion	Септиллион	
O	Octillion	Октиллион	
N	Nonillion	Нониллион	
d	Decillion	Дециллион

         */
        double d1000 = 1000;
        double d1000000 = 1000000;
        double d1000000000 = 1000000000;
        double d1000000000000 = 1000000000000;
        double d1000000000000000 = 1000000000000000;
        double d1000000000000000000 = 1000000000000000000;
        double notDigit;
        string NotDigit = "notwork";
        if (digitF < d1000)
        {
            NotDigit = digitF.ToString("0");
        }
        else if (digitF < 1000000)
        {
            notDigit = digitF / d1000;
            NotDigit = notDigit.ToString("0.000") + "K";
        }
        else if (digitF < 1000000000)
        {
            notDigit = digitF / d1000000;
            NotDigit = notDigit.ToString("0.000") + "M";
        }
        else if (digitF < 1000000000000)
        {
            notDigit = digitF / d1000000000;
            NotDigit = notDigit.ToString("0.000") + "B";
        }
        else if (digitF < 1000000000000000)
        {
            notDigit = digitF / d1000000000000;
            NotDigit = notDigit.ToString("0.000") + "T";
        }
        else if (digitF < 1000000000000000000)
        {
            notDigit = digitF / d1000000000000000;
            NotDigit = notDigit.ToString("0.000") + "q";
        }
        else if (digitF < d1000000000000000000 * 1000)
        {
            notDigit = digitF / 1000000000000000000;
            NotDigit = notDigit.ToString("0.000") + "Q";
        }
        else if (digitF < d1000000000000000000 * 1000000)
        {
            notDigit = digitF / (d1000000000000000000 * 1000);
            NotDigit = notDigit.ToString("0.000") + "s";
        }
        else if (digitF < d1000000000000000000 * 1000000000)
        {
            notDigit = digitF / (d1000000000000000000 * 1000000);
            NotDigit = notDigit.ToString("0.000") + "S";
        }
        else if (digitF < d1000000000000000000 * 1000000000000)
        {
            notDigit = digitF / (d1000000000000000000 * 1000000000);
            NotDigit = notDigit.ToString("0.000") + "O";
        }
        else if (digitF < d1000000000000000000 * d1000000000000000)
        {
            notDigit = digitF / (d1000000000000000000 * d1000000000000);
            NotDigit = notDigit.ToString("0.000") + "N";
        }
        else if (digitF < d1000000000000000000 * d1000000000000000000)
        {
            notDigit = digitF / (d1000000000000000000 * d1000000000000000);
            NotDigit = notDigit.ToString("0.000") + "d";
        }
        return NotDigit;
    }
}
