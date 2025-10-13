using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour {
   
	[Header("References")]
	[SerializeField] private SpriteRenderer sr;
	[SerializeField] private Color hoverColor;

   private GameObject tower;
   private Color startColor;

   private void Start() {
		startColor = sr.color;
   }

   private void onMouseEnter() {
		sr.color = hoverColor;
   }

   private void OnMouseExit() {
		sr.color = startColor;
   }

   private void OnMouseDown() {
		if (tower != null) return;

		GameObject towerToBuild = BuildManager.main.GetSelectedTower();
		Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, -1f);
		tower = Instantiate(towerToBuild, spawnPosition, Quaternion.identity);
   }
}
