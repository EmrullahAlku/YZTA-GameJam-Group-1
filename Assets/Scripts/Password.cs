using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System; // TextMeshPro kütüphanesini ekleyin

public class PasswordUI : MonoBehaviour
{
    public GameObject passwordPanel; // Şifre giriş paneli
    public TMP_InputField passwordInputField; // Şifreyi girmek için Input Field
    public Button submitButton; // Şifreyi onaylamak için Button
    public GameObject lockButton; // LockButtonPassword scriptine referans
    private string correctPassword; // Doğru şifre

    public GameObject Player; // Oyuncu referansı

    private void Start()
    {
        // Panel başlangıçta gizli
        passwordPanel.SetActive(false);

        // Butona tıklama olayını bağla
        submitButton.onClick.AddListener(CheckPassword);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            ClosePasswordPanel(); // Escape tuşuna basıldığında paneli kapat
        }
        if (Input.GetKeyDown(KeyCode.Return)){
            CheckPassword(); // Enter tuşuna basıldığında şifreyi kontrol et
        }
    }

    public void OpenPasswordPanel()
    {
        passwordPanel.SetActive(true); // Paneli göster
        Player.GetComponent<FirstPersonController>().enabled = false; // Oyuncunun hareketini durdur
        passwordInputField.ActivateInputField();
    }

    public void ClosePasswordPanel()
    {
        passwordPanel.SetActive(false); // Paneli gizle
        Player.GetComponent<FirstPersonController>().enabled = true; // Oyuncunun hareketini tekrar başlat
        passwordInputField.text = ""; // Input field'ı temizle
    }

    private void CheckPassword()
    {
        string enteredPassword = passwordInputField.text; // Kullanıcının girdiği şifre
        correctPassword = lockButton.GetComponent<LockButtonScript.LockButtonPassword>().correctPassword; // Doğru şifreyi al
        Debug.Log("Entered Password: " + enteredPassword);
        Debug.Log("Correct Password: " + correctPassword); // Doğru şifreyi kontrol et
        
        if (enteredPassword == correctPassword)
        {
            Debug.Log("Password correct. Unlocking...");
            lockButton.GetComponent<LockButtonScript.LockButtonPassword>().UnlockDoor(); // Kapıyı aç
            ClosePasswordPanel(); // Paneli kapat
        }
        else
        {
            Debug.Log("Wrong password!");
        }
    }
}