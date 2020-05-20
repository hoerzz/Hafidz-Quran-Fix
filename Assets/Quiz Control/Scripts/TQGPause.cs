﻿//Version 1.65 (10.08.2016)

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace TriviaQuizGame
{
	/// <summary>
	/// This script pauses/resumes the application by changing Time.timeScale.
	/// </summary>
	public class TQGPause:MonoBehaviour 
	{
		// The previous time scale. The speed of the application before pausing
		internal float prevTimeScale = 1;

		[Tooltip("Should we pause on start?")]
		public bool pauseOnStart = true;

		void Start()
		{
			// Pause the game on start
			if ( pauseOnStart == true )    Pause();
		}

		public void Pause()
		{
			// Record the previous time scale ( speed of game ) so that we can return to it when resuming
			prevTimeScale = Time.timeScale;

			// Pause the game
			Time.timeScale = 0;
		}

		public void Resume()
		{
			// Return to the previous game speed
			Time.timeScale = prevTimeScale;
		}
	}
}
