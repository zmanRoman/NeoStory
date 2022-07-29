using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StoryAssets : MonoBehaviour
{
    public abstract void SetTexture(Texture2D texture);
    public abstract void DestroyTexture();
}
