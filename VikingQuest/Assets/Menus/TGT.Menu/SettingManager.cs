/*
 * @summary			Settings, saving and loading
 * @description		Game options window in Unity 5 and saving the settings to the pc 
 * @version			1.2.1
 * @file			SettingManager.cs
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

namespace TGT.Menu
{
	using UnityEngine;
	using UnityEngine.UI;
	using System.Collections;
	using System.IO;
	using TGT.Menu;

	public class SettingManager : MonoBehaviour
	{

		public Toggle fullscreenToggle;
		public Dropdown resolutionDropdown;
		public Dropdown textureQualityDropdown;
		public Dropdown antialiasingDropdown;
		public Dropdown vSyncDropdown;
		public Slider audioVolumeSlider;
		public Button applyButton;

		public Resolution[] resolutions;
		public GameSettings gameSettings;
		public GameObject optionsPanel;
		public GameObject mainmenuPanel;

		public AudioSource audioSource;

		void OnEnable()
		{
			gameSettings = new GameSettings();

			//De respektive funktioner ser nu efter om der sker en ændring i de respektive variabler.
			fullscreenToggle.onValueChanged.AddListener(delegate
			{
				OnFullscreenToggle();
			});
			resolutionDropdown.onValueChanged.AddListener(delegate
			{
				OnResolutionChange();
			});
			textureQualityDropdown.onValueChanged.AddListener(delegate
			{
				OnTextureQualityChange();
			});
			antialiasingDropdown.onValueChanged.AddListener(delegate
			{
				OnAntialiasingChange();
			});
			vSyncDropdown.onValueChanged.AddListener(delegate
			{
				OnVSyncChange();
			});
			audioVolumeSlider.onValueChanged.AddListener(delegate
			{
				OnAudioVolumeChange();
			});
			applyButton.onClick.AddListener(delegate
			{
				OnApplyPress();
			});

			//Finder alle de skærmopløsninger din nurværende skærm understøtter og putter dem ind i array'et "Resolution[] resolutions"
			resolutions = Screen.resolutions;
			//Finder alle Skærmopløsninger(Resolution), navngiver dem resolution og putter dem ind i array'et resolutions
			//Der bliver ikke lavet en liste af valgmuligheder, der bliver lavet indivduelle valgmuligheder en af gangen
			foreach (Resolution resolution in resolutions)
			{
				resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
			}

			//Læser det gemte data, hvis er der noget
			LoadSettings();
		}

		public void OnFullscreenToggle()
		{
			Debug.Log("FullscreenToggle");

			//fullscreenToggle er din knap i GUI, enten er den true eller false
			//gameSettings.fullscreen gør det klar til at man kan gemmee det til en JSON fil
			//Screen.fullScreen sætter om den er fuldskærm eller ikke
			Screen.fullScreen = gameSettings.fullscreen = fullscreenToggle.isOn;
		}

		public void OnResolutionChange()
		{
			Debug.Log("ResolutionChange");

			//Screen.SetResolution sætter den reelle skærmopløsning, med den valgte skærmoplæsning på Dropdown.
			Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
			gameSettings.resolutionIndex = resolutionDropdown.value;
		}

		public void OnTextureQualityChange()
		{
			Debug.Log("TextureQualityChange");

			//QualitySettings.masterTextureLimit bruger tallene 0, 1 eller 2.			0 = High	1 = Medium	 	2 = Low
			//gameSettings.textureQuality gør det klar til at man kan gemmee det til en JSON fil
			//QualitySettings.masterTextureLimit sætter den reelle Texture Quality
			QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
		}

		public void OnAntialiasingChange()
		{
			Debug.Log("AntialiasingChange");

			//QualitySettings.antiAliasing bruger tallene 0, 2, 4 og 8. 	0 = None	2 = FXAA	4 = MSAA	8 = SSAA
			//gameSettings.antialiasing gør det klar til at man kan gemmee det til en JSON fil
			//Derfor skal vi gange antialiasingDropdown.value med 2.
			//QualitySettings.antiAliasing sætter den reelle Anti-Aliasing
			QualitySettings.antiAliasing = gameSettings.antialiasing = (int) Mathf.Pow(2, antialiasingDropdown.value);
		}

		public void OnVSyncChange()
		{
			Debug.Log("VSyncChange");

			//QualitySettings.vSyncCount bruger tallene 0, 1 og 2		0 = None	1 = Every V Blank	 2 = Every Second V Blank
			//gameSettings.antialiasing gør det klar til at man kan gemmee det til en JSON fil
			//QualitySettings.vSyncCount sætter den reelle VSync
			QualitySettings.vSyncCount = gameSettings.vSync = vSyncDropdown.value;
		}

		public void OnAudioVolumeChange()
		{
			Debug.Log("AudioVolumeChange");

			//audioSource.volume bruger værdien fra audioVolumeSlider.value til at justere lydens højde
			//gameSettings.audioVolume gør det klar til at man kan gemmee det til en JSON fil
			audioSource.volume = gameSettings.audioVolume = audioVolumeSlider.value;
		}

		public void OnApplyPress()
		{
			Debug.Log("OnApplyPress");
			SaveSettings();
			optionsPanel.SetActive(false);
			mainmenuPanel.SetActive(true);

		}

		public void SaveSettings()
		{
			Debug.Log("SaveSettings");

			//Gemmer gameSettings som jsonData, som nu er en JSON string, "true" gør at JSON string'en bliver letter at læse når den bliver gemt
			string jsonData = JsonUtility.ToJson(gameSettings, true);

			//persistenDataPath gemmer til LocalLow
			//C:\Users\[USER NAME]\AppData\LocalLow\[COMPANY NAME]\[GAME NAME]
			//For at ændre [COMPANY NAME] og [GAME NAME] skal du gå ind i Build Settings, så Player Settings, der kan du ændre det
			File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
		}

		public void LoadSettings()
		{
			Debug.Log("LoadSettings");

			//JsonUtility.FromJson<GameSettings>, laver den gemte fil om til data
			//"<GameSettings>" bliver brugt som en skabelon til hvordan daten bliver behandlet
			//File.ReadAllText(Application.persistentDataPath + "/gamesettings.json" er stien til der hvor data'en er gemt
			//"gameSettings =" er det der bliver skrevet til
			gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

			//De næste linjer læser dataen fra gameSettings som lige er blevet loadet
			//og gør sådan de trigger On___Change funktionerne og de putter dataen ind.

			fullscreenToggle.isOn = gameSettings.fullscreen;
			resolutionDropdown.value = gameSettings.resolutionIndex;
			textureQualityDropdown.value = gameSettings.textureQuality;
			antialiasingDropdown.value = gameSettings.antialiasing;
			vSyncDropdown.value = gameSettings.vSync;
			audioVolumeSlider.value = gameSettings.audioVolume;

			Screen.fullScreen = gameSettings.fullscreen;
			resolutionDropdown.RefreshShownValue();
		}
	}
}
