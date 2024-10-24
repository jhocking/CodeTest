using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class WebRequestHelper
{
    public static IEnumerator CallAPI_Coroutine(string url, Action<string> callback)
    {
        Debug.Log($"Calling {url}");
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                callback(request.downloadHandler.text);
            }
        }
    }

    public static IEnumerator GetImage_Coroutine(string url, Action<Texture2D> callback)
    {
        Debug.Log($"Getting image {url}");
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                callback(DownloadHandlerTexture.GetContent(request));
            }
        }
    }
}
