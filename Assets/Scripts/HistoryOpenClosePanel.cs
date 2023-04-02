using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryOpenClosePanel : MonoBehaviour
{
    public GameObject Panel;
    public void OpenPanel()
    {
        Panel.SetActive(true);
    }
    public void ClosePanel()
    {
        Panel.SetActive(false);
    }
}
