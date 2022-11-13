using System;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    public static EnvironmentController Instance;
    
    private Material mat;
    private float width;
    private float progress;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        width = mat.mainTextureScale.x;
    }

    public void UpdateTexture(float relativeSpeed)
    {
        progress += relativeSpeed/100;
        float x = progress;
        mat.mainTextureOffset = new Vector2(x, 0);
    }
}