using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PasswordChecker : MonoBehaviour
{
    public TMP_InputField passwordInput;
    public TMP_Text resultText;

    [SerializeField] private string correctPassword = "4281";

    public void CheckPassword()
    {
        string input = passwordInput.text.Trim();

        if (input == correctPassword)
        {
            resultText.text = "Giriş başarılı!";
            resultText.color = Color.green;
        }
        else
        {
            resultText.text = "Yanlış şifre, tekrar deneyin.";
            resultText.color = Color.red;
        }

        Debug.Log("Girilen Şifre: " + input);
        Debug.Log("Doğru Şifre: " + correctPassword);
    }
}