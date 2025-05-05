using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class RightChoice : MonoBehaviour
{
    public Button[] buttons;  // 9 adet buton
    public TMP_Text timerText;    // Zamaný gösterecek text

    private int correctChoiceIndex;  // Doðru seçeneðin indexi
    private int correctSelections;   // Kaç doðru seçim yapýldý
    private float timeLeft = 10f;    // 10 saniye süresi
    private bool gameActive = true;  // Oyun aktif mi?

    void Start()
    {
        correctSelections = 0;

        // Butonlara týklama olaylarý ekle
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;  // Her butona farklý index ver
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }

        // Ýlk doðru butonu göster
        ShowCorrectButton();
        StartCoroutine(Timer());
    }

    void ShowCorrectButton()
    {
        // Doðru seçeneði rastgele seç
        correctChoiceIndex = Random.Range(0, buttons.Length);
        Debug.Log("Correct Choice Index: " + correctChoiceIndex);

        // Tüm butonlarýn rengini sýfýrlýyoruz
        ResetButtonColors();

        Image correctButtonImage = buttons[correctChoiceIndex].GetComponent<Image>();
        correctButtonImage.color = Color.cyan;
    }

    void ResetButtonColors()
    {
        // Tüm butonlarýn rengini geri döndür
        foreach (Button button in buttons)
        {
            button.GetComponent<Image>().color = Color.white;
        }
    }

    void OnButtonClick(int index)
    {
        if (index == correctChoiceIndex)
        {
            correctSelections++;  // Doðru seçim yapýldýðýnda arttýr

            if (correctSelections >= 5)
            {
                WinGame();
            }
            else
            {
                // Doðru seçim yapýldýðýnda sadece doðru butonun rengini deðiþtir
                ShowCorrectButton();
            }
        }
        else
        {
            // Yanlýþ seçim yapýldýðýnda bir þey yapmaya gerek yok
            Debug.Log("Yanlýþ Seçim");
        }
    }

    void WinGame()
    {
        // eðer oyun baþarý ile sonuçlanýrsa burasý çalýþacak.
        gameActive = false;  // Oyunu bitir
        StopCoroutine(Timer());  // Zamanlayýcýyý durdur
        Debug.Log("Kazandýnýz!");
    }

    IEnumerator Timer()
    {
        while (timeLeft > 0 && gameActive)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Zaman: " + Mathf.Ceil(timeLeft);
            yield return null;
        }

        if (timeLeft <= 0)
        {
            LoseGame();
        }
    }

    void LoseGame()
    {
        // oyun baþarýlamazsa burasý çalýþacak.
        gameActive = false;  // Oyunu bitir
        Debug.Log("Süreniz Bitti, Kaybettiniz!");
    }
}
