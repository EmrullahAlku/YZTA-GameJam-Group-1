using System.Xml.Serialization;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Items itemType = Items.redCard;

    void Start()
    {
        this.gameObject.SetActive(true); 
    }
    void Update()
    {
        this.gameObject.SetActive(true); 
        Debug.Log("GameObject has been activated.");
    }
}