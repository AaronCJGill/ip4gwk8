using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// handles all json interactions and sends them to the json translator
/// </summary>
public class JsonManager : MonoBehaviour
{
    string url = "https://api.nobelprize.org/v1/prize.json";



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getJsonFromUrl(url, recievedJSON));
    }

    IEnumerator getJsonFromUrl(string url, System.Action<string> callback)
    {
        string jsonText;
        UnityWebRequest www = UnityWebRequest.Get(url);
        Debug.Log("Getting info");
        www.SetRequestHeader("Content-Type", "application/json");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            jsonText = www.error;
            Debug.Log("This attitude");
        }
        else
        {
            jsonText = www.downloadHandler.text;
            Debug.Log("sent");
        }
        callback(jsonText);
        www.Dispose();
    }

    void recievedJSON2(string jsonRecieved)
    {
        //print(jsonTextReceived);
        jsonTranslator tr = JsonUtility.FromJson<jsonTranslator>(jsonRecieved);
        print(tr);
        //tr.id += 1;

    }
    [SerializeField]
    Prizes[] p = new Prizes[1];
    void recievedJSON(string jsonRecieved)
    {
        jsonTranslator tr = new jsonTranslator();
        tr.prizes = null;
        tr = JsonUtility.FromJson<jsonTranslator>(jsonRecieved);
        //tr.prizes[0].laureates = JsonUtility.FromJson<Laureates>(jsonRecieved);
        p = tr.prizes;
        
        //Prizes[] p2 = new Prizes[tr.prizes.Length];
        /*
        foreach (Prizes prize in p)
        {
            Debug.Log(prize.year);
        }
        
        for (int i = 0; i < p.Length; i++)
        {
            p2[i] = p[i];
        }
        */
        GameManager.instance.StartGameManager(p);
    }
}
