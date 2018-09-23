using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseAlgorithms
{
    public class LamaIntervalTree
    {
        private readonly Interval _tree = new Interval
        {
            Start = DateTime.UtcNow.AddDays(-2),
            End = DateTime.Now.AddDays(2)
        };
        private int _overlapMinutesSize;
        private int depthLimit = 5;
        private int _maxDepth;

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

            var currentDepth = 0;

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
                            End = end,
                            Depth = currentDepth + 1
                        }};

                        return;
                    }

                    if (!currentNode.Childs.Any(x => x.Start <= start && x.End >= end))
                    {
                        currentNode.Childs.Add(new Interval
                        {
                            Start = start,
                            End = end,
                            Depth = currentDepth + 1
                        });
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

        private void RecalcDepth(Interval node, int level)
        {
            node.Depth = level;

            if (level > _maxDepth)
                _maxDepth = level;

            if (node.Childs != null)
            {
                foreach (var nodeChild in node.Childs)
                    RecalcDepth(nodeChild, level + 1);
            }
        }

        public void RebuildTree()
        {
            Rebuild();
            RecalcDepth(_tree, 0);

            if (_maxDepth + 1 >= depthLimit)
                throw new ArgumentOutOfRangeException(nameof(_maxDepth));
        }

        private void Rebuild()
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

                            if (currentNode.Childs[i]?.Start <= currentNode.Childs[j]?.Start
                               && currentNode.Childs[i]?.End >= currentNode.Childs[j]?.End)
                            {
                                if (currentNode.Childs[i].Childs == null)
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

        public List<Interval> GetIntervals()
        {
            var intervalsWithoutOvelaping = GetIntervalsWithoutOvelaping();

            var overlapsInsideIntervals = new double[_tree.Childs.Count];

            if (_tree.Childs != null)
            {
                for (var i = 0; i < _tree.Childs.Count; i++)
                {
                    overlapsInsideIntervals[i] = Sum(_tree.Childs[i], 0);
                }
            }

            double Sum(Interval interval, double val)
            {
                if (interval.Childs != null)
                {
                    foreach (var intervalChild in interval.Childs)
                    {
                        val = Sum(intervalChild, val);
                    }
                }

                return val + (interval.Depth == 1 ? 0 : (interval.End.Value - interval.Start.Value).TotalMinutes);
            }

            return intervalsWithoutOvelaping;
        }

        private List<Interval> GetIntervalsWithoutOvelaping()
        {
            if (_tree.Childs == null || _tree.Childs.Count == 0)
            {
                return new List<Interval>
                {
                    new Interval { Start = _tree.Start, End =  _tree.End }
                };
            }

            var freeIntervals = new List<Interval>();

            for (var i = 0; i < _tree.Childs.Count; i++)
            {
                if (freeIntervals.Count == 0 && _tree.Start < _tree.Childs[i].Start && i == 0)
                {
                    freeIntervals.Add(new Interval
                    {
                        Start = _tree.Start,
                        End = _tree.Childs[0].Start
                    });
                    continue;
                }

                if (i > 0 && _tree.Childs[i - 1].End < _tree.Childs[i].Start)
                {
                    freeIntervals.Add(new Interval
                    {
                        Start = _tree.Childs[i - 1].End,
                        End = _tree.Childs[i].Start
                    });
                }
            }

            freeIntervals.Add(new Interval
            {
                Start = _tree.Childs[_tree.Childs.Count - 1].End,
                End = _tree.End
            });

            return freeIntervals;
        }

        private long GetOverlapSize()
        {
            foreach (var child in _tree.Childs)
            {

            }

            return 0;
        }

        public void GwtSplitedIntervals(int splitSize) { }
    }



    public class Interval
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public List<Interval> Childs { get; set; }
        internal int Depth { get; set; }
    }
}
