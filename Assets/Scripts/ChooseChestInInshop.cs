using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseChestInInshop : MonoBehaviour
{
    [SerializeField] GameObject _chestOpenPrefab;
    [SerializeField] GameObject _parentPanel;
    [SerializeField] int _index;
    [SerializeField] string _name;

    // Start is called before the first frame update
    void Start()
    {
        _parentPanel = GameObject.FindGameObjectWithTag("PanelForNewItems");
    }

    public void CreateBuyView()
    {
        GameObject Case = Instantiate(_chestOpenPrefab, _parentPanel.transform) as GameObject;
        Case.GetComponent<ChestInShop>().SetInfo(_index,_name);
    }
    public void CreateBuyViewPotion()
    {
        GameObject Case = Instantiate(_chestOpenPrefab, _parentPanel.transform) as GameObject;
        Case.GetComponent<PotionsInShop>().SetInfo(_index, _name);
    }

}
