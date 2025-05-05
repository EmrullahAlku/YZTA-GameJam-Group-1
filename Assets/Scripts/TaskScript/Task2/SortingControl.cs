using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SortingControl : MonoBehaviour
{
    public List<Image> squares = new List<Image>();         // 8 kare (Inspector�dan atanacak)
    private List<int> sequence = new(); // Olu�turulan s�ra
    private int playerIndex = 0;        // Oyuncunun t�klama s�ras�

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
                // s�ray� do�ru �ekilde yap�nca olacak i�lemler buraya yaz�lacak.(kap� a��lmas� falan)
                Debug.Log("Tebrikler! Do�ru tekrar edildi.");
                isPlayerTurn = false;
            }
        }
        else
        {
            // yanl�� s�ralama yap�nca yap�lacaklar burada kontrol edilecek. (oyundan ��kma vb.)
            Debug.Log("Yanl�� kare! Oyun bitti.");
            isPlayerTurn = false;
        }
    }

    IEnumerator RevertColor(int index)
    {
        yield return new WaitForSeconds(0.2f);
        squares[index].color = whiteColor;
    }
}
