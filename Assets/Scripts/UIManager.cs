
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public RectTransform[] uiElements;
    public float moveDuration = 1f;
    public Vector2[] targetPositions;
    public Vector2[] targetScales;
    public GameObject SetingsMenu;

    void Start()
    {
        for (int i = 0; i < uiElements.Length; i++)
        {
            uiElements[i].DOAnchorPos(targetPositions[i], moveDuration);
            uiElements[i].DOScale(targetScales[i], moveDuration);
        }
    }
    public void Setings()
    {
        SetingsMenu.SetActive(false);
    }
    public void ShowSetings()
    {
        SetingsMenu.SetActive(true);
    }
    public void Scenechange()
    {
        SceneManager.LoadScene("Nivel");
    }
}
