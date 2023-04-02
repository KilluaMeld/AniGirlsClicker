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
        "Магазин бонусов" ,
        "Добыча золота (герои)",
        "Скорость добычи (герои)",
        "Улучшение сердца",
        "Магазин зелий",
        "Магазин сундуков",
        "Магазин валюты"
    };
    [SerializeField] private TextMeshProUGUI[] _attackMenu;
    private string[] _attackMenuEngText = new string[] {
    "Double\nClick",
    "Free\nChest"
    };
    private string[] _attackMenuRusText= new string[] { 
    "Двойной клик",
    "Бесплатный сундук"
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
    "Используйте 5 любых зелий",
    "Используйте 10 любых зелий",
    "Используйте 20 любых зелий",
    "Используйте 50 любых зелий",
    "Используйте 100 любых зелий",
    "Откройте 5 любых сундуков",
    "Откройте 10 любых сундуков",
    "Откройте 20 любых сундуков",
    "Откройте 50 любых сундуков",
    "Откройте 100 любых сундуков",
    "Кликните 1.000k Раз",
    "Кликните 25.000k Раз",
    "Кликните 50.000k Раз",
    "Кликните 100.000k Раз",
    "Кликните 500.000k Раз",
    "Кликните 1.000m Раз",
    "Кликните 5.000m Раз",
    "Кликните 10.000m Раз",
    "Кликните 50.000m Раз",
    "Кликните 100.000m Раз",
    "Купите первого героя",
    "Купите 5 героев",
    "Купите 10 героев",
    "Купите 15 героев",
    "Купите 20 героев",
    "Купите всех героев"
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
    "Достижения",
    "Обновления",
    "Помощь",
    "Настройки",
    "Больше игр",
    "Музыка",
    "Звуки",
    "Изменить язык"
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
    { "Зелье скорости 1","Уменьшает время добычи\nгероя на 1 ур.\n - 0.3 сек." },
    { "Зелье скорости 2","Уменьшает время добычи\nгероя на 2 ур.\n - 0.75 сек." },
    { "Зелье скорости 3","Уменьшает время добычи\nгероя на 3 ур.\n - 1.5 сек." },
    { "Зелье скорости 4","Уменьшает время добычи\nгероя на 4 ур.\n - 2 сек." },
    { "Зелье золота 1","Бонус золота у героев\n+ 10% доп. золота" },
    { "Зелье золота 2","Бонус золота у героев\n+ 20% доп. золота" },
    { "Зелье золота 3","Бонус золота у героев\n+ 30% доп. золота" },
    { "Зелье золота 4","Бонус золота у героев\n+ 40% доп. золота" },
    { "Зелье автоклика 1","Автоматический клик\n1 клик/1 сек" },
    { "Зелье автоклика 2","Автоматический клик\n1 клик/0.75 сек" },
    { "Зелье автоклика 3","Автоматический клик\n1 клик/0.5 сек" },
    { "Зелье автоклика 4","Автоматический клик\n1 клик/0.2 сек" },
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
        "Назад" ,
        "Купить",
        "Отмена",
        "Испльзовать",
        "Открыть",
        "Принять",
        "Выберете язык",
        "Продолжить"
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
