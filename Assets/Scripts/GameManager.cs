using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
	[SerializeField] GameObject titleUI;
	[SerializeField] TMP_Text livesUI;
	[SerializeField] TMP_Text timerUI;
	[SerializeField] Slider healthUI;

	[SerializeField] FloatVariable health;
	[Header("Events")]
	[SerializeField] IntEvent scoreEvent;
	[SerializeField] VoidEvent gameStartEvent;
	public enum State
	{
		TITLE,
		START_GAME,
		PLAY_GAME,
		GAME_OVER
	}

	public State state = State.TITLE;
	public float timer = 0;
	public int lives = 0;

	public int Lives {  
		get { return lives; } 
		set { lives = value; livesUI.text = lives.ToString(); } 
	}

	public float Timer
	{
		get { return timer; }
		set 
		{ 
			timer = value;
			timerUI.text = timer.ToString();
		}
	}

	void Start()
	{
		scoreEvent.Subscribe(OnAddPoints);
	}

	void Update()
	{
		switch (state) 
		{
			case State.TITLE:
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				titleUI.SetActive(true);
				break;
			case State.START_GAME:
				titleUI.SetActive(false);
				timer = 0;
				Lives = 3;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				gameStartEvent.RaiseEvent();
				state = State.PLAY_GAME;
				break; 
			case State.PLAY_GAME:
				Timer = Timer - Time.deltaTime;
				if (Timer <= 0.0f)
				{
					state = State.GAME_OVER;
					break;
				}
				break;
			case State.GAME_OVER:
				break;

		}

		healthUI.value = health.value / 100.0f;
	}

	public void OnStartGame()
	{
		state = State.START_GAME;
	}

	public void OnAddPoints(int points)
	{
		print(points);
	}
}
