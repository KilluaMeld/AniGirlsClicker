using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AudioMein : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetAudioClip());
    }

    IEnumerator GetAudioClip()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("https://soro-kams.ru/download/XC9zdHJlYW1cL215bVwvYUhSMGNITTZMeTl0YjI5emFXTXViWGt1YldGcGJDNXlkUzltYVd4bEwyUmpOalUxTVRoaU1XWXpOVFJrTlRRMVlUSTNOakF6WkRrME56Y3pNVE0yTG0xd016OXJNajAwTWprM1lqQmtPVFpqTVdVelpUbGpNVGswWm1Zek9EUmtNakZrTVdNeE53PT0=/Kakuchou%20Shoujo-kei%20Trinary%20-%20PaPa%20TuTu%20WaWa", AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError == true)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler);
                Debug.Log("lol");
               // AudioClip myClip = DownloadHandlerAudioClip.GetContent(www);
                GetComponent<AudioSource>().clip = DownloadHandlerAudioClip.GetContent(www);
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
