using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {
	
	public AudioMixerSnapshot paused;
	public AudioMixerSnapshot unpaused;
	
	Canvas canvas;

    //Debug variables
    private float accumulatedFrames = 0.0f;
    private int frames = 0;
    private float timeleft = 0.5f;
    private string FPSformat = "";

    void Start()
	{
		canvas = GetComponent<Canvas>();
	}

    private void OnGUI()
    {
        timeleft -= Time.deltaTime;
        accumulatedFrames += Time.timeScale / Time.deltaTime;
        frames++;

        if (timeleft <= 0.0)
        {
            float fps = accumulatedFrames / frames;
            FPSformat = System.String.Format("{0:F2} FPS", fps);
            timeleft = 0.5f;
            accumulatedFrames = 0.0f;
            frames = 0;
        }

        GUI.Label(new Rect(Screen.width - 300, Screen.height - 180, 500, 500), "" + FPSformat);
    }

    void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			canvas.enabled = !canvas.enabled;
			Pause();
		}
	}
	
	public void Pause()
	{
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		Lowpass ();
		
	}
	
	void Lowpass()
	{
		if (Time.timeScale == 0)
		{
			paused.TransitionTo(.01f);
		}
		
		else
			
		{
			unpaused.TransitionTo(.01f);
		}
	}
	
	public void Quit()
	{
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else 
		Application.Quit();
		#endif
	}
}
