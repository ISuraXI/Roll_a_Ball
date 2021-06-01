using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UI_Assistant : MonoBehaviour
{
	private Text messageText;
	private TextWriter.TextWriterSingle textWriterSingle;
	private AudioSource talkingLifeAudioSource;
	private AudioSource talkingScoreAudioSource;

	private GameObject talkingLifeAudioSoundGameObject;
	private GameObject talkingScoreAudioSourceGameObject;

	private int i = 0;

	private void Awake()
	{
		messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
		talkingLifeAudioSource = transform.Find("talkingLifeSound").GetComponent<AudioSource>();
		talkingScoreAudioSource = transform.Find("talkingScoreSound").GetComponent<AudioSource>();

		talkingLifeAudioSoundGameObject = GameObject.Find("talkingLifeSound");
		talkingScoreAudioSourceGameObject = GameObject.Find("talkingScoreSound");

		transform.Find("message").GetComponent<Button_UI>().ClickFunc = () =>
		{
			if (textWriterSingle != null && textWriterSingle.IsActive())
			{
				textWriterSingle.WriteAllAndDestroy();
			}
			else
			{
				string[] messageArray = new string[]
				{
					"That is your life. When you hit a red object your life decrease. If the bar is empty you will explode.",
					"That is your score. The faster you are, the more points you get.",
				};

				string message = messageArray[i];

				if (i == 0)
				{
					StartTalkingLifeSound();
				}
				else if (i == 1)
				{
					StartTalkingScoreSound();
				}

				textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .068f, true, true, StopTalkingSound);
				i++;
			}
		};
	}

	private void StartTalkingLifeSound()
	{
		talkingLifeAudioSource.Play();
	}

	private void StartTalkingScoreSound()
	{
		talkingScoreAudioSource.Play();
	}

	private void StopTalkingSound()
	{
		if (!talkingLifeAudioSoundGameObject.activeSelf)
		{
			talkingScoreAudioSourceGameObject.SetActive(false);
		}
		talkingScoreAudioSource.Stop();
		talkingLifeAudioSoundGameObject.SetActive(false);
		talkingLifeAudioSource.Stop();
	}

	private void Start()
	{
		if (textWriterSingle != null && textWriterSingle.IsActive())
		{
			textWriterSingle.WriteAllAndDestroy();
		}
		else
		{
			string[] messageArray = new string[]
			{
				"That is your life. When you hit a red object your life decrease. If the bar is empty you will explode.",
				"That is your score. The faster you are, the more points you get.",
			};

			string message = messageArray[i];
			if (i == 0)
			{
				StartTalkingLifeSound();
			}
			else if (i == 1)
			{
				StartTalkingScoreSound();
			}
			textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .065f, true, true, StopTalkingSound);
			i++;
		}
	}
}
