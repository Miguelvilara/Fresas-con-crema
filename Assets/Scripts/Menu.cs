using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour {
 
	[Header("References")]
	[SerializeField] TextMeshProUGUI currencyUI;
	// [SerializeField] Animator anim; // <-- ¡Eliminada!

	private bool isMenuOpen = true;
	
	public void ToggleMenu(){
		isMenuOpen = !isMenuOpen;
		// anim.SetBool("MenuOpen", isMenuOpen); // <-- ¡Eliminada!
	}

	private void OnGUI() {
		currencyUI.text = LevelManager.main.currency.ToString();
	}

	public void SetSelected(){

	}
}