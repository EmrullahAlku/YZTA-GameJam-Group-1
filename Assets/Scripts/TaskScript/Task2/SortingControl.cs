using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SortingControl : MonoBehaviour
{
    public List<Image> squares = new List<Image>();         // 8 kare (Inspector’dan atanacak)
    private List<int> sequence = new(); // Oluþturulan sýra
    private int playerIndex = 0;        // Oyuncunun týklama sýrasý

    public Color whiteColor = Color.white;
    public Color redColor = Color.red;
    public float flashDuration = 0.5f;

    private bool isPlayerTurn = false;

    void Start()
    {
        GenerateSequence();
        StartCoroutine(PlaySequence());
    }

    void GenerateSequence()
    {
        sequence.Clear();
        for (int i = 0; i < squares.Count; i++)
        {
            sequence.Add(i);
        }

        sequence = sequence.OrderBy(x => Random.value).ToList();
    }

    IEnumerator PlaySequence()
    {
        isPlayerTurn = false;

        foreach (int index in sequence)
        {
            squares[index].color = redColor;
            yield return new WaitForSeconds(flashDuration);
            squares[index].color = whiteColor;
            yield return new WaitForSeconds(0.2f);
        }

        isPlayerTurn = true;
        playerIndex = 0;
    }

    public void OnSquareClicked(int index)
    {
        if (!isPlayerTurn) return;

        if (index == sequence[playerIndex])
        {
            squares[index].color = redColor;
            StartCoroutine(RevertColor(index));

            playerIndex++;
            if (playerIndex >= sequence.Count)
            {
                // sýrayý doðru þekilde yapýnca olacak iþlemler buraya yazýlacak.(kapý açýlmasý falan)
                Debug.Log("Tebrikler! Doðru tekrar edildi.");
                isPlayerTurn = false;
            }
        }
        else
        {
            // yanlýþ sýralama yapýnca yapýlacaklar burada kontrol edilecek. (oyundan çýkma vb.)
            Debug.Log("Yanlýþ kare! Oyun bitti.");
            isPlayerTurn = false;
        }
    }

    IEnumerator RevertColor(int index)
    {
        yield return new WaitForSeconds(0.2f);
        squares[index].color = whiteColor;
    }
}
