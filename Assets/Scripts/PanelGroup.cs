using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGroup : MonoBehaviour
{
    public GameObject[] panels;
    public TabGroup tabGroup;
    void Awake()
    {
        ShowCurrentPanel(0);
    }

    public void ShowCurrentPanel(int index)
    {
        for(int i = 0; i < panels.Length; i++)
        {
            if (i == index)
            {
                panels[i].gameObject.SetActive(true);
            }
            else
            {
                panels[i].gameObject.SetActive(false);
            }
        }
    }
}
