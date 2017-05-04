using UnityEngine;

public class Grid : MonoBehaviour
{
	[System.Serializable]
	public struct Position
	{
		public int x;
		public int y;
	}

	public Tile blackTilePrefab;
	public Tile whiteTilePrefab;
	public Tile wallTilePrefab;

	public int width = 10;
	public int height = 10;

	public Vector2 spacing = new Vector2( 1.0f, 1.0f );

	public Position playerPosition;
	public Position[] wallPositions;

	private Tile[,] tiles;

	public void MoveTo( Position position )
	{
		foreach( Tile tile in tiles )
			tile.Highlight( false );

		tiles[position.x, position.y].Highlight( true );
	}

	private void Start()
	{
		tiles = new Tile[width, height];

		for( int i = 0; i < width; i++ )
		{
			for( int j = 0; j < height; j++ )
			{
				bool chooseWhite = ( i + j ) % 2 == 0;
				bool isWall = System.Array.IndexOf( wallPositions, new Position { x = i, y = j } ) >= 0;

				Tile tilePrefab;
				if( isWall )
					tilePrefab = wallTilePrefab;
				else if( chooseWhite )
					tilePrefab = whiteTilePrefab;
				else
					tilePrefab = blackTilePrefab;

				var position = new Vector3( i * spacing.x, 0.0f, j * spacing.y );

				Tile tile = Instantiate( tilePrefab, position, Quaternion.identity, transform );
				tile.position = new Position { x = i, y = j };
				tile.grid = this;
				tile.isWall = isWall;

				tiles[i, j] = tile;
			}
		}
	}
}
