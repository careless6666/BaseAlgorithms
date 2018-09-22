using System;
using System.Collections.Generic;

namespace BaseAlgorithms
{
    public class LamaIntervalTree
    {
        private readonly Interval _tree = new Interval();
        private int _overlapSize;

        public LamaIntervalTree(int overlapSize = 0)
        {
            _overlapSize = overlapSize;
        }

        private void Add(DateTime start, DateTime end)
        {
            var queue = new Queue<Interval>();
            queue.Enqueue(_tree);

            while (queue.Count > 0)
            {
                var q = queue.Dequeue();

                if (q.Start == DateTime.MinValue)
                {
                    q.Start = start;
                    q.End = end;
                    return;
                }

                if (q.Childs == null)
                {
                    q.Childs = new List<Interval> { new Interval
                        {
                            Start = start,
                            End = end
                        }};
                    return;
                }

                foreach (var interval in q.Childs)
                    queue.Enqueue(interval);
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
    }

    class Interval
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<Interval> Childs { get; set; }
    }
}
