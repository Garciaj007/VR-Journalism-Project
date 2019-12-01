using System.Collections.Generic;
using UnityEngine;

public class HideMenuBehaviour : MonoBehaviour
{

    [SerializeField] 
    private List<GameObject> objectsToHide = new List<GameObject>();

    private bool IsHidden { get; set; }

    public void OnPressed()
    {
        IsHidden = !IsHidden;
        foreach(var obj in objectsToHide) obj.SetActive(!IsHidden);
    }
}
