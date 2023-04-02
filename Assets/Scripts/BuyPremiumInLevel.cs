using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPremiumInLevel : MonoBehaviour
{
    void Start()
    {
        
    }
    public void BuyPrem()
    {
        GameObject.FindObjectOfType<InAppManager.InAppManager>().BuyProductID("premium1_game");
        Destr();
    }
    public void Destr()
    {
        Destroy(this.gameObject);
    }
}
