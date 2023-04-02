using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestClick : MonoBehaviour
{
    Button bttn;
    float time = 0;
    private void Start()
    {
        bttn = this.GetComponent<Button>();
        StartCoroutine(deb());
    }
    IEnumerator deb()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1);
            Debug.Log(123);
        }
        
    }
    void FixedUpdate()
    {
        //Debug.Log($"{time} + {Time.deltaTime}");
        time += Time.deltaTime;
        
        if (time >= 0.14f)
        {
            bttn.onClick.Invoke();
            time = 0;
        }
    }
}
