using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopPotion : MonoBehaviour
{
    public int index;
    public float prise;
    public Game gameScript;
    public TextMeshProUGUI priseText;
    // Start is called before the first frame update
    void Start()
    {
        gameScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>();
        priseText.text = prise.ToString();
    }
    public void BuyPotion()
    {
        if(gameScript.balanceCrystal >= prise)
        {
            GameObject.FindObjectOfType<Game>().MinusCrystalBalance(prise);
            gameScript.potions[index]++;
        }
    }
}
