using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabGroup : MonoBehaviour
{
    public List<GameObject> objectsToSwap;
    public List<TabButton> tabButtons;
    public TabButton selectedTab;
    public PanelGroup panelGroup;
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
        if(selectedTab != null)
        {
            selectedTab.Deselect();
        }
        selectedTab = button;

        selectedTab.Select();

        ResetTabs();
        button.background.color = button.GetComponent<TabButton>().tabSelected;
        button.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().color = button.GetComponent<TabButton>().textColorSelected;
        int index = button.transform.GetSiblingIndex();

        panelGroup.ShowCurrentPanel(index-1);
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
            button.background.color = button.GetComponent<TabButton>().tabHover;
            button.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().color = button.GetComponent<TabButton>().textColorSelected;
    }

    public void ResetTabs()
    {
        foreach(TabButton button in tabButtons)
        {
            if(selectedTab != null && button == selectedTab) { continue; }
            button.background.color = button.GetComponent<TabButton>().tabIdle;
            button.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().color = button.GetComponent<TabButton>().textColorIdle;
        }
    }
}
