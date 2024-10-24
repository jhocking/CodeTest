using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbumEntry : MonoBehaviour
{
    public event Action<AlbumEntry> OnClicked;

    private Material mat;
    private AlbumEntryData data;

    void Start()
    {
        mat = this.GetComponent<MeshRenderer>().material;
        SetHighlight(false);
    }

    void OnMouseDown()
    {
        OnClicked?.Invoke(this);
    }

    public void InjectData(AlbumEntryData data)
    {
        this.data = data;
        Debug.Log($"Injected {data}");
    }

    public void SetHighlight(bool doHighlight)
    {
        if (doHighlight)
        {
            mat.color = Color.yellow;
            StartCoroutine(WebRequestHelper.GetImage_Coroutine(data.Url, OnImage));
        }
        else
        {
            mat.color = Color.white;
            mat.mainTexture = null;
        }
    }

    private void OnImage(Texture2D tex)
    {
        mat.mainTexture = tex;
    }
}
