using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MaterialChanger : MonoBehaviour
{
    public Renderer objectRenderer;
    public Color targetColor;
    public float colorChangeDuration = 2f;

    void Start()
    {
        
        objectRenderer.material.DOColor(targetColor, colorChangeDuration);
    }
}
