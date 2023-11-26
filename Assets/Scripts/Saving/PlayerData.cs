
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string name;
    public float score;

    public float[] position;

    public PlayerData(string name, float score, Vector3 position)
    {
        this.name = name;
        this.score = score;

        this.position = new float[3];
        this.position[0] = position.x;
        this.position[1] = position.y;
        this.position[2] = position.z;
    }
}

