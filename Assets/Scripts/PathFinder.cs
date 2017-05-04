using System.Collections.Generic;

public static class PathFinder
{
	public static List<Grid.Position> FindPath( Tile[,] tiles, Grid.Position fromPosition, Grid.Position toPosition )
	{
		var path = new List<Grid.Position>();
		path.Add( fromPosition );
		path.Add( toPosition );

		return path;
	}
}
