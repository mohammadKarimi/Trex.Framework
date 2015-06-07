using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trex.Framework.Controls;

namespace Framework.Test
{
    public class policyTabbedPage : TxTabbedPage
    {
        public policyTabbedPage()
        {
            this.SwipeEnabled = true;
            Children.Add(new PolicyContent());
            Children.Add(new LossCrousel());
        }
    }
}
