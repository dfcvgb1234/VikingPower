/*
 * @summary			Main menu UI - sure new game window
 * @description		Are you sure you want to start a new game window
 * @version			1.0.1
 * @file				NewManager.cs
 * @author			Malte Gejr 
 * @contact			www.mkkvk.dk/kontakt
 *  
 * @copyright       Copyright (C) 2016 - 2017 Malte Gejr
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
	using System.Collections;
	using UnityEngine.UI;
	using System.Collections.Generic;
	using UnityEngine.SceneManagement;
	using System.IO;
	using UnityEngine;
	using TGT.Menu;

	public class NewManager : MonoBehaviour
	{
		public Button yesExitButton;
		public Button noExitButton;

		public GameObject mainmenuPanel;
		public GameObject sureNewPanel;

		void OnEnable()
		{
			yesExitButton.onClick.AddListener(delegate
			{
				OnYesExitPress();
			});

			noExitButton.onClick.AddListener(delegate
			{
				OnNoExitPress();
			});
		}

		public void OnYesExitPress()
		{
			Debug.Log("OnYesNewPress");

			System.IO.DirectoryInfo di = new DirectoryInfo(Application.persistentDataPath + "/Saves");

			foreach (FileInfo file in di.GetFiles())
			{
				Debug.Log(file.Name + " deleted");
				file.Delete();
			}
			foreach (DirectoryInfo dir in di.GetDirectories())
			{
				Debug.Log(dir.Name + " deleted");
				dir.Delete(true);
			}
			Debug.Log("/SAVES/ DELETED");
			di.Delete();

			SceneManager.LoadScene(1);

		}

		public void OnNoExitPress()
		{
			Debug.Log("OnNoNewPress");
			sureNewPanel.SetActive(false);
			mainmenuPanel.SetActive(true);
		}
	}
}