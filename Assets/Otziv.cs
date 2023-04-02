using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otziv : MonoBehaviour
{
    public void AcceptOtziv()
    {
        GameObject.FindObjectOfType<Game>().ChooseStar = false;
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Minor.Anigirl");
        Destroy(this.gameObject);
    }
    public void DislineOtziv()
    {
        GameObject.FindObjectOfType<Game>().ChooseStar = false;
        Destroy(this.gameObject);
    }
}
