using UnityEngine;
using UnityEngine.UI;

public class RingRotator : MonoBehaviour
{
    public float rotationStep = 90f;
    public Transform connector;
    public Transform targetSocket;
    public float threshold = 20f;

    private float currentRotation = 0f;
    private bool isCorrect = false;
    private bool isLocked = false;

    
    void Start()
    {
        do
        {
            int randomIndex = Random.Range(0, 4);
            currentRotation = randomIndex * rotationStep;
            transform.rotation = Quaternion.Euler(0, 0, currentRotation);
            CheckIfCorrect();
        }
        while (isCorrect); // Eğer doğru konumdaysa tekrar rastgele konum seç

        // Başlangıçta yanlış olduğuna emin olduğumuz için tekrar kontrol etmeye gerek yok
    }


    public void RotateRing()
    {
        if (isLocked) return;

        currentRotation += rotationStep;
        if (currentRotation >= 360f) currentRotation -= 360f;

        transform.rotation = Quaternion.Euler(0, 0, currentRotation);
        CheckIfCorrect();
    }

    void CheckIfCorrect()
    {
        float distance = Vector3.Distance(connector.position, targetSocket.position);

        if (distance < threshold)
        {
            isCorrect = true;
            isLocked = true;
            connector.GetComponent<Image>().color = Color.green;
        }
        else
        {
            isCorrect = false;
            isLocked = false;
            connector.GetComponent<Image>().color = Color.gray;
        }
    }

    public bool IsCorrect()
    {
        return isCorrect;
    }

    public void LockRing()
    {
        isLocked = true;
    }
}