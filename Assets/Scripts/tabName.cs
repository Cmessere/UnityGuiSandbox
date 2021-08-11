using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class tabName : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<TMPro.TextMeshProUGUI>().text = this.transform.parent.name.ToString();
    }
}
