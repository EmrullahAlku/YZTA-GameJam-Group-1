using UnityEngine;

public class Key : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Player etiketine sahip nesneyle çarpışma kontrolü
        {
            // Eğer GameManager instance'ı varsa
            if (GameManager.instance != null)
            {
                GameManager.instance.hasKey = true; // GameManager'ın hasKey değişkenini true yap
                Destroy(gameObject); // Key nesnesini yok et
            }
            else
            {
                Debug.LogWarning("GameManager instance bulunamadı!"); // Hata mesajı
            }
        }
    }
}
