using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Resources;
using System.Data.Common;

public class MainController : MonoBehaviour
{
    [SerializeField] Canvas uiCanvas;
    [SerializeField] AlbumEntry prefabTemplate;

    private List<AlbumEntryData> dataList;
    private int creationID;
    private AlbumEntry selectedEntry;

    private const string API_URL = "https://jsonplaceholder.typicode.com/photos";

    void Start()
    {
        uiCanvas.gameObject.SetActive(false);
        StartCoroutine(WebRequestHelper.CallAPI_Coroutine(API_URL, OnPhotoData));
    }

    private void OnPhotoData(string rawData)
    {
        uiCanvas.gameObject.SetActive(true);
        dataList = JsonConvert.DeserializeObject<List<AlbumEntryData>>(rawData);
        creationID = -1;
    }

    public void CreateAlbumEntry()
    {
        //instantiate high up so that it'll fall with the physics system
        var albumEntry = Instantiate(prefabTemplate, new Vector3(Random.value, 5, Random.value), Quaternion.identity);

        creationID++;
        if (creationID >= dataList.Count)
        {
            creationID = -1;
        }
        albumEntry.InjectData(dataList[creationID]);

        albumEntry.OnClicked += SelectAlbumEntry;
    }

    public void SelectAlbumEntry(AlbumEntry clicked)
    {
        if (selectedEntry != null)
        {
            selectedEntry.SetHighlight(false);
        }
        selectedEntry = clicked;
        selectedEntry.SetHighlight(true);
    }

    public void DeleteSelected()
    {
        if (selectedEntry != null)
        {
            Destroy(selectedEntry.gameObject);
            selectedEntry = null;
        }
    }
}
