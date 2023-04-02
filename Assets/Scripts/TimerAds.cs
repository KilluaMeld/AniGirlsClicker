using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerAds : MonoBehaviour
{
    public GameObject fill360;
    public bool adsReady = true;
    public float timer = 0;
    public float cooldown = 120;
    public void startTimer()
    {
        StartCoroutine(cooldownAds());
    }
    public IEnumerator cooldownAds()
    {
            timer = cooldown;
        adsReady = false;
            while (timer > 0)
            {
                fill360.GetComponent<Image>().fillAmount = (cooldown - timer) / cooldown;
                timer--;
                yield return new WaitForSeconds(1);
            }
        adsReady = true;
        fill360.GetComponent<Image>().fillAmount = 1;
        StopCoroutine(cooldownAds());
    }
}
