using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabsParticle;
    [SerializeField] private GameObject _mainMenuPanelForParticle;
    [SerializeField] private RectTransform _rect;
    // Start is called before the first frame update
    private void Start()
    {
        _rect = _mainMenuPanelForParticle.transform as RectTransform;
        StartCoroutine(CreatePartical());
    }
    IEnumerator CreatePartical()
    {
        while (true)
        {
            int randomForPrefabs = Random.Range(0, _prefabsParticle.Length);
            GameObject qwerty = Instantiate(_prefabsParticle[randomForPrefabs], _rect.position, Quaternion.identity, _rect) as GameObject;
            qwerty.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-_rect.sizeDelta.x / 2, _rect.sizeDelta.x / 2), Random.Range(-_rect.sizeDelta.y / 2, _rect.sizeDelta.y / 2));
            yield return new WaitForSeconds(0.5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //CreatePartical(_size,0,_speed,0,_mainMenuPanelForParticle.transform.position);
    }
}
