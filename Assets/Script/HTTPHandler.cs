using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HTTPHandler : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GetPrediction());
    }

    IEnumerator GetPrediction()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost:5000/GPTAssistant/predictOutput?input=Artemisa%20was");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
}
