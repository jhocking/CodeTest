using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class MainController : MonoBehaviour
{
    private const string API_URL = "https://jsonplaceholder.typicode.com/photos";

    void Start()
    {
        StartCoroutine(WebRequestHelper.CallAPI_Coroutine(API_URL, OnPhotoData));
    }

    private void OnPhotoData(string rawData)
    {
        var dataList = JsonConvert.DeserializeObject<List<AlbumEntryData>>(rawData);
        Debug.Log(dataList[0].Url);
    }
}
