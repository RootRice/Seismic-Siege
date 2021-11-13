using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    int currentSelection;
    MasterInput input;
    EventSystem myEvents;
    float inputTimer;
    bool menuOrLevel = true;
    bool instructionActive = false;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levelSelectMenu;
    [SerializeField] GameObject instruction;

    [SerializeField] GameObject[] menuButtons;
    [SerializeField] GameObject[] levelSButtons;


    void Start()
    {
        inputTimer = Time.time;
        myEvents = EventSystem.current;
        myEvents.SetSelectedGameObject(null);
        myEvents.SetSelectedGameObject(menuButtons[0]);
        SetInputs();
    }


    void Update()
    {

        if (menuOrLevel)
        {
            myEvents.SetSelectedGameObject(null);
            myEvents.SetSelectedGameObject(menuButtons[currentSelection]);
        }
        else
        {
            myEvents.SetSelectedGameObject(null);
            myEvents.SetSelectedGameObject(levelSButtons[currentSelection]);
        }
        
    }

    void SetInputs()
    {
        input = new MasterInput();
        input.Enable();
        input.MenuMap.Up.performed += ctx => ChangeSelection(-1);
        input.MenuMap.Down.performed += ctx => ChangeSelection(+1);
        input.MenuMap.Select.performed += ctx => PollButtons();
        input.MenuMap.Back.performed += ctx => BackToMenu();
    }

    int LoopIndexMain(int index)
    {
        if(index > 3)
        {
            return index - 4;
        }
        else if(index < 0)
        {
            return index + 4;
        }
        else
        {
            return index;
        }
    }


    void PollButtons()
    {
        if (menuOrLevel && !instructionActive)
        {
            if (currentSelection == 0)
            {
                SceneManager.LoadScene(1);
            }
            else if (currentSelection == 1)
            {
                mainMenu.SetActive(false);
                levelSelectMenu.SetActive(true);
                menuOrLevel = false;
                currentSelection = 0;
            }
            else if(currentSelection == 2)
            {
                instruction.SetActive(true);
                mainMenu.SetActive(false);
                instructionActive = true;
            }
            else if (currentSelection == 3)
            {
                Application.Quit();
            }
        }
        else if(!instructionActive)
        {
            if (currentSelection < 3)
            {
                SceneManager.LoadScene(currentSelection+1);
            }
            else
            {
                mainMenu.SetActive(true);
                levelSelectMenu.SetActive(false);
                menuOrLevel = !menuOrLevel;
                currentSelection = 1;
            }
        }
        else
        {
            BackToMenu();
        }
    }

    void ChangeSelection(int mod)
    {
        if (menuOrLevel)
        {
            if (Time.time - inputTimer > 0.15f)
            {
                inputTimer = Time.time;
                currentSelection = LoopIndexMain(currentSelection + mod);
            }
        }
        else
        {
            if (Time.time - inputTimer > 0.15f)
            {
                inputTimer = Time.time;
                currentSelection = LoopIndexMain(currentSelection + mod);
            }
        }
    }

    void BackToMenu()
    {
        if(!menuOrLevel || instructionActive)
        {
            menuOrLevel = true;
            instructionActive = false;
            mainMenu.SetActive(true);
            if(instruction.activeSelf)
            {
                instruction.SetActive(false);
                currentSelection = 2;
            }
            else if(levelSelectMenu.activeSelf)
            {
                levelSelectMenu.SetActive(false);
                currentSelection = 1;
            }
        }
    }
}
