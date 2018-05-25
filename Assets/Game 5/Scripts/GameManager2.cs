using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts;
using System.Linq;

public class GameManager2 : MonoBehaviour
{

    public CameraFollow1 cameraFollow;
    int currentBirdIndex;
    public SlingShot slingshot;
    private float lastCreated;
    public static GameState CurrentGameState = GameState.Start;
    public GameObject[] projectile;

    public GameObject[] balon;

    public TextMesh scoreLabel;
	public static int score;
	public int Score
	{
		set
		{
			score = value;

			scoreLabel.text = "Score: "+Score.ToString();
		}
		get
		{
			return score;
		}
	}

	private float speed;
    void Start()
    {
        CurrentGameState = GameState.Start;
        slingshot.enabled = false;
        //find all relevant game objects
       
        //unsubscribe and resubscribe from the event
        //this ensures that we subscribe only once
        slingshot.BirdThrown -= Slingshot_BirdThrown;
        slingshot.BirdThrown += Slingshot_BirdThrown;
        score = 0;
		lastCreated = 0;

		lastCreated = Time.time;

		speed = 3f;

		Invoke("CreateObjects", 0.5f);
    }
    
	void CreateObjects()
	{
        
		Instantiate(balon[Random.Range(0,balon.Length)], new Vector3(Random.Range(5f,14f), 9f, 0) ,Quaternion.identity);
		if (Score % 5 == 0)
			speed -= 0.01f;
        if(speed<=0.5f){
            speed =2f;
        }
		Invoke("CreateObjects", speed);
	}
    // Update is called once per frame
    void Update()
    {
        switch (CurrentGameState)
        {
            case GameState.Start:
                //if player taps, begin animating the bird 
                //to the slingshot
                if (Input.GetMouseButtonUp(0))
                {
                    AnimateBirdToSlingshot();
                }
                break;
            case GameState.BirdMovingToSlingshot:
                //do nothing
                break;
            case GameState.Playing:
                //if we have thrown a bird
                //and either everything has stopped moving
                //or there has been 5 seconds since we threw the bird
                //animate the camera to the start position
                if (slingshot.slingshotState == SlingshotState.BirdFlying &&
                    (balonprojectileStoppedMoving() || Time.time - slingshot.TimeSinceThrown > 5f))
                {
                    slingshot.enabled = false;
                    AnimateCameraToStartPosition();
                    CurrentGameState = GameState.BirdMovingToSlingshot;
                }
    
                break;
            case GameState.Lost:
            currentBirdIndex=14;
            Application.LoadLevel("Chap5 MainMenu");
                break;
            default:
                break;
        }
    }



    /// <summary>
    /// Animates the camera to the original location
    /// When it finishes, it checks if we have lost, won or we have other birds
    /// available to throw
    /// </summary>
    private void AnimateCameraToStartPosition()
    {
        float duration = Vector2.Distance(Camera.main.transform.position, cameraFollow.StartingPosition) / 10f;
        if (duration == 0.0f) duration = 0.1f;
        //animate the camera to start
        Camera.main.transform.positionTo
            (duration,
            cameraFollow.StartingPosition). //end position
            setOnCompleteHandler((x) =>
                        {
                            cameraFollow.IsFollowing = false;
                            //animate the next bird, if available
                             if (currentBirdIndex ==14)
                            {
                                currentBirdIndex=14;
                                Application.LoadLevel("Chap5 MainMenu");
                                Debug.Log(currentBirdIndex+"On Lost");
                                CurrentGameState = GameState.Lost;
                            }
                            else
                            {
                                slingshot.slingshotState = SlingshotState.Idle;
                                //bird to throw is the next on the list
                                currentBirdIndex++;
                                 Debug.Log(currentBirdIndex+"On Slingshot");
                                AnimateBirdToSlingshot();
                            }
                        });
    }

    /// <summary>
    /// Animates the bird from the waiting position to the slingshot
    /// </summary>
    void AnimateBirdToSlingshot()
    {
        CurrentGameState = GameState.BirdMovingToSlingshot;
        projectile[currentBirdIndex].transform.positionTo
            (Vector2.Distance(projectile[currentBirdIndex].transform.position / 10,
            slingshot.BirdWaitPosition.transform.position) / 10, //duration
            slingshot.BirdWaitPosition.transform.position). //final position
                setOnCompleteHandler((x) =>
                        {
                            x.complete();
                            x.destroy(); //destroy the animation
                            CurrentGameState = GameState.Playing;
                            slingshot.enabled = true; //enable slingshot
                            //current bird is the current in the list
                            slingshot.BirdToThrow = projectile[currentBirdIndex];
                            Debug.Log(currentBirdIndex+"On Animate");
                        });
    }

    /// <summary>
    /// Event handler, when the bird is thrown, camera starts following it
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Slingshot_BirdThrown(object sender, System.EventArgs e)
    {
        cameraFollow.BirdToFollow = projectile[currentBirdIndex].transform;
        cameraFollow.IsFollowing = true;
    }

    /// <summary>
    /// Check if all birds, pigs and bricks have stopped moving
    /// </summary>
    /// <returns></returns>
    bool balonprojectileStoppedMoving()
    {
        foreach (var item in projectile)
        {
            if (item != null && item.GetComponent<Rigidbody2D>().velocity.sqrMagnitude > Constants.MinVelocity)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Found here
    /// http://www.bensilvis.com/?p=500
    /// </summary>
    /// <param name="screenWidth"></param>
    /// <param name="screenHeight"></param>
    public static void AutoResize(int screenWidth, int screenHeight)
    {
        Vector2 resizeRatio = new Vector2((float)Screen.width / screenWidth, (float)Screen.height / screenHeight);
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(resizeRatio.x, resizeRatio.y, 1.0f));
    }

    /// <summary>
    /// Shows relevant GUI depending on the current game state
    /// </summary>
    void OnGUI()
    {
        AutoResize(800, 480);
        switch (CurrentGameState)
        {
            case GameState.Start:
                GUI.Label(new Rect(0, 150, 200, 100), "Tap the screen to start");
                break;
            case GameState.Won:
                GUI.Label(new Rect(0, 150, 200, 100), "You won! Tap the screen to restart");
                break;
            case GameState.Lost:
                GUI.Label(new Rect(0, 150, 200, 100), "You lost! Tap the screen to restart");
                break;
            default:
                break;
        }
    }
}
