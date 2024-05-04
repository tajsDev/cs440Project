using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class AddToDatabase : MonoBehaviour
{
    public string input;
    public string completeURL;

    void Start()
    {

    }

    public void SendInputAndData(string name, string password)
    {
        int sendRound = 0;
        int sendEndless = 0;
        if(ScoreTracker.isEndless) {

            sendEndless = ScoreTracker.currentScore ;
        }
        else {
            sendRound = ScoreTracker.currentScore ;          
        }
        var bodyData = new
        {
            name = name,
            round = sendRound,
            endless = sendEndless,
            time = ScoreTracker.time.ToString(),
        };

        StartCoroutine(PostRequest(bodyData));
    }

    IEnumerator PostRequest(object bodyData)
    {
        if (ScoreTracker.isEndless)
        {

        }
        string url = "https://us-central1-laststeps-f7991.cloudfunctions.net/AddRecord";
        string json = JsonUtility.ToJson(bodyData);
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            Debug.Log("Response: " + request.downloadHandler.text);
        }
    }
}
