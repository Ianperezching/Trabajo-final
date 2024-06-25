using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InteractiveObject : MonoBehaviour
{
    public float moveDuration = 2f;
    public Vector3 targetPosition;
    public Vector3 targetRotation;
    public Vector3 targetScale;

    void Start()
    {
        // Movimiento
        transform.DOMove(targetPosition, moveDuration);

        // Rotación
        transform.DORotate(targetRotation, moveDuration);

        // Escala
        transform.DOScale(targetScale, moveDuration);
    }
}
