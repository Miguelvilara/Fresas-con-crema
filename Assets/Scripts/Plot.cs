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

        GameObject towerToBuild = BuildManager.main.GetSelectedTower();
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, -1f);
        tower = Instantiate(towerToBuild, spawnPosition, Quaternion.identity);
    }
}
