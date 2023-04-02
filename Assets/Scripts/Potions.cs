using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class Potions : MonoBehaviour
{
    public int _index;
    public int count;
    public GameObject counter;
    public GameObject cooldownPanel;
    public TextMeshProUGUI coutText;
    public Game GameScript;
    [SerializeField] GameObject _effectsPanel;
    [SerializeField] Image _effectsfill;
    // Start is called before the first frame update
    void Start()
    {
        GameScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>();
        _parentPanel = GameObject.FindGameObjectWithTag("PanelForNewItems");
    }
    [SerializeField] GameObject _chestOpenPrefab;
    [SerializeField] GameObject _parentPanel;



    public void CreateUseView()
    {
        GameObject Case = Instantiate(_chestOpenPrefab, _parentPanel.transform) as GameObject;
        Case.GetComponent<PanelInfoPotionsUpdate>().SetInfo(_index);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SoundsManager>().PlaySound(5);
    }
    public void startcorutin()
    {
       StartCoroutine(timers());
    }
    public void startcorutineEffect()
    {
        StartCoroutine(timersEffects());
    }
    public IEnumerator timersEffects()
    {
        _effectsPanel.SetActive(true);
        _effectsfill.fillAmount = 1;
        for (int i = 0; i < 600; i++)
        {
            yield return new WaitForSeconds(0.1f);
            _effectsfill.GetComponent<Image>().fillAmount -= 1 / 600f;
            if (i >= 599) { _effectsPanel.SetActive(false); }
        }

    }
    public IEnumerator timers()
    {
        cooldownPanel.GetComponent<Image>().fillAmount = 1;
        for (int i = 0; i < 600; i++)
        {
            yield return new WaitForSeconds(0.1f);
            cooldownPanel.GetComponent<Image>().fillAmount -= 1/600f;
        }

    }
    // Update is called once per frame
    void Update()
    {
        count = GameScript.potions[_index];
        if (count > 0) { counter.SetActive(true); } else { counter.SetActive(false); }
        if (count > 999)
        {
            coutText.text = "999+";
        }
        else
        {
            coutText.text = GameScript.potions[_index].ToString();
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
