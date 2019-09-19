using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UI_Canvas : MonoBehaviour
{
    #region variables
    [Header("System Events")]
    public UnityEvent onSwitchedScreen = new UnityEvent();
    private Component[] appScreens = new Component[0];
    private UI_Screen currentScreen;
    public UI_Screen CurrentScreen { get { return currentScreen; } }
    private UI_Screen previousScreen;
    public UI_Screen PreviousScreen { get { return previousScreen; } }
    #endregion

    #region main methods
    // Start is called before the first frame update
    void Start()
    {
        appScreens = GetComponentsInChildren<UI_Screen>(true);
        if (appScreens.Length >0)
        {
            SwitchScreen(appScreens[0].GetComponent<UI_Screen>());
        }
    }
    #endregion

    #region helper methods
    public void SwitchScreen(UI_Screen activeScreen)
    {
        if (activeScreen)
        {
            if (currentScreen)
            {
                previousScreen = currentScreen;
                previousScreen.gameObject.SetActive(false);
            }
        }
        currentScreen = activeScreen;
        currentScreen.gameObject.SetActive(true);
        if(onSwitchedScreen != null)
        {
            onSwitchedScreen.Invoke();
        }
    }

    public void GoToPreviousScreen()
    {
        if (previousScreen)
        {
            SwitchScreen(previousScreen);
        }        
    }
    #endregion

}
