using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseAlgorithms
{
    public class LamaIntervalTree
    {
        private readonly Interval _tree = new Interval
        {
            Start = DateTime.MinValue,
            End = DateTime.MaxValue
        };
        private int _overlapMinutesSize;

        public LamaIntervalTree(int overlapMinutesSize = 0)
        {
            _overlapMinutesSize = overlapMinutesSize;
        }

        private void Add(DateTime start, DateTime end)
        {
            var queue = new Queue<Interval>();
            queue.Enqueue(_tree);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.Start == null)
                {
                    currentNode.Start = start;
                    currentNode.End = end;
                    return;
                }

                if (currentNode.Start <= start && currentNode.End >= end)  // входит в интервал, добавим к детям
                {
                    if (currentNode.Childs == null)
                    {
                        currentNode.Childs = new List<Interval> { new Interval
                        {
                            Start = start,
                            End = end
                        }};
                        return;
                    }

                    if (!currentNode.Childs.Any(x => x.Start <= start && x.End >= end))
                    {
                        currentNode.Childs.Add(new Interval { Start = start, End = end });
                        return;
                    }

                    foreach (var interval in currentNode.Childs)
                        queue.Enqueue(interval);
                }
            }
        }

        public bool TryAdd(DateTime start, DateTime end)
        {
            if (start == DateTime.MinValue)
                throw new ArgumentNullException(nameof(start));

            if (end == DateTime.MinValue)
                throw new ArgumentNullException(nameof(end));

            if (start >= end)
                throw new ArgumentException("end less or equals start");

            Add(start, end);

            return false;
        }

        public void Remove()
        {

        }

        public void Rebuild()
        {

        }
    }

    class Interval
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public List<Interval> Childs { get; set; }
    }
}
