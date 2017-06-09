/*
 * @summary			Settings, saving and loading
 * @description		Game options window in Unity 5 and saving the settings to the pc 
 * @version			1.0.1
 * @file			GameSettings.cs
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
	using System.Collections;
	using TGT.Menu;

	public class GameSettings
	{

		public bool fullscreen;
		public int textureQuality;
		public int antialiasing;
		public int vSync;
		public int resolutionIndex;
		public float audioVolume;
	}
}
