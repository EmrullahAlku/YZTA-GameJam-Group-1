using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ForecastControl : MonoBehaviour
{
    public TMP_Text messageText;  // Oyuncuya mesaj� g�sterecek Text
    public InputField inputField;  // Oyuncunun tahminini yazaca�� InputField
    public Button submitButton;  // Tahmin yap�lacak Button

    private int secretNumber;


    void Start()
    {
        // Oyunu ba�lat
        StartGame();
    }

    void StartGame()
    {
        secretNumber = Random.Range(1, 101);  // 1 ile 100 aras�nda rastgele bir say�

        UpdateUI("Tahmin Et: 1 ile 100 aras�nda bir say� girin.");
    }

    public void CheckGuess()
    {
        string userInput = inputField.text.Trim(); // Bo�luklar� temizle

        // Giri� de�erini kontrol et
        Debug.Log("User Input: " + userInput);  // Kullan�c�n�n girdi�i de�eri konsolda g�ster

        if (string.IsNullOrEmpty(userInput))
        {
            UpdateUI("Bir say� girmeniz gerekiyor!");
            return;
        }

        int userGuess;
        if (int.TryParse(userInput, out userGuess))
        {
            if (userGuess == secretNumber)
            {
                UpdateUI("Tebrikler! Do�ru Tahmin: " + secretNumber);
            }
            else if (userGuess < secretNumber)
            {
                UpdateUI("Tahmininiz k���k. Tekrar deneyin.");
            }
            else
            {
                UpdateUI("Tahmininiz b�y�k. Tekrar deneyin.");
            }

            inputField.text = "";  // Input field'� s�f�rlama
        }
        else
        {
            UpdateUI("Ge�erli bir say� girin!");
        }
    }



    void UpdateUI(string message)
    {
        messageText.text = message;  // Mesaj� g�ncelle
    }
}
