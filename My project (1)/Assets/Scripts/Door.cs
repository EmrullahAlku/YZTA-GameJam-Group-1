using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorTransform;
    private bool opened = false;

    void Update()
    {
        if (!opened && GameManager.instance.hasKey && Vector3.Distance(transform.position, GameManager.instance.player.transform.position) < 3f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                doorTransform.Rotate(Vector3.up, 90f);
                opened = true;
            }
        }
    }
}

