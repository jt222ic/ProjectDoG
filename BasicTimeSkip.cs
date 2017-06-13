using UnityEngine;
using System.Collections;

public class BasicTimeSkip : MonoBehaviour {

    // Use this for initialization
    
    public Material mat;

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, mat);
    }
}
