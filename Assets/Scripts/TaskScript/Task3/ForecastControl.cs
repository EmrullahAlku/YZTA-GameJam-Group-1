using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ForecastControl : MonoBehaviour
{
    public TMP_Text messageText;  // Oyuncuya mesajý gösterecek Text
    public InputField inputField;  // Oyuncunun tahminini yazacaðý InputField
    public Button submitButton;  // Tahmin yapýlacak Button

    private int secretNumber;


    void Start()
    {
        // Oyunu baþlat
        StartGame();
    }

    void StartGame()
    {
        secretNumber = Random.Range(1, 101);  // 1 ile 100 arasýnda rastgele bir sayý

        UpdateUI("Tahmin Et: 1 ile 100 arasýnda bir sayý girin.");
    }

    public void CheckGuess()
    {
        string userInput = inputField.text.Trim(); // Boþluklarý temizle

        // Giriþ deðerini kontrol et
        Debug.Log("User Input: " + userInput);  // Kullanýcýnýn girdiði deðeri konsolda göster

        if (string.IsNullOrEmpty(userInput))
        {
            UpdateUI("Bir sayý girmeniz gerekiyor!");
            return;
        }

        int userGuess;
        if (int.TryParse(userInput, out userGuess))
        {
            if (userGuess == secretNumber)
            {
                UpdateUI("Tebrikler! Doðru Tahmin: " + secretNumber);
            }
            else if (userGuess < secretNumber)
            {
                UpdateUI("Tahmininiz küçük. Tekrar deneyin.");
            }
            else
            {
                UpdateUI("Tahmininiz büyük. Tekrar deneyin.");
            }

            inputField.text = "";  // Input field'ý sýfýrlama
        }
        else
        {
            UpdateUI("Geçerli bir sayý girin!");
        }
    }



    void UpdateUI(string message)
    {
        messageText.text = message;  // Mesajý güncelle
    }
}
