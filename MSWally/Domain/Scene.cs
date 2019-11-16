using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;

namespace MSWally.Domain
{
    public class Scene
    {

        public string SceneTitle { get; private set; }

        public string SceneId { get; private set; }

        public int SetWidth { get; private set; } = -1;

        public int SetDepth { get; private set; } = -1;

        public bool SetDimEstimated { get; private set; } = false;

        public List<Wall> SetWalls { get; private set; }

        public decimal SetCeilingHeight { get; private set; }

        private XmlNode SetCeilingNode { get; set; }

        public bool SetCeilingHeightModified { get; private set; }

        public XmlNode SceneRootNode { get; private set; }

        public string ErrorText { get; private set; }

        public bool Dirty
        {
            get
            {
                if (SetCeilingHeightModified)
                    return true;
                if (SetWalls == null)
                    return false;
                foreach (Wall wall in SetWalls)
                    if (wall.Dirty)
                        return true;
                return false;
            }
        }


        // --------------------------------------------------------------------------------------

        public Scene()
        {

        }

        public Scene(XmlNode pRootNode)
        {
            SceneRootNode = pRootNode;
        }


        public bool ReadXmlDocument(XmlNode pRootNode = null)
        {
            // SceneRootNode = pRootNode;
            ErrorText = null;

            if (pRootNode != null)
                SceneRootNode = pRootNode;

            SceneId = SceneTitle = null;

            SetWalls = null;

            SetWidth = SetDepth = -1;
            SetDimEstimated = false;

            SetCeilingHeight = 0.0M;
            SetCeilingHeightModified = false;

            if (SceneRootNode == null)
            {
                ErrorText = "No root node";
                return false;
            }

            XmlNode nameNode = SceneRootNode.SelectSingleNode("title");
            if (nameNode == null)
            {
                ErrorText = "No Title node found";
                return false;
            }
            SceneTitle = nameNode.InnerText;

            XmlNode idNode = SceneRootNode.SelectSingleNode("ID");
            if (idNode == null)
            {
                ErrorText = "No ID node found";
                return false;
            }
            SceneId = idNode.InnerText;

            XmlNode sceneryNode = SceneRootNode.SelectSingleNode("set/scenery");
            if (sceneryNode == null)
            {
                ErrorText = "No set/scenery node found";
                return false;
            }


            if (!GetCeilingHeight(sceneryNode))
            {
                return false;
            }


            // bool needsWorldSizeEstimate = false;
            if (!GetWorldSize(sceneryNode, "floor") && !GetWorldSizeAlt() && !GetWorldSize(sceneryNode, "ceiling"))
            // if (!GetWorldSize(sceneryNode, "floor") && !GetWorldSizeAlt())
            {
                ErrorText = "World size couldn't be set";
                // needsWorldSizeEstimate = true;
                // return false;
            }


            SetWalls = new List<Wall>();
            foreach (XmlNode wallNode in sceneryNode.SelectNodes("wall"))
            {
                Wall wall = new Wall(wallNode);
                if (!wall.SetNode())
                {
                    ErrorText = $"Reading Wall info: {wall.ErrorText}";
                    return false;
                }

                SetWalls.Add(wall);
            }

            int estimatedWorldSize = EstimateWorldSize();
            if ((estimatedWorldSize > SetWidth) || (estimatedWorldSize > SetDepth))
            {
                SetDepth = SetWidth = estimatedWorldSize;
                SetDimEstimated = true;
            }

            return true;
        }

        private bool GetCeilingHeight(XmlNode pSceneryNode)
        {
            XmlNode ceilingNode = pSceneryNode.SelectSingleNode("ceiling");
            if (ceilingNode == null)
            {
                ErrorText = "No ceiling node found";
                return false;
            }

            XmlNode ceilingHeightNode = ceilingNode.SelectSingleNode("height");
            if (ceilingHeightNode == null)
            {
                ErrorText = "No ceiling height node found";
                return false;
            }

            SetCeilingHeight = Convert.ToDecimal(ceilingHeightNode.InnerText, CultureInfo.InvariantCulture);

            SetCeilingNode = ceilingHeightNode;

            return true;
        }


        private int EstimateWorldSize()
        {
            int minX = 9999,
                minY = 9999,
                maxX = -9999,
                maxY = -9999;

            if (SetWalls.Count == 0)
                return 0;

            foreach (Wall wall in SetWalls)
            {
                if (wall.StartX < minX)
                    minX = wall.StartX;
                if (wall.StartX > maxX)
                    maxX = wall.StartX;

                if (wall.EndX < minX)
                    minX = wall.EndX;
                if (wall.EndX > maxX)
                    maxX = wall.EndX;

                if (wall.StartY < minY)
                    minY = wall.StartY;
                if (wall.StartY > maxY)
                    maxY = wall.StartY;

                if (wall.EndY < minY)
                    minY = wall.EndY;
                if (wall.EndY > maxY)
                    maxY = wall.EndY;
            }

            int worldSize = 50;
            // SetDepth = SetWidth = 50;
            // if (minX < -24 || minY < -24 || maxX > 24 || maxY > 24)
            //    SetDepth = SetWidth = 100;
            // SetDimEstimated = true;

            int maxCoord = Math.Max(Math.Abs(minX), Math.Abs(maxX));
            maxCoord = Math.Max(Math.Max(maxCoord, Math.Abs(minY)), Math.Abs(maxY));
            if (maxCoord <= 25)
                return worldSize;

            if ((maxCoord > 25) && (maxCoord < 50))
                worldSize = 100;
            else
            {
                int maxSquareDim = 2 * (maxCoord + 1);
                worldSize = maxSquareDim;
            }

            return worldSize;
        }


        // TODO : GetWorldSizeAlt()
        private bool GetWorldSizeAlt()
        {
            return false;
        }


        private bool GetWorldSize(XmlNode pSceneryNode, string pTargetNodeName)
        {
            XmlNode targetNode = pSceneryNode.SelectSingleNode(pTargetNodeName);
            if (targetNode == null)
            {
                // ErrorText = "No floor node found";
                return false;
            }

            int width = -1;
            int depth = -1;
            foreach (XmlNode node in targetNode.ChildNodes)
            {
                if (node.Name == "width")
                    width = Convert.ToInt32(node.InnerText);
                if (node.Name == "depth")
                    depth = Convert.ToInt32(node.InnerText);
                if ((width > 0) && (depth > 0))
                    break;
            }

            if ((width < 0) || (depth < 0))
            {
                // ErrorText = "World size couldn't be set";
                return false;
            }

            SetWidth = width; SetDepth = depth;

            return true;
        }

        public void SetClean()
        {
            SetCeilingHeightModified = false;

            if ((SetWalls == null) || (!Dirty))
                return;

            foreach (Wall wall in SetWalls)
                wall.SetClean();

        }

        public decimal UpdateCeilingHeight(decimal pValue)
        {
            if (SetCeilingNode == null)
                return pValue;

            if (pValue < Wall.HeightMinimum)
                pValue = Wall.HeightMinimum;

            if (pValue > Wall.HeightMaximum)
                pValue = Wall.HeightMaximum;
            if (pValue == SetCeilingHeight)
                return pValue;

            SetCeilingHeight = pValue;
            string heightText = $"{pValue:F1}".Replace(",", ".");
            SetCeilingNode.InnerText = heightText;
            SetCeilingHeightModified = true;

            return SetCeilingHeight;
        }
    }
}
