using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Resources;

public class MainController : MonoBehaviour
{
    private List<AlbumEntryData> dataList;

    private const string API_URL = "https://jsonplaceholder.typicode.com/photos";

    void Start()
    {
        StartCoroutine(WebRequestHelper.CallAPI_Coroutine(API_URL, OnPhotoData));
    }

    private void OnPhotoData(string rawData)
    {
        dataList = JsonConvert.DeserializeObject<List<AlbumEntryData>>(rawData);
        
        StartCoroutine(WebRequestHelper.GetImage_Coroutine(dataList[0].Url, OnImage));
    }

    private void OnImage(Texture2D tex)
    {
        var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        var mat = obj.GetComponent<MeshRenderer>().material;
        mat.mainTexture = tex;
    }
}
