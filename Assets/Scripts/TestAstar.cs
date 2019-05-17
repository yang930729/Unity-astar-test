using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestAstar : MonoBehaviour
{
    private int tileHeight = 100;
    private int tileWidth = 100;
    public int col;
    public int row;
    public Vector2[] arrTilePos;

    private void Awake()
    {

    }

    void Start()
    {
        this.CreateMap();
    }

    private void CreateMap()
    {
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                var tile = Instantiate<GameObject>(Resources.Load("tile01") as GameObject);
                var tileLine = Instantiate<GameObject>(Resources.Load("tileLine2") as GameObject);

                tile.transform.SetParent(GameObject.Find("tiles").transform);
                tileLine.transform.SetParent(tile.transform);
                var screenPos = new Vector2(j * this.tileWidth + 512 - 300, i * -this.tileHeight + this.tileHeight * 6);
                var worldPos = Camera.main.ScreenToWorldPoint(screenPos);
                worldPos.z = 0;

                tile.GetComponentInChildren<TextMesh>().text = string.Format("({0},{1})", j, i);
                tile.transform.position = worldPos;

                if (j == this.arrTilePos[0].x && i == this.arrTilePos[0].y)
                {
                    tile.GetComponent<SpriteRenderer>().color = Color.green;
                }

                if (j == this.arrTilePos[1].x && i == this.arrTilePos[1].y)
                {
                    tile.GetComponent<SpriteRenderer>().color = Color.red;
                }

                if (j == this.arrTilePos[2].x && i <= this.arrTilePos[2].y)
                {
                    tile.GetComponent<SpriteRenderer>().color = Color.blue;
                }

                
            }
        }
    }
}