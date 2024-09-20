using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMaze : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject NewMaze;
    float Wallthickness = 0.09f;
    float Wallheight = 1f;      //墙的高度
    float RoomsideLength = 2f;  //房间大小（边长）

    private int RoomCount;  //房间数目
    void Start()
    {
        RoomCount = 0;
        NewMaze = new GameObject("New Maze");
        // 将新的游戏对象设置为当前对象的子对象
        NewMaze.transform.parent = this.transform;
        //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //Build_Wall(NewMaze,0, 2, RoomsideLength, Wallthickness, 0.1f);  //横墙

        GameObject InitWall =Build_Wall(NewMaze, 2, 0, Wallthickness, RoomsideLength, 0.6f);     //竖墙
        Generate_A_Room(InitWall, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //生成一个房间，输入的是起始的墙壁，1为西，2为北，3为东，4为南
    void Generate_A_Room(GameObject InitWallObject, int InitWall)
    {
        RoomCount = RoomCount + 1;
        if (RoomCount > 100) return;
        float door_Pos; //门的位置，随机生成
        if (InitWall == 1)  //起始位置在西边
        {
            float x = InitWallObject.transform.position.x;
            float z = InitWallObject.transform.position.z;
            door_Pos= Random.Range(0f, 1f);
            if (door_Pos > 0.1f)    //有九成的概率有门
            {
                door_Pos = Random.Range(0f, 1f);
            }
            else
            {
                door_Pos = -1f;
            }
            GameObject WestWall = Build_Wall(InitWallObject, x + RoomsideLength, z, Wallthickness, RoomsideLength, door_Pos);  //西边的门
            if (door_Pos != -1)//如果这面墙有门，以该墙再拓展一个房间
            {
                Generate_A_Room(WestWall, 1);
            }


            door_Pos = Random.Range(0f, 1f);
            if (door_Pos > 0.1f)    //有九成的概率有门
            {
                door_Pos = Random.Range(0f, 1f);
            }
            else
            {
                door_Pos = -1f;
            }
            GameObject NorthWall = Build_Wall(InitWallObject, x + 0.5f * RoomsideLength, z + 0.5f * RoomsideLength, RoomsideLength, Wallthickness, door_Pos);  //北边的门
            if (door_Pos != -1)//如果这面墙有门，以该墙再拓展一个房间
            {
                Generate_A_Room(NorthWall, 4);       //这里起始的墙是南边
            }


            door_Pos = Random.Range(0f, 1f);
            if (door_Pos > 0.1f)    //有九成的概率有门
            {
                door_Pos = Random.Range(0f, 1f);
            }
            else
            {
                door_Pos = -1f;
            }
            GameObject SouthWall = Build_Wall(InitWallObject, x + 0.5f * RoomsideLength, z - 0.5f * RoomsideLength, RoomsideLength, Wallthickness, door_Pos);  //西边的门
            if (door_Pos != -1)//如果这面墙有门，以该墙再拓展一个房间
            {
                Generate_A_Room(SouthWall, 2);       //这里起始的墙是北边
            }
        }

        if (InitWall == 2)  //起始位置在北边
        {
            float x = InitWallObject.transform.position.x;
            float z = InitWallObject.transform.position.z;
            //创建西边的墙
            door_Pos = Random.Range(0f, 1f);
            if (door_Pos > 0.1f)    //有九成的概率有门
            {
                door_Pos = Random.Range(0f, 1f);
            }
            else
            {
                door_Pos = -1f;
            }
            GameObject WestWall = Build_Wall(InitWallObject, x + 0.5f * RoomsideLength, z - 0.5f * RoomsideLength, Wallthickness, RoomsideLength, door_Pos);  //西边的门
            if (door_Pos != -1)//如果这面墙有门，以该墙再拓展一个房间
            {
                Generate_A_Room(WestWall, 1);
            }

            //创建东边的墙
            door_Pos = Random.Range(0f, 1f);
            if (door_Pos > 0.1f)    //有九成的概率有门
            {
                door_Pos = Random.Range(0f, 1f);
            }
            else
            {
                door_Pos = -1f;
            }
            GameObject EastWall = Build_Wall(InitWallObject, x - 0.5f * RoomsideLength, z - 0.5f * RoomsideLength, Wallthickness, RoomsideLength, door_Pos);  //西边的门
            if (door_Pos != -1)//如果这面墙有门，以该墙再拓展一个房间
            {
                Generate_A_Room(EastWall, 3);
            }

            //创建北边的墙
            /*
            door_Pos = Random.Range(0f, 1f);
            if (door_Pos > 0.1f)    //有九成的概率有门
            {
                door_Pos = Random.Range(0f, 1f);
            }
            else
            {
                door_Pos = -1f;
            }
            GameObject NorthWall = Build_Wall(InitWallObject, x + 0.5f * RoomsideLength, z + 0.5f * RoomsideLength, RoomsideLength, Wallthickness, door_Pos);  //北边的门
            if (door_Pos != -1)//如果这面墙有门，以该墙再拓展一个房间
            {
                Generate_A_Room(WestWall, 4);       //这里起始的墙是南边
            }
            */
            //创建南边的墙
            door_Pos = Random.Range(0f, 1f);
            if (door_Pos > 0.1f)    //有九成的概率有门
            {
                door_Pos = Random.Range(0f, 1f);
            }
            else
            {
                door_Pos = -1f;
            }
            GameObject SouthWall = Build_Wall(InitWallObject, x , z -  RoomsideLength, RoomsideLength, Wallthickness, door_Pos);  //西边的门
            if (door_Pos != -1)//如果这面墙有门，以该墙再拓展一个房间
            {
                Generate_A_Room(SouthWall, 2);       //这里起始的墙是北边
            }
        }
    }

    void Generate_Room_Bydoor()
    {

    }

    //建立一个墙壁，输入的gameObject是挂载的父级，输入的door_Pos是门的位置，如果输入是-1，表示没有门
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

        // 创建洞的游戏对象
        GameObject door = GameObject.CreatePrimitive(PrimitiveType.Cube);
        door.name = "Door";
        door.transform.parent = Wall.transform;
        float doorwidth = RoomsideLength * 0.1f;       //们的宽度
        float doorheigth = Wallheight * 2.0f / 3.0f;   //门的高度 

        if (width< height)   //说明是竖着的墙
        {
            // 计算洞的位置
            float holeX = x;
            float holeZ = z + (door_Pos - 0.5f) * RoomsideLength;
            door.transform.localScale = new Vector3( Wallthickness/ Wallthickness * 1.02f, doorheigth, doorwidth);
            door.transform.position = new Vector3(holeX, doorheigth / 2.0f, holeZ);
        }
        else//说明是横着的墙
        {
            // 计算洞的位置
            float holeX = x +(door_Pos-0.5f) * RoomsideLength;
            float holeZ = z ;
            door.transform.localScale = new Vector3(doorwidth,doorheigth, Wallthickness / Wallthickness * 1.02f);
            door.transform.position = new Vector3(holeX, doorheigth / 2.0f, holeZ);
        }
        // 移除洞在长方体上的一部分
        MeshFilter cubeMeshFilter = Wall.GetComponent<MeshFilter>();
        cubeMeshFilter.mesh = SubtractMeshes(cubeMeshFilter.mesh, door.GetComponent<MeshFilter>().mesh);

        // 删除洞的游戏对象
        //Destroy(door);
        door.GetComponent<Renderer>().material.color = Color.red;
        return Wall;

    }
    // 从网格中减去另一个网格
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
