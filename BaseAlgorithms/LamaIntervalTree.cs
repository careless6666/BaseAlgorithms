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

        public LamaIntervalTree(DateTime start, DateTime end, int overlapMinutesSize = 0)
        {
            _overlapMinutesSize = overlapMinutesSize;
            _tree = new Interval
            {
                Start = start,
                End = end
            };
        }

        private void Add(DateTime start, DateTime end)
        {
            var queue = new Queue<Interval>();
            queue.Enqueue(_tree);

            if (start <= _tree.Start || end >= _tree.End)
                throw new ArgumentException("Interval outside tree boundaries");
            
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

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

        public Interval GetFullTree => _tree;

        public void Remove(DateTime start, DateTime end)
        {
            var queue = new Queue<Interval>();
            queue.Enqueue(_tree);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
            }
        }

        public void Rebuild()
        {
            var queue = new Queue<Interval>();
            queue.Enqueue(_tree);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.Childs?.Any() == true)
                {
                    for (var i = 0; i < currentNode.Childs.Count; i++)
                    {
                        for (int j = 0; j < currentNode.Childs.Count; j++)
                        {
                            //проверяем что есть на одном уровне узлы, которые могут включать в себя другие узлы
                            if (i == j)
                                continue;

                            if(currentNode.Childs[i]?.Start <= currentNode.Childs[j]?.Start
                               && currentNode.Childs[i]?.End >= currentNode.Childs[j]?.End)
                            {
                                if(currentNode.Childs[i].Childs == null)
                                    currentNode.Childs[i].Childs = new List<Interval>();

                                currentNode.Childs[i].Childs.Add(currentNode.Childs[j]); //скопируем на уровень ниже
                                currentNode.Childs.Remove(currentNode.Childs[j]);

                                Rebuild();
                                return;
                            }
                        }
                    }

                    foreach (var interval in currentNode.Childs)
                        queue.Enqueue(interval);
                }
            }
        }

        public void GetIntervals()
        {

        }
        public void GwtSplitedIntervals(int splitSize) { }
    }

    public class Interval
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public List<Interval> Childs { get; set; }
    }
}
