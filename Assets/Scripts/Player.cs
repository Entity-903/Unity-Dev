using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] FloatVariable health;
    [SerializeField] PhysicsCharacterController characterController;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;
    [SerializeField] VoidEvent gameStartEvent = default;
    [SerializeField] VoidEvent playerDeadEvent = default;

    private int score = 0;

    public int Score 
    { 
        get { return score; } 
        set { 
            score = value; 
            scoreText.text = "Score: " + score.ToString(); 
            scoreEvent.RaiseEvent(score);
        }
    }

    private void OnEnable()
    {
        gameStartEvent.Subscribe(OnStartGame);
    }

    private void Start()
    {
        // health.value = 50f;
    }

    public void AddPoints(int points)
    {
        Score += points;
    }

    private void OnStartGame()
    {
        characterController.enabled = true;
    }

    public void ApplyDamage(float damage)
    {
        health.value -= damage;
        if (health.value <= 0)
        {
            playerDeadEvent.RaiseEvent();
        }

		if (health.value >= 100)
		{
			health.value = 100;
		}
	}

    public Rigidbody GetRigidbody()
    {
        return characterController.rb;
    }

    public void OnRespawn(GameObject respawn)
    {
        transform.position = respawn.transform.position;
        transform.rotation = respawn.transform.rotation;

        characterController.Reset();
    }

	public static explicit operator Player(GameObject v)
	{
		throw new NotImplementedException();
	}
}
