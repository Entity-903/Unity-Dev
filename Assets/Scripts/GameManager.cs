using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
	[SerializeField] GameObject titleUI;
	[SerializeField] GameObject gameUI;
	[SerializeField] GameObject winUI;
	[SerializeField] GameObject loseUI;
	[SerializeField] TMP_Text livesUI;
	[SerializeField] TMP_Text timerUI;
	[SerializeField] Slider healthUI;

	[SerializeField] FloatVariable health;

	[SerializeField] GameObject respawn;
	[Header("Events")]
	[SerializeField] VoidEvent gameStartEvent;
	[SerializeField] GameObjectEvent respawnEvent;
	public enum State
	{
		TITLE,
		START_GAME,
		PLAY_GAME,
		PLAYER_DEAD,
		GAME_WON,
		GAME_OVER
	}

	public State state = State.TITLE;
	private float timer;
	private int lives;

	public int Lives {  
		get { return lives; } 
		set { lives = value; livesUI.text = "Lives: " + lives.ToString(); } 
	}

	public float Timer
	{
		get { return timer; }
		set 
		{ 
			timer = value;
			timerUI.text = string.Format("{0:F1}", timer);
		}
	}

	void Start()
	{
		//
	}

	void Update()
	{
		switch (state) 
		{
			case State.TITLE:
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				titleUI.SetActive(true);
				gameUI.SetActive(false);
				winUI.SetActive(false);
				loseUI.SetActive(false);
				break;
			case State.START_GAME:
				titleUI.SetActive(false);
				gameUI.SetActive(true);
				timer = 120; // 120
				Lives = 3;
				health.value = 100.0f;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				gameStartEvent.RaiseEvent();
				state = State.PLAY_GAME;
				break; 
			case State.PLAY_GAME:
				Timer -= Time.deltaTime;
				if (Timer <= 0.0f)
				{
					state = State.GAME_OVER;
					break;
				}
				Player player = GameObject.Find("Player").GetComponent<Player>();
				if (player.Score >= 10)
				{
					state = State.GAME_WON;
				}
				break;
			case State.PLAYER_DEAD:
				Lives -= 1;
				health.value = 100;

				respawnEvent.RaiseEvent(respawn);
				
				if(Lives != 0)
				{
					state = State.PLAY_GAME;
				}
				else
				{
					state = State.GAME_OVER;
				}

				break;
			case State.GAME_WON:
				gameUI.SetActive(false);
				winUI.SetActive(true);

				break;
			case State.GAME_OVER:
				gameUI.SetActive(false);
				loseUI.SetActive(true);
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

	public void OnPlayerDead()
	{
		state = State.PLAYER_DEAD;
	}
}
