using System;
using System.Collections.Generic;
using System.Text;
using BlogDemo.Core.Interfaces;

namespace BlogDemo.Core.Entites
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
