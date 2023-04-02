using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TranslateMeneger : MonoBehaviour
{
    [SerializeField] private TMP_FontAsset _russianFont;
    [SerializeField] private TMP_FontAsset _englishFont;
    [SerializeField] private TextMeshProUGUI[] _shopMenu;
    private string[] _shopMenuEngText = new string[]
    {
        "Bonus shop" ,
        "Gold Bonus for hero",
        "Acceleration Speed Hero",
        "Increase heart",
        "Potion shop",
        "Chest shop",
        "Money shop"
    };
private string[] _shopMenuRusText = new string[]
    {
        "������� �������" ,
        "������ ������ (�����)",
        "�������� ������ (�����)",
        "��������� ������",
        "������� �����",
        "������� ��������",
        "������� ������"
    };
    [SerializeField] private TextMeshProUGUI[] _attackMenu;
    private string[] _attackMenuEngText = new string[] {
    "Double\nClick",
    "Free\nChest"
    };
    private string[] _attackMenuRusText= new string[] { 
    "������� ����",
    "���������� ������"
    };
    [SerializeField] private TextMeshProUGUI[] _AchiveMenu;
    private string[] _AchiveMenuEngText = new string[] {
    "Use any 5 potions",
    "Use any 10 potions",
    "Use any 20 potions",
    "Use any 50 potions",
    "Use any 100 potions",
    "Open any 5 any chests",
    "Open any 10 any chests",
    "Open any 20 any chests",
    "Open any 50 any chests",
    "Open any 100 any chests",
    "Clicks 1.000k times",
    "Clicks 25.000k times",
    "Clicks 50.000k times",
    "Clicks 100.000k times",
    "Clicks 500.000k times",
    "Clicks 1.000m times",
    "Clicks 5.000m times",
    "Clicks 10.000m times",
    "Clicks 50.000m times",
    "Clicks 100.000m times",
    "Buy first heros",
    "Buy 5 heros",
    "Buy 10 heros",
    "Buy 15 heros",
    "Buy 20 heros",
    "Buy all heros"
    };
    private string[] _AchiveMenuRusText = new string[]{
    "����������� 5 ����� �����",
    "����������� 10 ����� �����",
    "����������� 20 ����� �����",
    "����������� 50 ����� �����",
    "����������� 100 ����� �����",
    "�������� 5 ����� ��������",
    "�������� 10 ����� ��������",
    "�������� 20 ����� ��������",
    "�������� 50 ����� ��������",
    "�������� 100 ����� ��������",
    "�������� 1.000k ���",
    "�������� 25.000k ���",
    "�������� 50.000k ���",
    "�������� 100.000k ���",
    "�������� 500.000k ���",
    "�������� 1.000m ���",
    "�������� 5.000m ���",
    "�������� 10.000m ���",
    "�������� 50.000m ���",
    "�������� 100.000m ���",
    "������ ������� �����",
    "������ 5 ������",
    "������ 10 ������",
    "������ 15 ������",
    "������ 20 ������",
    "������ ���� ������"
    };


    [SerializeField] private TextMeshProUGUI[] _backMenu;
    private string[] _backMenuEngText = new string[] {
    "Achivments",
    "Update log",
    "Support",
    "Settings",
    "More games",
    "Musics",
    "Sounds",
    "Change language"
    };
    private string[] _backMenuRusText = new string[] { 
    "����������",
    "����������",
    "������",
    "���������",
    "������ ���",
    "������",
    "�����",
    "�������� ����"
    };


    [SerializeField] private TextMeshProUGUI[] _potionsName;
    [SerializeField] private TextMeshProUGUI[] _potionsInfo;
    private string[,] _potionEngText = new string[,]{
    { "Haste potion 1","Get speed 1 lvl\n - 0.3 sec" },
    { "Haste potion 2","Get speed 2 lvl\n - 0.75 sec" },
    { "Haste potion 3","Get speed 3 lvl\n - 1.5 sec" },
    { "Haste potion 4","Get speed 4 lvl\n - 2 sec" },
    { "Golden potion 1","Get hero gold bonus\n+ 10% gold" },
    { "Golden potion 2","Get hero gold bonus\n+ 20% gold" },
    { "Golden potion 3","Get hero gold bonus\n+ 30% gold" },
    { "Golden potion 4","Get hero gold bonus\n+ 40% gold" },
    { "AutoClick potion 2","Automaticly clicks\n1 click/1 sec" },
    { "AutoClick potion 2","Automaticly clicks\n1 click/0.75 sec" },
    { "AutoClick potion 3","Automaticly clicks\n1 click/0.5 sec" },
    { "AutoClick potion 4","Automaticly clicks\n1 click/0.2 sec" }
    };
    [SerializeField]
    private string[,] _potionRusText = new string[,]{
    { "����� �������� 1","��������� ����� ������\n����� �� 1 ��.\n - 0.3 ���." },
    { "����� �������� 2","��������� ����� ������\n����� �� 2 ��.\n - 0.75 ���." },
    { "����� �������� 3","��������� ����� ������\n����� �� 3 ��.\n - 1.5 ���." },
    { "����� �������� 4","��������� ����� ������\n����� �� 4 ��.\n - 2 ���." },
    { "����� ������ 1","����� ������ � ������\n+ 10% ���. ������" },
    { "����� ������ 2","����� ������ � ������\n+ 20% ���. ������" },
    { "����� ������ 3","����� ������ � ������\n+ 30% ���. ������" },
    { "����� ������ 4","����� ������ � ������\n+ 40% ���. ������" },
    { "����� ��������� 1","�������������� ����\n1 ����/1 ���" },
    { "����� ��������� 2","�������������� ����\n1 ����/0.75 ���" },
    { "����� ��������� 3","�������������� ����\n1 ����/0.5 ���" },
    { "����� ��������� 4","�������������� ����\n1 ����/0.2 ���" },
    };
    private string[] _anyTranslateEng = new string[]
{
        "Back" ,
        "Buy",
        "Cancel",
        "Use",
        "Open",
        "Claim",
        "Select language",
        "Continue"
};
    private string[] _anyTranslateRus = new string[]
{
        "�����" ,
        "������",
        "������",
        "�����������",
        "�������",
        "�������",
        "�������� ����",
        "����������"
};
    void Start()
    {

        for (int i = 0; i < _shopMenu.Length; i++)
        {
            _shopMenuEngText[i] = _shopMenu[i].text;
        }

        if (GameObject.FindObjectOfType<Game>().Language == "ru_RU")
        {
            SetLanguage("ru_RU");
        }
        else
        {
            SetLanguage("en_EN");
        }
    }

    public string GetPotionsTranslate(int a, int b)
    {
        if (GameObject.FindObjectOfType<Game>().Language == "ru_RU")
        {
            return _potionRusText[a,b];
        }
        else
        {
            return _potionEngText[a,b];
        }
    }
    public string GetAnyTranslate(int a)
    {
        if (GameObject.FindObjectOfType<Game>().Language == "ru_RU")
        {
            return _anyTranslateRus[a];
        }
        else
        {
            return _anyTranslateEng[a];
        }
    }
    public void SetLanguage(string lang)
    {
        GameObject.FindObjectOfType<Game>().Language = lang;
        TextForLanguage[] allAnyText =  GameObject.FindObjectsOfType<TextForLanguage>();
        for (int i = 0; i < allAnyText.Length; i++)
        {
            allAnyText[i].SetLanguage();
        }
        if (lang == "ru_RU")
        {
            RewriteText(ref _shopMenu, _shopMenuRusText, _russianFont);
            RewriteText(ref _attackMenu, _attackMenuRusText, _russianFont);
            RewriteText(ref _backMenu, _backMenuRusText, _russianFont);
            RewriteText(ref _AchiveMenu, _AchiveMenuRusText, _russianFont);
        }
        else
        {
            RewriteText(ref _shopMenu, _shopMenuEngText, _englishFont);
            RewriteText(ref _attackMenu, _attackMenuEngText, _englishFont);
            RewriteText(ref _backMenu, _backMenuEngText, _englishFont);
            RewriteText(ref _AchiveMenu, _AchiveMenuEngText, _englishFont);
        }

    }
    void RewriteText(ref TextMeshProUGUI[] mainText,string[] curLangText, TMP_FontAsset curLangFont)
    {
            for (int i = 0; i < mainText.Length; i++)
            {
                mainText[i].font = curLangFont;
                mainText[i].text = curLangText[i];
            }
    }
}
