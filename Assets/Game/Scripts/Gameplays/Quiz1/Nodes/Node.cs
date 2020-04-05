using System.Collections.Generic;
using Game.Scripts.Gameplays.Quiz1.Units;
using UnityEngine;

namespace Game.Scripts.Gameplays.Quiz1.Nodes
{

    /// <summary>
    /// Base field on the map on which units can stand and move between them
    /// </summary>
    public class Node : MonoBehaviour
    {
        /// <summary>
        /// True if any unit is on this node
        /// </summary>
        public bool Occupied;

        /// <summary>
        /// Unit that currently occupias this node 
        /// </summary>
        public Unit Unit;

        /// <summary>
        /// Position in node map
        /// </summary>
        public Vector2Int Position { get; private set; }

        /// <summary>
        /// List of all connected nodes with this node
        /// </summary>
        public Dictionary<Node, float> ConnectedNodes = new Dictionary<Node, float>();

        /// <summary>
        /// Sets position value basing on node map
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetPosition(int x, int y)
        {
            Position = new Vector2Int(x, y);
        }

        /// <summary>
        /// Adds neighbour node
        /// </summary>
        /// <param name="node"></param>
        public void AddConnectedNode(Node node)
        {
            float angle = Vector3.SignedAngle(Vector3.forward, node.transform.position - transform.position, Vector3.up);
            ConnectedNodes.Add(node, angle);
        }

        /// <summary>
        /// Returns neighbour node in given direction
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public Node GetNeighbourNodeWithNearestAngle(float angle)
        {
            Node nearestNode = null;
            float nearestDeltaAngle = 360f;

            foreach (var node in ConnectedNodes)
            {
                if (node.Key.Occupied)
                {
                    continue;
                }
                float deltaAngle = Mathf.Abs(Mathf.DeltaAngle(node.Value, angle));
                if (deltaAngle < nearestDeltaAngle)
                {
                    nearestDeltaAngle = deltaAngle;
                    nearestNode = node.Key;
                }
            }

            return nearestNode;
        }
    }

}