using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class COR : MonoBehaviour
{
    [SerializeField] float time = 3;
    [SerializeField] bool go = true;

    Coroutine timerCoroutine;

    void Start()
    {
        StartCoroutine(Timer(time));
        StartCoroutine(StoryTime());
        StartCoroutine(WaitAction());
    }

    void Update()
    {
        //time -= Time.deltaTime;
        //if (time <= 0)
        //{
        //    time = 3;
        //    print("Hello there!");
        //}
    }

    IEnumerator Timer(float time)
    {
        while (true) 
        { 
        yield return new WaitForSeconds(time);
        // Check perception
		print("Tick");        
        }
		//yield return null;
    }

    IEnumerator StoryTime()
    {
        print("Hello");
		yield return new WaitForSeconds(1);
        print("Welcome to the new world");
		yield return new WaitForSeconds(1);
        print("Now leave...");
		yield return new WaitForSeconds(1);
        print("NOW!");

        StopCoroutine(timerCoroutine);

		yield return null;
    }

    IEnumerator WaitAction()
    {
        yield return new WaitUntil(() => go);
        print("go");
        yield return null;

    }
}
