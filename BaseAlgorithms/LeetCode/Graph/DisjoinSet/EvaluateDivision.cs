using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseAlgorithms.LeetCode.Graph.DisjoinSet
{
    //search path cost in grapth and reverse path's
    //https://leetcode.com/problems/evaluate-division/
    public class EvaluateDivision
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {

        Dictionary<String, KeyValuePair<String, Double>> gidWeight = new ();

        // Step 1). build the union groups
        for (int i = 0; i < equations.Count(); i++) {
            var equation = equations[i];
            String dividend = equation[0], divisor = equation[1];
            double quotient = values[i];

            union(gidWeight, dividend, divisor, quotient);
        }

        // Step 2). run the evaluation, with "lazy" updates in find() function
        double[] results = new double[queries.Count()];
        for (int i = 0; i < queries.Count(); i++) {
            var query = queries[i];
            String dividend = query[0], divisor = query[1];

            if (!gidWeight.ContainsKey(dividend) || !gidWeight.ContainsKey(divisor))
                // case 1). at least one variable did not appear before
                results[i] = -1.0;
            else {
                KeyValuePair<String, Double> dividendEntry = find(gidWeight, dividend);
                KeyValuePair<String, Double> divisorEntry = find(gidWeight, divisor);

                String dividendGid = dividendEntry.Key;
                String divisorGid = divisorEntry.Key;
                Double dividendWeight = dividendEntry.Value;
                Double divisorWeight = divisorEntry.Value;

                if (dividendGid != divisorGid)
                    // case 2). the variables do not belong to the same chain/group
                    results[i] = -1.0;
                else
                    // case 3). there is a chain/path between the variables
                    results[i] = dividendWeight / divisorWeight;
            }
        }

        return results;
    }

    private KeyValuePair<String, Double> find(Dictionary<String, KeyValuePair<String, Double>> gidWeight, String nodeId) {
        if (!gidWeight.ContainsKey(nodeId))
            gidWeight.Add(nodeId, new KeyValuePair<String, Double>(nodeId, 1.0));

        KeyValuePair<String, Double> entry = gidWeight[nodeId];
        // found inconsistency, trigger chain update
        if (entry.Key != nodeId) {
            KeyValuePair<String, Double> newEntry = find(gidWeight, entry.Key);
            gidWeight[nodeId] = new KeyValuePair<String, Double>(
                    newEntry.Key, entry.Value * newEntry.Value);
        }

        return gidWeight[nodeId];
    }

    private void union(Dictionary<String, KeyValuePair<String, Double>> gidWeight, String dividend, String divisor, Double value) {
        var dividendEntry = find(gidWeight, dividend);
        var divisorEntry = find(gidWeight, divisor);

        var dividendGid = dividendEntry.Key;
        var divisorGid = divisorEntry.Key;
        var dividendWeight = dividendEntry.Value;
        var divisorWeight = divisorEntry.Value;

        // merge the two groups together,
        // by attaching the dividend group to the one of divisor
        if (dividendGid != divisorGid) {
            
                gidWeight[dividendGid] = new KeyValuePair<string, double>(divisorGid,
                    divisorWeight * value / dividendWeight);
        }
    }
    }
}