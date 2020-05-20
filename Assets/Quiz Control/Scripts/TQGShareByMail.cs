//Version 1.65 (10.08.2016)

using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using TriviaQuizGame.Types;

#if UNITY_STANDALONE
// For sending email
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace TriviaQuizGame
{
	/// <summary>
	/// This script
	/// </summary>
	public class TQGShareByMail:MonoBehaviour 
	{
		internal TQGGameController gameController;
		internal Text textMessage;
		
		[Tooltip("This is the email address that the results will be sent to")]
		public string mailTarget;
		
		// For now this is the same as the target email address
		internal string mailSource;
		
		[Tooltip("This is the password of the email address that the results will be sent to")]
		public string mailPassword = "";
		
		public string mailSMTPServer = "smtp.gmail.com";
		
		internal Text inputFieldName;
		
		internal Button buttonSendMail;
		
		//[Tooltip("Share the score we got. If there are more than 1 player, all the scores of all the players will be shared in a list")]
		//public bool shareScore = true;
		
		// The name of the use who answered
		
		
		/// <summary>
		/// Start is only called once in the lifetime of the behaviour.
		/// The difference between Awake and Start is that Start is only called if the script instance is enabled.
		/// This allows you to delay any initialization code, until it is really needed.
		/// Awake is always called before any Start functions.
		/// This allows you to order initialization of scripts
		/// </summary>
		void Start() 
		{
			// Look for the game controller in this level
			gameController = (TQGGameController) FindObjectOfType(typeof(TQGGameController));
			
			// If there is no game controller we can't use mail sharing
			if ( gameController == null )    Debug.LogWarning("Can't find a game controller object, mail sharing cannot be used");
			
			// Assign the text message object, which shows if the message was sent or failed
			textMessage = GameObject.Find("TextMessage").GetComponent<Text>();
			
			// Clear the text message
			if ( textMessage )    textMessage.text = "";
			
			mailSource = mailTarget;
			
			inputFieldName = GameObject.Find("InputFieldName/Text").GetComponent<Text>();
			
			buttonSendMail = GameObject.Find("ButtonSendMail").GetComponent<Button>();
			
		}
		
		/// <summary>
		/// Updates the mail source address
		/// </summary>
		/// <param name="changeValue">The new mail source address</param>
		public void UpdateMailSource( string changeValue )
		{
			//mailSource = changeValue;
		}
		
		/// <summary>
		/// Updates the mail source password
		/// </summary>
		/// <param name="changeValue">The new password</param>
		public void UpdateMailSourcePassword( string changeValue )
		{
			//mailPassword = changeValue;
		}
		
		/// <summary>
		/// Tries to send mail.
		/// </summary>
		public void TryToSendMail()
		{
			if ( inputFieldName.text == "" )
			{
				// If we forgot to enter a name, remind us
				if ( textMessage )    textMessage.text = "You must enter your name";
			}
			else
			{
				// Sending mail in progress...
				if ( textMessage )    textMessage.text = "Sending mail...";
				
				buttonSendMail.interactable = false;
				
				StartCoroutine(SendMail(0.1f));
				//StartCoroutine(SendMail(), 1);
			}
		}
		
		/// <summary>
		/// Shares the results of the quiz by mail.
		/// </summary>
		IEnumerator SendMail(float delay)
		{
			yield return new WaitForSeconds(delay);
			
			// Create a new mail message
			MailMessage mail = new MailMessage();
			
			// Assign the source of the mail. This will appear in the "From" field in the mail you recieve
			mail.From = new MailAddress(mailSource);
			mail.To.Add(mailTarget);
			mail.Subject = "Trivia quiz results";
			mail.Body = inputFieldName.text + "'s score is " + gameController.players[gameController.currentPlayer].score.ToString();
			
			SmtpClient smtpServer = new SmtpClient(mailSMTPServer);
			smtpServer.Port = 587;
			smtpServer.Credentials = new System.Net.NetworkCredential(mailSource, mailPassword) as ICredentialsByHost;
			smtpServer.EnableSsl = true;
			ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
			{ 
				return true; 
			};
			
			smtpServer.Send(mail);
			
			// Mail has been sent to the address
			if ( textMessage )    textMessage.text = "Mail sent!";
			
			yield return new WaitForSeconds(1);
			
			gameObject.SetActive(false);
		}
	}
}
#else
namespace TriviaQuizGame
{
	/// <summary>
	/// This script
	/// </summary>
	public class TQGShareByMail : MonoBehaviour
	{
		[Tooltip("Sharing by EMail is only available on PC, Mac, & Linux Standalone. Please switch to one of these platforms.")]
		public string Warning;
		
	}
}
#endif