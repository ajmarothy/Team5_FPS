using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField] int sens;
    [SerializeField] int lockVertMin;
    [SerializeField] int lockVertMax;
    [SerializeField] bool invertY;

    float rotX;
    float recoilOffsetY = 0;

    public void ApplyRecoil(float recoilAmount)
    {
        recoilOffsetY -= recoilAmount;
    }


    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {

        float mouseY = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * sens * Time.deltaTime;

        if (!invertY)
        {
            rotX -= mouseY;
           
        }
        else
        {
            rotX += mouseY;
        }

        rotX = Mathf.Clamp(rotX, lockVertMin, lockVertMax);

        recoilOffsetY = Mathf.Lerp(recoilOffsetY, 0, Time.deltaTime / 0.5f);

        transform.localRotation = Quaternion.Euler(rotX + recoilOffsetY, 0, 0);

        transform.parent.Rotate(Vector3.up * mouseX);
        
    }
}
