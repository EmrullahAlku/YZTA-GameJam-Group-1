using UnityEngine;
using UnityEngine.SceneManagement; // SceneManager sınıfını kullanmak için gerekli

public class PuzzlePieceW : MonoBehaviour
{
    public int pieceCount = 9; // Number of pieces in the puzzle
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PieceCounter()
    {
        pieceCount--;
        if (pieceCount <= 0) {
            GameObject player = GameManager.Instance.player;
            if (player != null)
            {
                player.GetComponent<PlayerInventory>().isPuzzle2Completed = true; // Puzzle tamamlandı
                player.GetComponent<FirstPersonController>().PlayerUnFreeze(); // Oyuncuyu dondur
                player.GetComponent<FirstPersonController>().LockCursor(); // Oyuncuyu dondur
                
                Debug.Log("All cards used!");
                SceneManager.LoadScene(0); // End sahnesini yükle
            }
            else
            {
                Debug.LogError("Player reference is null in GameManager!");
            }

        } else {
            Debug.Log("Cards left: " + pieceCount);
        }}
}
