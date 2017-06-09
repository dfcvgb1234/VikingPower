/*
 * @summary			Main menu UI - credits window
 * @description		Shows the Credits for the game
 * @version			1.0.1
 * @file			CreditManager.cs
 * @author			Malte Gejr 
 * @contact			www.mkkvk.dk/kontakt
 *  
 * @copyright		Copyright (C) 2016 - 2017 Malte Gejr
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

using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TGT.Menu;

public class CreditManager : MonoBehaviour
{

	public Button backButton;

	public GameObject mainmenuPanel;
	public GameObject creditsPanel;

	void OnEnable()
	{
		backButton.onClick.AddListener(delegate
		{
			OnBackPress();
		});
	}

	public void OnBackPress()
	{
		Debug.Log("OnBackPress");
		creditsPanel.SetActive(false);
		mainmenuPanel.SetActive(true);
	}
}
