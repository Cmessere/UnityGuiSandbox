using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<GameObject> objectsToSwap;
    public List<TabButton> tabButtons;
    public Color32 tabIdle = new Color32(39, 60, 117, 255);
    public Color32 tabHover = new Color32(64, 115, 158, 255);
    public Color32 tabSelected = new Color32(0, 168, 255, 255);
    public TabButton selectedTab;
    public void Subscribe(TabButton button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
    }

    public void OnTabExit(TabButton button) 
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button) 
    {
        selectedTab = button;
        ResetTabs();
        button.background.color = tabSelected;
        int index = button.transform.GetSiblingIndex();
        for( int i = 0; i < objectsToSwap.Count; i++)
        {
            if( i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }
    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if(selectedTab == null || button != selectedTab)
        button.background.color = tabHover;
    }

    public void ResetTabs()
    {
        foreach(TabButton button in tabButtons)
        {
            if(selectedTab != null && button == selectedTab) { continue; }
            button.background.color = tabIdle;
        }
    }
}
