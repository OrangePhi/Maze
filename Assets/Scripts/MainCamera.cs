using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    [Tooltip("鼠标灵敏度，越大转动速度越快")]
    [Range(20f, 1000f)]
    private float mouseSensitivity;   //鼠标敏感度，越大移动速度越快
    [SerializeField]
    [Tooltip("键盘灵敏度，越大移动速度越快")]
    [Range(1f, 30f)]
    private float KeyboardSensitivity;   //键盘敏感度，越大移动速度越快
    [SerializeField]
    [Tooltip("摄像头和player之间的距离")]
    private float distance;
    


    public float pitch;
    public float yaw;
    private float distance2obj = 0f;
    private Vector3 currentRotation;
    private Vector3 rotationSmoothVelocity;
    public GameObject Player;           //凝视的物体


    void Start()
    {


    }

    void Update()
    {
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        //Vector3 dir = new Vector3(h, 0, v)*Time.deltaTime;
        //controller.Move(dir);
        //ControllerCamera(false, true);
        //transform.position = new Vector3(0, 3.95f, -4.42f);     //初始场景
        //transform.position = new Vector3(-86f, 53.1f, -36.8f);     //第二场景

        ControllerCamera(true, true);
        MovePlayer();



    }


    private void ControllerCamera(bool move, bool rotate)//相机的旋转和移动
    {

        float rotationSmoothTime = 0.1f;
        float lookAtPlayerLerpTime = 5f;
        float distancePlayerOffset = 1.5f;

        // 视角控制
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        if (!rotate)
        {
            if (!Input.GetMouseButton(1))
            {
                mouseX = 0;
                mouseY = 0;
            }

        }
        pitch -= 2 * mouseY;
        pitch = Mathf.Clamp(pitch, -20f, 50f);

        yaw += mouseX;

        //这是鼠标滚轮
        distance2obj -= Input.GetAxis("Mouse ScrollWheel");
        distance2obj = Mathf.Clamp(distance2obj, -0.20f, 2.5f);
        distancePlayerOffset += distance2obj * 5;

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;//实现相机平滑旋转
        if (move)
        {
            Vector3 targetPosition = Player.transform.position - transform.forward * distancePlayerOffset * distance + transform.up * (distancePlayerOffset - distance2obj * 5) * 0.4f * 0f;
            transform.position = Vector3.Lerp(transform.position, targetPosition, lookAtPlayerLerpTime * Time.deltaTime);
            //实现相机平滑移动
        }

    }


    private void MovePlayer()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        float ud = 0f;
        if (Input.GetKey(KeyCode.Space))
        {
            ud = 0.5f;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                ud = -0.5f;
            }
        }

        // 计算移动方向
        Vector3 movement = transform.forward * verticalMovement + transform.right * horizontalMovement + Player.transform.up * ud;
        movement.y = 0; //  限制只能在水平面内移动
        Player.transform.Translate(movement * Time.deltaTime * KeyboardSensitivity);


    }
}
