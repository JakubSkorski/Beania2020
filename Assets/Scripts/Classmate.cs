using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Classmate : IEquatable<Classmate>
    {
        public string DisplayName { get; set; }
        public int Id { get; set; }
        //public Texture2D Avatar { get; set; }

        public Classmate()
        {

        }

        //Auto-generated code:
        public override bool Equals(object obj) => Equals(obj as Classmate);
        public bool Equals(Classmate other) => other != null && Id == other.Id;
        public override int GetHashCode() => -1737426059 + Id.GetHashCode();

        public static bool operator ==(Classmate left, Classmate right) => EqualityComparer<Classmate>.Default.Equals(left, right);
        public static bool operator !=(Classmate left, Classmate right) => !(left == right);
    }
}
