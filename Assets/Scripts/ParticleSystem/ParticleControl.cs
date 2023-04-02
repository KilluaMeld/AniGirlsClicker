using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleControl : MonoBehaviour
{
    // Start is called before the first frame update
    public double _count;
    public int speed;
    public Vector3 mousePos;
    public Vector3 randVect;
    public Vector3 mousePosClick;
    byte alpha = 255;
    void Start()
    {
        StartCoroutine(destr());
        randVect = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
    }
    IEnumerator destr()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    
    // Update is called once per frame

    void Update()
    {
        transform.Translate((randVect * Time.deltaTime) * speed);
    }
}
