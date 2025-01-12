using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils;
public class UIClickHandler : MonoBehaviour
{
    //Set all panels on inactive except main

    GameObject canvas;
    [SerializeField] GameObject[] panels;
    public GameObject SelectedGameObject;
    private TowerPlace towerPlace;
    void Start()
    {
        towerPlace = gameObject.GetComponent<TowerPlace>();
    }



    public void MainScreenPanelButtons(string name)
    {
        if (name == "Start")
        {
            panels[(int)PanelType.tower].SetActive(true);
            panels[(int)PanelType.main].SetActive(false);
        }
        else
        {
            Application.Quit();
            Debug.Log("Else statement reached - Should be intended");
        }

    }
    public void TowerPlacementButtons(GameObject game0bject)
    {
        Debug.Log($"{game0bject.name}");
        towerPlace.ButtonClickedAction(Instantiate(game0bject));
    }

    public void PanelPlacementMouseClick(BaseEventData eventData)
    {

    }

    public void NextWave()
    {
        if (EnemyWaves.Enemies.Count == 0)
        {
            EnemyWaves.StartWave();
        }
        
    }

    public void EndState()
    {
        panels[(int)PanelType.main].SetActive(true);
        panels[(int)(PanelType.tower)].SetActive(false);
        panels[(int)PanelType.lost].SetActive(false);
        panels[(int)PanelType.won].SetActive(false);
    }

    enum PanelType
    {
        main, tower, lost, won
    }
}
