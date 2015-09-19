using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public Texture2D cursorTexture;
    public Texture2D cursorTextureNull;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private Vector3 target;
    [SerializeField] private string _prefabName = "Type Prefab Name Here";
    //[SerializeField] public Transform _where;
    private GameObject _theGameObject;

    /*void OnMouseEnter() {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
    void OnMouseExit() {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        Cursor.visible = false;
    }*/

    public void Appear()
    {
        Clear();
        _theGameObject = (GameObject)GameObject.Instantiate(Resources.Load(_prefabName));
        //_theGameObject.transform.parent = _where;
        _theGameObject.transform.localPosition = target;
    }
    public void Clear()
    {
        if (_theGameObject != null)
        {
            Destroy(_theGameObject);
        }
    }

    void Start() {
        /*Cursor.SetCursor(cursorTextureNull, hotSpot, cursorMode);
        Cursor.visible = false;

        #if UNITY_EDITOR
                print("I'm on the Unity Editor");
                Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
                Cursor.visible = true;
        #endif*/
    }

    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            Clear();
        }

        if (Input.GetMouseButtonUp(0)) {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            Appear();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            Clear();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            Appear();
        }
    }
}