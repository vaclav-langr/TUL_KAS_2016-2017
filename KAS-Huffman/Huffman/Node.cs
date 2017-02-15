using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAS_Huffman
{
    class Node
    {
        #region Variables
        /// <summary>
        /// List of bytes that contains specific node of Huffman tree
        /// </summary>
        public List<byte> bytes;
        /// <summary>
        /// Left and right node of a merged node. Left means 0, right means 1
        /// </summary>
        public Node left, right;
        #endregion
        #region Functions
        /// <summary>
        /// Constructor for leaf node of Huffman tree
        /// </summary>
        /// <param name="b">Byte that is contained by node</param>
        public Node(byte b)
        {
            left = right = null;
            bytes = new List<byte>(1);
            bytes.Add(b);
        }
        /// <summary>
        /// Constructor to merge nodes into one
        /// </summary>
        /// <param name="n1">Left node of a merged one</param>
        /// <param name="n2">Right node of a merged one</param>
        public Node(Node n1, Node n2)
        {
            left = n1;
            right = n2;
            bytes = new List<byte>(n1.bytes.Count + n2.bytes.Count);
            bytes.AddRange(n1.bytes);
            bytes.AddRange(n2.bytes);
        }
        /// <summary>
        /// Determines if a node is leaf or not
        /// </summary>
        /// <returns>Bool value if node is leaf</returns>
        public bool is_leaf()
        {
            return left != null;
        }
        #endregion
    }
}
