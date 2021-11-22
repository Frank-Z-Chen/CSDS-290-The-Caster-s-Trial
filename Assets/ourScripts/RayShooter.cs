using UnityEngine;
using System.Collections;
using UnityEngine.UI; /* Required for controlling Canvas UI system */


public class RayShooter : MonoBehaviour
{
	private Camera _camera;

	[SerializeField] private GameObject fireballPrefab;
	private GameObject _fireball;

	private Animator _animator;


	void Start()																						
	{
		_camera = GetComponent<Camera>();
	}

	/** Deprecated in Unity 2018 
	void OnGUI() {
		int size = 12;
		float posX = _camera.pixelWidth/2 - size/4;
		float posY = _camera.pixelHeight/2 - size/2;
		GUI.Label(new Rect(posX, posY, size, size), "*");
	}
    **/


	void Update()
	{
		if (Input.GetButtonDown("Fireball") )
		{
			_fireball = Instantiate(fireballPrefab) as GameObject;
			_fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
			_fireball.transform.rotation = transform.rotation;
			Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
			Ray ray = _camera.ScreenPointToRay(point);
		}
	}

}