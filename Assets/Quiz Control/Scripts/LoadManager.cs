﻿//Version 1.65 (10.08.2016)

#if UNITY_5_3 || UNITY_5_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif

using UnityEngine;
using System.Collections;

namespace QuizGame
{
	/// <summary>
	/// Includes functions for loading levels and URLs. It's intended for use with UI Buttons
	/// </summary>
	public class LoadManager:MonoBehaviour
	{
		[Tooltip("How many seconds to wait before loading a level or URL")]
		public float loadDelay = 1;

		[Tooltip("The name of the URL to be loaded")]
		public string urlName = "";

		[Tooltip("The name of the level to be loaded")]
		public string levelName = "";

		[Tooltip("Loading sound and its source")]
		public AudioClip soundLoad;
		public string soundSourceTag = "GameController";
		public GameObject soundSource;

		//Open Panel
		public GameObject Panel;

		// Holds the gamecontroller in the scene
		internal GameObject gameController;



		/// <summary>
		/// Start is only called once in the lifetime of the behaviour.
		/// The difference between Awake and Start is that Start is only called if the script instance is enabled.
		/// This allows you to delay any initialization code, until it is really needed.
		/// Awake is always called before any Start functions.
		/// This allows you to order initialization of scripts
		/// </summary>
		void Start()
		{
		    // If there is a gamecontroller in the scene, assign it to the variable
			if ( GameObject.FindGameObjectWithTag("GameController") )    gameController = GameObject.FindGameObjectWithTag("GameController");

			// If there is no sound source assigned, try to assign it from the tag name
			if ( !soundSource && GameObject.FindGameObjectWithTag(soundSourceTag) )    soundSource = GameObject.FindGameObjectWithTag(soundSourceTag);
		}

		/// <summary>
		/// Loads the URL.
		/// </summary>
		/// <param name="urlName">URL/URI</param>
		public void LoadURL()
		{
			Time.timeScale = 1;

			// If there is a sound, play it from the source
			if ( soundSource && soundLoad )    soundSource.GetComponent<AudioSource>().PlayOneShot(soundLoad);

			// Execute the function after a delay
			Invoke("ExecuteLoadURL", loadDelay);
		}

		/// <summary>
		/// Executes the load URL function
		/// </summary>
		void ExecuteLoadURL()
		{
			Application.OpenURL(urlName);
		}
	
		/// <summary>
		/// Loads the level.
		/// </summary>
		/// <param name="levelName">Level name.</param>
		public void LoadLevel()
		{
			Time.timeScale = 1;

			// If there is a sound, play it from the source
			if ( soundSource && soundLoad )    soundSource.GetComponent<AudioSource>().PlayOneShot(soundLoad);

			// Execute the function after a delay
			Invoke("ExecuteLoadLevel", loadDelay);
		}

		/// <summary>
		/// Executes the Load Level function
		/// </summary>
		void ExecuteLoadLevel()
		{
			#if UNITY_5_3 || UNITY_5_3_OR_NEWER
			SceneManager.LoadScene(levelName);
			#else
			Application.LoadLevel(levelName);
			#endif
		}

		/// <summary>
		/// Restarts the current level.
		/// </summary>
		public void RestartLevel()
		{
			Time.timeScale = 1;

			// If there is a sound, play it from the source
			if ( soundSource && soundLoad )    soundSource.GetComponent<AudioSource>().PlayOneShot(soundLoad);

			// Execute the function after a delay
			Invoke("ExecuteRestartLevel", loadDelay);
		}
		
		/// <summary>
		/// Executes the Load Level function
		/// </summary>
		void ExecuteRestartLevel()
		{
			#if UNITY_5_3 || UNITY_5_3_OR_NEWER
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			#else
			Application.LoadLevel(Application.loadedLevelName);
			#endif
		}

		/// <summary>
		/// Starts the game in the gamecontroller, if it exists
		/// </summary>
		public void StartGame()
		{
			if ( gameController )    gameController.SendMessage("StartGame");
		}
        public void Bermain()
        {
            SceneManager.LoadScene("Bermain");
        }

		public void OpenPanel()
		{
			if (Panel != null)
			{
				bool isActive = Panel.activeSelf;

				if (soundSource && soundLoad) soundSource.GetComponent<AudioSource>().PlayOneShot(soundLoad);

				Panel.SetActive(!isActive);
			}
		}
		public void BukaPanelAnim()
		{
			if (Panel != null)
			{
				Animator animator = Panel.GetComponent<Animator>();
				if (animator != null)
				{
					bool isOpen = animator.GetBool("open");

					animator.SetBool("open", !isOpen);
				}
			}
		}
	}
}