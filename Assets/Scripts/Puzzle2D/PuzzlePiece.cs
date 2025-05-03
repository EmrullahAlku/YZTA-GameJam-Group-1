using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform correctPosition;
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector3 originalPosition;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.position;
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float distance = Vector3.Distance(rectTransform.position, correctPosition.position);
        if (distance < 50f)
        {
            rectTransform.position = correctPosition.position;
        }
        else
        {
            rectTransform.position = originalPosition;
        }
    }
}