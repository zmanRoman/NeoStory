using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundPrefab : StoryAssets
{
   
    [SerializeField] private long _id;
    [SerializeField] private string _url;
    [SerializeField] private string _path;
    private AssyncDownloader AssyncDownloader;
    [SerializeField] private Texture2D texture;
    public long Id => _id;

    public Texture2D Texture
    {
        get => texture;
    }
 
    public void Init(long id, string url, string path, AssyncDownloader assyncDownloader)
    {
        _id = id;
        _url = url;
        _path = path;
        this.AssyncDownloader = assyncDownloader;
    }
    
    public void LoadTexture()
    {
        AssyncDownloader.BackgroundLoading(_url, Id.ToString(), gameObject,  _path);
        //для удоства иерархии
        gameObject.name = Id + "- Loaded";
    }

    public override void SetTexture(Texture2D texture)
    {
        this.texture = texture;
    }
    public override void DestroyTexture()
    {
        Destroy(texture);
        //для удоства иерархии
        gameObject.name = Id + "- Unload";
    }
}