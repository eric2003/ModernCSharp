using System;
using System.Collections.Generic;

namespace Tetris
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffSet { get; }
        public abstract int Id { get; }
        private int rotationState = 0;
        private Position offset;
        public Block()
        {
            offset = new Position(StartOffSet.Row,StartOffSet.Column);
        }

        public IEnumerable<Position> TilePositions()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position( p.Row + offset.Row, p.Column + offset.Column );
            }
        }


        public void RotateCW()
        {
            //Console.WriteLine("begin rotationState = {0} Tiles.Length = {1}, blockId = {2}", rotationState, Tiles.Length, Id);
            rotationState = (rotationState + 1)%Tiles.Length;
            //Console.WriteLine("end rotationState = {0} Tiles.Length = {1}, blockId = {2}", rotationState, Tiles.Length, Id);
        }

        public void RotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffSet.Row;
            offset.Column = StartOffSet.Column;
        }
    }

}
