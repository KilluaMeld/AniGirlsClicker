using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyHeroPanel : MonoBehaviour
{
    [SerializeField] private GameObject _buy;
    [SerializeField] private GameObject _main;
    [SerializeField] private Sprite _buyPlus;
    [SerializeField] private int _index;
    [SerializeField] private GameObject _unlockPrefab;
    [SerializeField] private GameObject _parentPanel;
    private void Start()
    {
        _parentPanel = GameObject.FindGameObjectWithTag("PanelForNewItems");
    }
    public void DestoyAndContinue()
    {
            GameObject UnlckPanel = GameObject.Instantiate(_unlockPrefab, _parentPanel.transform) as GameObject;
            UnlckPanel.GetComponent<UnLockHeroDestroy>().SetSprite(_buyPlus, _index);
            Destroy(this.gameObject);

    }
    public void SetSprite(Sprite buy, Sprite main, int index, Sprite buyPlus)
    {
        _buy.GetComponent<Image>().sprite = main;
        _main.GetComponent<Image>().sprite = buy;
        _buyPlus = buyPlus;
        _index =index;
    }
}
