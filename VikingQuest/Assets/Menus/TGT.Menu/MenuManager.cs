/*
 * @summary			Main menu UI
 * @description		Main menu with lot's of customizable things, includes new game, load game, options, exit game
 * @version			1.0.1
 * @file			MenuManager.cs
 * @author			Malte Gejr 
 * @contact			www.mkkvk.dk/kontakt
 * 
 * @copyright	    Copyright (C) 2016 - 2017 Malte Gejr
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 */

namespace TGT.Menu
{
	using UnityEngine;
	using UnityEngine.UI;
	using UnityEngine.SceneManagement;
	using System.Collections;
	using System.IO;
	using TGT.Menu;
	using UnityEngine.Experimental.Director;

	public class MenuManager : MonoBehaviour
	{
		public Button ravGameButton;
		public Button hugGameButton;
		public Button settingsButton;
		public Button creditButton;
		public Button exitgameButton;

		public GameObject mainmenuPanel;
		public GameObject optionsPanel;
		public GameObject crditsPanel;
		public GameObject sureExitPanel;
		public GameObject sureNewPanel;
		public GameObject picturePanel;

		public string levelToLoad;

		void OnEnable()
		{
			ravGameButton.onClick.AddListener(delegate
			{
				OnRavPress();
			});

			hugGameButton.onClick.AddListener(delegate
			{
				OnHugPress();
			});

			settingsButton.onClick.AddListener(delegate
			{
				OnSettingsPress();
			});

			creditButton.onClick.AddListener(delegate
			{
				OnCreditsPress();
			});

			exitgameButton.onClick.AddListener(delegate
			{
				OnExitGamePress();
			});
		}

		public void OnRavPress()
		{
			Debug.Log("OnRavPress");
			SceneManager.LoadScene("Rav");

		}

		public void OnHugPress()
		{
			Debug.Log("OnHugPress");
			SceneManager.LoadScene ("WoodCuttingScene");
		}

		public void OnSettingsPress()
		{
			Debug.Log("OnSettingsPress");
			mainmenuPanel.SetActive(false);
			optionsPanel.SetActive(true);
		}

		public void OnCreditsPress()
		{
			Debug.Log("OnCreditsPress");
			mainmenuPanel.SetActive(false);
			crditsPanel.SetActive(true);
		}

		public void OnExitGamePress()
		{
			Debug.Log("OnExitGamePress");
			sureExitPanel.SetActive(true);
			mainmenuPanel.SetActive(false);
		}
	}
}