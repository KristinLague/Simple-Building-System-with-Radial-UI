using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public bool CursorLocked;
    public bool rotateForYoutube;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //CursorLocked = true;
    }

    void Update()
    {
        if(rotateForYoutube)
        {
            transform.Rotate(Vector3.up, Speed * Time.deltaTime);
        }

        float translation = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        float straffe = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Break();
            if(CursorLocked)
            {
                //Cursor.lockState = CursorLockMode.None;
                //CursorLocked = false;
            }
            else
            {
                //Cursor.lockState = CursorLockMode.Locked;
                //CursorLocked = true;
            }
            
        }
    }
}
