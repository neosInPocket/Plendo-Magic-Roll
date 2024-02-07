using UnityEngine;

public class LevelBorders : MonoBehaviour
{
    [SerializeField] private SingleBorder[] borders;
    [SerializeField] private float width;
    [SerializeField] private float topBorder;
    [SerializeField] private float bottomBorder;


    private void Start()
    {
        var screenSize = ViewInfo.Screen;
        var topEdgePosition = 2 * screenSize.y * topBorder - screenSize.y;
        var bottomEdgePosition = 2 * screenSize.y * bottomBorder - screenSize.y;

        borders[0].transform.position = new Vector2(0, topEdgePosition + width / 2);
        borders[1].transform.position = new Vector2(0, bottomEdgePosition - width / 2);
        borders[2].transform.position = new Vector2(screenSize.x + width / 2, 0);
        borders[3].transform.position = new Vector2(-screenSize.x - width / 2, 0);

        borders[0].Size = new Vector2(2 * screenSize.x, width);
        borders[1].Size = new Vector2(2 * screenSize.x, width);
        borders[2].Size = new Vector2(width, 2 * screenSize.y);
        borders[3].Size = new Vector2(width, 2 * screenSize.y);
    }
}
