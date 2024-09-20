using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    [Tooltip("��������ȣ�Խ��ת���ٶ�Խ��")]
    [Range(20f, 1000f)]
    private float mouseSensitivity;   //������жȣ�Խ���ƶ��ٶ�Խ��
    [SerializeField]
    [Tooltip("���������ȣ�Խ���ƶ��ٶ�Խ��")]
    [Range(1f, 30f)]
    private float KeyboardSensitivity;   //�������жȣ�Խ���ƶ��ٶ�Խ��
    [SerializeField]
    [Tooltip("����ͷ��player֮��ľ���")]
    private float distance;
    


    public float pitch;
    public float yaw;
    private float distance2obj = 0f;
    private Vector3 currentRotation;
    private Vector3 rotationSmoothVelocity;
    public GameObject Player;           //���ӵ�����


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
        //transform.position = new Vector3(0, 3.95f, -4.42f);     //��ʼ����
        //transform.position = new Vector3(-86f, 53.1f, -36.8f);     //�ڶ�����

        ControllerCamera(true, true);
        MovePlayer();



    }


    private void ControllerCamera(bool move, bool rotate)//�������ת���ƶ�
    {

        float rotationSmoothTime = 0.1f;
        float lookAtPlayerLerpTime = 5f;
        float distancePlayerOffset = 1.5f;

        // �ӽǿ���
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

        //����������
        distance2obj -= Input.GetAxis("Mouse ScrollWheel");
        distance2obj = Mathf.Clamp(distance2obj, -0.20f, 2.5f);
        distancePlayerOffset += distance2obj * 5;

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;//ʵ�����ƽ����ת
        if (move)
        {
            Vector3 targetPosition = Player.transform.position - transform.forward * distancePlayerOffset * distance + transform.up * (distancePlayerOffset - distance2obj * 5) * 0.4f * 0f;
            transform.position = Vector3.Lerp(transform.position, targetPosition, lookAtPlayerLerpTime * Time.deltaTime);
            //ʵ�����ƽ���ƶ�
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

        // �����ƶ�����
        Vector3 movement = transform.forward * verticalMovement + transform.right * horizontalMovement + Player.transform.up * ud;
        movement.y = 0; //  ����ֻ����ˮƽ�����ƶ�
        Player.transform.Translate(movement * Time.deltaTime * KeyboardSensitivity);


    }
}
