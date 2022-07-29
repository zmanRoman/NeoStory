using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatPrefab : StoryAssets
{
    [SerializeField] private int id;
    [SerializeField] private string findName;
    [SerializeField] private string localizedName;
    [SerializeField] private string url;
    
    private Texture2D _texture;
    private Sprite _sprite;

    //public Texture2D Texture => _texture;
    public Sprite Sprite => _sprite;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI textLocalized;
    [SerializeField] private TextMeshProUGUI textValue;
    public int ID => id;
    public string FindName => findName;
    public string LocalizedName => localizedName;
    public string Url => url;

    
    public void Init(int _id, string _findName, string _localizedName, string _url)
    {
        id = _id;
        findName = _findName;
        localizedName = _localizedName;
        textLocalized.text = localizedName;
        url = _url;
        gameObject.SetActive(false);
    }
    public override void SetTexture(Texture2D texture)
    {
        _texture = texture;
        _sprite = Sprite.Create(this._texture, new Rect(0.0f, 0.0f, _texture.width, _texture.height), new Vector2(0.5f, 0.5f), 100.0f, 0, SpriteMeshType.FullRect);
        image.sprite = _sprite;
    }

    public void SetValue(int value)
    {
        textValue.text = value.ToString();
    }
    public override void DestroyTexture()
    {
        Destroy(_texture);
    }
}
