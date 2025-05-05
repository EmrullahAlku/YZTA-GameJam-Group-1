using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MatchController : MonoBehaviour
{
    public Image backImage;
    public Image frontImage;
    public string cardId;

    public GameObject task; // Kart�n parent objesi
    private static MatchController firstCard = null;
    private static MatchController secondCard = null;
    private static bool isChecking = false;

    public void OnClick()
    {
        // E�er kart a��k ya da kontrol s�reci varsa t�klamay� engelle
        if (frontImage.gameObject.activeSelf || isChecking)
            return;

        // Kart� a�
        frontImage.gameObject.SetActive(true);
        backImage.gameObject.SetActive(false);

        if (firstCard == null)
        {
            firstCard = this;
        }
        else if (secondCard == null)
        {
            secondCard = this;
            isChecking = true;
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(0.5f); // biraz beklet

        if (firstCard.cardId == secondCard.cardId)
        {
            // E�le�iyorsa parent objeleri sil
            Destroy(firstCard.gameObject);
            Destroy(secondCard.gameObject);
            task.GetComponent<Task1W>().CardCounter();

        }
        else
        {
            // E�le�miyorsa kartlar� kapat
            yield return new WaitForSeconds(0.5f); // oyuncuya g�sterme s�resi

            firstCard.frontImage.gameObject.SetActive(false);
            firstCard.backImage.gameObject.SetActive(true);

            secondCard.frontImage.gameObject.SetActive(false);
            secondCard.backImage.gameObject.SetActive(true);
        }

        // S�f�rlama
        firstCard = null;
        secondCard = null;
        isChecking = false;
    }
}
