using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLook : MonoBehaviour
{
    public float Sensitivity = 10f;
    public float Smoothing = 2.0f;

    Vector2 mouseLook;
    Vector2 smoothV;

    GameObject character;
    static CharacterLook instance;
    public bool Lock;
    public static CharacterLook Instance { get { return instance; } }

    void Start()
    {
        character = transform.parent.gameObject;
        instance = this;
    }

    void Update()
    {
        Lock = UserInterface.Instance.Active;
        if(Lock)
        {
            return;
        }

        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(Sensitivity * Smoothing, Sensitivity * Smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / Smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / Smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    } 
}
