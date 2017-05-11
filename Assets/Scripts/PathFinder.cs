using System.Collections.Generic;

public static class PathFinder
{
	public static List<Grid.Position> FindPath( Tile[,] tiles, Grid.Position fromPosition, Grid.Position toPosition )
	{
		PathNode node = BreadthFirstSearch( tiles, fromPosition, toPosition );

		var path = new List<Grid.Position>();

		while( node != null )
		{
			path.Add( node.position );
			node = node.parent;
		}

		path.Reverse();

		return path;
	}

	private class PathNode
	{
		public Grid.Position position;
		public PathNode parent;

		public PathNode( Grid.Position position, PathNode parent )
		{
			this.position = position;
			this.parent = parent;
		}
	}

	private static PathNode BreadthFirstSearch( Tile[,] tiles, Grid.Position fromPosition, Grid.Position toPosition )
	{
		HashSet<PathNode> nodes = new HashSet<PathNode>();
		var queue = new Queue<PathNode>();

		var root = new PathNode( fromPosition, null );

		nodes.Add( root );
		queue.Enqueue( root );

		while( queue.Count > 0 )
		{
			PathNode node = queue.Dequeue();
			if( node.position.x == toPosition.x && node.position.y == toPosition.y )
			{
				return node;
			}
			else
			{
				TryEnqueueNode( tiles, queue, nodes, node, new Grid.Position( node.position.x + 1, node.position.y ) );
				TryEnqueueNode( tiles, queue, nodes, node, new Grid.Position( node.position.x - 1, node.position.y ) );
				TryEnqueueNode( tiles, queue, nodes, node, new Grid.Position( node.position.x, node.position.y + 1 ) );
				TryEnqueueNode( tiles, queue, nodes, node, new Grid.Position( node.position.x, node.position.y - 1 ) );

				TryEnqueueNode( tiles, queue, nodes, node, new Grid.Position( node.position.x + 1, node.position.y + 1) );
				TryEnqueueNode( tiles, queue, nodes, node, new Grid.Position( node.position.x - 1, node.position.y + 1) );
				TryEnqueueNode( tiles, queue, nodes, node, new Grid.Position( node.position.x + 1, node.position.y - 1 ) );
				TryEnqueueNode( tiles, queue, nodes, node, new Grid.Position( node.position.x - 1, node.position.y - 1 ) );
			}
		}

		return null;
	}

	private static void TryEnqueueNode( Tile[,] tiles, Queue<PathNode> queue, HashSet<PathNode> nodes, PathNode currentNode, Grid.Position position )
	{
		int maxX = tiles.GetLength( 0 ) - 1;
		int maxY = tiles.GetLength( 1 ) - 1;
		if( position.x < 0 || position.x > maxX || position.y < 0 || position.y > maxY )
			return;

		if( tiles[position.x, position.y].isWall )
			return;

		bool contains = false;
		foreach( var n in nodes )
		{
			if( n.position.x == position.x && n.position.y == position.y )
			{
				contains = true;
				break;
			}
		}

		if( !contains )
		{
			var node = new PathNode( position, currentNode );

			nodes.Add( node );
			queue.Enqueue( node );
		}
	}
}
