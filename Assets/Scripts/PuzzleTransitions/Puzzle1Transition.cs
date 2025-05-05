using UnityEngine;
using UnityEngine.SceneManagement; // Sahne yönetimi için gerekli

public class Puzzle1Transition : MonoBehaviour
{
    private bool playerInRange = false; // Oyuncunun alanda olup olmadığını kontrol etmek için
    public int sceneToLoad; // Yüklemek istediğiniz sahnenin numarası
    private GameObject player; // Oyuncu nesnesi (isteğe bağlı, sahne geçişi için kullanılabilir)
    public bool isPuzzleCompleted = false; // Bulmacanın tamamlanma durumu (isteğe bağlı, sahne geçişi için kullanılabilir)
    
    void Update()
    {
        // Oyuncu alandaysa ve Enter tuşuna basarsa sahneyi değiştir
        if (playerInRange && Input.GetKeyDown(KeyCode.Return))
        {   
            isPuzzleCompleted = false; // Bulmacanın tamamlanma durumunu sıfırla
                switch (sceneToLoad)
                {
                    case 1:
                        if(player.GetComponent<PlayerInventory>().isPuzzle1Completed){
                            isPuzzleCompleted = true; // Puzzle tamamlandı
                        }
                        break;
                    case 2:;
                        if(player.GetComponent<PlayerInventory>().isPuzzle2Completed){
                            isPuzzleCompleted = true; // Puzzle tamamlandı                          
                        }
                        break;
                    case 3:
                        if(player.GetComponent<PlayerInventory>().isPuzzle3Completed){
                            isPuzzleCompleted = true; // Puzzle tamamlandı
                        }
                        break;
                    case 4:
                        if(player.GetComponent<PlayerInventory>().isPuzzle4Completed){
                            isPuzzleCompleted = true; // Puzzle tamamlandı
                        }
                        break;
                    case 5:
                        if(player.GetComponent<PlayerInventory>().isPuzzle5Completed){
                            isPuzzleCompleted = true; // Puzzle tamamlandı
                        }
                        break;
                    case 6:
                        if(player.GetComponent<PlayerInventory>().isPuzzle6Completed){
                            isPuzzleCompleted = true; // Puzzle tamamlandı
                        }
                        break;
                    case 7:
                        if(player.GetComponent<PlayerInventory>().isPuzzle7Completed){
                            isPuzzleCompleted = true; // Puzzle tamamlandı
                        }
                        break;
                    default:
                        Debug.LogWarning("Invalid sceneToLoad value: " + sceneToLoad);
                        break;
                }
            if (!isPuzzleCompleted){

            player.GetComponent<FirstPersonController>().PlayerFreeze(); // Oyuncunun hareketini durdur
            player.GetComponent<FirstPersonController>().UnlockCursor();
            SceneManager.LoadScene(sceneToLoad);
            } else{
                Debug.Log("Puzzle is already completed. Cannot transition to the next scene.");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            player = GameManager.Instance.player;

            Debug.Log("Player entered the transition area.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Oyuncu alandan çıktığında
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player exited the transition area.");
        }
    }
}