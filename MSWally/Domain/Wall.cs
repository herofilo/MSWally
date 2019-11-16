using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using MSWally.UI;

namespace MSWally.Domain
{
    public class Wall
    {

        public const decimal HeightMinimumDefault = 3.0M;

        public const decimal HeightMaximumDefault = 24.0M;

        public const decimal ThicknessMinimumDefault = 0.1M;

        public const decimal ThicknessMaximumDefault = 0.5M;

        public const decimal ZOffsetMaximumDefault = 5.0M;

        public static decimal HeightMinimum { get; set; } = HeightMinimumDefault;

        public static decimal HeightMaximum { get; set; } = HeightMaximumDefault;

        public static decimal ThicknessMinimum { get; set; } = ThicknessMinimumDefault;

        public static decimal ThicknessMaximum { get; set; } = ThicknessMaximumDefault;

        public static decimal ZOffsetMaximum { get; set; } = ZOffsetMaximumDefault;

        public Point StartCoordinate { get; private set; } = Point.Empty;

        public int StartX => StartCoordinate.X;

        public int StartY => StartCoordinate.Y;

        public decimal StartZOffset { get; private set; }


        public Point EndCoordinate { get; private set; } = Point.Empty;

        public int EndX => EndCoordinate.X;

        public int EndY => EndCoordinate.Y;

        public decimal EndZOffset { get; private set; }


        public double Length { get; private set; }

        public double Argument { get; private set; }

        public WallDirection Direction { get; private set; }

        public decimal Height { get; private set; }

        public decimal Thickness { get; private set; }

        public XmlNode Node { get; private set; }

        public XmlNode StartPointNode { get; private set; }

        public XmlNode EndPointNode { get; private set; }

        private XmlNode HeightNode { get; set; }

        private XmlNode ThicknessNode { get; set; }

        public string ErrorText { get; private set; }


        public bool HeightModified { get; private set; }

        public bool ThicknessModified { get; private set; }

        public bool StartZOffsetModified { get; private set; }

        public bool EndZOffsetModified { get; private set; }


        public bool Dirty => HeightModified || ThicknessModified || StartZOffsetModified || EndZOffsetModified;

        // -------------------------------------------------------------------------

        public Wall()
        {


        }


        public Wall(XmlNode pNode)
        {
            Node = pNode;
        }


        public bool SetNode(XmlNode pNode = null)
        {
            ErrorText = null;

            if (pNode != null)
                Node = pNode;

            StartCoordinate = Point.Empty;
            EndCoordinate = Point.Empty;

            StartZOffset = EndZOffset = 0.0M;

            Length = 0.0;
            Argument = 0.0;
            Direction = WallDirection.None;

            Height = 0.0M;
            Thickness = 0.0M;

            HeightModified = ThicknessModified = StartZOffsetModified = EndZOffsetModified = false;

            if (Node == null)
            {
                ErrorText = "No root node";
                return false;
            }

            decimal zOffset;
            StartCoordinate = ReadCoordinate("left", "Start", out zOffset);
            if (StartCoordinate == Point.Empty)
            {
                if(ErrorText != null)
                    ErrorText =  "Invalid Start node";
                return false;
            }
            StartZOffset = zOffset;

            EndCoordinate = ReadCoordinate("right", "End", out zOffset);
            if (EndCoordinate == Point.Empty)
            {
                if (ErrorText != null)
                    ErrorText = "Invalid End node";
                return false;
            }
            EndZOffset = zOffset;

            CharacterizeWall();


            XmlNode heightNode = Node.SelectSingleNode("height");
            if (heightNode == null)
            {
                ErrorText = "No Height node found";
                return false;
            }
            Height = Convert.ToDecimal(heightNode.InnerText, CultureInfo.InvariantCulture);
            HeightNode = heightNode;

            XmlNode thicknessNode = Node.SelectSingleNode("thickness");
            if (thicknessNode == null)
            {
                ErrorText = "No Thickness node found";
                return false;
            }
            Thickness = Convert.ToDecimal(thicknessNode.InnerText, CultureInfo.InvariantCulture);
            ThicknessNode = thicknessNode;
            
            return true;
        }

        private void CharacterizeWall()
        {
            if ((StartCoordinate == Point.Empty) || (EndCoordinate == Point.Empty) || 
                ((StartX == EndX) && (StartY == EndY)))
            {
                Length = 0.0;
                Argument = 0.0;
                Direction = WallDirection.None;
                return;
            }

            if (StartX == EndX)
            {
                Direction = WallDirection.Vertical;
                Length = Math.Abs(EndY - StartY);
                Argument =
                    EndY < StartY ? 90 : -90;
                return;
            }

            if (StartY == EndY)
            {
                Direction = WallDirection.Horizontal;
                Length = Math.Abs(EndX - StartX);
                Argument =
                    EndX < StartX ? 180 : 0;
                return;
            }

            Direction = WallDirection.Oblique;
            Length = Math.Sqrt(Math.Pow(EndX - StartX, 2) + Math.Pow(EndY - StartY, 2));

            // StartY - EndY, for Y grows downwards
            Argument = Math.Atan2(StartY - EndY, EndX - StartX) * 180.0 / Math.PI;
        }


