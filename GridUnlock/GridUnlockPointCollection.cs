using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridUnlock.Common;

namespace GridUnlock
{
    public class GridUnlockPointCollection : CollectionBase<GridUnlockPoint>
    {
        public Key ToKey()
        {
            Key result = new Key();

            foreach (var item in this)
            {
                result.Items.Add(item.KeyPoint);
            }

            return result;
        }
    }
}
