
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
    public GameObject CreditsMenu;

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
    public void Credits()
    {
        CreditsMenu.SetActive(false);
    }
    public void ShowCredits()
    {
        CreditsMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Scenechange()
    {
        SceneManager.LoadScene("Nivel");
    }
    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
