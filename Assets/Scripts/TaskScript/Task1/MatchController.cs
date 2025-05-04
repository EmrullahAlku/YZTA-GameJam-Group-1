using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MatchController : MonoBehaviour
{
    public Image backImage;
    public Image frontImage;
    public string cardId;

    private static MatchController firstCard = null;
    private static MatchController secondCard = null;
    private static bool isChecking = false;

    public void OnClick()
    {
        // Eðer kart açýk ya da kontrol süreci varsa týklamayý engelle
        if (frontImage.gameObject.activeSelf || isChecking)
            return;

        // Kartý aç
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
            // Eþleþiyorsa parent objeleri sil
            Destroy(firstCard.gameObject);
            Destroy(secondCard.gameObject);
        }
        else
        {
            // Eþleþmiyorsa kartlarý kapat
            yield return new WaitForSeconds(0.5f); // oyuncuya gösterme süresi

            firstCard.frontImage.gameObject.SetActive(false);
            firstCard.backImage.gameObject.SetActive(true);

            secondCard.frontImage.gameObject.SetActive(false);
            secondCard.backImage.gameObject.SetActive(true);
        }

        // Sýfýrlama
        firstCard = null;
        secondCard = null;
        isChecking = false;
    }
}
