using UnityEngine;

public class Grid : MonoBehaviour
{
	public Tile blackTilePrefab;
	public Tile whiteTilePrefab;

	public int width = 10;
	public int height = 10;

	public Vector2 spacing = new Vector2( 1.0f, 1.0f );
}
