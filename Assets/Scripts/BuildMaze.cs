using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMaze : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject NewMaze;
    float Wallthickness = 0.09f;
    float Wallheight = 1f;      //ǽ�ĸ߶�
    float RoomsideLength = 2f;  //�����С���߳���

    private int RoomCount;  //������Ŀ
    void Start()
    {
        RoomCount = 0;
        NewMaze = new GameObject("New Maze");
        // ���µ���Ϸ��������Ϊ��ǰ������Ӷ���
        NewMaze.transform.parent = this.transform;
        //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //Build_Wall(NewMaze,0, 2, RoomsideLength, Wallthickness, 0.1f);  //��ǽ

        GameObject InitWall =Build_Wall(NewMaze, 2, 0, Wallthickness, RoomsideLength, 0.6f);     //��ǽ
        Generate_A_Room(InitWall, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //����һ�����䣬���������ʼ��ǽ�ڣ�1Ϊ����2Ϊ����3Ϊ����4Ϊ��
    void Generate_A_Room(GameObject InitWallObject, int InitWall)
    {
        RoomCount = RoomCount + 1;
        if (RoomCount > 100) return;
        float door_Pos; //�ŵ�λ�ã��������
        if (InitWall == 1)  //��ʼλ��������
        {
            float x = InitWallObject.transform.position.x;
            float z = InitWallObject.transform.position.z;
            door_Pos= Random.Range(0f, 1f);
            if (door_Pos > 0.1f)    //�оųɵĸ�������
            {
                door_Pos = Random.Range(0f, 1f);
            }
            else
            {
                door_Pos = -1f;
            }
            GameObject WestWall = Build_Wall(InitWallObject, x + RoomsideLength, z, Wallthickness, RoomsideLength, door_Pos);  //���ߵ���
            if (door_Pos != -1)//�������ǽ���ţ��Ը�ǽ����չһ������
            {
                Generate_A_Room(WestWall, 1);
            }


            door_Pos = Random.Range(0f, 1f);
            if (door_Pos > 0.1f)    //�оųɵĸ�������
            {
                door_Pos = Random.Range(0f, 1f);
            }
            else
            {
                door_Pos = -1f;
            }
            GameObject NorthWall = Build_Wall(InitWallObject, x + 0.5f * RoomsideLength, z + 0.5f * RoomsideLength, RoomsideLength, Wallthickness, door_Pos);  //���ߵ���
            if (door_Pos != -1)//�������ǽ���ţ��Ը�ǽ����չһ������
            {
                Generate_A_Room(NorthWall, 4);       //������ʼ��ǽ���ϱ�
            }


            door_Pos = Random.Range(0f, 1f);
            if (door_Pos > 0.1f)    //�оųɵĸ�������
            {
                door_Pos = Random.Range(0f, 1f);
            }
            else
            {
                door_Pos = -1f;
            }
            GameObject SouthWall = Build_Wall(InitWallObject, x + 0.5f * RoomsideLength, z - 0.5f * RoomsideLength, RoomsideLength, Wallthickness, door_Pos);  //���ߵ���
            if (door_Pos != -1)//�������ǽ���ţ��Ը�ǽ����չһ������
            {
                Generate_A_Room(SouthWall, 2);       //������ʼ��ǽ�Ǳ���
            }
        }

        if (InitWall == 2)  //��ʼλ���ڱ���
        {
            float x = InitWallObject.transform.position.x;
            float z = InitWallObject.transform.position.z;
            //�������ߵ�ǽ
            door_Pos = Random.Range(0f, 1f);
            if (door_Pos > 0.1f)    //�оųɵĸ�������
            {
                door_Pos = Random.Range(0f, 1f);
            }
            else
            {
                door_Pos = -1f;
            }
            GameObject WestWall = Build_Wall(InitWallObject, x + 0.5f * RoomsideLength, z - 0.5f * RoomsideLength, Wallthickness, RoomsideLength, door_Pos);  //���ߵ���
            if (door_Pos != -1)//�������ǽ���ţ��Ը�ǽ����չһ������
            {
                Generate_A_Room(WestWall, 1);
            }

            //�������ߵ�ǽ
            door_Pos = Random.Range(0f, 1f);
            if (door_Pos > 0.1f)    //�оųɵĸ�������
            {
                door_Pos = Random.Range(0f, 1f);
            }
            else
            {
                door_Pos = -1f;
            }
            GameObject EastWall = Build_Wall(InitWallObject, x - 0.5f * RoomsideLength, z - 0.5f * RoomsideLength, Wallthickness, RoomsideLength, door_Pos);  //���ߵ���
            if (door_Pos != -1)//�������ǽ���ţ��Ը�ǽ����չһ������
            {
                Generate_A_Room(EastWall, 3);
            }

            //�������ߵ�ǽ
            /*
            door_Pos = Random.Range(0f, 1f);
            if (door_Pos > 0.1f)    //�оųɵĸ�������
            {
                door_Pos = Random.Range(0f, 1f);
            }
            else
            {
                door_Pos = -1f;
            }
            GameObject NorthWall = Build_Wall(InitWallObject, x + 0.5f * RoomsideLength, z + 0.5f * RoomsideLength, RoomsideLength, Wallthickness, door_Pos);  //���ߵ���
            if (door_Pos != -1)//�������ǽ���ţ��Ը�ǽ����չһ������
            {
                Generate_A_Room(WestWall, 4);       //������ʼ��ǽ���ϱ�
            }
            */
            //�����ϱߵ�ǽ
            door_Pos = Random.Range(0f, 1f);
            if (door_Pos > 0.1f)    //�оųɵĸ�������
            {
                door_Pos = Random.Range(0f, 1f);
            }
            else
            {
                door_Pos = -1f;
            }
            GameObject SouthWall = Build_Wall(InitWallObject, x , z -  RoomsideLength, RoomsideLength, Wallthickness, door_Pos);  //���ߵ���
            if (door_Pos != -1)//�������ǽ���ţ��Ը�ǽ����չһ������
            {
                Generate_A_Room(SouthWall, 2);       //������ʼ��ǽ�Ǳ���
            }
        }
    }

    void Generate_Room_Bydoor()
    {

    }

    //����һ��ǽ�ڣ������gameObject�ǹ��صĸ����������door_Pos���ŵ�λ�ã����������-1����ʾû����
    GameObject Build_Wall(GameObject gameObject, float x, float z, float width, float height, float door_Pos)
    {
        if (door_Pos < 0.1f && door_Pos > 0f)
        {
            door_Pos = 0.1f;
        }
        if (door_Pos > 0.9f)
        {
            door_Pos = 0.9f;
        }
        GameObject Wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Wall.name = "Wall";
        Wall.transform.localScale = new Vector3(width, Wallheight, height);
        Wall.transform.position = new Vector3(x, Wallheight/2, z);
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

        if (width< height)   //˵�������ŵ�ǽ
        {
            // ���㶴��λ��
            float holeX = x;
            float holeZ = z + (door_Pos - 0.5f) * RoomsideLength;
            door.transform.localScale = new Vector3( Wallthickness/ Wallthickness * 1.02f, doorheigth, doorwidth);
            door.transform.position = new Vector3(holeX, doorheigth / 2.0f, holeZ);
        }
        else//˵���Ǻ��ŵ�ǽ
        {
            // ���㶴��λ��
            float holeX = x +(door_Pos-0.5f) * RoomsideLength;
            float holeZ = z ;
            door.transform.localScale = new Vector3(doorwidth,doorheigth, Wallthickness / Wallthickness * 1.02f);
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
}
