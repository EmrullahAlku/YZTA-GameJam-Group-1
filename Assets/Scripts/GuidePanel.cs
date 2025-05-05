using UnityEngine;
 

public class GuidePanel : MonoBehaviour
 

{
 
    [SerializeField] private GameObject panel;
 
    private void Start()

    {
 
        if (panel != null)
 

        {
            panel.SetActive(true); // oyun başında göster
        }
 

        else
 

        {

            Debug.LogError("Panel atanmamış!");
 
        }
 

    }
 

    private void Update()
 
    {
 
        if (panel != null && Input.GetKeyDown(KeyCode.H))

        {

            bool isActive = panel.activeSelf;
 
            panel.SetActive(!isActive); // aç/kapa

        }
 

    }
 

}