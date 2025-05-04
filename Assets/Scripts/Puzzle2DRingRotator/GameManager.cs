using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RingRotator[] rings;
    public GameObject completionPanel;

    void Update()
    {
        if (AllRingsCorrect())
        {
            completionPanel.SetActive(true);
        }
    }

    bool AllRingsCorrect()
    {
        foreach (var ring in rings)
        {
            if (!ring.IsCorrect())
                return false;
        }
        return true;
    }
}
