using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<GameObject> objectsToSwap;
    public List<TabButton> tabButtons;
    public Color tabIdle = new Color(0.15f, 0.23f, 0.45f);
    public Color tabHover = new Color(0.25f, 0.45f, 0.61f);
    public Color tabSelected = new Color(0f, 0.65f, 1f);
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
