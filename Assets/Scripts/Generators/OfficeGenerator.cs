using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeGenerator : Singleton<OfficeGenerator>
{
    public GameObject Corner;
    public GameObject Straight;
    public GameObject Middle;

    private float pieceSize = 10;

    public GameObject Generate(int width, int height)
    {
        var office = new GameObject("Office");

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                var piece = SpawnPiece(width, height, x, z);
                piece.transform.SetParent(office.transform);
            }
        }

        return office;
    }

    private GameObject SpawnPiece(int width, int height, int x, int z)
    {
        GameObject pieceToSpawn;
        var rotation = new Vector3();

        if (x == 0 && z == 0)
        {
            pieceToSpawn = Corner; //Top Left.
            rotation = new Vector3(0, 270, 0);
        }
        else if (x == 0 && z == height - 1)
        {
            pieceToSpawn = Corner; //Top Right.
        }
        else if(x == width - 1 && z == 0)
        {
            pieceToSpawn = Corner; //Bottom Left.
            rotation = new Vector3(0, 180, 0);
        }
        else if (x == width - 1 && z == height - 1)
        {
            pieceToSpawn = Corner;
            rotation = new Vector3(0, 90, 0);
        }
        else if (x == 0)
        {
            pieceToSpawn = Straight; //Left Wall.
            rotation = new Vector3(0, 270, 0);
        }
        else if (x == width - 1)
        {
            pieceToSpawn = Straight; //Right Wall.
            rotation = new Vector3(0, 90, 0);
        }
        else if (z == 0)
        {
            pieceToSpawn = Straight; //Top Wall.
            rotation = new Vector3(0, 180, 0);
        }
        else if (z == height - 1)
        {
            pieceToSpawn = Straight; //Bottom Wall.
        }
        else
        {
            pieceToSpawn = Middle;
        }
        
        var newPiece = Instantiate(pieceToSpawn, new Vector3(x * pieceSize, 0, z * pieceSize), Quaternion.Euler(rotation));

        return newPiece;
    }
}