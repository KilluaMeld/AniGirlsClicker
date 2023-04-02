using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyInShop : MonoBehaviour
{
    [SerializeField] Game GameScript;
    [SerializeField] GiveItems ShopAdmin;



    [SerializeField] int Gold1Count;
    [SerializeField] int Gold2Count;
    [SerializeField] int Gold3Count;

    [SerializeField] int Gem1Count;
    [SerializeField] int Gem2Count;
    [SerializeField] int Gem3Count;




    [SerializeField] private GameObject Case;
    [SerializeField] GameObject _chestOpenPrefab;
    [SerializeField] GameObject _parentPanel;
    // Start is called before the first frame update
    void Awake()
    {
        GameScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>();
        ShopAdmin = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GiveItems>();
    }



    void CreateBuyView(Sprite image, int count)
    {
        Case = Instantiate(_chestOpenPrefab, _parentPanel.transform) as GameObject;
        Case.GetComponent<ChestView>().SetInfo(image, count);
    }
    public void BuyGold1()
    {
            GameScript.balance += Gold1Count;
            CreateBuyView(GameScript.GoldSprite[0], Gold1Count);
    }
    public void BuyGold2()
    {
        GameScript.balance += Gold2Count;
        CreateBuyView(GameScript.GoldSprite[1], Gold2Count);
    }
    public void BuyGold3()
    {
        GameScript.balance += Gold3Count;
        CreateBuyView(GameScript.GoldSprite[2], Gold3Count);
    }
    public void BuyGem1()
    {
        GameScript.balanceCrystal += Gem1Count;
        CreateBuyView(GameScript.CrystalSprite[0], Gem1Count);
    }public void BuyGem2()
    {
        GameScript.balanceCrystal += Gem2Count;
        CreateBuyView(GameScript.CrystalSprite[1], Gem2Count);
    }public void BuyGem3()
    {
        GameScript.balanceCrystal += Gem3Count;
        CreateBuyView(GameScript.CrystalSprite[2], Gem3Count);
    }

}
