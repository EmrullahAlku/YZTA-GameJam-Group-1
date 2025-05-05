using UnityEngine;
using UnityEngine.SceneManagement;

public class Task1W : MonoBehaviour
{
    public int cardCount = 8; // Number of cards in the inventory
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CardCounter(){
        cardCount-=2;
        if (cardCount <= 0) {
            GameObject player = GameManager.Instance.player;
            if (player != null)
            {
                player.GetComponent<PlayerInventory>().isPuzzle1Completed = true; // Puzzle tamamlandı
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
            Debug.Log("Cards left: " + cardCount);
        }
    } 
}
