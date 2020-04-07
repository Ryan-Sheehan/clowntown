using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class ExamplePongLogic : MonoBehaviour {

	public Rigidbody2D racketLeft;
	public Rigidbody2D racketRight;
	public Rigidbody2D ball;
	public float ballSpeed = 10f;
	public Text uiText;

	private Vector2 leftPos;
	private Vector2 rightPos;

#if !DISABLE_AIRCONSOLE
	private int scoreRacketLeft = 0;
	private int scoreRacketRight = 0;

	void Awake () {
		AirConsole.instance.onMessage += OnMessage;
		AirConsole.instance.onConnect += OnConnect;
		AirConsole.instance.onDisconnect += OnDisconnect;
	}

	/// <summary>
	/// We start the game if 2 players are connected and the game is not already running (activePlayers == null).
	/// 
	/// NOTE: We store the controller device_ids of the active players. We do not hardcode player device_ids 1 and 2,
	///       because the two controllers that are connected can have other device_ids e.g. 3 and 7.
	///       For more information read: http://developers.airconsole.com/#/guides/device_ids_and_states
	/// 
	/// </summary>
	/// <param name="device_id">The device_id that connected</param>
	void OnConnect (int device_id) {
		if (AirConsole.instance.GetActivePlayerDeviceIds.Count == 0) {
			if (AirConsole.instance.GetControllerDeviceIds ().Count >= 2) {
				StartGame ();
			} else {
				uiText.text = "NEED MORE PLAYERS";
			}
		}
	}

	/// <summary>
	/// If the game is running and one of the active players leaves, we reset the game.
	/// </summary>
	/// <param name="device_id">The device_id that has left.</param>
	void OnDisconnect (int device_id) {
		int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber (device_id);
		if (active_player != -1) {
			if (AirConsole.instance.GetControllerDeviceIds ().Count >= 2) {
				StartGame ();
			} else {
				AirConsole.instance.SetActivePlayers (0);
				uiText.text = "PLAYER LEFT - NEED MORE PLAYERS";
			}
		}
	}

	/// <summary>
	/// We check which one of the active players has moved the paddle.
	/// </summary>
	/// <param name="from">From.</param>
	/// <param name="data">Data.</param>
	void OnMessage (int device_id, JToken data) {
		int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber (device_id);
		if (active_player != -1) {
			if (active_player == 0) {
				Vector2 pL = this.racketLeft.transform.position;
				this.racketLeft.velocity = Vector3.up * (float)data ["moveUpDown"];
				pL.x += (float)data["moveLeftRight"];
				this.racketLeft.transform.position = pL;
				Debug.Log(this.racketLeft.transform.position.x);
			}
			if (active_player == 1) {
				Vector2 pR = this.racketRight.transform.position;
				this.racketRight.velocity = Vector3.up * (float)data ["moveUpDown"];
				pR.x += (float)data["moveLeftRight"];
				this.racketRight.transform.position = pR;
				Debug.Log(this.racketRight.transform.position.x);
			}
		}
	}

	void StartGame () {
		leftPos = racketLeft.position;
		rightPos = racketRight.position;
		AirConsole.instance.SetActivePlayers (2);
		ResetClowns();
		scoreRacketLeft = 0;
		scoreRacketRight = 0;
		UpdateScoreUI ();
	}

	void ResetClowns () {

		// place ball at center
		this.racketLeft.position = leftPos;
		this.racketRight.position = rightPos;
	}

	void UpdateScoreUI () {
		// update text canvas
		uiText.text = scoreRacketLeft + ":" + scoreRacketRight;
	}

	void FixedUpdate () {

		// check if ball reached one of the ends
		if (this.racketLeft.position.x < -9f) {
			scoreRacketRight++;
			UpdateScoreUI ();
			ResetClowns();
		}

		if (this.racketLeft.position.x > 9f) {
			scoreRacketRight++;
			UpdateScoreUI ();
			ResetClowns();
		}

		if (this.racketRight.position.x < -9f)
		{
			scoreRacketLeft++;
			UpdateScoreUI();
			ResetClowns();
		}

		if (this.racketRight.position.x > 9f)
		{
			scoreRacketLeft++;
			UpdateScoreUI();
			ResetClowns();
		}
	}

	void OnDestroy () {

		// unregister airconsole events on scene change
		if (AirConsole.instance != null) {
			AirConsole.instance.onMessage -= OnMessage;
		}
	}
#endif
}
