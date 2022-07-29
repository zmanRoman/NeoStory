using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutfitPrefab : StoryAssets
{
    [SerializeField] private Enums.OutfitEnum partOutfit;
    [SerializeField] private string title;
    [SerializeField] private long assetVariable;
    [SerializeField] private int varId;
    [SerializeField] private int value;
    [SerializeField] private string nameOutfit;
    [SerializeField] private string url;
    [SerializeField] private string heroBelongs;
    [SerializeField] private int face;
    public CostStep cost;
    public bool paid;

    [SerializeField]private Texture2D texture;
    
    public Texture2D Texture => texture;
    public string Title => title;
    
    public long AssetVariable => assetVariable;
    public int VarId => varId;
    public int Value => value;
    public string NameOutfit => nameOutfit;
    public string URL => url;

    public Enums.OutfitEnum PartOutfit => partOutfit;
    public int Face => face;
    public string HeroBelongs => heroBelongs;
    public void Init( string title, int assetVariable, int varId, int value, string nameOutfit, string url, int face, string nameHero)
    {
        this.title = title;
        this.assetVariable = assetVariable;
        this.varId = varId;
        this.value = value;
        this.nameOutfit = nameOutfit;
        this.url = url;
        this.face = face;
        heroBelongs = nameHero;
    }
    
    public void SetPartOutfit(Enums.OutfitEnum _outfitEnum )
    {
        partOutfit = _outfitEnum;
    }
   
    public override void SetTexture(Texture2D texture)
    {
        this.texture = texture;
    }
    public  override void DestroyTexture()
    {
        Destroy(texture);
    }
}
