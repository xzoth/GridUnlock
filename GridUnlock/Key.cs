using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GridUnlock
{
    /// <summary>
    /// 钥
    /// </summary>
    public class Key : INotifyPropertyChanged
    {
        public TimeSpan TimeSpamp
        {
            get;
            internal set;
        }

        public KeyPointCollection Items
        {
            get;
            private set;
        }

        public static bool operator ==(Key source, Key target)
        {
            return source.Equals(target);
        }

        public static bool operator !=(Key source, Key target)
        {
            return !source.Equals(target);
        }

        public override bool Equals(object obj)
        {
            Key target = obj as Key;

            bool isEqula = false;

            if (this.Items.Count >= GridUnlock.MinKeyPoint && this.Items.Count == target.Items.Count)
            {
                for (int i = 0; i < this.Items.Count; i++)
                {

                    if ((this.Items[i].X != target.Items[i].X) ||
                        this.Items[i].Y != target.Items[i].Y)
                    {
                        return false;
                    }
                }
            }

            return isEqula;
        }

        public override int GetHashCode()
        {
            return this.Items.GetHashCode();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
