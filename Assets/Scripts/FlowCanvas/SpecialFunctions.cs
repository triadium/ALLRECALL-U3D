using System.Collections.Generic;
using ParadoxNotion.Design;

namespace FlowCanvas.Nodes
{

    [Category("Game/Functions")]
    public class FillChipPositions : CallableActionNode<List<byte>, List<byte>, byte, byte>
    {
        public override void Invoke(List<byte> rows, List<byte> cols, byte area, byte quantity)
        {
            HashSet<int> bookedSet = new HashSet<int>(); 
            rows.Clear();
            cols.Clear();

            int maxRows = 9;
            int maxCols = 9;

            if(area == 4)
            {
                maxRows = 4;
                maxCols = 4;
            }
            else if(area == 2)
            {
                maxCols = 4;
            }
            //else { noop }

            for(int i = 0; i < quantity; ++i)
            {
                int r = UnityEngine.Random.Range(0, maxRows);
                int c = UnityEngine.Random.Range(0, maxCols);
                int rc = (r << 16) | c;
                if (bookedSet.Contains(rc))
                {
                    bool found = false;
                    for (int j = 0; j <= maxRows; j+=2)
                    {
                        for(int k = 0; k <= maxCols; k+=2)
                        {
                            rc = (j << 16) | k;
                            if (!bookedSet.Contains(rc))
                            {
                                bookedSet.Add(rc);
                                rows.Add((byte)j);
                                cols.Add((byte)k);
                                j = maxRows + 1;
                                k = maxCols + 1;
                                found = true;
                            }
                            //else { noop }
                        }
                    }

                    if (!found)
                    {
                        for (int j = 1; j <= maxRows; j += 2)
                        {
                            for (int k = 1; k <= maxCols; k += 2)
                            {
                                rc = (j << 16) | k;
                                if (!bookedSet.Contains(rc))
                                {
                                    bookedSet.Add(rc);
                                    rows.Add((byte)j);
                                    cols.Add((byte)k);
                                    j = maxRows + 1;
                                    k = maxCols + 1;
                                    found = true;
                                }
                                //else { noop }
                            }
                        }
                    }
                    //else { noop }
                }
                else
                {
                    bookedSet.Add(rc);
                    rows.Add((byte)r);
                    cols.Add((byte)c);
                }
            }
        }
    }
}