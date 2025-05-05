using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class RightChoice : MonoBehaviour
{
    public Button[] buttons;  // 9 adet buton
    public TMP_Text timerText;    // Zaman� g�sterecek text

    private int correctChoiceIndex;  // Do�ru se�ene�in indexi
    private int correctSelections;   // Ka� do�ru se�im yap�ld�
    private float timeLeft = 10f;    // 10 saniye s�resi
    private bool gameActive = true;  // Oyun aktif mi?

    void Start()
    {
        correctSelections = 0;

        // Butonlara t�klama olaylar� ekle
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;  // Her butona farkl� index ver
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }

        // �lk do�ru butonu g�ster
        ShowCorrectButton();
        StartCoroutine(Timer());
    }

    void ShowCorrectButton()
    {
        // Do�ru se�ene�i rastgele se�
        correctChoiceIndex = Random.Range(0, buttons.Length);
        Debug.Log("Correct Choice Index: " + correctChoiceIndex);

        // T�m butonlar�n rengini s�f�rl�yoruz
        ResetButtonColors();

        Image correctButtonImage = buttons[correctChoiceIndex].GetComponent<Image>();
        correctButtonImage.color = Color.cyan;
    }

    void ResetButtonColors()
    {
        // T�m butonlar�n rengini geri d�nd�r
        foreach (Button button in buttons)
        {
            button.GetComponent<Image>().color = Color.white;
        }
    }

    void OnButtonClick(int index)
    {
        if (index == correctChoiceIndex)
        {
            correctSelections++;  // Do�ru se�im yap�ld���nda artt�r

            if (correctSelections >= 5)
            {
                WinGame();
            }
            else
            {
                // Do�ru se�im yap�ld���nda sadece do�ru butonun rengini de�i�tir
                ShowCorrectButton();
            }
        }
        else
        {
            // Yanl�� se�im yap�ld���nda bir �ey yapmaya gerek yok
            Debug.Log("Yanl�� Se�im");
        }
    }

    void WinGame()
    {
        // e�er oyun ba�ar� ile sonu�lan�rsa buras� �al��acak.
        gameActive = false;  // Oyunu bitir
        StopCoroutine(Timer());  // Zamanlay�c�y� durdur
        Debug.Log("Kazand�n�z!");
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
        // oyun ba�ar�lamazsa buras� �al��acak.
        gameActive = false;  // Oyunu bitir
        Debug.Log("S�reniz Bitti, Kaybettiniz!");
    }
}
