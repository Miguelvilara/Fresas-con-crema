using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject tower;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        print("On Mouse Enter");
        sr.color = hoverColor;
    }

    void OnMouseOver()
    {
        print("On Mouse Over");
    }

    private void OnMouseExit()
    {
        print("On Mouse Exit");
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        print("On Mouse Down");
        if (tower != null) return;

        Tower towerToBuild = BuildManager.main.GetSelectedTower();

        if(towerToBuild.cost > LevelManager.main.currency) {
            Debug.Log("No hay feria Bro");
            return;
        }

        LevelManager.main.SpendCurrency(towerToBuild.cost);

        tower = Instantiate (towerToBuild.prefab, transform.position, Quaternion.identity);
        
    }
}
