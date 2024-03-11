using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class SceneLoader : MonoBehaviour {
    [System.Obsolete]
    void Awake () {
		float ratio = Mathf.Clamp((float)1024 / Screen.height, 0, 1);
		Screen.SetResolution((int)(Screen.width * ratio), (int)(Screen.height * ratio), true, 60);
	}

	// Use this for initialization
	void Start () {
		// 자기 자신은 캔버스 객체 이며 자식으로 있는 버튼을 찾아서 이벤트를 등록한다.
		Button[] buttons = GetComponentsInChildren<Button>();
		foreach (Button button in buttons) {
			button.onClick.AddListener(() => Load(button.name));
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Load(string name) {
		StartCoroutine(DoLoad(name));
	}

	IEnumerator DoLoad(string name) {
		AsyncOperation async = SceneManager.LoadSceneAsync(name);
		yield return async;
	}
}
