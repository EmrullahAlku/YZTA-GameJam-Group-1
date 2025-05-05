using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleGameManager : MonoBehaviour
{
    public RingRotator[] rings;
    public GameObject completionPanel;

    void Update()
    {
        if (AllRingsCorrect())
        {
            completionPanel.SetActive(true);
            Invoke("changeScene", 2f);// Puzzle tamamlandı
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

    void changeScene()
    {
        GameObject player = GameManager.Instance.player;
            if (player != null)
            {
                player.GetComponent<PlayerInventory>().isPuzzle4Completed = true; // Puzzle tamamlandı
                player.GetComponent<FirstPersonController>().PlayerUnFreeze(); // Oyuncuyu dondur
                player.GetComponent<FirstPersonController>().LockCursor(); // Oyuncuyu dondur
                
                Debug.Log("All cards used!");
                SceneManager.LoadScene(0); // End sahnesini yükle
            }
            else
            {
                Debug.LogError("Player reference is null in GameManager!");
            }}
}
