using UnityEngine;
using System.Collections;

public class WaterBending : MonoBehaviour
{



    //F : force
    //m : mass
    //a : acceleration
    //x: discplacement of object


    //Hookes law : F=−kx this representantion of a spring and spring discplacement when pushing the spring , the k is a constant spring which you put ona strian on a string
    //NewTon Second Law of Motion : F= ma      force accelerate the mass and the mass get lighter


    //a =−k/mx Like VTS (swedish) to know how acceleration goes between distance and time, put this time is acceleration between particles. 


    LineRenderer Body;



    GameObject[] meshobjects;
    Mesh[] meshes;


    //spring

    const float springconstant = 0.30f;
    const float damping = 0.40f;
    const float spread = 0.80f;
    const float z = -1f;

    float baseheight;
    float left;
    float bottom;






    float[] xpositions;
    float[] ypositions;
    float[] velocities;
    float[] accelerations;


    //Vector3 waveSource1 = new Vector3(2.0f, 0.0f, 2.0f);


    //float TimeFactor = Time.deltaTime * Time.timeScale;



    public Material LineRendererMaterial;
    public GameObject watermesh;
    GameObject[] colliders;


    void Start()
    {
       SpawningWater(transform.position.x, 24, 0, -3);
       // SpawningWater(-10, 20, 0, -3);

    }

    void SpawningWater(float Left, float Width, float Top, float Bottom)               // creating Water by the size of the float value
    {



        gameObject.AddComponent<BoxCollider2D>();
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(transform.position.x - (left+Width) +5.3f, (Top + Bottom) / 2);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(Width, Top - Bottom);
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

        int edgecount = Mathf.RoundToInt(Width) * 5;                                    // node is like a pointer dot how many pointer dot should be exist between them 
        int nodecount = edgecount + 1;


        xpositions = new float[nodecount];
        ypositions = new float[nodecount];
        velocities = new float[nodecount];
        accelerations = new float[nodecount];
        // after Dot are lined up we put on a line render to connect each dot.

        Body = gameObject.AddComponent<LineRenderer>();
        Body.material = LineRendererMaterial;
        Body.material.renderQueue = 1000;
        Body.SetVertexCount(nodecount);
        Body.SetWidth(0.1f, 0.1f);
        
        

        meshobjects = new GameObject[edgecount];
        meshes = new Mesh[edgecount];

        colliders = new GameObject[edgecount];



        //Set our variables
        baseheight = Top;
        bottom = Bottom;
        left = Left;

        //For each node, set the line renderer and our physics arrays
        for (int i = 0; i < nodecount; i++)
        {
            ypositions[i] = Top;
            xpositions[i] = Left + Width * i / edgecount;
            accelerations[i] = 0;
            velocities[i] = 0;
            Body.SetPosition(i, new Vector3(xpositions[i], ypositions[i], z));

        }


        for (int i = 0; i < edgecount; i++)
        {
            //Make the mesh
            meshes[i] = new Mesh();

            //Create the corners of the mesh
            Vector3[] Vertices = new Vector3[4];
            Vertices[0] = new Vector3(xpositions[i], ypositions[i], z);
            Vertices[1] = new Vector3(xpositions[i + 1], ypositions[i + 1], z);
            Vertices[2] = new Vector3(xpositions[i], bottom, z);
            Vertices[3] = new Vector3(xpositions[i + 1], bottom, z);

            //Set the UVs of the texture
            Vector2[] UVs = new Vector2[4];
            UVs[0] = new Vector2(0, 1);
            UVs[1] = new Vector2(1, 1);
            UVs[2] = new Vector2(0, 0);
            UVs[3] = new Vector2(1, 0);

            //Set where the triangles should be.
            int[] tris = new int[6] { 0, 1, 3, 3, 2, 0 };

            //Add all this data to the mesh.
            meshes[i].vertices = Vertices;

            meshes[i].triangles = tris;

            //Create a holder for the mesh, set it to be the manager's child
            meshobjects[i] = Instantiate(watermesh, Vector3.zero, Quaternion.identity) as GameObject;

            meshobjects[i].GetComponent<MeshFilter>().mesh = meshes[i];

            meshobjects[i].transform.parent = transform;

        }
    }

    void Update()
    {
       // Debug.Log("Updating");
        //Here we use the Euler method to handle all the physics of our springs:
        for (int i = 0; i < xpositions.Length; i++)
        {
            float force = springconstant * (ypositions[i] - baseheight) + velocities[i] * damping;
            accelerations[i] = -force;
            ypositions[i] += velocities[i];
            velocities[i] += accelerations[i];

            Vector3 pos = new Vector3(0.5F, Mathf.Sin(Time.time), 0);
           // Body.SetPosition(1, pos);
            Body.SetPosition(i, new Vector3(pos.x, pos.y, z));

            

            //We make 8 small passes for fluidity:
           
    }
        float[] leftDeltas = new float[xpositions.Length];
        float[] rightDeltas = new float[xpositions.Length];
        for (int j = 0; j < 8; j++)
        {
            for (int i = 0; i < xpositions.Length; i++)
            {
                //We check the heights of the nearby nodes, adjust velocities accordingly, record the height differences
                if (i > 0)
                {
                    leftDeltas[i] = spread * (ypositions[i] - ypositions[i - 1]);
                    velocities[i - 1] += leftDeltas[i];
                }
                if (i < xpositions.Length - 1)
                {
                    rightDeltas[i] = spread * (ypositions[i] - ypositions[i + 1]);
                    velocities[i + 1] += rightDeltas[i];
                }
            }
            for (int i = 0; i < xpositions.Length; i++)
            {
                if (i > 0)
                    ypositions[i - 1] += leftDeltas[i];
                if (i < xpositions.Length - 1)
                    ypositions[i + 1] += rightDeltas[i];
            }
        }
       
    }


    void UpdateMeshes()
    {
            for (int i = 0; i < meshes.Length; i++)
            {

                Vector3[] Vertices = new Vector3[4];
                Vertices[0] = new Vector3(xpositions[i], ypositions[i], z);
                Vertices[1] = new Vector3(xpositions[i + 1], ypositions[i + 1], z);
                Vertices[2] = new Vector3(xpositions[i], bottom, z);
                Vertices[3] = new Vector3(xpositions[i + 1], bottom, z);

                meshes[i].vertices = Vertices;
            }


        }


   
    }



  



