using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeGenerator : Singleton<OfficeGenerator>
{
    public GameObject Corner;
    public GameObject Straight;
    public GameObject Middle;

    public GameObject Generate(int width, int height)
    {
        var office = new GameObject();

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
        GameObject newPiece;

        if (x == 0 && z == 0)
        {
            newPiece = Instantiate(Corner, new Vector3(), Quaternion.identity); //Top Left.
        }

        if (x == 0 && z == height - 1)
        {
            newPiece = Instantiate(Corner, new Vector3(), Quaternion.identity); //Top Right.
        }

        if (x == width - 1 && height == 0)
        {
            newPiece = Instantiate(Corner, new Vector3(), Quaternion.identity); //Bottom Left.
        }

        if (x == width - 1 && z == height - 1)
        {
            newPiece = Instantiate(Corner, new Vector3(), Quaternion.identity); //Bottom Right.
        }

        if (x == 0)
        {
            newPiece = Instantiate(Straight, new Vector3(), Quaternion.identity); //Left Wall.
        }

        if (x == width - 1)
        {
            newPiece = Instantiate(Straight, new Vector3(), Quaternion.identity); //Right Wall.
        }

        if (z == 0)
        {
            newPiece = Instantiate(Straight, new Vector3(), Quaternion.identity); //Top Wall.
        }

        if (z == height - 1)
        {
            newPiece = Instantiate(Straight, new Vector3(), Quaternion.identity); //Bottom Wall.
        }

        newPiece = Instantiate(Middle, new Vector3(), Quaternion.identity);

        return newPiece;
    }
}