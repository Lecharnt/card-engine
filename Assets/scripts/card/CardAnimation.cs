using UnityEngine;
using System.Collections;

public class CardAnimation : MonoBehaviour
{
    [Header("Movement")]
    public float moveSmooth = 15f;
    public float snapThreshold = 0.01f;

    private Coroutine currentAnimation;
    private Transform cardTransform;

    void Awake()
    {
        cardTransform = transform;
    }
    public void MoveTo(Vector3 targetPosition)
    {
        StopCurrentAnimation();
        currentAnimation = StartCoroutine(MoveRoutine(targetPosition));
    }
    public void SnapTo(Vector3 position)
    {
        StopCurrentAnimation();
        cardTransform.position = position;
    }

    public void StopCurrentAnimation()
    {
        if (currentAnimation != null)
        {
            StopCoroutine(currentAnimation);
            currentAnimation = null;
        }
    }

    IEnumerator MoveRoutine(Vector3 target)
    {
        while (Vector3.Distance(cardTransform.position, target) > snapThreshold)
        {
            cardTransform.position = Vector3.Lerp(cardTransform.position, target, Time.deltaTime * moveSmooth);
            yield return null;
        }

        cardTransform.position = target;
        currentAnimation = null;
    }
}
