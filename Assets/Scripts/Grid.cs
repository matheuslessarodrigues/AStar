using UnityEngine;

public class Grid : MonoBehaviour
{
	public Tile blackTilePrefab;
	public Tile whiteTilePrefab;

	public int width = 10;
	public int height = 10;

	public Vector2 spacing = new Vector2( 1.0f, 1.0f );

	private void Start()
	{
		for( int i = 0; i < width; i++ )
		{
			for( int j = 0; j < height; j++ )
			{
				bool chooseWhite = ( i * height + j ) % 2 == 0;
				var position = new Vector3( i * spacing.x, j * spacing.y, 0.0f );
				Tile tile = Instantiate( chooseWhite ? whiteTilePrefab : blackTilePrefab, position, Quaternion.identity, transform );
				tile.x = i;
				tile.y = j;
			}
		}
	}
}
