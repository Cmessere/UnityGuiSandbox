using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationScript : MonoBehaviour
{
    public void GotoBaseLayout()
    {
        SceneManager.LoadScene("BaseLayout");
    }
    public void GotoGridLayout()
    {
        SceneManager.LoadScene("GridLayout");
    }
    public void GotoTabLayout()
    {
        SceneManager.LoadScene("TabLayout");
    }
}
