using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemPrefab : StoryAssets
{
    public long id;
    public string url;
    public Texture2D texture;

    public long ID => id;

    public string Url => url;

    public Texture2D Texture => texture;

    public void Init(long _id, string _url)
    {
        id = _id;
        url = _url;
    }
    
    public override void SetTexture(Texture2D texture)
    {
        this.texture = texture;
    }

    public override void DestroyTexture()
    {
       Destroy(texture);
    }
}