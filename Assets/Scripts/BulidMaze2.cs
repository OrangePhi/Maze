using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BulidMaze2 : MonoBehaviour
{
    GameObject NewMaze;
    float Wallthickness = 0.09f;
    float Wallheight = 1f;      //ǽ�ĸ߶�
    float RoomsideLength = 3f;  //�����С���߳���
    [SerializeField]
    [Range(0f,1f)]
    private float Probability_door=0f;  //���ŵĸ���

    [SerializeField]
    private Slider Slider_Probability_door;

    [SerializeField]
    private Text Text_Probability_door;

    struct Room
    {
        public float x;
        public float y;
        public float westdoor;
        public float northdoor;
        public float eastdoor;
        public float southdoor;
    }

    //[SerializeField]
    int w = 10;
    int h = 10;
    Room[,] roomsArray = new Room[10, 10];

    // Start is called before the first frame update
    void Start()
    {
        NewMaze = new GameObject("New Maze");
        // ���µ���Ϸ��������Ϊ��ǰ������Ӷ���
        NewMaze.transform.parent = this.transform;
        BulidMaze();
        Render_Maze();
        //Build_Wall_With_Door(NewMaze, 0, 2, RoomsideLength, Wallthickness, 0.2f);  //��ǽ
        //Build_Wall_With_Door(NewMaze, 2, 0 , Wallthickness, RoomsideLength,0.2f);  //��ǽ
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RebulidMaze();
        }
    }
    void BulidMaze()
    {
        for(int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                if (i == 0 && j == 0)
                {
                    roomsArray[i, j].x = 0f;
                    roomsArray[i, j].y = 0f;
                    roomsArray[i, j].eastdoor = Random.Range(0f, 1f);
                    roomsArray[i, j].northdoor = -1f;
                    roomsArray[i, j].southdoor = Random.Range(0f, 1f);
                    roomsArray[i, j].westdoor = -1f;
                }
                else if (i == 0)        //��һ��
                {
                    roomsArray[i, j].x = roomsArray[i, j - 1].x + RoomsideLength;
                    roomsArray[i, j].y = 0f;
                    //���ߣ��������
                    float door_Pos = Random.Range(0f, 1f);
                    if (door_Pos > (1- Probability_door))    //�оųɵĸ�������
                    {
                        door_Pos = Random.Range(0f, 1f);
                    }
                    else
                    {
                        door_Pos = -1f;
                    }
                    roomsArray[i, j].eastdoor = door_Pos;
                    //����û��
                    roomsArray[i, j].northdoor = -1f;
                    //�ϱߣ��������
                    door_Pos = Random.Range(0f, 1f);
                    if (door_Pos > (1 - Probability_door))    //�оųɵĸ�������
                    {
                        door_Pos = Random.Range(0f, 1f);
                    }
                    else
                    {
                        door_Pos = -1f;
                    }
                    roomsArray[i, j].southdoor = door_Pos;
                    //���ߣ������߷���Ķ�ǽ��û����
                    if (roomsArray[i, j - 1].eastdoor == -1f)
                    {
                        roomsArray[i, j].westdoor = -1f;
                    }
                    else
                    {
                        roomsArray[i, j].westdoor = roomsArray[i, j - 1].eastdoor;
                    }
                    
                }
                else if (j == 0)//��һ��
                {
                    roomsArray[i, j].x = 0f;
                    roomsArray[i, j].y = roomsArray[i-1 , j].y - RoomsideLength;
                    roomsArray[i, j].westdoor = -1f;    //����û����
                    //���ߣ������߷������ǽ��û����
                    if (roomsArray[i - 1, j].southdoor == -1f)
                    {
                        roomsArray[i, j].northdoor = -1f;
                    }
                    else
                    {
                        roomsArray[i, j].northdoor = roomsArray[i - 1, j].southdoor;
                    }
                    //�ϱߣ��������
                    float door_Pos = Random.Range(0f, 1f);
                    if (door_Pos > (1 - Probability_door))    //�оųɵĸ�������
                    {
                        door_Pos = Random.Range(0f, 1f);
                    }
                    else
                    {
                        door_Pos = -1f;
                    }
                    roomsArray[i, j].southdoor = door_Pos;
                    //���ߣ��������
                    door_Pos = Random.Range(0f, 1f);
                    if (door_Pos > (1 - Probability_door))    //�оųɵĸ�������
                    {
                        door_Pos = Random.Range(0f, 1f);
                    }
                    else
                    {
                        door_Pos = -1f;
                    }
                    roomsArray[i, j].eastdoor = door_Pos;

                }
                else        //ʣ�µ�
                {
                    roomsArray[i, j].x = roomsArray[i - 1, j - 1].x + RoomsideLength;
                    roomsArray[i, j].y = roomsArray[i - 1, j - 1].y - RoomsideLength;
                    //���ߣ������߷������ǽ��û����
                    if (roomsArray[i - 1, j].southdoor == -1f)
                    {
                        roomsArray[i, j].northdoor = -1f;
                    }
                    else
                    {
                        roomsArray[i, j].northdoor = roomsArray[i - 1, j].southdoor;
                    }
                    //���ߣ������߷���Ķ�ǽ��û����
                    if (roomsArray[i, j - 1].eastdoor == -1f)
                    {
                        roomsArray[i, j].westdoor = -1f;
                    }
                    else
                    {
                        roomsArray[i, j].westdoor = roomsArray[i, j - 1].eastdoor;
                    }
                    //�ϱߣ��������
                    float door_Pos = Random.Range(0f, 1f);
                    if (door_Pos > (1 - Probability_door))    //�оųɵĸ�������
                    {
                        door_Pos = Random.Range(0f, 1f);
                    }
                    else
                    {
                        door_Pos = -1f;
                    }
                    roomsArray[i, j].southdoor = door_Pos;
                    //���ߣ��������
                    door_Pos = Random.Range(0f, 1f);
                    if (door_Pos > (1 - Probability_door))    //�оųɵĸ�������
                    {
                        door_Pos = Random.Range(0f, 1f);
                    }
                    else
                    {
                        door_Pos = -1f;
                    }
                    roomsArray[i, j].eastdoor = door_Pos;
                }
                
            }
        }
    }

    void Render_Maze()      //��Ⱦ�Թ�
    {
        for(int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                Generate_A_Room(NewMaze, roomsArray[i, j]);
            }
        }
    }
    //����һ�����䣬�����gameObject�ǹ��صĸ���
    void Generate_A_Room(GameObject gameObject,Room room)
    {

        GameObject NewRoom = new GameObject("room");
        NewRoom.transform.parent = gameObject.transform;
        Build_Wall_With_Door(NewRoom, room.x - 0.5f * RoomsideLength, room.y, Wallthickness, RoomsideLength, room.westdoor);
        Build_Wall_With_Door(NewRoom, room.x, room.y + 0.5f * RoomsideLength, RoomsideLength, Wallthickness, room.northdoor);
        Build_Wall_With_Door(NewRoom, room.x + 0.5f * RoomsideLength, room.y, Wallthickness, RoomsideLength, room.eastdoor);
        Build_Wall_With_Door(NewRoom, room.x, room.y - 0.5f * RoomsideLength, RoomsideLength, Wallthickness, room.southdoor);


    }
    //����һ��ǽ�ڣ������gameObject�ǹ��صĸ����������door_Pos���ŵ�λ�ã����������-1����ʾû����
    GameObject Build_Wall(GameObject gameObject, float x, float z, float width, float height, float door_Pos)
    {
        if (door_Pos < 0.1f && door_Pos > 0f)
        {
            door_Pos = 0.1f;
        }
        if (door_Pos > 0.9f && door_Pos <1f)
        {
            door_Pos = 0.9f;
        }
        GameObject Wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Wall.name = "Wall";
        Wall.transform.localScale = new Vector3(width, Wallheight, height);
        Wall.transform.position = new Vector3(x, Wallheight / 2, z);
        Wall.transform.parent = gameObject.transform;
        if (door_Pos == -1f)
        {
            return Wall;
        }

        // ����������Ϸ����
        GameObject door = GameObject.CreatePrimitive(PrimitiveType.Cube);
        door.name = "Door";
        door.transform.parent = Wall.transform;
        float doorwidth = RoomsideLength * 0.1f;       //�ǵĿ��
        float doorheigth = Wallheight * 2.0f / 3.0f;   //�ŵĸ߶� 

        if (width < height)   //˵�������ŵ�ǽ
        {
            // ���㶴��λ��
            float holeX = x;
            float holeZ = z + (door_Pos - 0.5f) * RoomsideLength;
            door.transform.localScale = new Vector3(Wallthickness / Wallthickness * 1.02f, doorheigth, doorwidth);
            door.transform.position = new Vector3(holeX, doorheigth / 2.0f, holeZ);
        }
        else//˵���Ǻ��ŵ�ǽ
        {
            // ���㶴��λ��
            float holeX = x + (door_Pos - 0.5f) * RoomsideLength;
            float holeZ = z;
            door.transform.localScale = new Vector3(doorwidth, doorheigth, Wallthickness / Wallthickness * 1.02f);
            door.transform.position = new Vector3(holeX, doorheigth / 2.0f, holeZ);
        }
        // �Ƴ����ڳ������ϵ�һ����
        MeshFilter cubeMeshFilter = Wall.GetComponent<MeshFilter>();
        cubeMeshFilter.mesh = SubtractMeshes(cubeMeshFilter.mesh, door.GetComponent<MeshFilter>().mesh);

        // ɾ��������Ϸ����
        //Destroy(door);
        door.GetComponent<Renderer>().material.color = Color.red;
        return Wall;

    }

    //����һ��ǽ�ڣ������gameObject�ǹ��صĸ����������door_Pos���ŵ�λ�ã����������-1����ʾû����
    GameObject Build_Wall_With_Door(GameObject gameObject, float x, float z, float width, float height, float door_Pos)
    {
        if (door_Pos == -1)
        {
            return Build_Wall(gameObject, x, z, width, height, door_Pos);
        }
        float doorwidth = RoomsideLength * 0.2f;       //�ǵĿ��
        float doorheigth = Wallheight * 2.0f / 3.0f;   //�ŵĸ߶� 
        if (door_Pos < 0.1f && door_Pos > 0f)
        {
            door_Pos = 0.1f;
        }
        if (door_Pos > 0.9f && door_Pos < 1f)
        {
            door_Pos = 0.9f;
        }
        GameObject Wall = new GameObject("Wall");
        Wall.transform.parent = gameObject.transform;

        GameObject Wall1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Wall1.name = "Wall1";
        Wall1.transform.parent = Wall.transform;

        GameObject Wall2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Wall2.name = "Wall2";
        Wall2.transform.parent = Wall.transform;

        GameObject Wall3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Wall3.name = "Wall3";
        Wall3.transform.parent = Wall.transform;
        if (width < height)//˵�������ŵ�ǽ
        {
            Wall1.transform.localScale = new Vector3(width, Wallheight, height * door_Pos - 0.5f * doorwidth);
            Wall1.transform.position = new Vector3(x , Wallheight / 2, z- (0.5f * height - 0.5f * (height * door_Pos - 0.5f * doorwidth)));

            Wall2.transform.localScale = new Vector3(width , Wallheight, height* (1 - door_Pos) - 0.5f * doorwidth);
            Wall2.transform.position = new Vector3(x , Wallheight / 2, z+ (0.5f * height - 0.5f * (height * (1 - door_Pos) - 0.5f * doorwidth)));

            Wall3.transform.localScale = new Vector3(width, Wallheight - doorheigth, height);
            Wall3.transform.position = new Vector3(x, doorheigth + 0.5f * (Wallheight - doorheigth), z);
        }
        else
        {
            Wall1.transform.localScale = new Vector3(width * door_Pos - 0.5f * doorwidth, Wallheight, height);
            Wall1.transform.position = new Vector3(x - (0.5f * width - 0.5f * (width * door_Pos - 0.5f * doorwidth)), Wallheight / 2, z);

            Wall2.transform.localScale = new Vector3(width * (1 - door_Pos) - 0.5f * doorwidth, Wallheight, height);
            Wall2.transform.position = new Vector3(x + (0.5f * width - 0.5f * (width * (1 - door_Pos) - 0.5f * doorwidth)), Wallheight / 2, z);

            Wall3.transform.localScale = new Vector3(width, Wallheight - doorheigth, height);
            Wall3.transform.position = new Vector3(x, doorheigth + 0.5f * (Wallheight - doorheigth), z);
        }
           


        return Wall;
    }
    // �������м�ȥ��һ������
    private Mesh SubtractMeshes(Mesh meshA, Mesh meshB)
    {
        CombineInstance[] combine = new CombineInstance[2];
        combine[0].mesh = meshA;
        combine[0].transform = Matrix4x4.identity;
        combine[1].mesh = meshB;
        combine[1].transform = Matrix4x4.identity;

        Mesh result = new Mesh();
        result.CombineMeshes(combine, true, false);
        return result;
    }

    //�ؽ��Թ�
    public void RebulidMaze()
    {
        Destroy(NewMaze);
        NewMaze = new GameObject("New Maze");
        // ���µ���Ϸ��������Ϊ��ǰ������Ӷ���
        NewMaze.transform.parent = this.transform;

        Probability_door = Slider_Probability_door.value;
        
        BulidMaze();
        Render_Maze();
    }

    //�ı�����ŵĸ��ʵ��ı���ʾ
    public void ChangeProbabilityValue()
    {
        Text_Probability_door.text = Slider_Probability_door.value.ToString();
        
    }
}