        private Point ReadCoordinate(string pNodeName, string pName, out decimal pZOffset)
        {
            Point point = Point.Empty;
            pZOffset = 0.0M;

            try
            {
                XmlNode endNode = Node.SelectSingleNode(pNodeName);
                if (endNode == null)
                {
                    ErrorText = $"No {pName} node found";
                    return point;
                }


                XmlNode coordNode = endNode.SelectSingleNode("pt");
                if (coordNode == null)
                    return point;

                string coordinateText = coordNode.InnerText;
                string[] coordinates = coordinateText.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (coordinates.Length != 3)
                    return point;

                int x, y;
                y = (int)Convert.ToDecimal(coordinates[0], CultureInfo.InvariantCulture);
                x = (int)Convert.ToDecimal(coordinates[1], CultureInfo.InvariantCulture);
                pZOffset = Convert.ToDecimal(coordinates[2], CultureInfo.InvariantCulture);

                point = new Point(x, y);
                if (pNodeName == "left")
                    StartPointNode = coordNode;
                else if (pNodeName == "right")
                    EndPointNode = coordNode;
            }
            catch (Exception exception)
            {
                ErrorText = $"ReadCoordinate(): {exception.Message}";
            }

            return point;
        }



        public void ModifySetting(WallSetting pWallSetting, decimal pIncrement)
        {
            switch (pWallSetting)
            {
                case WallSetting.Height: HeightIncrement(pIncrement); break;
                case WallSetting.Thickness: ThicknessIncrement(pIncrement); break;
                case WallSetting.StartZOffset: ZOffsetIncrement(0, pIncrement); break;
                case WallSetting.EndZOffset: ZOffsetIncrement(1, pIncrement); break;
            }
        }


        public void HeightIncrement(decimal pIncrement)
        {
            decimal newHeight = Height + pIncrement;
            if (newHeight < HeightMinimum)
                newHeight = HeightMinimum;

            if (newHeight > HeightMaximum)
                newHeight = HeightMaximum;
            if (newHeight == Height)
                return;

            Height = newHeight;
            string heightText = $"{Height:F1}".Replace(",", ".");
            HeightNode.InnerText = heightText;
            HeightModified = true;
        }


        public void ThicknessIncrement(decimal pIncrement)
        {
            decimal newThickness = Thickness + pIncrement;
            if (newThickness < ThicknessMinimum)
                newThickness = ThicknessMinimum;

            if (newThickness > ThicknessMaximum)
                newThickness = ThicknessMaximum;
            if (newThickness == Thickness)
                return;


            Thickness = newThickness;
            string thicknessText = $"{Thickness:F1}".Replace(",", ".");
            ThicknessNode.InnerText = thicknessText;
            ThicknessModified = true;
        }


        public void StartZOffsetIncrement(decimal pIncrement)
        {
            ZOffsetIncrement(0, pIncrement);
        }


        public void EndZOffsetIncrement(decimal pIncrement)
        {
            ZOffsetIncrement(1, pIncrement);
        }


        public void ZOffsetIncrement(int pPoint, decimal pIncrement)
        {
            bool startPoint = true;
            switch (pPoint)
            {
                case 0: break;
                case 1: startPoint = false; break;
                default: return;
            }

            decimal newZoffset = (startPoint ? StartZOffset : EndZOffset) + pIncrement;

            if (newZoffset < 0.0M)
                newZoffset = 0.0M;

            if (newZoffset > ZOffsetMaximum)
                newZoffset = ZOffsetMaximum;
            if (newZoffset == Thickness)
                return;

            string zOffsetText = $"{newZoffset:F1}".Replace(",", ".");
            if (startPoint)
            {
                if (SetNewZOffset(StartPointNode, zOffsetText))
                {
                    StartZOffset = newZoffset;
                    StartZOffsetModified = true;
                }
                return;
            }

            if (SetNewZOffset(EndPointNode, zOffsetText))
            {
                EndZOffset = newZoffset;
                EndZOffsetModified = true;
            }
        }

        private bool SetNewZOffset(XmlNode pCoordNode, string pNewZOffsetValue)
        {
            string[] items = pCoordNode.InnerText.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (items.Length != 3)
                return false;

            pCoordNode.InnerText = $"{items[0]} {items[1]} {pNewZOffsetValue}";
            return true;
        }


        public void SetClean()
        {
            HeightModified = ThicknessModified = StartZOffsetModified = EndZOffsetModified = false;
        }
    }


    public enum WallDirection
    {
        None,
        Horizontal,
        Vertical,
        Oblique
    }

}
