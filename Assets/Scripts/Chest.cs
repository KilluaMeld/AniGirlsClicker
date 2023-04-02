using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Chest : MonoBehaviour
{
    public int id;
    public int count;

    public GameObject counter;
    public TextMeshProUGUI coutText;
    public Game GameScript;

    [SerializeField] private string _name;


    [SerializeField] private int _countItem;
    [SerializeField] private int _countItemVip;



    [SerializeField] GameObject _chestOpenPrefab;
    [SerializeField] GameObject _parentPanel;
    // Start is called before the first frame update
    void Start()
    {
        GameScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>();
    }
    public void OpenPanelInfo()
    {

        GameObject View = Instantiate(_chestOpenPrefab, _parentPanel.transform) as GameObject;
        View.GetComponent<OpenChest>().SetInfo(id, _name, _countItem, _countItemVip);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(5);
    }


    // Update is called once per frame
    void Update()
    {
        count = GameScript.chests[id];
        if (count > 0) { counter.SetActive(true); } else { counter.SetActive(false); }
        if (count > 999)
        {
            coutText.text = "999+";
        }
        else
        {
            coutText.text = GameScript.chests[id].ToString();
        }
        if (count <= 0)
        {
            this.gameObject.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
        }
        else
        {
            this.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}
