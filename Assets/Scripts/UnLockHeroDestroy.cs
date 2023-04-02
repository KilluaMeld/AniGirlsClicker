using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnLockHeroDestroy : MonoBehaviour
{
    [SerializeField] GameObject _buy;
    [SerializeField] GameObject _main;
    int index;
    public void Destoy()
    {
        int status = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().Status;
        if (index > 2 && status==0 && index%2!=0)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Ads>().ShowStranica();
        }
        Destroy(this.gameObject);
    }
    public void SetSprite(Sprite buy,int _index)
    {
        _main.GetComponent<Image>().sprite = buy;
        index = _index;
    }
}
